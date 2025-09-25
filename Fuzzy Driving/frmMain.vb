Imports System.ComponentModel
Imports SharpDX
Imports SharpDX.DirectInput
'Imports SharpDX.XInput
Public Class frmMain
    Private directInput As DirectInput
    Private joystick As Joystick
    'Private xinputController As Controller

    Private driveMode As String = DriveStates.PARK

    'Private lastShiftTime As DateTime = DateTime.MinValue
    Private zLocked As Boolean = False 'allows for shift events to start and end
    Private zMin As Integer = 0
    Private axisMax As Integer = 65535
    Private zSlop As Integer = 3000 'this controls how precize shifts neeed to be, smaller produces more misses
    Private lastShiftTime As DateTime = DateTime.MinValue
    Private shiftCooldown As Integer = 250 'ms 'this allows timing to ignore shifts, higher produces more misses
    Private originalImage As Image
    Private shiftDefaultTop As Integer
    Private maxShiftTop As Integer = 200

    Private animationFrames() As Image
    Private currentFrameIndex As Integer = 0
    Private timerStepCount As Integer = 0

    Private steerMax As Integer = 75
    Private steerChange As Integer = 0

    Private wheelRatio As Double
    Private wheelHeight As Integer = 800

    Private instructions As New Queue(Of String)()

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        originalImage = picWheel.Image
        shiftDefaultTop = picShifter.Top

        animationFrames = {
            My.Resources.r1,
            My.Resources.r2,
            My.Resources.r3,
            My.Resources.r4,
            My.Resources.r5,
            My.Resources.r6,
            My.Resources.r7,
            My.Resources.r8,
            My.Resources.r9,
            My.Resources.r10
        }

        ' get the wheel ratio from the image size
        wheelRatio = picWheel.Width / picWheel.Height
        picWheel.SizeMode = PictureBoxSizeMode.StretchImage
        picWheel.Height = wheelHeight
        picWheel.Width = CInt(wheelHeight * wheelRatio)

        directInput = New DirectInput()

        ' Find a joystick/gamepad
        Dim joystickGuid As Guid = Guid.Empty
        For Each deviceInstance In directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices)
            joystickGuid = deviceInstance.InstanceGuid
            Exit For
        Next
        If joystickGuid = Guid.Empty Then
            For Each deviceInstance In directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices)
                joystickGuid = deviceInstance.InstanceGuid
                Exit For
            Next
        End If

        If joystickGuid = Guid.Empty Then
            MessageBox.Show("No joystick/gamepad found.")
            Return
        End If

        'xinputController = New Controller(UserIndex.One)
        'If Not xinputController.IsConnected Then
        'MessageBox.Show("XInput controller not connected.")
        'End If

        ' Instantiate the joystick
        joystick = New Joystick(directInput, joystickGuid)
        joystick.Properties.BufferSize = 128
        joystick.Acquire()

        ' Start polling (for demo, use a timer)
        Dim pollTimer As New Timer()
        AddHandler pollTimer.Tick, AddressOf PollJoystick
        pollTimer.Interval = 50
        pollTimer.Start()
    End Sub

    Private Sub PollJoystick(sender As Object, e As EventArgs)
        If joystick Is Nothing Then Return
        joystick.Poll()
        Dim state = joystick.GetCurrentState()
        ' Example: read X and Y axis
        Dim x = state.X
        Dim y = state.Y
        Dim z = state.RotationZ

        ' Example: read buttons
        Dim buttons = state.Buttons
        ' Do something with the input...
        ' For demonstration, show in title bar:
        'Me.Text = buttons(8).ToString & " " & buttons(9).ToString
        Dim driveButton = buttons(9)

        If driveButton And lblDriveMode.Text = DriveStates.DRIVE Then
            timerStepCount = 1
            steerChange = -1 * steerMax * (x - axisMax / 2) / axisMax
        ElseIf driveButton And lblDriveMode.Text = DriveStates.REVERSE Then
            timerStepCount = -1
            steerChange = steerMax * (x - axisMax / 2) / axisMax
        Else
            timerStepCount = 0
            steerChange = 0
        End If

        Dim now = DateTime.Now
        If Not zLocked And ((now - lastShiftTime).TotalMilliseconds >= shiftCooldown) Then
            If z < zMin + zSlop Then
                zLocked = True
                ShiftUp()
                lastShiftTime = now
            ElseIf z > axisMax - zSlop Then
                zLocked = True
                ShiftDown()
                lastShiftTime = now
            End If
        ElseIf (z >= zMin + zSlop) And (z <= axisMax - zSlop) Then
            zLocked = False
        End If

        picWheel.Image = RotateImage(originalImage, ((x - axisMax / 2) / axisMax) * 180) ' Rotate based on X axis input
        picShifter.Top = shiftDefaultTop + ((z - axisMax / 2) / axisMax) * maxShiftTop ' Adjust Y position based on Y axis input

        'deal with instructions if any
        If instructions.Count > 0 Then
            If ((instructions.Peek() = Instruction.GO_GAS And driveButton) Or (instructionToDriveState() = lblDriveMode.Text)) Then
                instructions.Dequeue()
                Interaction.Beep()
            End If
        End If
        If instructions.Count = 0 Then
            lblInstructions.Text = Instruction.WAIT
        Else
            lblInstructions.Text = instructions.Peek()
        End If
    End Sub

    Private Function instructionToDriveState() As String
        Select Case instructions.Peek()
            Case Instruction.GO_PARK
                Return DriveStates.PARK
            Case Instruction.GO_REVERSE
                Return DriveStates.REVERSE
            Case Instruction.GO_NEUTRAL
                Return DriveStates.NEUTRAL
            Case Instruction.GO_DRIVE
                Return DriveStates.DRIVE
            Case Else
                Return ""
        End Select
    End Function

    Private Sub ShiftUp()
        Select Case driveMode
            Case DriveStates.PARK
                driveMode = DriveStates.PARK
            Case DriveStates.REVERSE
                driveMode = DriveStates.PARK
            Case DriveStates.NEUTRAL
                driveMode = DriveStates.REVERSE
            Case DriveStates.DRIVE
                driveMode = DriveStates.NEUTRAL
        End Select
        lblDriveMode.Text = driveMode
    End Sub

    Private Sub ShiftDown()
        Select Case driveMode
            Case DriveStates.PARK
                driveMode = DriveStates.REVERSE
            Case DriveStates.REVERSE
                driveMode = DriveStates.NEUTRAL
            Case DriveStates.NEUTRAL
                driveMode = DriveStates.DRIVE
            Case DriveStates.DRIVE
                driveMode = DriveStates.DRIVE
        End Select
        lblDriveMode.Text = driveMode
    End Sub

    Private Function RotateImage(img As Image, angle As Single) As Bitmap
        Dim bmp As New Bitmap(img.Width, img.Height)
        bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.TranslateTransform(img.Width / 2, img.Height / 2)
            g.RotateTransform(angle)
            g.TranslateTransform(-img.Width / 2, -img.Height / 2)
            g.DrawImage(img, New Point(0, 0))
        End Using
        Return bmp
    End Function

    Private Sub timerAnimation_Tick(sender As Object, e As EventArgs) Handles timerAnimation.Tick
        If timerStepCount <> 0 Then
            currentFrameIndex = (currentFrameIndex + timerStepCount) Mod animationFrames.Length
            If currentFrameIndex < 0 Then
                currentFrameIndex = animationFrames.Length + timerStepCount
            End If
            picAnimation.Image = animationFrames(currentFrameIndex)

            Dim leftNew As Integer = picAnimation.Left + steerChange
            picAnimation.Left = Math.Min(Math.Max(leftNew, -1432), 0)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox(GetFuzzyState("").Item(DriveStates.REVERSE))
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox(GetFuzzyInput(TransmissionInput.UP1).Item(TransmissionInput.UP1))
    End Sub

    Private Function GetFuzzyState(message As String) As Collection
        'Use the sliders to indicate the deree to which the transimision is in each of the following states.
        If message <> "" Then
            frmFuzzyState.SetLabelMessage(message)
        End If
        frmFuzzyState.ShowDialog()
        If frmFuzzyState.DialogResult = DialogResult.OK Then
            Dim results As New Collection
            results.Add(frmFuzzyState.fuzzPark.Value, DriveStates.PARK)
            results.Add(frmFuzzyState.fuzzReverse.Value, DriveStates.REVERSE)
            results.Add(frmFuzzyState.fuzzNeutral.Value, DriveStates.NEUTRAL)
            results.Add(frmFuzzyState.fuzzDrive.Value, DriveStates.DRIVE)
            frmFuzzyState.Close()
            Return results
        Else
            Return Nothing
        End If
    End Function

    Private Function GetFuzzyInput(tInput As String) As Collection
        'frmFuzzyState.lblMessage.Text = message
        frmFuzzyInput.lblAction.Text = tInput
        frmFuzzyInput.ShowDialog()
        If frmFuzzyInput.DialogResult = DialogResult.OK Then
            Dim results As New Collection
            results.Add(frmFuzzyInput.fuzzUp1.Value, TransmissionInput.UP1)
            results.Add(frmFuzzyInput.fuzzUp2.Value, TransmissionInput.UP2)
            results.Add(frmFuzzyInput.fuzzUp3.Value, TransmissionInput.UP3)
            results.Add(frmFuzzyInput.fuzzDown1.Value, TransmissionInput.DOWN1)
            results.Add(frmFuzzyInput.fuzzDown2.Value, TransmissionInput.DOWN2)
            results.Add(frmFuzzyInput.fuzzDown3.Value, TransmissionInput.DOWN3)
            frmFuzzyState.Close()
            Return results
        Else
            Return Nothing
        End If
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        instructions.Enqueue(Instruction.GO_REVERSE)
        instructions.Enqueue(Instruction.GO_GAS)
        instructions.Enqueue(Instruction.GO_NEUTRAL)
        instructions.Enqueue(Instruction.GO_GAS)
        instructions.Enqueue(Instruction.GO_DRIVE)
        instructions.Enqueue(Instruction.GO_GAS)
        instructions.Enqueue(Instruction.GO_PARK)
        instructions.Enqueue(Instruction.GO_GAS)
    End Sub

    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If MsgBox("Are you sure you want to exit the application?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Quit") = MsgBoxResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MsgBox(GetFuzzyState("Assume that you know that the car is in (D) Drive and you know that input Up × 1 occured and was recognized by the system. Use the sliders to indicate the degree to which you think this will put the car into each of the following states.").Item(DriveStates.REVERSE))
    End Sub
End Class
