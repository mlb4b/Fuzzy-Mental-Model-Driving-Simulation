Imports System.ComponentModel

'a variable containing words to be bolded in the message label based on the constants in DriveStates.vb and TransmissionInput.vb

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

    Public Sub SetLabelMessage(ByVal message As String)
        If message <> "" Then
            lblMessage.Text = message
            For Each word In wordsToBold
                BoldWordInRichTextBox(word)
            Next
        End If
    End Sub

    'subroutine to bold a specific word in the rich text box lblMessage
    Private Sub BoldWordInRichTextBox(ByVal word As String)
        Dim startIndex As Integer = 0
        While startIndex < lblMessage.TextLength
            Dim wordIndex As Integer = lblMessage.Text.IndexOf(word, startIndex, StringComparison.CurrentCultureIgnoreCase)
            If wordIndex = -1 Then
                Exit While
            End If
            lblMessage.Select(wordIndex, word.Length)
            lblMessage.SelectionFont = New Font(lblMessage.Font, FontStyle.Bold)
            startIndex = wordIndex + word.Length
        End While
        lblMessage.Select(0, 0) 'remove selection
    End Sub

    Private Sub frmFuzzyState_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

