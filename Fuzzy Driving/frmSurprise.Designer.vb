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
        lblMessage.Text = "Use the sliders to indicate the deree to which you were surprised by the behavior of the car when you pressed the gas?"
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
        ' frmSurprise
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1152, 311)
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
End Class
