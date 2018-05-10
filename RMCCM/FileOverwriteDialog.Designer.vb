<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileOverwriteDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FileOverwriteDialog))
        Me.btnYes = New System.Windows.Forms.Button()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.btnNoAll = New System.Windows.Forms.Button()
        Me.btnYesAll = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnYes
        '
        Me.btnYes.Location = New System.Drawing.Point(12, 64)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(75, 23)
        Me.btnYes.TabIndex = 0
        Me.btnYes.Text = "Yes"
        Me.btnYes.UseVisualStyleBackColor = True
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Location = New System.Drawing.Point(12, 9)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(61, 13)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "Msg is here"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnNo
        '
        Me.btnNo.Location = New System.Drawing.Point(93, 64)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(75, 23)
        Me.btnNo.TabIndex = 5
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'btnNoAll
        '
        Me.btnNoAll.Location = New System.Drawing.Point(255, 64)
        Me.btnNoAll.Name = "btnNoAll"
        Me.btnNoAll.Size = New System.Drawing.Size(75, 23)
        Me.btnNoAll.TabIndex = 6
        Me.btnNoAll.Text = "No (for all)"
        Me.btnNoAll.UseVisualStyleBackColor = True
        '
        'btnYesAll
        '
        Me.btnYesAll.Location = New System.Drawing.Point(174, 64)
        Me.btnYesAll.Name = "btnYesAll"
        Me.btnYesAll.Size = New System.Drawing.Size(75, 23)
        Me.btnYesAll.TabIndex = 7
        Me.btnYesAll.Text = "Yes (for all)"
        Me.btnYesAll.UseVisualStyleBackColor = True
        '
        'FileOverwriteDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 99)
        Me.Controls.Add(Me.btnYesAll)
        Me.Controls.Add(Me.btnNoAll)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.btnYes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FileOverwriteDialog"
        Me.Text = "File already exists"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnYes As System.Windows.Forms.Button
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents btnNo As System.Windows.Forms.Button
    Friend WithEvents btnNoAll As System.Windows.Forms.Button
    Friend WithEvents btnYesAll As System.Windows.Forms.Button
End Class
