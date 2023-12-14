'
' Created by SharpDevelop.
' User: Giuseppe.DiResta
' Date: 17/12/2016
' Time: 09:32
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'


Partial Class Form1
    Inherits System.Windows.Forms.Form

    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    Private Declare Function FindWindowA Lib "user32" (ByVal lpClassName As String, ByVal lpWindowName As String) As Long
    Private Declare Function ShowWindow Lib "user32" (ByVal hwnd As Long, ByVal nCmdShow As Long) As Long
    Private Const SW_HIDE = 0
    Private Const SW_SHOW = 5

    ''' <summary>
    ''' Designer variable used to keep track of non-visual components.
    ''' </summary>
    Private components As System.ComponentModel.IContainer


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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.timermessaggi = New System.Windows.Forms.Timer(Me.components)
        Me.timerurgente = New System.Windows.Forms.Timer(Me.components)
        Me.timeraggiorna = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LEggiUltimoMessaggioRicevutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LEggiUltimi5MessaggiRicevutiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LeggiUltimi5MessaggiRicevutiToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.timermenu = New System.Windows.Forms.Timer(Me.components)
        Me.Label10 = New viewmyip.shadow.ShadowLabel(Me.components)
        Me.Label9 = New viewmyip.shadow.ShadowLabel(Me.components)
        Me.Label8 = New viewmyip.shadow.ShadowLabel(Me.components)
        Me.Label7 = New viewmyip.shadow.ShadowLabel(Me.components)
        Me.Label5 = New viewmyip.shadow.ShadowLabel(Me.components)
        Me.Label6 = New viewmyip.shadow.ShadowLabel(Me.components)
        Me.Label4 = New viewmyip.shadow.ShadowLabel(Me.components)
        Me.Label3 = New viewmyip.shadow.ShadowLabel(Me.components)
        Me.label2 = New viewmyip.shadow.ShadowLabel(Me.components)
        Me.Label1 = New viewmyip.shadow.ShadowLabel(Me.components)
        Me.label11 = New viewmyip.shadow.ShadowLabel(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'timermessaggi
        '
        Me.timermessaggi.Interval = 1000
        '
        'timerurgente
        '
        Me.timerurgente.Interval = 180000
        '
        'timeraggiorna
        '
        Me.timeraggiorna.Interval = 1000
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LEggiUltimoMessaggioRicevutoToolStripMenuItem, Me.LEggiUltimi5MessaggiRicevutiToolStripMenuItem, Me.LeggiUltimi5MessaggiRicevutiToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(302, 76)
        '
        'LEggiUltimoMessaggioRicevutoToolStripMenuItem
        '
        Me.LEggiUltimoMessaggioRicevutoToolStripMenuItem.Name = "LEggiUltimoMessaggioRicevutoToolStripMenuItem"
        Me.LEggiUltimoMessaggioRicevutoToolStripMenuItem.Size = New System.Drawing.Size(301, 24)
        Me.LEggiUltimoMessaggioRicevutoToolStripMenuItem.Text = "Leggi Ultimo Messaggio Ricevuto"
        '
        'LEggiUltimi5MessaggiRicevutiToolStripMenuItem
        '
        Me.LEggiUltimi5MessaggiRicevutiToolStripMenuItem.Name = "LEggiUltimi5MessaggiRicevutiToolStripMenuItem"
        Me.LEggiUltimi5MessaggiRicevutiToolStripMenuItem.Size = New System.Drawing.Size(301, 24)
        Me.LEggiUltimi5MessaggiRicevutiToolStripMenuItem.Text = "Leggi ultimi 3 Messaggi Ricevuti"
        '
        'LeggiUltimi5MessaggiRicevutiToolStripMenuItem1
        '
        Me.LeggiUltimi5MessaggiRicevutiToolStripMenuItem1.Name = "LeggiUltimi5MessaggiRicevutiToolStripMenuItem1"
        Me.LeggiUltimi5MessaggiRicevutiToolStripMenuItem1.Size = New System.Drawing.Size(301, 24)
        Me.LeggiUltimi5MessaggiRicevutiToolStripMenuItem1.Text = "Leggi ultimi 5 Messaggi Ricevuti"
        '
        'timermenu
        '
        Me.timermenu.Interval = 5000
        '
        'Label10
        '
        Me.Label10.Angle = 0!
        Me.Label10.EndColor = System.Drawing.Color.Black
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(0, 186)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.ShadowColor = System.Drawing.Color.Gray
        Me.Label10.Size = New System.Drawing.Size(82, 23)
        Me.Label10.StartColor = System.Drawing.Color.Black
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Label1"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label10.XOffset = 1.0!
        Me.Label10.YOffset = 1.0!
        '
        'Label9
        '
        Me.Label9.Angle = 0!
        Me.Label9.EndColor = System.Drawing.Color.Black
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(0, 163)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.ShadowColor = System.Drawing.Color.Gray
        Me.Label9.Size = New System.Drawing.Size(82, 23)
        Me.Label9.StartColor = System.Drawing.Color.Black
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Label1"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label9.XOffset = 1.0!
        Me.Label9.YOffset = 1.0!
        '
        'Label8
        '
        Me.Label8.Angle = 0!
        Me.Label8.EndColor = System.Drawing.Color.Black
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(0, 140)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.ShadowColor = System.Drawing.Color.Gray
        Me.Label8.Size = New System.Drawing.Size(82, 23)
        Me.Label8.StartColor = System.Drawing.Color.Black
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Label1"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.XOffset = 1.0!
        Me.Label8.YOffset = 1.0!
        '
        'Label7
        '
        Me.Label7.Angle = 0!
        Me.Label7.EndColor = System.Drawing.Color.Black
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(0, 117)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.ShadowColor = System.Drawing.Color.Gray
        Me.Label7.Size = New System.Drawing.Size(82, 23)
        Me.Label7.StartColor = System.Drawing.Color.Black
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Label1"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label7.XOffset = 1.0!
        Me.Label7.YOffset = 1.0!
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Angle = 0!
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.EndColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(89, 2)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.ShadowColor = System.Drawing.Color.Gray
        Me.Label5.Size = New System.Drawing.Size(62, 23)
        Me.Label5.StartColor = System.Drawing.Color.White
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "MSG"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label5.Visible = False
        Me.Label5.XOffset = 1.0!
        Me.Label5.YOffset = 1.0!
        '
        'Label6
        '
        Me.Label6.Angle = 0!
        Me.Label6.EndColor = System.Drawing.Color.Black
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(0, 94)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.ShadowColor = System.Drawing.Color.Gray
        Me.Label6.Size = New System.Drawing.Size(82, 23)
        Me.Label6.StartColor = System.Drawing.Color.Black
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Label1"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.XOffset = 1.0!
        Me.Label6.YOffset = 1.0!
        '
        'Label4
        '
        Me.Label4.Angle = 0!
        Me.Label4.EndColor = System.Drawing.Color.Black
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(0, 71)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.ShadowColor = System.Drawing.Color.Gray
        Me.Label4.Size = New System.Drawing.Size(82, 23)
        Me.Label4.StartColor = System.Drawing.Color.Black
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Label1"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.XOffset = 1.0!
        Me.Label4.YOffset = 1.0!
        '
        'Label3
        '
        Me.Label3.Angle = 0!
        Me.Label3.EndColor = System.Drawing.Color.Black
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(0, 48)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.ShadowColor = System.Drawing.Color.Gray
        Me.Label3.Size = New System.Drawing.Size(82, 23)
        Me.Label3.StartColor = System.Drawing.Color.Black
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Label1"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.XOffset = 1.0!
        Me.Label3.YOffset = 1.0!
        '
        'label2
        '
        Me.label2.Angle = 0!
        Me.label2.EndColor = System.Drawing.Color.Black
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.White
        Me.label2.Location = New System.Drawing.Point(0, 25)
        Me.label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label2.Name = "label2"
        Me.label2.ShadowColor = System.Drawing.Color.Gray
        Me.label2.Size = New System.Drawing.Size(82, 23)
        Me.label2.StartColor = System.Drawing.Color.Black
        Me.label2.TabIndex = 9
        Me.label2.Text = "Label1"
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.label2.XOffset = 1.0!
        Me.label2.YOffset = 1.0!
        '
        'Label1
        '
        Me.Label1.Angle = 0!
        Me.Label1.EndColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 2)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.ShadowColor = System.Drawing.Color.Gray
        Me.Label1.Size = New System.Drawing.Size(82, 23)
        Me.Label1.StartColor = System.Drawing.Color.Black
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.XOffset = 1.0!
        Me.Label1.YOffset = 1.0!
        '
        'label11
        '
        Me.label11.Angle = 0!
        Me.label11.EndColor = System.Drawing.Color.Black
        Me.label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label11.ForeColor = System.Drawing.Color.White
        Me.label11.Location = New System.Drawing.Point(0, 209)
        Me.label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label11.Name = "label11"
        Me.label11.ShadowColor = System.Drawing.Color.Gray
        Me.label11.Size = New System.Drawing.Size(82, 23)
        Me.label11.StartColor = System.Drawing.Color.Black
        Me.label11.TabIndex = 21
        Me.label11.Text = "Label1"
        Me.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.label11.XOffset = 1.0!
        Me.label11.YOffset = 1.0!
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(155, 240)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.Black
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents timeraggiorna As System.Windows.Forms.Timer
    Public WithEvents timerurgente As System.Windows.Forms.Timer
    Private WithEvents timermessaggi As System.Windows.Forms.Timer
    Public Shared toolTip1 As System.Windows.Forms.ToolTip
    Public Shared button1 As System.Windows.Forms.Button







    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents LEggiUltimoMessaggioRicevutoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LEggiUltimi5MessaggiRicevutiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LeggiUltimi5MessaggiRicevutiToolStripMenuItem1 As ToolStripMenuItem

    Friend WithEvents Label1 As shadow.ShadowLabel
    Friend WithEvents label2 As shadow.ShadowLabel
    Friend WithEvents Label3 As shadow.ShadowLabel
    Friend WithEvents Label4 As shadow.ShadowLabel
    Friend WithEvents Label6 As shadow.ShadowLabel
    Friend WithEvents Label5 As shadow.ShadowLabel
    Friend WithEvents Label7 As shadow.ShadowLabel
    Friend WithEvents Label8 As shadow.ShadowLabel
    Friend WithEvents Label9 As shadow.ShadowLabel
    Friend WithEvents Label10 As shadow.ShadowLabel
    Friend WithEvents timermenu As Timer
    Friend WithEvents label11 As shadow.ShadowLabel
End Class
