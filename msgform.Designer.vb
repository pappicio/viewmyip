'
' Created by SharpDevelop.
' User: giuseppe.diresta
' Date: 31/12/2016
' Time: 09:57
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class msgform
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.label1 = New System.Windows.Forms.Label()
        Me.button1 = New System.Windows.Forms.Button()
        Me.titololabel = New System.Windows.Forms.Label()
        Me.timerbutton = New System.Windows.Forms.Timer(Me.components)
        Me.label2 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.richTextBox1 = New viewmyip.RichTextBoxEx()
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.BackColor = System.Drawing.Color.Maroon
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(0, 0)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(1053, 53)
        Me.label1.TabIndex = 0
        Me.label1.Text = "MESSAGGIO IMPORTANTE:"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'button1
        '
        Me.button1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.button1.Enabled = False
        Me.button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button1.Location = New System.Drawing.Point(188, 638)
        Me.button1.Margin = New System.Windows.Forms.Padding(4)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(678, 53)
        Me.button1.TabIndex = 3
        Me.button1.Text = "LEGGA IL MESSAGGIO! (Il tasto sarà attivo tra: 30 s.)"
        Me.button1.UseVisualStyleBackColor = False
        '
        'titololabel
        '
        Me.titololabel.BackColor = System.Drawing.SystemColors.Control
        Me.titololabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titololabel.ForeColor = System.Drawing.Color.Black
        Me.titololabel.Location = New System.Drawing.Point(8, 54)
        Me.titololabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.titololabel.Name = "titololabel"
        Me.titololabel.Size = New System.Drawing.Size(1037, 71)
        Me.titololabel.TabIndex = 4
        '
        'timerbutton
        '
        Me.timerbutton.Interval = 1000
        '
        'label2
        '
        Me.label2.BackColor = System.Drawing.Color.Maroon
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.White
        Me.label2.Location = New System.Drawing.Point(1049, 0)
        Me.label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(4, 695)
        Me.label2.TabIndex = 5
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label3
        '
        Me.label3.BackColor = System.Drawing.Color.Maroon
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.Color.White
        Me.label3.Location = New System.Drawing.Point(0, 2)
        Me.label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(4, 695)
        Me.label3.TabIndex = 6
        Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label4
        '
        Me.label4.BackColor = System.Drawing.Color.Maroon
        Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.Color.White
        Me.label4.Location = New System.Drawing.Point(1, 692)
        Me.label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(1055, 4)
        Me.label4.TabIndex = 7
        Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(862, 636)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(179, 56)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Developed by:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DI RESTA Giuseppe" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'richTextBox1
        '
        Me.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.richTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.richTextBox1.Location = New System.Drawing.Point(8, 129)
        Me.richTextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.ReadOnly = True
        Me.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.richTextBox1.Size = New System.Drawing.Size(1037, 501)
        Me.richTextBox1.TabIndex = 2
        Me.richTextBox1.Text = ""
        '
        'msgform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1053, 695)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.titololabel)
        Me.Controls.Add(Me.richTextBox1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "msgform"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "msgform"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents label4 As System.Windows.Forms.Label
    Public WithEvents label3 As System.Windows.Forms.Label
    Public WithEvents label2 As System.Windows.Forms.Label
    Public WithEvents timerbutton As System.Windows.Forms.Timer
    Public WithEvents titololabel As System.Windows.Forms.Label
    Public WithEvents richTextBox1 As viewmyip.RichTextBoxEx
    Public WithEvents label1 As System.Windows.Forms.Label
    Public WithEvents button1 As Button
    Friend WithEvents Label5 As Label
End Class
