Imports System.ComponentModel
Imports System.Diagnostics.Eventing.Reader
Imports System.Net.Mail
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar
Imports SharpDX
Imports SharpDX.DirectInput
'Imports SharpDX.XInput
Public Class frmMain
    Private directInput As DirectInput
    Private joystick As Joystick
    'Private xinputController As Controller

    Private driveMode As String = DriveStates.PARK
    Private instructedMode As String = DriveStates.PARK
    Private selectedMode As String = DriveStates.PARK 'tracks actual inputs
    Private isVague As Boolean = False

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
    Private failureRate As Double = 0.2
    Private goToDrive As Boolean = False
    Private lastInstruction As String = ""
    Private revertCommand As Boolean = False

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
            .Enqueue(Instruction.GET_DEMOGRAPHICS) 'step 1
            .Enqueue(Instruction.GET_MSG_BEGIN) 'step 2
            .Enqueue(Instruction.GO_OPEN) 'step 3
            .Enqueue(Instruction.GET_MSG_PARK) 'step 4
            .Enqueue(Instruction.GO_DRIVE) 'step 5
            .Enqueue(Instruction.GO_GAS) 'step 6
            .Enqueue(Instruction.GO_REVERSE) 'step 7
            .Enqueue(Instruction.GO_GAS) 'step 8
            .Enqueue(Instruction.GO_NEUTRAL) 'step 9
            .Enqueue(Instruction.GO_GAS) 'step 10
            .Enqueue(Instruction.GO_PARK) 'step 11
            .Enqueue(Instruction.GO_GAS) 'step 12
            .Enqueue(Instruction.GO_REVERSE) 'step 13
            .Enqueue(Instruction.GO_GAS) 'step 14
            .Enqueue(Instruction.GO_DRIVE) 'step 15
            .Enqueue(Instruction.GO_GAS) 'step 16
            .Enqueue(Instruction.GO_NEUTRAL) 'step 17
            .Enqueue(Instruction.GO_GAS) 'step 18
            .Enqueue(Instruction.GO_REVERSE) 'step 19
            .Enqueue(Instruction.GO_GAS) 'step 20
            .Enqueue(Instruction.GO_PARK) 'step 21
            .Enqueue(Instruction.GO_GAS) 'step 22
            .Enqueue(Instruction.GO_NEUTRAL) 'step 23
            .Enqueue(Instruction.GO_GAS) 'step 24
            .Enqueue(Instruction.GO_DRIVE) 'step 25
            .Enqueue(Instruction.GO_GAS) 'step 26
            .Enqueue(Instruction.GO_PARK) 'step 27
            .Enqueue(Instruction.GO_GAS) 'step 28
            .Enqueue(Instruction.GET_MSG_REVERSE) 'step 29
            .Enqueue(Instruction.GO_PARK) 'step 30
            .Enqueue(Instruction.GO_GAS) 'step 31
            .Enqueue(Instruction.GO_NEUTRAL) 'step 32
            .Enqueue(Instruction.GO_GAS) 'step 33
            .Enqueue(Instruction.GO_REVERSE) 'step 34
            .Enqueue(Instruction.GO_GAS) 'step 35
            .Enqueue(Instruction.GO_DRIVE) 'step 36
            .Enqueue(Instruction.GO_GAS) 'step 37
            .Enqueue(Instruction.GO_PARK) 'step 38
            .Enqueue(Instruction.GO_GAS) 'step 39
            .Enqueue(Instruction.GO_DRIVE) 'step 40
            .Enqueue(Instruction.GO_GAS) 'step 41
            .Enqueue(Instruction.GO_NEUTRAL) 'step 42
            .Enqueue(Instruction.GO_GAS) 'step 43
            .Enqueue(Instruction.GO_PARK) 'step 44
            .Enqueue(Instruction.GO_GAS) 'step 45
            .Enqueue(Instruction.GO_REVERSE) 'step 46
            .Enqueue(Instruction.GO_GAS) 'step 47
            .Enqueue(Instruction.GO_NEUTRAL) 'step 48
            .Enqueue(Instruction.GO_GAS) 'step 49
            .Enqueue(Instruction.GO_DRIVE) 'step 50
            .Enqueue(Instruction.GO_GAS) 'step 51
            .Enqueue(Instruction.GO_REVERSE) 'step 52
            .Enqueue(Instruction.GO_GAS) 'step 53
            .Enqueue(Instruction.GET_MSG_DRIVE) 'step 54
            .Enqueue(Instruction.GO_NEUTRAL) 'step 55
            .Enqueue(Instruction.GO_GAS) 'step 56
            .Enqueue(Instruction.GO_PARK) 'step 57
            .Enqueue(Instruction.GO_GAS) 'step 58
            .Enqueue(Instruction.GO_REVERSE) 'step 59
            .Enqueue(Instruction.GO_GAS) 'step 60
            .Enqueue(Instruction.GO_NEUTRAL) 'step 61
            .Enqueue(Instruction.GO_GAS) 'step 62
            .Enqueue(Instruction.GO_DRIVE) 'step 63
            .Enqueue(Instruction.GO_GAS) 'step 64
            .Enqueue(Instruction.GO_REVERSE) 'step 65
            .Enqueue(Instruction.GO_GAS) 'step 66
            .Enqueue(Instruction.GO_PARK) 'step 67
            .Enqueue(Instruction.GO_GAS) 'step 68
            .Enqueue(Instruction.GO_NEUTRAL) 'step 69
            .Enqueue(Instruction.GO_GAS) 'step 70
            .Enqueue(Instruction.GO_REVERSE) 'step 71
            .Enqueue(Instruction.GO_GAS) 'step 72
            .Enqueue(Instruction.GO_DRIVE) 'step 73
            .Enqueue(Instruction.GO_GAS) 'step 74
            .Enqueue(Instruction.GO_PARK) 'step 75
            .Enqueue(Instruction.GO_GAS) 'step 76
            .Enqueue(Instruction.GO_DRIVE) 'step 77
            .Enqueue(Instruction.GO_GAS) 'step 78
            .Enqueue(Instruction.GET_UP1) 'step 79
            .Enqueue(Instruction.GET_UP2) 'step 80
            .Enqueue(Instruction.GET_UP3) 'step 81
            .Enqueue(Instruction.GET_DOWN1) 'step 82
            .Enqueue(Instruction.GET_DOWN2) 'step 83
            .Enqueue(Instruction.GET_DOWN3) 'step 84
            .Enqueue(Instruction.GET_GAS) 'step 85
            .Enqueue(Instruction.GET_MSG_BREAK) 'step 86
            .Enqueue(Instruction.GET_MSG_PARK) 'step 87
            .Enqueue(Instruction.GO_REVERSE_V) 'step 88
            .Enqueue(Instruction.GET_STATE) 'step 89
            .Enqueue(Instruction.GET_MSG_REVERSE) 'step 90
            .Enqueue(Instruction.GO_NEUTRAL_V) 'step 91
            .Enqueue(Instruction.GET_STATE) 'step 92
            .Enqueue(Instruction.GET_MSG_NEUTRAL) 'step 93
            .Enqueue(Instruction.GO_PARK_V) 'step 94
            .Enqueue(Instruction.GET_STATE) 'step 95
            .Enqueue(Instruction.GET_MSG_PARK) 'step 96
            .Enqueue(Instruction.GO_REVERSE_V) 'step 97
            .Enqueue(Instruction.GET_STATE) 'step 98
            .Enqueue(Instruction.GET_MSG_REVERSE) 'step 99
            .Enqueue(Instruction.GO_DRIVE_V) 'step 100
            .Enqueue(Instruction.GET_STATE) 'step 101
            .Enqueue(Instruction.GET_MSG_DRIVE) 'step 102
            .Enqueue(Instruction.GO_NEUTRAL_V) 'step 103
            .Enqueue(Instruction.GET_STATE) 'step 104
            .Enqueue(Instruction.GET_MSG_NEUTRAL) 'step 105
            .Enqueue(Instruction.GO_REVERSE_V) 'step 106
            .Enqueue(Instruction.GET_STATE) 'step 107
            .Enqueue(Instruction.GET_MSG_REVERSE) 'step 1
            .Enqueue(Instruction.GO_PARK_V) 'step 2
            .Enqueue(Instruction.GET_STATE) 'step 3
            .Enqueue(Instruction.GET_MSG_PARK) 'step 4
            .Enqueue(Instruction.GO_NEUTRAL_V) 'step 5
            .Enqueue(Instruction.GET_STATE) 'step 6
            .Enqueue(Instruction.GET_MSG_NEUTRAL) 'step 7
            .Enqueue(Instruction.GO_DRIVE_V) 'step 8
            .Enqueue(Instruction.GET_STATE) 'step 9
            .Enqueue(Instruction.GET_MSG_DRIVE) 'step 10
            .Enqueue(Instruction.GO_PARK_V) 'step 11
            .Enqueue(Instruction.GET_STATE) 'step 12
            .Enqueue(Instruction.GET_MSG_PARK) 'step 13
            .Enqueue(Instruction.GO_DRIVE_V) 'step 14
            .Enqueue(Instruction.GET_STATE) 'step 15
            .Enqueue(Instruction.GET_MSG_DRIVE) 'step 16
            .Enqueue(Instruction.GO_REVERSE_V) 'step 17
            .Enqueue(Instruction.GET_STATE) 'step 18
            .Enqueue(Instruction.GET_MSG_REVERSE) 'step 126
            .Enqueue(Instruction.GO_NEUTRAL_V) 'step 127
            .Enqueue(Instruction.GET_STATE) 'step 128
            .Enqueue(Instruction.GET_MSG_NEUTRAL) 'step 129
            .Enqueue(Instruction.GO_PARK_V) 'step 130
            .Enqueue(Instruction.GET_STATE) 'step 131
            .Enqueue(Instruction.GET_MSG_BREAK) 'step 132
            .Enqueue(Instruction.GET_MSG_NEUTRAL) 'step 133
            .Enqueue(Instruction.GO_PARK_V) 'step 134
            .Enqueue(Instruction.GO_GAS) 'step 135
            .Enqueue(Instruction.GET_SURPRISE) 'step 136
            .Enqueue(Instruction.GET_MSG_PARK) 'step 137
            .Enqueue(Instruction.GO_REVERSE_V) 'step 138
            .Enqueue(Instruction.GO_GAS) 'step 139
            .Enqueue(Instruction.GET_SURPRISE) 'step 140
            .Enqueue(Instruction.GET_MSG_REVERSE) 'step 141
            .Enqueue(Instruction.GO_NEUTRAL_V) 'step 142
            .Enqueue(Instruction.GO_GAS) 'step 143
            .Enqueue(Instruction.GET_SURPRISE) 'step 144
            .Enqueue(Instruction.GET_MSG_NEUTRAL) 'step 145
            .Enqueue(Instruction.GO_DRIVE_V) 'step 146
            .Enqueue(Instruction.GO_GAS) 'step 147
            .Enqueue(Instruction.GET_SURPRISE) 'step 148
            .Enqueue(Instruction.GET_MSG_DRIVE) 'step 149
            .Enqueue(Instruction.GO_REVERSE_V) 'step 150
            .Enqueue(Instruction.GO_GAS) 'step 151
            .Enqueue(Instruction.GET_SURPRISE) 'step 152
            .Enqueue(Instruction.GET_MSG_REVERSE) 'step 153
            .Enqueue(Instruction.GO_PARK_V) 'step 154
            .Enqueue(Instruction.GO_GAS) 'step 155
            .Enqueue(Instruction.GET_SURPRISE) 'step 156
            .Enqueue(Instruction.GET_MSG_PARK) 'step 157
            .Enqueue(Instruction.GO_NEUTRAL_V) 'step 158
            .Enqueue(Instruction.GO_GAS) 'step 159
            .Enqueue(Instruction.GET_SURPRISE) 'step 160
            .Enqueue(Instruction.GET_MSG_NEUTRAL) 'step 161
            .Enqueue(Instruction.GO_REVERSE_V) 'step 162
            .Enqueue(Instruction.GO_GAS) 'step 163
            .Enqueue(Instruction.GET_SURPRISE) 'step 164
            .Enqueue(Instruction.GET_MSG_REVERSE) 'step 165
            .Enqueue(Instruction.GO_DRIVE_V) 'step 166
            .Enqueue(Instruction.GO_GAS) 'step 167
            .Enqueue(Instruction.GET_SURPRISE) 'step 168
            .Enqueue(Instruction.GET_MSG_DRIVE) 'step 169
            .Enqueue(Instruction.GO_PARK_V) 'step 170
            .Enqueue(Instruction.GO_GAS) 'step 171
            .Enqueue(Instruction.GET_SURPRISE) 'step 172
            .Enqueue(Instruction.GET_MSG_PARK) 'step 173
            .Enqueue(Instruction.GO_DRIVE_V) 'step 174
            .Enqueue(Instruction.GO_GAS) 'step 175
            .Enqueue(Instruction.GET_SURPRISE) 'step 176
            .Enqueue(Instruction.GET_MSG_DRIVE) 'step 177
            .Enqueue(Instruction.GO_NEUTRAL_V) 'step 178
            .Enqueue(Instruction.GO_GAS) 'step 179
            .Enqueue(Instruction.GET_SURPRISE) 'step 180
            .Enqueue(Instruction.GET_MSG_NEUTRAL) 'step 181
            .Enqueue(Instruction.GO_REVERSE_SPECIAL) 'step 182
            .Enqueue(Instruction.GO_GAS) 'step 183
            .Enqueue(Instruction.GET_SURPRISE) 'step 184
            .Enqueue(Instruction.GET_MSG_END) 'step 185


            ' this is old stuff
            '.Enqueue(Instruction.GO_OPEN)
            '.Enqueue(Instruction.GET_MSG_NEUTRAL)
            '.Enqueue(Instruction.GO_REVERSE_SPECIAL)
            '.Enqueue(Instruction.GO_GAS)
            '.Enqueue(Instruction.GET_MSG_REVERSE)
            '.Enqueue(Instruction.GO_DRIVE)
            '.Enqueue(Instruction.GET_DEMOGRAPHICS)
            '.Enqueue(Instruction.GO_OPEN)
            '.Enqueue(Instruction.GET_MSG_BREAK)
            '.Enqueue(Instruction.GET_SURPRISE)
            '.Enqueue(Instruction.GO_REVERSE)
            '.Enqueue(Instruction.GO_GAS)
            '.Enqueue(Instruction.GO_NEUTRAL)
            '.Enqueue(Instruction.GO_GAS_LONG)
            '.Enqueue(Instruction.GO_DRIVE)
            '.Enqueue(Instruction.GO_GAS)
            '.Enqueue(Instruction.GO_PARK)
            '.Enqueue(Instruction.GO_GAS)
            '.Enqueue(Instruction.GET_STATE)
            '.Enqueue(Instruction.GET_UP1)
            '.Enqueue(Instruction.GET_UP2)
            '.Enqueue(Instruction.GET_UP3)
            '.Enqueue(Instruction.GET_DOWN1)
            '.Enqueue(Instruction.GET_DOWN2)
            '.Enqueue(Instruction.GET_DOWN3)
            '.Enqueue(Instruction.GET_GAS)
            '.Enqueue(Instruction.GET_MSG_END)
        End With

        Dim firstStep As Integer = CInt(InputBox("Please enter the step to start on:", "First Step", "1"))
        For i = 1 To firstStep - 1 'dequeues the instructions to get to the start 
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

        If driveButton And (driveMode = DriveStates.DRIVE Or goToDrive) Then
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

        Dim isShiftUp As Boolean = (z < zMin + zSlop)
        Dim isShiftDown As Boolean = (z > axisMax - zSlop)
        Dim isShift As Boolean = isShiftUp Or isShiftDown

        Dim isCooldownOver As Boolean = (now - lastShiftTime).TotalMilliseconds >= shiftCooldown
        Dim canShift As Boolean = Not zLocked AndAlso isCooldownOver

        If canShift AndAlso isShift Then
            Dim failToShift As Boolean = Rnd() < failureRate
            If isShiftUp Then
                If Not failToShift Then ShiftUp()
                ConceptualShiftUp()
            ElseIf isShiftDown Then
                If Not failToShift Then ShiftDown()
                ConceptualShiftDown()
            End If
            zLocked = True
            lastShiftTime = DateTime.Now
        ElseIf Not isShift Then
            zLocked = False
        End If

        'If Not zLocked And ((now - lastShiftTime).TotalMilliseconds >= shiftCooldown) Then
        '    If failToShift And isShift Then
        '        If isShiftUp Then
        '            ConceptualShiftUp()
        '        ElseIf isShiftDown Then
        '            ConceptualShiftDown()
        '        End If
        '        zLocked = True
        '        lastShiftTime = now
        '    ElseIf isShiftUp Then
        '        zLocked = True
        '        ShiftUp()
        '        ConceptualShiftUp()
        '        lastShiftTime = now
        '    ElseIf isShiftDown Then
        '        zLocked = True
        '        ShiftDown()
        '        ConceptualShiftDown()
        '        lastShiftTime = now
        '    End If
        'ElseIf Not isShift Then
        '    zLocked = False
        'End If

        picWheel.Image = RotateImage(originalImage, ((x - axisMax / 2) / axisMax) * 180) ' Rotate based on X axis input
        picShifter.Top = shiftDefaultTop + ((z - axisMax / 2) / axisMax) * maxShiftTop ' Adjust Y position based on Y axis input

        'deal with instructions if any
        'if the last instruction has been satisfied, set countdown
        If lblInstructions.Text = Instruction.WAIT And instructions.Count > 0 Then
            nextInstructionCountDown = 0
        End If

        isVague = Instruction.IsVagueInstruction(lblInstructions.Text) Or isVague And Instruction.IsGasInstruction(lblInstructions.Text)
        Dim isNotVague As Boolean = Not isVague

        If Instruction.IsGasInstruction(lblInstructions.Text) And instructedMode <> driveMode And isNotVague Then
            lastInstruction = If(lblInstructions.Text <> DriveStateToInstruction(instructedMode), lblInstructions.Text, lastInstruction)
            lblInstructions.Text = DriveStateToInstruction(instructedMode)
            revertCommand = True
            'Private lastInstruction As String = ""
            'Private revertCommand As Boolean = False
        ElseIf revertCommand And instructedMode = driveMode And isNotVague Then
            lblInstructions.Text = lastInstruction
            lastInstruction = ""
            revertCommand = False
        Else
            If nextInstructionCountDown < 0 And ((
                (Instruction.IsGasInstruction(lblInstructions.Text) And driveButton) Or
                (isNotVague And driveMode = instructionToDriveState()) Or
                (isVague And selectedMode = instructionToDriveState())
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
                                SetSelectedDriveMode(nextMode)
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
                            If instructions.Peek() = Instruction.GO_REVERSE_SPECIAL Then
                                goToDrive = True
                            ElseIf goToDrive Then
                                goToDrive = False
                            End If
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
            nextInstructionCountDown = Math.Max(nextInstructionCountDown - 1, -1)
        End If
        TextBox1.Text = CStr(nextInstructionCountDown)
    End Sub

    Private Function instructionToDriveState(Optional inst As String = "") As String
        'this works even for vague instructions due to the trimming
        Dim lookupVal As String
        If inst = "" Then
            lookupVal = lblInstructions.Text
        Else
            lookupVal = inst
        End If
        Select Case Trim(lookupVal)
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

    Private Function DriveStateToInstruction(state As String) As String
        Select Case state
            Case DriveStates.PARK
                Return Instruction.GO_PARK
            Case DriveStates.REVERSE
                Return Instruction.GO_REVERSE
            Case DriveStates.NEUTRAL
                Return Instruction.GO_NEUTRAL
            Case DriveStates.DRIVE
                Return Instruction.GO_DRIVE
            Case Else
                Return ""
        End Select
    End Function

    Private Sub ConceptualShiftUp()
        Select Case selectedMode
            Case DriveStates.PARK
                SetSelectedDriveMode(DriveStates.PARK)
            Case DriveStates.REVERSE
                SetSelectedDriveMode(DriveStates.PARK)
            Case DriveStates.NEUTRAL
                SetSelectedDriveMode(DriveStates.REVERSE)
            Case DriveStates.DRIVE
                SetSelectedDriveMode(DriveStates.NEUTRAL)
        End Select
    End Sub

    Private Sub ConceptualShiftDown()
        Select Case selectedMode
            Case DriveStates.PARK
                SetSelectedDriveMode(DriveStates.REVERSE)
            Case DriveStates.REVERSE
                SetSelectedDriveMode(DriveStates.NEUTRAL)
            Case DriveStates.NEUTRAL
                SetSelectedDriveMode(DriveStates.DRIVE)
            Case DriveStates.DRIVE
                SetSelectedDriveMode(DriveStates.DRIVE)
        End Select
    End Sub

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

    Private Sub SetSelectedDriveMode(newMode As String)
        selectedMode = newMode
        lblSelected.Text = selectedMode
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
        outFile.Flush()
        outStepCounter += 1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        instructions.Enqueue(Instruction.GO_OPEN)
        instructions.Enqueue(Instruction.GET_MSG_NEUTRAL)
        instructions.Enqueue(Instruction.GO_REVERSE_SPECIAL)
        instructions.Enqueue(Instruction.GO_GAS)
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
