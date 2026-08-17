Imports System.Reflection
Public Class Instruction
    Public Const WAIT As String = "Wait for instruction"
    Public Const GO_PARK As String = "Put the car in " + vbCrLf + "P - Park"
    Public Const GO_NEUTRAL As String = "Put the car in " + vbCrLf + "N - Neutral"
    Public Const GO_REVERSE As String = "Put the car in " + vbCrLf + "R - Reverse"
    Public Const GO_DRIVE As String = "Put the car in " + vbCrLf + "D - Drive"

    Public Const GO_PARK_V As String = "Put the car in " + vbCrLf + "P - Park "
    Public Const GO_NEUTRAL_V As String = "Put the car in " + vbCrLf + "N - Neutral "
    Public Const GO_REVERSE_V As String = "Put the car in " + vbCrLf + "R - Reverse "
    Public Const GO_DRIVE_V As String = "Put the car in " + vbCrLf + "D - Drive "
    Public Const GO_REVERSE_SPECIAL As String = "Put the car in " + vbCrLf + "R - Reverse  " 'the extra spaces are necessary
    Public Const GO_PARK_SPECIAL As String = "Put the car in " + vbCrLf + "P - Park  " 'the extra spaces are necessary

    Public Const GET_TOGGLE_GAS As String = "Disable/Enable gas"

    Public Const GET_MSG_OPEN_PART As String = "In the following section of the experiment, you are given time to explore the functionality of the car. Please use the game controller to transition to different drive states (i.e., P - Park, R - Reverse, N - Neutral, D - Drive), apply the gas, and steer the steering wheel."
    Public Const GET_MSG_LEARNING_PART As String = "The following section of the experiment is designed to ensure you are familiar with the functionality of the car. In this section, you will be asked to transition between different drive states (i.e., P - Park, R - Reverse, N - Neutral, D - Drive) and apply the gas."
    Public Const GET_MSG_STATES_PART As String = "In the following section of the experiment, you will be asked to transition the car to different drive states (i.e., P - Park, R - Reverse, N - Neutral, D - Drive), and then you will provide ratings concerning the degree you think this car is in each state. The effect of applying the gas has been DISABLED in this section."
    Public Const GET_MSG_SURPRISE_PART As String = "The ability to apply the gas has been re-enabled in this part of the experiment. Here, you will be asked to transition the car to different drive states (i.e., P - Park, R - Reverse, N - Neutral, D - Drive) as well as apply the Gas. You will also be asked to provide ratings concerning how surprised you are by the behavior of the car after you apply the gas."

    Public Const GO_GAS As String = "Apply the gas"
    Public Const GO_GAS_LONG As String = "Apply the gas for a while"
    Public Const GO_OPEN As String = "Drive around: change drive modes, press the gas, steer, etc."
    Public Const GET_MSG_END As String = "The experiment is complete. Thank you for your time!"
    Public Const GET_MSG_BREAK As String = "This section of the experiment has finished. You may take a break if you wish. Click on Ok when you are ready to continue."
    Public Const GET_MSG_BEGIN As String = "You are about to begin the experiment. Press 'Ok' when you are ready to start."
    Public Const GET_MSG_PARK As String = "Note, the car has now been put in Park."
    Public Const GET_MSG_PARK_SPECIAL As String = "Note, the car has now been put in P - Park."
    Public Const GET_MSG_NEUTRAL As String = "Note, the car has now been put in Neutral."
    Public Const GET_MSG_REVERSE As String = "Note, the car has now been put in Reverse."
    Public Const GET_MSG_DRIVE As String = "Note, the car has now been put in Drive."
    Public Const GET_STATE As String = "Get state"
    Public Const GET_DEMOGRAPHICS As String = "Get demographics"
    Public Const GET_SURPRISE As String = "Get surprise"
    Public Const GET_UP1 As String = TransmissionInput.UP1
    Public Const GET_UP2 As String = TransmissionInput.UP2
    Public Const GET_UP3 As String = TransmissionInput.UP3
    Public Const GET_DOWN1 As String = TransmissionInput.DOWN1
    Public Const GET_DOWN2 As String = TransmissionInput.DOWN2
    Public Const GET_DOWN3 As String = TransmissionInput.DOWN3
    Public Const GET_GAS As String = TransmissionInput.GAS

    Public Shared Function IsGet(Instruction) As Boolean
        Return Instruction = GET_STATE _
            OrElse Instruction = GET_GAS _
            OrElse Instruction = GET_DEMOGRAPHICS _
            OrElse Instruction = GET_SURPRISE _
            OrElse Instruction = GET_TOGGLE_GAS _
            OrElse IsGetInputRequest(Instruction) _
            OrElse IsMessage(Instruction)
    End Function

    Public Shared Function IsStateMessage(instruction As String) As Boolean
        Return instruction = GET_MSG_PARK _
            OrElse instruction = GET_MSG_NEUTRAL _
            OrElse instruction = GET_MSG_REVERSE _
            OrElse instruction = GET_MSG_DRIVE
    End Function

    Public Shared Function IsGetInputRequest(instruction As String) As Boolean
        Return instruction = GET_UP1 _
            OrElse instruction = GET_UP2 _
            OrElse instruction = GET_UP3 _
            OrElse instruction = GET_DOWN1 _
            OrElse instruction = GET_DOWN2 _
            OrElse instruction = GET_DOWN3 _
            OrElse instruction = GET_GAS
    End Function

    Public Shared Function IsInstruction(instruction As String) As Boolean
        Return Not IsGet(instruction)
    End Function

    Public Shared Function IsGoInstruction(instruction As String) As Boolean
        Return Not IsGet(instruction) And Not instruction = WAIT And Not instruction = GO_OPEN
    End Function

    Public Shared Function IsMessage(instruction As String) As Boolean
        ' use GetInstrunctionName to get the name of the instruction constant and see if it starts with "GET_MSG_"
        Return GetInstrunctionName(instruction).StartsWith("GET_MSG_")
        'Return instruction = GET_MSG_END _
        '    OrElse instruction = GET_MSG_BREAK _
        '    OrElse instruction = GET_MSG_BEGIN _
        '    OrElse instruction = GET_MSG_PARK _
        '    OrElse instruction = GET_MSG_NEUTRAL _
        '    OrElse instruction = GET_MSG_REVERSE _
        '    OrElse instruction = GET_MSG_DRIVE
    End Function

    Public Shared Function IsGasInstruction(instruction As String) As Boolean
        Return instruction = GO_GAS OrElse instruction = GO_GAS_LONG
    End Function

    Public Shared Function IsVagueInstruction(instruction As String) As Boolean
        Return instruction = GO_PARK_V _
            OrElse instruction = GO_NEUTRAL_V _
            OrElse instruction = GO_REVERSE_V _
            OrElse instruction = GO_DRIVE_V _
            OrElse instruction = GO_REVERSE_SPECIAL _
            OrElse instruction = GO_PARK_SPECIAL
    End Function

    Public Shared Function GetTickCount(instruction As String) As Integer
        Select Case instruction
            Case GO_GAS_LONG
                Return 300
            Case GO_OPEN
                Return 1000
            Case Else
                Return 10
        End Select
    End Function

    Public Shared Function GetInstrunctionName(instruction As String) As String

        Dim fields() As FieldInfo = GetType(Instruction).GetFields(BindingFlags.Public Or BindingFlags.Static)

        For Each field As FieldInfo In fields
            If field.IsLiteral AndAlso field.FieldType = GetType(String) Then
                Dim val As String = CStr(field.GetValue(Nothing))
                If val = instruction Then
                    Return field.Name
                End If
            End If
        Next

        Return instruction
    End Function


End Class
