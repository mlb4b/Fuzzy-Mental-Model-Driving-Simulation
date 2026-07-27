Imports System.ComponentModel
Imports System.Diagnostics.Eventing.Reader
Imports System.Net.Mail
Imports SharpDX
Imports SharpDX.DirectInput
'Imports SharpDX.XInput
Public Class frmMain
    Private directInput As DirectInput
    Private joystick As Joystick
    'Private xinputController As Controller

    Private driveMode As String = DriveStates.PARK
    Private instructedMode As String = DriveStates.PARK

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
    Private failureRate As Double = 0.5

    Private animationFrames() As Image
    Private currentFrameIndex As Integer = 0
    Private timerStepCount As Integer = 0

    Private steerMax As Integer = 75
    Private steerChange As Integer = 0

    Private wheelRatio As Double
    Private wheelHeight As Integer = 800

    Private instructions As New Queue(Of String)()
    Private nextInstructionCountDown As Long = -1
    Private pollTimer As New Timer()

    Private outFile As System.IO.StreamWriter
    Private outStepCounter As Integer = 0

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''''process inputs first
        'set up the output file
        Dim participantID As String = InputBox("Please enter the participant ID:", "Participant ID")
        Dim timestamp As String = DateTime.Now.ToString("yyyy.MM.dd_HH.mm.ss")
        Dim filePath As String = System.IO.Path.Combine(Application.StartupPath, $"{participantID}_{timestamp}.txt")
        outFile = New System.IO.StreamWriter(filePath, True)

        Dim initialData As New Dictionary(Of String, String)()
        initialData.Add(NameOf(participantID), participantID)
        initialData.Add(NameOf(timestamp), timestamp)
        WriteData(Instruction.WAIT, initialData)

        With instructions
            .Enqueue(Instruction.GET_MSG_REVERSE)
            .Enqueue(Instruction.GO_DRIVE)
            .Enqueue(Instruction.GET_DEMOGRAPHICS)
            .Enqueue(Instruction.GO_OPEN)
            .Enqueue(Instruction.GET_MSG_BREAK)
            .Enqueue(Instruction.GET_SURPRISE)
            .Enqueue(Instruction.GO_REVERSE)
            .Enqueue(Instruction.GO_GAS)
            .Enqueue(Instruction.GO_NEUTRAL)
            .Enqueue(Instruction.GO_GAS_LONG)
            .Enqueue(Instruction.GO_DRIVE)
            .Enqueue(Instruction.GO_GAS)
            .Enqueue(Instruction.GO_PARK)
            .Enqueue(Instruction.GO_GAS)
            .Enqueue(Instruction.GET_STATE)
            .Enqueue(Instruction.GET_UP1)
            .Enqueue(Instruction.GET_UP2)
            .Enqueue(Instruction.GET_UP3)
            .Enqueue(Instruction.GET_DOWN1)
            .Enqueue(Instruction.GET_DOWN2)
            .Enqueue(Instruction.GET_DOWN3)
            .Enqueue(Instruction.GET_GAS)
            .Enqueue(Instruction.GET_MSG_END)
        End With

        Dim firstStep As Integer = CInt(InputBox("Please enter the step to start on:", "First Step", "1"))
        For i = 1 To firstStep - 1
            outStepCounter += 1
            instructions.Dequeue()
        Next i

        MsgBox($"Starting the experiment with participant {participantID} at step {firstStep}. Click 'Ok' when you are ready to start.")

        'set everything else up
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

        lblInstructions.Text = Instruction.WAIT

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

        ' Start polling 
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
        Dim z = state.RotationY
        TextBox1.Text = state.ToString()
        ' Example: read buttons
        Dim buttons = state.Buttons
        ' Do something with the input...
        ' For demonstration, show in title bar:
        'Me.Text = buttons(8).ToString & " " & buttons(9).ToString
        Dim driveButton = state.Z < 30000

        If driveButton And driveMode = DriveStates.DRIVE Then
            timerStepCount = 1
            steerChange = -1 * steerMax * (x - axisMax / 2) / axisMax
        ElseIf driveButton And driveMode = DriveStates.REVERSE Then
            timerStepCount = -1
            steerChange = steerMax * (x - axisMax / 2) / axisMax
        Else
            timerStepCount = 0
            steerChange = 0
        End If

        Dim now = DateTime.Now

        If Not zLocked And ((now - lastShiftTime).TotalMilliseconds >= shiftCooldown) And (Rnd() > failureRate) Then
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
        'if the last instruction has been satisfied, set countdown
        If lblInstructions.Text = Instruction.WAIT And instructions.Count > 0 Then
            nextInstructionCountDown = 0
        End If
        'If lblInstructions.Text = Instruction.WAIT And instructions.Count > 0 Then
        '    lblInstructions.Text = instructions.Peek()
        '    If lblInstructions.Text = Instruction.GO_OPEN Then
        '        nextInstructionCountDown = Instruction.GetTickCount(lblInstructions.Text)
        '    End If
        '    WriteData(instructions.Peek())
        '    instructions.Dequeue()
        '    Interaction.Beep()
        'Else
        If nextInstructionCountDown < 0 And ((
                (Instruction.IsGasInstruction(lblInstructions.Text) And driveButton) Or
                (driveMode = instructionToDriveState())
            )) Then
            nextInstructionCountDown = Instruction.GetTickCount(lblInstructions.Text)
        ElseIf nextInstructionCountDown = 0 Then
            If instructions.Count > 0 Then
                If Instruction.IsGet(instructions.Peek()) Then
                    Dim results As Dictionary(Of String, String) = Nothing
                    pollTimer.Stop()
                    If instructions.Peek() = Instruction.GET_STATE Then
                        results = GetFuzzyState()
                    ElseIf Instruction.IsGetInputRequest(instructions.Peek()) Then
                        results = GetFuzzyInput(instructions.Peek())
                    ElseIf instructions.Peek() = Instruction.GET_DEMOGRAPHICS Then
                        results = GetDemographics()
                    ElseIf instructions.Peek() = Instruction.GET_SURPRISE Then
                        results = GetSurprise()
                    ElseIf Instruction.IsMessage(instructions.Peek()) Then
                        MsgBox(instructions.Peek(), MsgBoxStyle.Information, "")
                        Dim nextMode As String = MsgToDriveState(instructions.Peek())
                        If nextMode <> "" Then
                            SetDriveMode(nextMode)
                        End If
                    Else
                        'should never get here
                    End If
                    WriteData(instructions.Peek(), results)
                    instructions.Dequeue()
                    pollTimer.Start()
                End If
                If instructions.Count > 0 AndAlso Instruction.IsInstruction(instructions.Peek()) Then
                    lblInstructions.Text = instructions.Peek()
                    If instructionToDriveState() <> "" Then
                        instructedMode = instructionToDriveState()
                        lblAssigned.Text = instructedMode
                    End If
                    If lblInstructions.Text = Instruction.GO_OPEN Then
                        nextInstructionCountDown = Instruction.GetTickCount(lblInstructions.Text)
                    End If
                    WriteData(instructions.Peek())
                    instructions.Dequeue()
                    Interaction.Beep()
                Else
                    nextInstructionCountDown += 1 '
                End If
            Else
                lblInstructions.Text = Instruction.WAIT
            End If
        End If
        'End If
        nextInstructionCountDown = Math.Max(nextInstructionCountDown - 1, -1)
        TextBox1.Text = CStr(nextInstructionCountDown)
    End Sub

    Private Function instructionToDriveState() As String
        Select Case lblInstructions.Text
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

    Private Function MsgToDriveState(msg As String) As String
        Select Case msg
            Case Instruction.GET_MSG_PARK
                Return DriveStates.PARK
            Case Instruction.GET_MSG_REVERSE
                Return DriveStates.REVERSE
            Case Instruction.GET_MSG_NEUTRAL
                Return DriveStates.NEUTRAL
            Case Instruction.GET_MSG_DRIVE
                Return DriveStates.DRIVE
            Case Else
                Return ""
        End Select
    End Function

    Private Sub ShiftUp()
        Select Case driveMode
            Case DriveStates.PARK
                SetDriveMode(DriveStates.PARK)
            Case DriveStates.REVERSE
                SetDriveMode(DriveStates.PARK)
            Case DriveStates.NEUTRAL
                SetDriveMode(DriveStates.REVERSE)
            Case DriveStates.DRIVE
                SetDriveMode(DriveStates.NEUTRAL)
        End Select
    End Sub

    Private Sub ShiftDown()
        Select Case driveMode
            Case DriveStates.PARK
                SetDriveMode(DriveStates.REVERSE)
            Case DriveStates.REVERSE
                SetDriveMode(DriveStates.NEUTRAL)
            Case DriveStates.NEUTRAL
                SetDriveMode(DriveStates.DRIVE)
            Case DriveStates.DRIVE
                SetDriveMode(DriveStates.DRIVE)
        End Select
    End Sub

    Private Sub SetDriveMode(newMode As String)
        driveMode = newMode
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
        MsgBox(GetFuzzyState().Item(DriveStates.REVERSE))
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox(GetFuzzyInput(TransmissionInput.UP1).Item(TransmissionInput.UP1))
    End Sub

    Private Function GetFuzzyState(Optional message As String = "") As Dictionary(Of String, String)
        'Use the sliders to indicate the deree to which the transimision is in each of the following states.
        If message <> "" Then
            frmFuzzyState.SetLabelMessage(message)
        End If
        frmFuzzyState.ShowDialog()
        If frmFuzzyState.DialogResult = DialogResult.OK Then
            Dim results As New Dictionary(Of String, String)
            results.Add(DriveStates.PARK, frmFuzzyState.fuzzPark.Value)
            results.Add(DriveStates.REVERSE, frmFuzzyState.fuzzReverse.Value)
            results.Add(DriveStates.NEUTRAL, frmFuzzyState.fuzzNeutral.Value)
            results.Add(DriveStates.DRIVE, frmFuzzyState.fuzzDrive.Value)
            frmFuzzyState.Close()
            Return results
        Else
            frmFuzzyState.Close()
            Return Nothing
        End If
    End Function

    Private Function GetFuzzyInput(tInput As String) As Dictionary(Of String, String)
        'frmFuzzyState.lblMessage.Text = message
        frmFuzzyInput.lblAction.Text = tInput
        frmFuzzyInput.ShowDialog()
        If frmFuzzyInput.DialogResult = DialogResult.OK Then
            Dim results As New Dictionary(Of String, String)
            results.Add(TransmissionInput.UP1, frmFuzzyInput.fuzzUp1.Value)
            results.Add(TransmissionInput.UP2, frmFuzzyInput.fuzzUp2.Value)
            results.Add(TransmissionInput.UP3, frmFuzzyInput.fuzzUp3.Value)
            results.Add(TransmissionInput.DOWN1, frmFuzzyInput.fuzzDown1.Value)
            results.Add(TransmissionInput.DOWN2, frmFuzzyInput.fuzzDown2.Value)
            results.Add(TransmissionInput.DOWN3, frmFuzzyInput.fuzzDown3.Value)
            frmFuzzyInput.Close()
            Return results
        Else
            frmFuzzyInput.Close()
            Return Nothing
        End If
    End Function

    Private Function GetDemographics() As Dictionary(Of String, String)
        frmDemographics.ShowDialog()
        If frmDemographics.DialogResult = DialogResult.OK Then
            Dim results As New Dictionary(Of String, String)
            results.Add("Age", frmDemographics.age.Text)
            results.Add("Race", frmDemographics.race.Text)
            results.Add("AdditionalRace", frmDemographics.additionalRace.Text)
            results.Add("AdditionalGender", frmDemographics.additionalGender.Text)
            frmDemographics.Close()
            Return results
        Else
            frmDemographics.Close()
            Return Nothing
        End If
    End Function

    Private Function GetSurprise() As Dictionary(Of String, String)
        frmSurprise.ShowDialog()
        If frmSurprise.DialogResult = DialogResult.OK Then
            Dim results As New Dictionary(Of String, String)
            results.Add("Surprise", frmSurprise.fuzzSurprise.Value)
            frmSurprise.Close()
            Return results
        Else
            frmSurprise.Close()
            Return Nothing
        End If
    End Function

    Private Sub WriteData(inst As String, Optional theData As Dictionary(Of String, String) = Nothing)
        Dim outString As String = CStr(outStepCounter) + "," + Instruction.GetInstrunctionName(inst)
        If theData IsNot Nothing Then
            outString += "," + String.Join(",", theData.Select(Function(kvp) $"{kvp.Key}:{kvp.Value}"))
        End If
        outString += $",ActualState:{driveMode},InstructedState:{instructedMode}"
        outFile.WriteLine(outString)
        outStepCounter += 1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        instructions.Enqueue(Instruction.GO_OPEN)
        instructions.Enqueue(Instruction.GET_MSG_BREAK)
        instructions.Enqueue(Instruction.GO_REVERSE)
        instructions.Enqueue(Instruction.GO_GAS)
        instructions.Enqueue(Instruction.GO_NEUTRAL)
        instructions.Enqueue(Instruction.GO_GAS_LONG)
        instructions.Enqueue(Instruction.GO_DRIVE)
        instructions.Enqueue(Instruction.GO_GAS)
        instructions.Enqueue(Instruction.GO_PARK)
        instructions.Enqueue(Instruction.GO_GAS)
        instructions.Enqueue(Instruction.GET_STATE)
        instructions.Enqueue(Instruction.GET_MSG_END)
    End Sub

    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If MsgBox("Are you sure you want to exit the application?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Quit") = MsgBoxResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GetFuzzyState("Some text")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        GetDemographics()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button5.Click
        GetSurprise()
    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If outFile IsNot Nothing Then
            outFile.Close()
            outFile.Dispose()
        End If

        If joystick IsNot Nothing Then
            Try
                joystick.Unacquire()
                joystick.Dispose()
            Catch ex As Exception
                ' Catch any exceptions in case the joystick was pulled out mid-use
            End Try
        End If

        If directInput IsNot Nothing Then
            directInput.Dispose()
        End If
    End Sub

End Class
