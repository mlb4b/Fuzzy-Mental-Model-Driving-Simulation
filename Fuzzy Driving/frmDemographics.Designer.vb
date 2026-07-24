<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDemographics
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        age = New ComboBox()
        Label2 = New Label()
        Label3 = New Label()
        raceList = New CheckedListBox()
        Label4 = New Label()
        additionalRace = New TextBox()
        Label5 = New Label()
        genderPanel = New Panel()
        optOther = New RadioButton()
        optNoAnswer = New RadioButton()
        optNB = New RadioButton()
        optWoman = New RadioButton()
        optMan = New RadioButton()
        Label6 = New Label()
        additionalGender = New TextBox()
        buttonOk = New Button()
        gender = New TextBox()
        race = New TextBox()
        genderPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(34, 29)
        Label1.Name = "Label1"
        Label1.Size = New Size(790, 32)
        Label1.TabIndex = 0
        Label1.Text = "For each item below, please provide information that best describes you."
        ' 
        ' age
        ' 
        age.FormattingEnabled = True
        age.Items.AddRange(New Object() {"18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        age.Location = New Point(461, 95)
        age.Name = "age"
        age.Size = New Size(411, 40)
        age.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(34, 95)
        Label2.Name = "Label2"
        Label2.Size = New Size(164, 32)
        Label2.TabIndex = 2
        Label2.Text = "Age (in years):"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(34, 175)
        Label3.Name = "Label3"
        Label3.Size = New Size(410, 32)
        Label3.TabIndex = 2
        Label3.Text = "Race / Ethnicity (select all that apply):"
        ' 
        ' raceList
        ' 
        raceList.CheckOnClick = True
        raceList.FormattingEnabled = True
        raceList.Items.AddRange(New Object() {"American Indian or Alaska Native", "Asian", "Black or African American", "Hispanic or Latino", "Middle Eastern or North African", "Native Hawaiian or Pacific Islander", "White", "Choose not to answers"})
        raceList.Location = New Point(461, 175)
        raceList.Name = "raceList"
        raceList.Size = New Size(411, 292)
        raceList.TabIndex = 3
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(461, 470)
        Label4.Name = "Label4"
        Label4.Size = New Size(313, 32)
        Label4.TabIndex = 2
        Label4.Text = "Additional (optional) details:"
        ' 
        ' additionalRace
        ' 
        additionalRace.BorderStyle = BorderStyle.FixedSingle
        additionalRace.Location = New Point(461, 505)
        additionalRace.Name = "additionalRace"
        additionalRace.Size = New Size(411, 39)
        additionalRace.TabIndex = 4
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(34, 585)
        Label5.Name = "Label5"
        Label5.Size = New Size(227, 32)
        Label5.TabIndex = 2
        Label5.Text = "Gender (select one):"
        ' 
        ' genderPanel
        ' 
        genderPanel.BackColor = SystemColors.Window
        genderPanel.BorderStyle = BorderStyle.FixedSingle
        genderPanel.Controls.Add(optOther)
        genderPanel.Controls.Add(optNoAnswer)
        genderPanel.Controls.Add(optNB)
        genderPanel.Controls.Add(optWoman)
        genderPanel.Controls.Add(optMan)
        genderPanel.Location = New Point(461, 585)
        genderPanel.Name = "genderPanel"
        genderPanel.Size = New Size(411, 223)
        genderPanel.TabIndex = 5
        ' 
        ' optOther
        ' 
        optOther.AutoSize = True
        optOther.Location = New Point(3, 171)
        optOther.Name = "optOther"
        optOther.Size = New Size(385, 36)
        optOther.TabIndex = 0
        optOther.TabStop = True
        optOther.Text = "Other (optionally specify below)"
        optOther.UseVisualStyleBackColor = True
        ' 
        ' optNoAnswer
        ' 
        optNoAnswer.AutoSize = True
        optNoAnswer.Location = New Point(3, 129)
        optNoAnswer.Name = "optNoAnswer"
        optNoAnswer.Size = New Size(261, 36)
        optNoAnswer.TabIndex = 0
        optNoAnswer.TabStop = True
        optNoAnswer.Text = "Prefer not to answer"
        optNoAnswer.UseVisualStyleBackColor = True
        ' 
        ' optNB
        ' 
        optNB.AutoSize = True
        optNB.Location = New Point(3, 87)
        optNB.Name = "optNB"
        optNB.Size = New Size(167, 36)
        optNB.TabIndex = 0
        optNB.TabStop = True
        optNB.Text = "Non-binary"
        optNB.UseVisualStyleBackColor = True
        ' 
        ' optWoman
        ' 
        optWoman.AutoSize = True
        optWoman.Location = New Point(3, 45)
        optWoman.Name = "optWoman"
        optWoman.Size = New Size(127, 36)
        optWoman.TabIndex = 0
        optWoman.TabStop = True
        optWoman.Text = "Woman"
        optWoman.UseVisualStyleBackColor = True
        ' 
        ' optMan
        ' 
        optMan.AutoSize = True
        optMan.Location = New Point(3, 3)
        optMan.Name = "optMan"
        optMan.Size = New Size(93, 36)
        optMan.TabIndex = 0
        optMan.TabStop = True
        optMan.Text = "Man"
        optMan.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(461, 811)
        Label6.Name = "Label6"
        Label6.Size = New Size(313, 32)
        Label6.TabIndex = 2
        Label6.Text = "Additional (optional) details:"
        ' 
        ' additionalGender
        ' 
        additionalGender.BorderStyle = BorderStyle.FixedSingle
        additionalGender.Location = New Point(461, 846)
        additionalGender.Name = "additionalGender"
        additionalGender.Size = New Size(411, 39)
        additionalGender.TabIndex = 4
        ' 
        ' buttonOk
        ' 
        buttonOk.Location = New Point(380, 927)
        buttonOk.Name = "buttonOk"
        buttonOk.Size = New Size(150, 46)
        buttonOk.TabIndex = 15
        buttonOk.Text = "Submit"
        buttonOk.UseVisualStyleBackColor = True
        ' 
        ' gender
        ' 
        gender.Location = New Point(34, 631)
        gender.Name = "gender"
        gender.Size = New Size(200, 39)
        gender.TabIndex = 16
        gender.Visible = False
        ' 
        ' race
        ' 
        race.Location = New Point(34, 220)
        race.Name = "race"
        race.Size = New Size(200, 39)
        race.TabIndex = 16
        race.Visible = False
        ' 
        ' frmDemographics
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(911, 1009)
        Controls.Add(race)
        Controls.Add(gender)
        Controls.Add(buttonOk)
        Controls.Add(genderPanel)
        Controls.Add(additionalGender)
        Controls.Add(additionalRace)
        Controls.Add(Label6)
        Controls.Add(raceList)
        Controls.Add(Label4)
        Controls.Add(Label5)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(age)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmDemographics"
        ShowIcon = False
        genderPanel.ResumeLayout(False)
        genderPanel.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents age As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents raceList As CheckedListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents additionalRace As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents genderPanel As Panel
    Friend WithEvents optNoAnswer As RadioButton
    Friend WithEvents optNB As RadioButton
    Friend WithEvents optWoman As RadioButton
    Friend WithEvents optMan As RadioButton
    Friend WithEvents optOther As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents additionalGender As TextBox
    Friend WithEvents buttonOk As Button
    Friend WithEvents gender As TextBox
    Friend WithEvents race As TextBox
End Class
