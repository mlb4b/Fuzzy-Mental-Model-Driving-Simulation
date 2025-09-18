<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFuzzyInput
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
        lblMessage = New Label()
        buttonOk = New Button()
        fuzzDown1 = New cntrlFuzzySlider()
        fuzzUp3 = New cntrlFuzzySlider()
        fuzzUp2 = New cntrlFuzzySlider()
        fuzzUp1 = New cntrlFuzzySlider()
        lblDown1 = New Label()
        lblUp3 = New Label()
        lblUp2 = New Label()
        lblUp1 = New Label()
        lblDown2 = New Label()
        fuzzDown3 = New cntrlFuzzySlider()
        lblDown3 = New Label()
        Label1 = New Label()
        Label2 = New Label()
        fuzzDown2 = New cntrlFuzzySlider()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' lblMessage
        ' 
        lblMessage.Location = New Point(30, 25)
        lblMessage.Name = "lblMessage"
        lblMessage.Size = New Size(1584, 48)
        lblMessage.TabIndex = 15
        lblMessage.Text = "Use the sliders to indicate the extent that performing the given action on the car's transmission will be recognized as each of the possible actions."
        ' 
        ' buttonOk
        ' 
        buttonOk.Location = New Point(741, 1096)
        buttonOk.Name = "buttonOk"
        buttonOk.Size = New Size(150, 46)
        buttonOk.TabIndex = 14
        buttonOk.Text = "Submit"
        buttonOk.UseVisualStyleBackColor = True
        ' 
        ' fuzzDown1
        ' 
        fuzzDown1.Location = New Point(464, 624)
        fuzzDown1.Name = "fuzzDown1"
        fuzzDown1.Size = New Size(1119, 137)
        fuzzDown1.TabIndex = 10
        fuzzDown1.Value = 0R
        ' 
        ' fuzzUp3
        ' 
        fuzzUp3.Location = New Point(464, 464)
        fuzzUp3.Name = "fuzzUp3"
        fuzzUp3.Size = New Size(1119, 137)
        fuzzUp3.TabIndex = 11
        fuzzUp3.Value = 0R
        ' 
        ' fuzzUp2
        ' 
        fuzzUp2.Location = New Point(464, 305)
        fuzzUp2.Name = "fuzzUp2"
        fuzzUp2.Size = New Size(1119, 137)
        fuzzUp2.TabIndex = 12
        fuzzUp2.Value = 0R
        ' 
        ' fuzzUp1
        ' 
        fuzzUp1.Location = New Point(464, 148)
        fuzzUp1.Name = "fuzzUp1"
        fuzzUp1.Size = New Size(1119, 137)
        fuzzUp1.TabIndex = 13
        fuzzUp1.Value = 0R
        ' 
        ' lblDown1
        ' 
        lblDown1.AutoSize = True
        lblDown1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDown1.Location = New Point(241, 673)
        lblDown1.Name = "lblDown1"
        lblDown1.Size = New Size(126, 32)
        lblDown1.TabIndex = 6
        lblDown1.Text = "Down × 1"
        ' 
        ' lblUp3
        ' 
        lblUp3.AutoSize = True
        lblUp3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUp3.Location = New Point(241, 514)
        lblUp3.Name = "lblUp3"
        lblUp3.Size = New Size(91, 32)
        lblUp3.TabIndex = 7
        lblUp3.Text = "Up × 3"
        ' 
        ' lblUp2
        ' 
        lblUp2.AutoSize = True
        lblUp2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUp2.Location = New Point(241, 356)
        lblUp2.Name = "lblUp2"
        lblUp2.Size = New Size(91, 32)
        lblUp2.TabIndex = 8
        lblUp2.Text = "Up × 2"
        ' 
        ' lblUp1
        ' 
        lblUp1.AutoSize = True
        lblUp1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUp1.Location = New Point(241, 200)
        lblUp1.Name = "lblUp1"
        lblUp1.Size = New Size(91, 32)
        lblUp1.TabIndex = 9
        lblUp1.Text = "Up × 1"
        ' 
        ' lblDown2
        ' 
        lblDown2.AutoSize = True
        lblDown2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDown2.Location = New Point(241, 826)
        lblDown2.Name = "lblDown2"
        lblDown2.Size = New Size(126, 32)
        lblDown2.TabIndex = 16
        lblDown2.Text = "Down × 2"
        ' 
        ' fuzzDown3
        ' 
        fuzzDown3.Location = New Point(464, 953)
        fuzzDown3.Name = "fuzzDown3"
        fuzzDown3.Size = New Size(1119, 137)
        fuzzDown3.TabIndex = 19
        fuzzDown3.Value = 0R
        ' 
        ' lblDown3
        ' 
        lblDown3.AutoSize = True
        lblDown3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDown3.Location = New Point(241, 990)
        lblDown3.Name = "lblDown3"
        lblDown3.Size = New Size(126, 32)
        lblDown3.TabIndex = 18
        lblDown3.Text = "Down × 3"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(30, 200)
        Label1.Name = "Label1"
        Label1.Size = New Size(91, 32)
        Label1.TabIndex = 9
        Label1.Text = "Up × 1"
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(30, 109)
        Label2.Name = "Label2"
        Label2.Size = New Size(180, 76)
        Label2.TabIndex = 9
        Label2.Text = "If you perform the action:"
        ' 
        ' fuzzDown2
        ' 
        fuzzDown2.Location = New Point(464, 789)
        fuzzDown2.Name = "fuzzDown2"
        fuzzDown2.Size = New Size(1119, 137)
        fuzzDown2.TabIndex = 17
        fuzzDown2.Value = 0R
        ' 
        ' Label3
        ' 
        Label3.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(241, 109)
        Label3.Name = "Label3"
        Label3.Size = New Size(193, 76)
        Label3.TabIndex = 9
        Label3.Text = "It will be interpretted as:"
        ' 
        ' frmFuzzyInput
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1633, 1190)
        Controls.Add(fuzzDown3)
        Controls.Add(lblDown3)
        Controls.Add(fuzzDown2)
        Controls.Add(lblDown2)
        Controls.Add(lblMessage)
        Controls.Add(buttonOk)
        Controls.Add(fuzzDown1)
        Controls.Add(fuzzUp3)
        Controls.Add(fuzzUp2)
        Controls.Add(fuzzUp1)
        Controls.Add(lblDown1)
        Controls.Add(lblUp3)
        Controls.Add(lblUp2)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(lblUp1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmFuzzyInput"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblMessage As Label
    Friend WithEvents buttonOk As Button
    Friend WithEvents fuzzDown1 As cntrlFuzzySlider
    Friend WithEvents fuzzUp3 As cntrlFuzzySlider
    Friend WithEvents fuzzUp2 As cntrlFuzzySlider
    Friend WithEvents fuzzUp1 As cntrlFuzzySlider
    Friend WithEvents lblDown1 As Label
    Friend WithEvents lblUp3 As Label
    Friend WithEvents lblUp2 As Label
    Friend WithEvents lblUp1 As Label
    Friend WithEvents lblDown2 As Label
    Friend WithEvents fuzzDown3 As cntrlFuzzySlider
    Friend WithEvents lblDown3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents fuzzDown2 As cntrlFuzzySlider
    Friend WithEvents Label3 As Label
End Class
