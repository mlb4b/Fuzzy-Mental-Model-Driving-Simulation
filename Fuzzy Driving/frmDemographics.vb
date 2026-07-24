Imports System.ComponentModel

Public Class frmDemographics

    Private userClose As Boolean = True

    Private Sub Race_SelectedIndexChanged(sender As Object, e As EventArgs) Handles raceList.SelectedIndexChanged
        Dim LastIndex As Long = raceList.Items.Count - 1
        If raceList.SelectedIndex = LastIndex And raceList.GetItemChecked(LastIndex) Then
            For i As Integer = 0 To LastIndex - 1
                raceList.SetItemChecked(i, False)
            Next
            additionalRace.Text = ""
        Else
            raceList.SetItemChecked(LastIndex, False)
        End If
    End Sub

    Private Sub frmFuzzyState_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If userClose Then
            e.Cancel = True
        End If
    End Sub

    Private Sub buttonOk_Click(sender As Object, e As EventArgs) Handles buttonOk.Click
        'check if age is a number greater than 18
        If Not IsNumeric(age.Text) OrElse CInt(age.Text) < 18 Then
            MsgBox("Please enter a valid age greater than or equal to 18.", MsgBoxStyle.Exclamation, "Invalid Age")
            Return
        End If

        'check that at least one race is selected
        race.Text = ""
        If raceList.CheckedItems.Count = 0 Then
            MsgBox("Please select at least one race or ethnicity.", MsgBoxStyle.Exclamation, "Invalid Race/Ethnicity Selection")
            Return
        End If
        'store values of all checked items in Race.Text
        race.Text = raceList.CheckedItems.Cast(Of String)().Aggregate(Function(a, b) a & "," & b)

        'check that a gender was selected
        Dim Opt As RadioButton
        gender.Text = ""
        For Each Opt In genderPanel.Controls.OfType(Of RadioButton)()
            If Opt.Checked Then
                gender.Text = Opt.Text
            End If
        Next
        If gender.Text = "" Then
            MsgBox("Please select a gender.", MsgBoxStyle.Exclamation, "Invalid Gender Selection")
            Return
        End If

        If MsgBox("Are you sure you want to continue? Click Yes to conrirm the ratings you have provided on the form. Click No to review your ratings.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Ratings") = MsgBoxResult.Yes Then
            Me.DialogResult = DialogResult.OK
            userClose = False
            Me.Close()
        End If
    End Sub
End Class

