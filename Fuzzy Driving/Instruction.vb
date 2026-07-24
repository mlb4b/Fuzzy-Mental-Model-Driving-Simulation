Public Class Instruction
    Public Const WAIT As String = "Wait for instruction"
    Public Const GO_PARK As String = "Put the car in Park"
    Public Const GO_NEUTRAL As String = "Put the car in Neutral"
    Public Const GO_REVERSE As String = "Put the car in Reverse"
    Public Const GO_DRIVE As String = "Put the car in Drive"
    Public Const GO_GAS As String = "Apply the gas and drive"
    Public Const GET_STATE As String = ""
    Public Const GET_UP1 As String = TransmissionInput.UP1
    Public Const GET_UP2 As String = TransmissionInput.UP2
    Public Const GET_UP3 As String = TransmissionInput.UP3
    Public Const GET_DOWN1 As String = TransmissionInput.DOWN1
    Public Const GET_DOWN2 As String = TransmissionInput.DOWN2
    Public Const GET_DOWN3 As String = TransmissionInput.DOWN3
    Public Const GET_GAS As String = TransmissionInput.GAS

    Public Shared Function IsInputRequest(instruction As String) As Boolean
        Return instruction = GET_UP1 OrElse instruction = GET_UP2 OrElse instruction = GET_UP3 OrElse instruction = GET_DOWN1 OrElse instruction = GET_DOWN2 OrElse instruction = GET_DOWN3 OrElse instruction = GET_GAS
    End Function
End Class
