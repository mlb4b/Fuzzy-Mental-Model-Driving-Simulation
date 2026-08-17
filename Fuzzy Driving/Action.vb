Public Class Action
    Public Const SHIFT_UP As String = "Shift Up"
    Public Const SHIFT_DOWN As String = "Shift Down"
    Public Const SHIFT_UP_FAIL As String = "Shift Up Fail"
    Public Const SHIFT_DOWN_FAIL As String = "Shift Down Fail"
    Public Const GAS As String = "Gas"

    Public Shared Function IsAction(act As String) As Boolean
        Return act = SHIFT_UP _
            OrElse act = SHIFT_DOWN _
            OrElse act = SHIFT_UP_FAIL _
            OrElse act = SHIFT_DOWN_FAIL _
            OrElse act = GAS
    End Function
End Class
