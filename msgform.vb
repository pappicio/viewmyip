'
' Created by SharpDevelop.
' User: giuseppe.diresta
' Date: 31/12/2016
' Time: 09:57
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Partial Class msgform
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		 
		'
	End Sub
	
	Sub Label2Click(sender As Object, e As EventArgs)
		'''Me.Visible=false		
	End Sub




    Sub Button1Click(sender As Object, e As EventArgs) Handles button1.Click

        button1.Enabled = False
        timer = 0

        Me.Visible = False
        If button1.Text.Trim.ToLower <> "chiudi questo messaggio" Then
            If cls.eurgente = True Then
                Form1.timerurgente.Enabled = True
                cls.spostamessaggio()
                cls.mostramessaggi()
                Return
            End If
            If cls.quoting = False Then
                cls.spostamessaggio()
                cls.mostramessaggi()
            Else
                cls.spostamessaggio()
                cls.mostramessaggi()
            End If
        End If


        button1.Text = "LEGGA IL MESSAGGIO! (Il tasto sarà attivo tra: 30 s.)"

    End Sub

    Sub RichTextBox1TextChanged(sender As Object, e As EventArgs) Handles richTextBox1.TextChanged

        Dim w As String = richTextBox1.Text
        Dim ii As Integer = richTextBox1.SelectionStart

        richTextBox1.Text = ""
        Dim count() As String = Split(w, "<")
        If count.Length > 0 Then
            Dim c As Integer = 0
            For Each s As String In count
                If c / 2 <> Int(c / 2) Then
                    ' RichTextBoxEx1.SelectedText = Chr(34)
                    Dim i As Integer = s.IndexOf(">")
                    If i > 0 Then
                        c = c + 1
                        richTextBox1.SelectedText = ("<")
                        richTextBox1.InsertLink(Mid(s, 1, s.IndexOf(">")))
                        richTextBox1.SelectedText = Mid(s, s.IndexOf(">") + 1, s.Length)
                    Else
                        richTextBox1.SelectedText = ("<")
                        richTextBox1.InsertLink(s)
                    End If


                Else
                    richTextBox1.SelectedText = s
                End If
                c = c + 1

            Next
        End If
        richTextBox1.SelectionStart = ii

    End Sub

    Sub RichTextBox1LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles richTextBox1.LinkClicked
        Try
            System.Diagnostics.Process.Start(e.LinkText)
        Catch ex As Exception

        End Try
    End Sub

    Sub MsgformShown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim kj As Integer = 0
    End Sub

    Sub MsgformSystemColorsChanged(sender As Object, e As EventArgs) Handles MyBase.SystemColorsChanged

    End Sub

    Public Shared timer As Integer = 0
    Sub TimerbuttonTick(sender As Object, e As EventArgs) Handles timerbutton.Tick

        If timer = 30 Then
            timerbutton.Enabled = False
            timer = 0
            button1.Text = "HO LETTO IL MESSAGGIO!"
            button1.Enabled = True
            Application.DoEvents()
        Else
            Dim s As String = CStr(30 - timer)
            If s.Length = 1 Then
                s = "0" & s
            End If
            'LEGGA IL MESSAGGIO! (Il tasto sarà attivo tra: 30 s.)
            button1.Text = "LEGGA IL MESSAGGIO! (Il tasto sarà attivo tra: " & s & " s.)"
            Application.DoEvents()
        End If

        timer = timer + 1

    End Sub

    Private Sub msgform_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub button1_MouseClick(sender As Object, e As MouseEventArgs) Handles button1.MouseClick

    End Sub

    Private Sub msgform_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

    End Sub

    Private Sub label1_Click(sender As Object, e As EventArgs) Handles label1.Click

    End Sub
End Class
