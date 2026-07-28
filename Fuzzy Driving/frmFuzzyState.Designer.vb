<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFuzzyState
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
        lblPark = New Label()
        lblReverse = New Label()
        lblNeutral = New Label()
        lblDrive = New Label()
        fuzzPark = New cntrlFuzzySlider()
        fuzzReverse = New cntrlFuzzySlider()
        fuzzNeutral = New cntrlFuzzySlider()
        fuzzDrive = New cntrlFuzzySlider()
        buttonOk = New Button()
        lblMessage = New RichTextBox()
        SuspendLayout()
        ' 
        ' lblPark
        ' 
        lblPark.AutoSize = True
        lblPark.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPark.Location = New Point(45, 166)
        lblPark.Name = "lblPark"
        lblPark.Size = New Size(104, 32)
        lblPark.TabIndex = 2
        lblPark.Text = "(P) Park"
        ' 
        ' lblReverse
        ' 
        lblReverse.AutoSize = True
        lblReverse.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblReverse.Location = New Point(45, 322)
        lblReverse.Name = "lblReverse"
        lblReverse.Size = New Size(143, 32)
        lblReverse.TabIndex = 2
        lblReverse.Text = "(R) Reverse"
        ' 
        ' lblNeutral
        ' 
        lblNeutral.AutoSize = True
        lblNeutral.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblNeutral.Location = New Point(45, 480)
        lblNeutral.Name = "lblNeutral"
        lblNeutral.Size = New Size(144, 32)
        lblNeutral.TabIndex = 2
        lblNeutral.Text = "(N) Neutral"
        ' 
        ' lblDrive
        ' 
        lblDrive.AutoSize = True
        lblDrive.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDrive.Location = New Point(45, 639)
        lblDrive.Name = "lblDrive"
        lblDrive.Size = New Size(118, 32)
        lblDrive.TabIndex = 2
        lblDrive.Text = "(D) Drive"
        ' 
        ' fuzzPark
        ' 
        fuzzPark.Location = New Point(210, 114)
        fuzzPark.Name = "fuzzPark"
        fuzzPark.Size = New Size(1119, 137)
        fuzzPark.TabIndex = 3
        fuzzPark.Value = 0R
        ' 
        ' fuzzReverse
        ' 
        fuzzReverse.Location = New Point(210, 271)
        fuzzReverse.Name = "fuzzReverse"
        fuzzReverse.Size = New Size(1119, 137)
        fuzzReverse.TabIndex = 3
        fuzzReverse.Value = 0R
        ' 
        ' fuzzNeutral
        ' 
        fuzzNeutral.Location = New Point(210, 430)
        fuzzNeutral.Name = "fuzzNeutral"
        fuzzNeutral.Size = New Size(1119, 137)
        fuzzNeutral.TabIndex = 3
        fuzzNeutral.Value = 0R
        ' 
        ' fuzzDrive
        ' 
        fuzzDrive.Location = New Point(210, 590)
        fuzzDrive.Name = "fuzzDrive"
        fuzzDrive.Size = New Size(1119, 137)
        fuzzDrive.TabIndex = 3
        fuzzDrive.Value = 0R
        ' 
        ' buttonOk
        ' 
        buttonOk.Location = New Point(622, 733)
        buttonOk.Name = "buttonOk"
        buttonOk.Size = New Size(150, 46)
        buttonOk.TabIndex = 4
        buttonOk.Text = "Submit"
        buttonOk.UseVisualStyleBackColor = True
        ' 
        ' lblMessage
        ' 
        lblMessage.BackColor = SystemColors.ButtonFace
        lblMessage.BorderStyle = BorderStyle.None
        lblMessage.Location = New Point(45, 29)
        lblMessage.Name = "lblMessage"
        lblMessage.ReadOnly = True
        lblMessage.Size = New Size(1284, 79)
        lblMessage.TabIndex = 6
        lblMessage.TabStop = False
        lblMessage.Text = "Use the sliders to indicate the degree to which you think the car is in each of the following states."
        ' 
        ' frmFuzzyState
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1391, 808)
        Controls.Add(lblMessage)
        Controls.Add(buttonOk)
        Controls.Add(fuzzDrive)
        Controls.Add(fuzzNeutral)
        Controls.Add(fuzzReverse)
        Controls.Add(fuzzPark)
        Controls.Add(lblDrive)
        Controls.Add(lblNeutral)
        Controls.Add(lblReverse)
        Controls.Add(lblPark)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmFuzzyState"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents Label5 As Label
    Friend WithEvents lblPark As Label
    Friend WithEvents TrackBar2 As TrackBar
    Friend WithEvents Label4 As Label
    Friend WithEvents lblReverse As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TrackBar3 As TrackBar
    Friend WithEvents Label8 As Label
    Friend WithEvents lblNeutral As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TrackBar4 As TrackBar
    Friend WithEvents Label11 As Label
    Friend WithEvents lblDrive As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblVal As Label
    Friend WithEvents fuzzPark As cntrlFuzzySlider
    Friend WithEvents fuzzReverse As cntrlFuzzySlider
    Friend WithEvents fuzzNeutral As cntrlFuzzySlider
    Friend WithEvents fuzzDrive As cntrlFuzzySlider
    Friend WithEvents buttonOk As Button
    Friend WithEvents lblMessage As RichTextBox
End Class
