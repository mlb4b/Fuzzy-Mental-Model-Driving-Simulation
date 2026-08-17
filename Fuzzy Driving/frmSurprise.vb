Imports System.ComponentModel
Imports Windows.Win32.System

Public Class frmSurprise

    Private userClose As Boolean = True

    Private Sub buttonOk_Click(sender As Object, e As EventArgs) Handles buttonOk.Click
        If Not fuzzSurprise.ValSet Then
            MsgBox("Please provide a rating before submitting.", MsgBoxStyle.Exclamation, "Ratings Required")
            Return
        End If
        'If MsgBox("Are you sure you want to continue? Click Yes to conrirm the ratings you have provided on the form. Click No to review your ratings.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Ratings") = MsgBoxResult.Yes Then
        Me.DialogResult = DialogResult.OK
        userClose = False
        Me.Close()
        'End If
    End Sub

    Private Sub frmFuzzyState_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If userClose Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click, Label3.Click, Label4.Click, Label5.Click

    End Sub
End Class