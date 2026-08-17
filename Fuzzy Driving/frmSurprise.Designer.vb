<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSurprise
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
        fuzzSurprise = New cntrlFuzzySlider()
        lblMessage = New Label()
        buttonOk = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        SuspendLayout()
        ' 
        ' fuzzSurprise
        ' 
        fuzzSurprise.Location = New Point(12, 106)
        fuzzSurprise.Name = "fuzzSurprise"
        fuzzSurprise.Size = New Size(1119, 137)
        fuzzSurprise.TabIndex = 0
        fuzzSurprise.Value = 0.5R
        ' 
        ' lblMessage
        ' 
        lblMessage.Location = New Point(12, 18)
        lblMessage.Name = "lblMessage"
        lblMessage.Size = New Size(1119, 66)
        lblMessage.TabIndex = 16
        lblMessage.Text = "To what degree did the car’s behavior make sense to you when you pressed the gas?"
        lblMessage.TextAlign = ContentAlignment.TopCenter
        ' 
        ' buttonOk
        ' 
        buttonOk.Location = New Point(499, 249)
        buttonOk.Name = "buttonOk"
        buttonOk.Size = New Size(150, 46)
        buttonOk.TabIndex = 17
        buttonOk.Text = "Submit"
        buttonOk.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.FromArgb(CByte(128), CByte(128), CByte(255))
        Label1.Font = New Font("Segoe UI", 7.875F)
        Label1.Location = New Point(30, 106)
        Label1.Name = "Label1"
        Label1.Size = New Size(221, 37)
        Label1.TabIndex = 18
        Label1.Text = "Perfect Sense"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label2
        ' 
        Label2.BackColor = Color.FromArgb(CByte(128), CByte(192), CByte(192))
        Label2.Font = New Font("Segoe UI", 7.875F)
        Label2.Location = New Point(248, 106)
        Label2.Name = "Label2"
        Label2.Size = New Size(221, 37)
        Label2.TabIndex = 18
        Label2.Text = "Mostly Clear"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label3
        ' 
        Label3.BackColor = Color.FromArgb(CByte(128), CByte(255), CByte(128))
        Label3.Font = New Font("Segoe UI", 7.875F)
        Label3.Location = New Point(463, 106)
        Label3.Name = "Label3"
        Label3.Size = New Size(221, 37)
        Label3.TabIndex = 18
        Label3.Text = "Moderately Confusing"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label4
        ' 
        Label4.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(128))
        Label4.Font = New Font("Segoe UI", 7.875F)
        Label4.Location = New Point(679, 106)
        Label4.Name = "Label4"
        Label4.Size = New Size(221, 37)
        Label4.TabIndex = 18
        Label4.Text = "Highly Confusing"
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label5
        ' 
        Label5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(128))
        Label5.Font = New Font("Segoe UI", 7.875F)
        Label5.Location = New Point(896, 106)
        Label5.Name = "Label5"
        Label5.Size = New Size(221, 37)
        Label5.TabIndex = 18
        Label5.Text = "No Sense"
        Label5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label6
        ' 
        Label6.BackColor = SystemColors.ButtonFace
        Label6.Font = New Font("Segoe UI", 7.875F)
        Label6.Location = New Point(0, 206)
        Label6.Name = "Label6"
        Label6.Size = New Size(1153, 37)
        Label6.TabIndex = 18
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' frmSurprise
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1152, 338)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label6)
        Controls.Add(Label1)
        Controls.Add(buttonOk)
        Controls.Add(lblMessage)
        Controls.Add(fuzzSurprise)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmSurprise"
        ShowIcon = False
        ResumeLayout(False)
    End Sub

    Friend WithEvents fuzzSurprise As cntrlFuzzySlider
    Friend WithEvents lblMessage As Label
    Friend WithEvents buttonOk As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class
