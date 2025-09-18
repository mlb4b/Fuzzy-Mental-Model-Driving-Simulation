Imports System.ComponentModel

Public Class frmFuzzyState

    Private userClose As Boolean = True

    Private Sub buttonOk_Click(sender As Object, e As EventArgs) Handles buttonOk.Click
        For Each con In Me.Controls
            If TypeOf con Is cntrlFuzzySlider Then
                If Not CType(con, cntrlFuzzySlider).ValSet Then
                    MsgBox("Please provide a rating for all the options before submitting.", MsgBoxStyle.Exclamation, "Ratings Required")
                    Return
                End If
            End If
        Next con
        If MsgBox("Are you sure you want to continue? Click Yes to conrirm the ratings you have provided on the form. Click No to review your ratings.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Ratings") = MsgBoxResult.Yes Then
            Me.DialogResult = DialogResult.OK
            userClose = False
            Me.Close()
        End If
    End Sub

    Private Sub frmFuzzyState_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If userClose Then
            e.Cancel = True
        End If
    End Sub

End Class

