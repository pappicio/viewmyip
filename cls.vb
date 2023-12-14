'
' Creato da SharpDevelop.
' Utente: io
' Data: 05/01/2017
' Ora: 10:59
' 
' Per modificare questo modello usa Strumenti | Opzioni | Codice | Modifica Intestazioni Standard
'
Imports System.Linq
Imports System.Net
Imports System.Net.Sockets
Imports System.Security
Imports System.Security.Principal


Public Class cls
    ''' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''' 
    ''' Dim listamessaggi As New List (Of String)

    Public Shared messaggiutenti As String = "" '"\\10.194.60.21\Uffici Compartimentali\messaggi\messaggiutenti"
    Public Shared rispostautenti As String = "" '"\\10.194.60.21\Uffici Compartimentali\messaggi\rispostautenti"
    Public Shared pingip As String = "" '"10.194.60.21"
    Public Shared errori As String = "" '"\\10.194.60.21\Uffici Compartimentali\messaggi\rispostautenti\errori"

    Public Shared messaggio As Integer = 0
    Public Shared urgente As Integer = 0
    Public Shared eurgente As Boolean = False

    Public Shared salvamessaggio As String = ""

    Public Shared location As String = System.Reflection.Assembly.GetExecutingAssembly().Location
    Public Shared appPath As String = IO.Path.GetDirectoryName(location)       ' C:\Some\Directory
    Public Shared appNamenoext As String = IO.Path.GetFileNameWithoutExtension(location)            ' MyLibrary.DLL
    Public Shared appName As String = IO.Path.GetFileName(location)            ' MyLibrary.DLL

    Public Shared listamessaggi As New List(Of messaggio)
    Public Shared listaquotemess As New List(Of String)
    Public Shared listaurgenti As New List(Of messaggio)

    Public Shared user As String = ""
    Public Shared pc As String = ""
    Public Shared ip As String = ""

    Public Shared usertemp As String = ""
    Public Shared macchiantemp As String = ""



    Public Shared Sub verificamessaggiurgenti()
        urgente = 0
        eurgente = False

        Dim da As String = cls.messaggiutenti & "\" & usertemp
        Dim a As String = cls.rispostautenti & "\" & usertemp
        Dim errori As String = cls.rispostautenti & "\errori"

        listaurgenti.Clear()

        Dim xml As New xml

        If usertemp = "" Or usertemp.Length < 2 Then
            Exit Sub
        End If

        'messaggi utente, gruppo, tutti, macchina_e_utente
        Try
            Dim di As New IO.DirectoryInfo(IO.Path.Combine(messaggiutenti, usertemp))
            Dim diar1 As IO.FileInfo() = di.GetFiles
            Dim dra As IO.FileInfo

            For Each dra In diar1
                Dim f As String = dra.FullName.ToLower
                Dim ff As String = dra.Name.ToLower
                If ff.EndsWith("_urgente.xml") Then
                    'se nn esiste messaggio in risposta utente, e non esiste in errore utente....
                    If (IO.File.Exists(IO.Path.Combine(a, ff)) = True) Or (IO.File.Exists(IO.Path.Combine(errori, usertemp & "_errore_cancellazione_" & ff)) = True) Then
                    Else
                        listaurgenti.Add(xml.read(f))
                    End If
                End If
            Next

        Catch ex As Exception
        End Try

        'solo macchina
        Try
            Dim di As New IO.DirectoryInfo(IO.Path.Combine(messaggiutenti, macchiantemp))
            Dim diar1 As IO.FileInfo() = di.GetFiles
            Dim dra As IO.FileInfo
            For Each dra In diar1
                Dim f As String = dra.FullName.ToLower
                Dim ff As String = dra.Name.ToLower
                If ff.EndsWith("_urgente.xml") Then
                    'se nn esiste messaggio in risposta utente, e non esiste in errore utente....
                    If (IO.File.Exists(IO.Path.Combine(a, ff)) = True) Or (IO.File.Exists(IO.Path.Combine(errori, usertemp & "_errore_cancellazione_" & ff)) = True) Then
                    Else
                        listaurgenti.Add(xml.read(f))
                    End If
                End If
            Next

        Catch ex As Exception
        End Try

        If listaurgenti.Count > 0 Then
            eurgente = True
            urgente = 0
        End If


    End Sub

    Public Shared Sub verificamessaggiutenti()

        usertemp = cls.user.ToLower.Trim
        macchiantemp = cls.pc.ToLower.Trim



        Dim da As String = cls.messaggiutenti & "\" & usertemp
        Dim a As String = cls.rispostautenti & "\" & usertemp
        Dim errori As String = cls.rispostautenti & "\errori"
        listamessaggi.Clear()



        Dim xml As New xml



        If usertemp = "" Or usertemp.Length < 2 Then
            Exit Sub
        End If

        'messaggi utente, gruppo, tutti, macchina_e_utente
        Try
            Dim di As New IO.DirectoryInfo(IO.Path.Combine(messaggiutenti, usertemp))
            Dim diar1 As IO.FileInfo() = di.GetFiles
            Dim dra As IO.FileInfo

            For Each dra In diar1
                Dim f As String = dra.FullName.ToLower
                Dim ff As String = dra.Name.ToLower
                If ff.EndsWith(".xml") And (Not ff.EndsWith("_urgente.xml")) Then
                    'se nn esiste messaggio in risposta utente, e non esiste in errore utente....
                    If (IO.File.Exists(IO.Path.Combine(a, ff)) = True) Or (IO.File.Exists(IO.Path.Combine(errori, usertemp & "_errore_cancellazione_" & ff)) = True) Then
                    Else
                        listamessaggi.Add(xml.read(f))
                    End If
                End If
            Next

        Catch ex As Exception

        End Try

        'solo macchina
        Try
            Dim di As New IO.DirectoryInfo(IO.Path.Combine(messaggiutenti, macchiantemp))
            Dim diar1 As IO.FileInfo() = di.GetFiles
            Dim dra As IO.FileInfo
            For Each dra In diar1
                Dim f As String = dra.FullName.ToLower
                Dim ff As String = dra.Name.ToLower
                If ff.EndsWith(".xml") And (Not ff.EndsWith("_urgente.xml")) Then
                    'se nn esiste messaggio in risposta utente, e non esiste in errore utente....
                    If (IO.File.Exists(IO.Path.Combine(a, ff)) = True) Or (IO.File.Exists(IO.Path.Combine(errori, usertemp & "_errore_cancellazione_" & ff)) = True) Then
                    Else
                        listamessaggi.Add(xml.read(f))
                    End If
                End If
            Next

        Catch ex As Exception

        End Try



    End Sub

    Public Shared Function TestDecoding(cipherText As String, password As String) As String



        ' DecryptData throws if the wrong password is used.
        Try
            Dim plainText As String = Simple3Des.DecryptData(cipherText, password)
            Return plainText
            ' MsgBox("The plain text is: " & plainText)
        Catch ex As System.Security.Cryptography.CryptographicException
            ' MsgBox("The data could not be decrypted with the password.")
            Return "wrong password"
        End Try
    End Function

    Public Shared Function TestEncoding(plainText As String, password As String) As String
        Dim cipherText As String = Simple3Des.EncryptData(plainText, password)
        Return cipherText
    End Function
    ''' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



    Public Shared Sub spostamessaggio()
        Dim usertemp As String = cls.user.ToLower
        Dim mess As String = cls.salvamessaggio
        Dim da As String = cls.messaggiutenti & "\" & usertemp
        Dim a As String = cls.rispostautenti & "\" & usertemp
        Dim errori As String = cls.rispostautenti & "\errori"
        Try
            IO.Directory.CreateDirectory(IO.Path.Combine(cls.rispostautenti, usertemp))
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        Try
            IO.Directory.CreateDirectory(errori)
        Catch ex As Exception
            '''  Debug.Print(ex.Message)
        End Try

        Dim x As Integer = 0
        Try
            If mess <> "" Then
                IO.File.Delete(IO.Path.Combine(da, mess))
            End If

        Catch ex As Exception
            Try
                My.Computer.FileSystem.WriteAllText(IO.Path.Combine(errori, usertemp & "_errore_cancellazione_" & mess), "", False)
            Catch ex1 As Exception

            End Try
        End Try



        'cripta e scrive messaggio in ricevuta.....
        Dim s As String = cls.TestEncoding(msgform.richTextBox1.Text, usertemp)
        Dim ss As String = "#####TITLE#####" & msgform.titololabel.Text & "#####TITLE#####" & vbCr
        Dim time As String = DateTime.Now.Ticks.ToString
        s = ss & msgform.richTextBox1.Text &
            vbCr & "***********" &
            vbCr & time &
            vbCr & "***********" &
            vbCr & s


        Try
            My.Computer.FileSystem.WriteAllText(IO.Path.Combine(a, mess), s, False)
        Catch ex As Exception
            Try
                My.Computer.FileSystem.WriteAllText(IO.Path.Combine(errori, usertemp & "_errore_scrittura_" & mess), "", False)
            Catch ex1 As Exception

            End Try

        End Try





    End Sub



    Public Shared Sub calcolatutto()
        AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal)
        Dim myID As WindowsIdentity = WindowsIdentity.GetCurrent()

        Try
            If TypeOf My.User.CurrentPrincipal Is System.Security.Principal.WindowsPrincipal Then
                Dim p() As String = Split(My.User.Name, "\")
                pc = p(0)
                user = p(1)
                user = user.ToLower
            End If
        Catch e As Exception
            user = "N\A"
            pc = "N\A"
        End Try

        Try
            pc = System.Net.Dns.GetHostName
            ip = GetIPv4Address()
        Catch e As Exception
            ip = "N\A"
        End Try


    End Sub

    Public Shared Function GetIPv4Address() As String

        Dim addressList As IPAddress() = Dns.GetHostEntry(Dns.GetHostName()).AddressList
        Dim s As String = ""
        If pingip.Length > 3 Then
            s = Mid(pingip, 1, pingip.IndexOf(".")).Trim & "."
        End If
        For num As Integer = 0 To addressList.Length - 1
            Dim pAddress As IPAddress = addressList(num)
            If (pAddress.AddressFamily = AddressFamily.InterNetwork) Then
                If pAddress.ToString().Trim.StartsWith(s) Then
                    Return pAddress.ToString()
                End If
            End If
        Next
        Return ""
    End Function
    Public Shared quota As Integer = 0

    Public Shared quoting As Boolean = False

    Public Shared Sub mostramessaggi()
        msgform.Close()
        msgform.Dispose()

        Form1.timerurgente.Enabled = False

        cls.salvamessaggio = ""

        If eurgente = True Then
            GoTo fallo2
        End If


        listaquotemess.Clear()
        GoTo fallo

        If listaquotemess.Count > 0 And quota < listaquotemess.Count Then
            quoting = True
            For x As Integer = 0 To 500
                System.Threading.Thread.Sleep(3)
                Application.DoEvents()
            Next



            Try
                Dim s As String = listaquotemess(quota)
                Dim sx() As String = Split(s, ";")

                cls.salvamessaggio = sx(0)

                msgform.titololabel.Text = sx(1)


                msgform.richTextBox1.SelectedText = sx(2)

                msgform.label1.Text = "ALLERT NR.:" & (quota + 1) & " DI " & listaquotemess.Count & " - AGLI AMMINISTRATORI:"

                msgform.timer = 0
                msgform.Visible = True
                msgform.TopMost = True
                msgform.timerbutton.Enabled = True

            Catch ex As Exception
            End Try

            quota = quota + 1
            Return
        Else
            quota = 0
            quoting = False
            msgform.Visible = False
            Form1.timerurgente.Enabled = True
        End If


fallo:

        Form1.timerurgente.Enabled = False
        If cls.messaggio > cls.listamessaggi.Count - 1 Then
            msgform.Visible = False
            Form1.timerurgente.Enabled = True
            Return
        End If

        For x As Integer = 0 To 500
            System.Threading.Thread.Sleep(3)
            Application.DoEvents()
        Next
        msgform.richTextBox1.Text = ""

        Dim m As messaggio = cls.listamessaggi(cls.messaggio)
        msgform.titololabel.Text = m.titolo


        msgform.richTextBox1.SelectedText = m.corpo

        msgform.label1.Text = "MESSAGGIO NR.: " & cls.messaggio + 1 & " DI " & cls.listamessaggi.Count

        cls.salvamessaggio = m.file.nomefile


        If m.titolo <> "" Or m.corpo <> "" Then

            msgform.timer = 0
            msgform.Visible = True
            msgform.TopMost = True
            msgform.timerbutton.Enabled = True
        Else
            Try
                cls.eseguiscript(cls.listamessaggi(cls.messaggio))
            Catch ex As Exception

            End Try

        End If

        cls.messaggio = cls.messaggio + 1
        Return


fallo2:


        If cls.urgente > cls.listaurgenti.Count - 1 Then
            Form1.timerurgente.Enabled = True
            msgform.Visible = False
            cls.eurgente = False
            cls.urgente = 0
            Return
        End If

        For x As Integer = 0 To 500
            System.Threading.Thread.Sleep(3)
            Application.DoEvents()
        Next


        msgform.richTextBox1.Text = ""

        Dim mx As messaggio = cls.listaurgenti(cls.urgente)
        msgform.titololabel.Text = mx.titolo

        msgform.richTextBox1.SelectedText = mx.corpo

        msgform.label1.Text = "MESSAGGIO URGENTE NR.: " & cls.urgente + 1 & " DI " & cls.listaurgenti.Count

        cls.salvamessaggio = mx.file.nomefile


        If mx.titolo <> "" Or mx.corpo <> "" Then
            Form1.timerurgente.Enabled = False

            msgform.timer = 0
            msgform.timerbutton.Enabled = True
            msgform.Visible = True
            msgform.TopMost = True
        Else
            Try
                cls.eseguiscript(cls.listaurgenti(cls.messaggio))
            Catch ex As Exception

            End Try

        End If

        cls.urgente = cls.urgente + 1

    End Sub

    Public Shared Sub leggiultimi(i As Integer)
        Dim utente As String = Environment.UserName
        If utente = "" Then
            Return
        End If


        If Form1.GetPingMs(cls.pingip) = -1 Then
            MsgBox("ci sono problemi di rete...")
            Return
        End If
        Try
        Dim x As New xml
        Dim u As New messaggio

            Dim di As New IO.DirectoryInfo(rispostautenti & "\" & utente)
            Dim diar1 As IO.FileInfo() = di.GetFiles().OrderByDescending(Function(p) p.LastWriteTime).ToArray


        Dim dra As IO.FileInfo

            Dim c As Integer = 0
            For Each dra In diar1
            c = c + 1
                If c > i Then

                    Exit Sub
                End If
                If dra.Name.ToLower.EndsWith(".xml") Then

                    msgform.Close()
                    msgform.Dispose()
                    Dim titolo As String = ""
                    Dim m As New msgform
                    If dra.Name.ToLower.EndsWith("urgente.xml") Then
                        m.label1.Text = "MESSAGGIO URGENTE"
                    Else
                        m.label1.Text = "MESSAGGIO"
                    End If
                    Try

                        Dim s() As String = IO.File.ReadAllLines(dra.FullName)
                        For xx As Integer = 0 To s.Length - 1
                            If s(xx).StartsWith("***********") Then
                                Exit For
                            End If
                            If s(xx).StartsWith("#####TITLE#####") Then
                                titolo = s(xx).Replace("TITLE", "").Replace("##########", "").Trim
                                Continue For
                            End If
                            m.richTextBox1.AppendText(s(xx) & vbCr)
                        Next
                        m.titololabel.Text = titolo.Trim
                        m.button1.Enabled = True
                        m.button1.Text = "Chiudi Questo Messaggio"
                        m.TopMost = True
                        m.ShowDialog(Form1)

                    Catch ex As Exception

                    End Try

                    m.Close()
                End If
            Next


        Catch ex As Exception

        End Try

    End Sub

    Public Shared Sub eseguiscript(m As messaggio)
        Dim file As String = "c:\users\script." & m.script.tipologia.ToLower

        Select Case m.script.tipologia.ToLower

            Case "cmd", "vbs"

                Dim write As New IO.StreamWriter(file, False)
                For x As Integer = 0 To m.script.listato.Count - 1
                    write.WriteLine(m.script.listato(x))
                Next
                write.Close()
                write.Flush()
                Shell(file, AppWinStyle.Hide, False)

            Case "exe"
                System.Diagnostics.Process.Start(m.script.comando, m.script.opzioni)

            Case "open"
                System.Diagnostics.Process.Start(m.script.comando)
        End Select

        spostamessaggio()
        cls.mostramessaggi()
    End Sub
End Class
