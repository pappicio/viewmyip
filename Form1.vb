' 


Imports System.IO
Imports System.Linq
Imports System.Management
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Security.Principal
Imports System.Threading
Imports System.Windows.Input
Imports Microsoft.Win32

Partial Public Class Form1

    Private Const DESKTOPVERTRES As Integer = &H75
    Private Const DESKTOPHORZRES As Integer = &H76
    <Runtime.InteropServices.DllImport("gdi32.dll")> Private Shared Function GetDeviceCaps(ByVal hdc As IntPtr, ByVal nIndex As Integer) As Integer
    End Function




    Private Declare Function GetDiskFreeSpaceEx Lib "kernel32" Alias "GetDiskFreeSpaceExA" _
        (ByVal lpDirectoryName As String, ByRef lpFreeBytesAvailableToMe As Long,
        ByRef lpTotalNumberOfBytes As Long, ByRef lpTotalNumberOfFreeBytes As Long) As Integer



    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Shared Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr
    End Function


    <System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint:="SendMessageA")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As String) As IntPtr
    End Function


    <DllImport("user32.dll", EntryPoint:="SetWindowLong")>
    Private Shared Function SetWindowLongxxx(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.None, ExactSpelling:=False)>
    Private Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As IntPtr) As Integer
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.None, ExactSpelling:=False)>
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInteger) As Boolean
    End Function


    <DllImport("user32.dll", CharSet:=CharSet.None, ExactSpelling:=False)>
    Private Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.None, ExactSpelling:=False)>
    Private Shared Function FindWindowEx(ByVal parentHandle As IntPtr, ByVal childAfter As IntPtr, ByVal className As String, ByVal windowTitle As String) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.None, ExactSpelling:=False, SetLastError:=True)>
    Private Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
    End Function


    Public Declare Function EnumWindows Lib "user32" (lpEnumFunc As EnumWindowsProc, lParam As IntPtr) As Boolean

    Public Delegate Function EnumMonitorProc(hMonitor As IntPtr, hdcMonitor As IntPtr, ByRef rcMonitor As RECT, data As IntPtr) As Boolean

    Public Delegate Function EnumWindowsProc(hwnd As IntPtr, lParam As IntPtr) As Boolean



    Public Structure RECT

        Public ReadOnly Property Width As Integer
            Get
                Return Me.Right - Me.Left
            End Get
        End Property

        Public ReadOnly Property Height As Integer
            Get
                Return Me.Bottom - Me.Top
            End Get
        End Property


        Public Left As Integer


        Public Top As Integer


        Public Right As Integer


        Public Bottom As Integer
    End Structure

    Private HWND_BOTTOM As IntPtr
    Const WS_EX_APPWINDOW = &H40000
    Private loc As String
    Const GWL_EXSTYLE = (-20)

    Public Function lastreboot() As Date
        Dim EventoLogApp As New System.Diagnostics.EventLog("System")
        Dim Ora As Date
        Try
            For i = EventoLogApp.Entries.Count - 1 To 1 Step -1

                If EventoLogApp.Entries(i).InstanceId.ToString = "1" Then
                    Ora = EventoLogApp.Entries(i).TimeGenerated
                    Exit For
                End If
            Next

        Catch ex As Exception
            Ora = DateTime.Now
        End Try

        Return Ora
    End Function

    Function caricaorario() As DateTime
        Dim d As DateTime = DateTime.Now
        If IO.File.Exists(IO.Path.Combine(Application.StartupPath, "accesoda")) = False Then
            Return (lastreboot())
        End If
        Try
            Dim orario As String = IO.Path.Combine(Application.StartupPath, "accesoda")
            If IO.File.Exists(orario) = True Then
                Using reader As New IO.StreamReader(orario)
                    d = reader.ReadLine()
                    reader.Close()
                    reader.Dispose()
                End Using
            End If
        Catch ex As Exception

        End Try

        Return d

    End Function

    Dim IsAdministrator As Boolean = False

    Function CreateShortCut() As Boolean

        Dim TargetName As String = Application.ProductName
        Dim ShortCutPath As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup)
        Dim myshortcutpath As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
        Dim oShell As Object
        Dim oLink As Object

        If IsAdministrator Then
            Try
                oShell = CreateObject("WScript.Shell")
                oLink = oShell.CreateShortcut(ShortCutPath & "\" & TargetName & ".lnk")

                oLink.TargetPath = Application.ExecutablePath
                oLink.WindowStyle = 1
                oLink.Save()

                MsgBox("Eseguito con diritti AMMINISTRATORE, Link ad esecuzione autmatica allusers creata!" & vbCr & " ora mi chiudo, rieseguimi con diritti utente!")

                End
            Catch ex As Exception
                MsgBox("ERRORE nell' esecuzione con diritti AMMINISTRATORE, ora mi chiudo, Riprovare!!!")
                End
                Return False
            End Try
        Else
            If IO.File.Exists(ShortCutPath) = False Then
                If usershortcut = True Then
                    Try
                        oShell = CreateObject("WScript.Shell")
                        oLink = oShell.CreateShortcut(myshortcutpath & "\" & TargetName & ".lnk")

                        oLink.TargetPath = Application.ExecutablePath
                        oLink.WindowStyle = 1
                        oLink.Save()
                    Catch ex As Exception
                        Return False
                    End Try
                Else
                    Try
                        IO.File.Delete(myshortcutpath)
                    Catch ex As Exception

                    End Try
                End If
            End If
        End If

        If creaini Then
            creaini = False
            End
        End If

        Return True


    End Function


    Private Const GWL_HWNDPARENT As Integer = (-8)

    Dim creaini As Boolean = False

    Sub creacfg()
        Dim writer As New StreamWriter(Application.StartupPath & "\viewmyip.cfg")
        writer.Write(My.Resources.viewmyip)
        writer.Close()
        writer.Dispose()
        ''' System.IO.File.WriteAllBytes(Application.StartupPath & "\viewmyip.cfg", My.Resources.viewmyip)

        MsgBox("ho provveduto a creare il file di configurazione 'viewmyip.cfg'." & vbCr &
               "ora bisogna configurarlo!" & vbCr & vbCr &
               "SOPRATTUTTO indicare IP del default gateway" & vbCr & "Nel parametro: [iptoping]" & vbCr & vbCr &
               "arpo 'viewmyip.cfg' per le dovute modifiche e esco...")
        Shell("notepad.exe " & Application.StartupPath & "\viewmyip.cfg", AppWinStyle.MaximizedFocus)
        creaini = True
    End Sub

    Dim scalex, scaley As Single
    Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            IO.File.Delete(Application.StartupPath & "\accesoda")
        Catch ex As Exception

        End Try

        Try
            IO.File.Delete(Application.StartupPath & "\viewmyip.ini")
        Catch ex As Exception

        End Try


        Dim mut As System.Threading.Mutex = New System.Threading.Mutex(False, Application.ProductName)
        Dim running As Boolean = Not mut.WaitOne(0, False)
        If running Then
            Application.ExitThread()
            Return
        End If

        Using g As Graphics = Graphics.FromHwnd(IntPtr.Zero)
            Dim hdc As IntPtr = g.GetHdc
            Dim TrueScreenSize As New Size(GetDeviceCaps(hdc, DESKTOPHORZRES), GetDeviceCaps(hdc, DESKTOPVERTRES))
            Dim sclX As Single = CSng(Math.Round((TrueScreenSize.Width / Screen.PrimaryScreen.Bounds.Width), 2))
            Dim sclY As Single = CSng(Math.Round((TrueScreenSize.Height / Screen.PrimaryScreen.Bounds.Height), 2))
            g.ReleaseHdc(hdc)

            'show the true screen size
            'Label1.Text = "Screen Width:  " & TrueScreenSize.Width.ToString & vbLf &
            '              "Screen Height: " & TrueScreenSize.Height.ToString & vbLf & vbLf &
            '              "Scale X: " & sclX.ToString & vbLf &
            '              "Scale Y: " & sclY.ToString

            scalex = sclX
            scaley = sclY

        End Using


        If IO.File.Exists(Application.StartupPath & "\viewmyip.cfg") = False Then
            creacfg()
        Else
            Dim streamReader As System.IO.StreamReader = New System.IO.StreamReader(String.Concat(Application.StartupPath, "\viewmyip.cfg"))


            Dim ce As Boolean = False
            While streamReader.Peek() <> -1
                Dim str As String = streamReader.ReadLine().ToLower.Trim()
                If (str.StartsWith("'")) Then
                    Continue While
                End If
                If (str.Contains("[label11color]")) Then
                    ce = True
                    Exit While
                End If
            End While
            streamReader.Close()
            streamReader.Dispose()

            If ce = False Then
                creacfg()
            End If
        End If

        Me.Enabled = False


        IsAdministrator = New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)
        Try
            IO.File.Delete(Application.StartupPath & "\giainesecuzione")
        Catch ex As Exception

        End Try


        Me.Visible = False
        Me.Left = -10000
        Me.Top = -10000

        InitializeComponent()


        cls.pingip = ""
        cls.user = ""
        cls.pc = ""
        cls.ip = ""

        Me.aspetta = 0

        caricaconfig()

        AddHandler NetworkChange.NetworkAvailabilityChanged, AddressOf OnNetWorkChanged_Event
        AddHandler NetworkChange.NetworkAddressChanged, AddressOf OnNetworkAddrChanged_Event

        If folder <> "" Then
            Try
                IO.Directory.CreateDirectory(cls.messaggiutenti)
            Catch ex As Exception
                Debug.Print("error")
            End Try
            Try
                IO.Directory.CreateDirectory(cls.rispostautenti)
            Catch ex As Exception
                Debug.Print("error")
            End Try

            Try
                IO.Directory.CreateDirectory(cls.errori)
            Catch ex As Exception
                '''Debug.Print("error")
            End Try
        End If


        Try
            If IO.File.Exists("c: \temp\necessitariavvio") Then
                IO.File.Delete("c:\temp\necessitariavvio")
            End If
        Catch ex As Exception

        End Try


        riavvio = False


        Label1.Text = ""
        label2.Text = ""
        Label3.Text = ""

        Try
            IO.Directory.CreateDirectory("c:\temp")
        Catch ex As Exception

        End Try

        cls.calcolatutto()


        loadnic()


        timermessaggi.Enabled = True

        CreateShortCut()

        setwindowpos()




        timeraggiorna.Enabled = True
    End Sub


    Private Sub OnNetworkAddrChanged_Event(ByVal sender As Object, ByVal e As EventArgs)
        loadnic()
    End Sub
    Private Sub OnNetWorkChanged_Event(ByVal sender As Object, ByVal e As NetworkInformation.NetworkAvailabilityEventArgs) ' Handles Me.NetChangedHandler
        loadnic()
    End Sub

    Dim Thread As Threading.Thread = Nothing


    Public Function CheckNet() As Boolean
        Dim num As Integer
        Return InternetGetConnectedState(num, 0)
    End Function
    Private Declare Function InternetGetConnectedState Lib "wininet.dll" (ByRef lpdwFlags As Int32,
ByVal dwReserved As Int32) As Boolean

    Dim LocalIPAddress As String
    Dim bandwidth As String = ""



    Public Function GetLocalIPAddress() As String
        Dim addressList As IPAddress() = Dns.GetHostEntry(Dns.GetHostName()).AddressList
        Dim num As Integer = 0
        Do
            Dim pAddress As IPAddress = addressList(num)
            If (pAddress.AddressFamily = AddressFamily.InterNetwork) Then
                Dim a() As String = Split(cls.pingip, ".")
                Dim b() As String = Split(pAddress.ToString(), ".")
                If a(0) = b(0) And pAddress.ToString() = cls.GetIPv4Address Then
                    Return pAddress.ToString()
                End If

            End If
            num = num + 1
        Loop While num < CInt(addressList.Length)
        Return ""
        Throw New Exception("no ipv4")

    End Function
    Sub setwindowpos()

        If allwayson = True Then
            HWND_BOTTOM = New IntPtr(1)

            Dim sopraleicone As Boolean = True
            Dim Handle = MyBase.Handle

            'SetWindowLong(Handle, GWL_EXSTYLE, CType(GetWindowLong(Handle, GWL_EXSTYLE), IntPtr))
            'SetWindowPos(Handle, New IntPtr(CLng(HWND_BOTTOM)), 0, 0, 0, 0, SWP_NOACTIVATE)
            SetWindowLong(Handle, -20, GetWindowLong(Handle, -20) Or 134217728)
            SetWindowPos(Handle, New IntPtr(1), 0, 0, 0, 0, 19UI)

            Dim progmanHandle = Form1.FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Progman", Nothing)
            Dim workerWHandle = IntPtr.Zero

            If sopraleicone Then
                workerWHandle = progmanHandle
            Else
                EnumWindows(New EnumWindowsProc(Function(topHandle, topParamHandle)
                                                    Dim shellHandle As IntPtr = FindWindowEx(topHandle, IntPtr.Zero, "SHELLDLL_DefView", Nothing)

                                                    If shellHandle <> IntPtr.Zero Then
                                                        workerWHandle = FindWindowEx(IntPtr.Zero, topHandle, "WorkerW", Nothing)
                                                    End If

                                                    Return True
                                                End Function), IntPtr.Zero)
                workerWHandle = If(workerWHandle = IntPtr.Zero, progmanHandle, workerWHandle)
            End If

            SetParent(Handle, workerWHandle)


            If (Environment.OSVersion.Version.Major >= 6) Then
                SendMessage(FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Progman", Nothing), 1324, 13, 0)
                SendMessage(FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Progman", Nothing), 1234, 13, 1)
            End If

            SetWindowLong(MyBase.Handle, GWL_EXSTYLE, CType((GetWindowLong(Handle, GWL_EXSTYLE) And Not WS_EX_APPWINDOW), IntPtr))
            SetWindowLong(MyBase.Handle, GWL_EXSTYLE, CType((GetWindowLong(Handle, GWL_EXSTYLE) Or WS_EX_APPWINDOW), IntPtr))

        End If

    End Sub






    Function GetPingMs(ip As String) As String

        Dim ping As New System.Net.NetworkInformation.Ping
        Try
            Dim Result As System.Net.NetworkInformation.PingReply = ping.Send(ip, 1000)
            If Result.Status = System.Net.NetworkInformation.IPStatus.Success Then
                Return Result.RoundtripTime.ToString
            Else
                Return "-1"
            End If
        Catch ex As Exception
            Return "-1"
        End Try
    End Function


    Const SWP_NOSIZE As UInt32 = &H1
    Const SWP_NOMOVE As UInt32 = &H2
    Const SWP_NOACTIVATE As UInt32 = &H10

    Private Function getpcname() As String
        Dim ComputerName As String
        ComputerName = System.Net.Dns.GetHostName
        Return ComputerName
    End Function

    Dim contarefresh As Integer = 0

    Private Sub timeraggiorna_Tick(sender As Object, e As EventArgs) Handles timeraggiorna.Tick

        If ContextMenuStrip1.Visible = False Then
            contamenu = 0
        End If


        Dim size As Rectangle = Screen.PrimaryScreen.Bounds
        If IO.File.GetLastWriteTime(Application.StartupPath & "\viewmyip.cfg") <> lastedit Or sizeold <> size Then
            Me.Top = -10000
            Me.Left = -10000
            date1 = caricaorario()
            caricaconfig()
            setwindowpos()
            contarefresh = 0
            temporizza = 0
        End If

        sizeold = size

        Dim sei As Integer = 6
        Dim quindici As Integer = 30



        If ((Me.Label3.Text.Contains("ms") Or Me.Label3.Text.ToLower().Contains("non ")) And Me.aspetta < sei) Then
            Me.aspetta = Me.aspetta + 1
        Else
            If (Me.aspetta >= sei) Then
                Me.aspetta = Me.aspetta + 1
            End If
            If (Me.aspetta > quindici) Then
                Me.aspetta = 0
            End If
            Me.Label3.ForeColor = label3color
            Me.Label3.Text = String.Concat("Utente: ", Environment.UserName)
        End If


        ''''''''''''''''''''''''''''''REFRESH OGNI TOT SECONDI'''''''''''''''''''''''

        If contarefresh Mod refreshami = 0 Then

            Me.Label1.Text = String.Concat("IP: ", cls.GetIPv4Address())
            Me.label2.Text = String.Concat("Nome PC: ", Me.getpcname())
            Me.label2.ForeColor = label2color

            Try
                Dim testo As String = ""
                If Environment.UserDomainName.ToLower.Trim = Me.getpcname().ToLower.Trim Then
                    testo = "Dominio: Non in dominio"
                Else
                    testo = "Dominio: " & Environment.UserDomainName
                End If
                Me.Label6.Text = testo

            Catch ex As Exception
                Me.Label6.Text = ""
            End Try

            Me.Label6.ForeColor = label6color




            '''''''''''''''''''''''''''''''''''''''''''''''''

            Try
                Dim date2 As DateTime = DateTime.Now
                Dim sec As Long = DateDiff(DateInterval.Second, date1, date2)
                Dim myticks As String = sec
                Dim day As Double = TimeSpan.FromSeconds(myticks).Days
                Dim Hours As Double = TimeSpan.FromSeconds(myticks).Hours
                Dim Minutes As Double = TimeSpan.FromSeconds(myticks).Minutes

                Label4.Text = "acceso da: " & day.ToString & "g " & Hours.ToString & "h " & Minutes.ToString & "m"




            Catch ex As Exception
                Label4.Text = ""
            End Try

            Label5.Text = "MSG"
            '''''''''''''''''''''''''''''''''''''''''''''''''
yyy:
            Try
                If IO.File.Exists("c:\temp\necessitariavvio") Then
                    If letto = False Then
                        letto = True
                        Dim objReader As New System.IO.StreamReader("c:\temp\necessitariavvio")
                        Dim sx As String = objReader.ReadLine
                        objReader.Close()
                        objReader.Dispose()
                        If sx.ToLower.Contains("spegnimento") Then
                            spegni = True
                        End If
                    End If


                    Label3.ForeColor = Color.Red
                    If spegni Then
                        Label3.Text = "NECESSITO SPEGNIMENTO!  "
                    Else
                        Label3.Text = "NECESSITO RIAVVIO!      "
                    End If

                End If
            Catch ex As Exception

            End Try

            Dim getinfo As Boolean = False
            Try
                Dim cpu As String = CreateObject("WScript.Shell").RegRead("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0\ProcessorNameString")
                Dim cpu2 As String = cpu
                Dim cpux() As String
                cpux = Split(cpu, " ")
                cpu = ""
                For x As Integer = 0 To cpux.Count - 1
                    If getinfo Then
                        If cpux(x).ToLower.Trim = "cpu" Or cpux(x).ToLower.Trim = "" Then
                            Continue For
                        End If
                        cpu = cpu & cpux(x) & " "
                    End If
                    If cpux(x).Trim.ToLower.Contains("core") Then
                        getinfo = True
                    End If
                Next
                If getinfo = False Then
                    For x As Integer = 0 To cpux.Count - 1
                        If cpux(x).ToLower.Trim = "with" Then
                            getinfo = True
                            Exit For
                        End If
                        cpu = cpu & cpux(x) & " "
                    Next
                End If
                If getinfo = False Then
                    For x As Integer = 0 To cpux.Count - 1

                        If cpux(x).ToLower.Trim.Contains("(R)".ToLower) Or cpux(x).ToLower.Trim.Contains("(TM)".ToLower) _
                        Or cpux(x).ToLower.Trim = "@".ToLower Or cpux(x).ToLower.Trim = "amd".ToLower Or cpux(x).ToLower.Trim = "" Or cpux(x).ToLower.Trim = "cpu".ToLower Then
                            getinfo = True
                            Continue For
                        End If
                        cpu = cpu & cpux(x) & " "
                    Next
                End If


                If getinfo = False Then
                    cpu = cpu2
                End If

                Me.Label7.Text = "CPU: " & cpu

            Catch ex As Exception
                Me.Label7.Text = "CPU: N/D"
            End Try

            Try
                Dim gb As String = "GB"
                Dim ram1 As Double = My.Computer.Info.TotalPhysicalMemory
                Dim ram2 As Double = My.Computer.Info.AvailablePhysicalMemory
                ram1 = ram1 / (1024 * 1024)
                ram2 = ram2 / (1024 * 1024)
                Dim ram11 As String = CInt(ram1)
                Dim ram22 As String = CInt(ram2)
                If ram22.Length < 4 Then
                    gb = "MB"
                End If
                ram1 = Math.Round(CDbl(Val(Format(Int(ram1), "###,###"))), 1)
                ram2 = Math.Round(CDbl(Val(Format(Int(ram2), "###,###"))), 1)

                ram11 = ram1
                ram22 = ram2

                If CStr(ram11).Contains(",") = False Then
                    ram11 = ram11 & ",0"
                End If
                If CStr(ram22).Contains(",") = False And gb.ToLower <> "mb" Then
                    ram22 = ram22 & ",0"
                End If

                Me.Label8.Text = "RAM: " & ram11 & " GB / " & ram22 & " " & gb
            Catch ex As Exception
                Me.Label8.Text = "RAM: N/D"
            End Try


            Try
                Dim DriveOrFolder As String = "c:"

                Dim FreeBytesAvailableToMe As Long
                Dim TotalBytes As Long
                Dim FreeBytes As Long

                Dim Result As Integer


                Result = GetDiskFreeSpaceEx(DriveOrFolder, FreeBytesAvailableToMe, TotalBytes, FreeBytes)
                If Result <> 0 Then


                    Dim total As Integer = CInt(TotalBytes \ 1024) \ 1024
                    Dim free As Integer = CInt(FreeBytes \ 1024) \ 1024

                    Dim gb As String = "GB"
                    Dim ram11 As String = CInt(total)
                    Dim ram22 As String = CInt(free)
                    If ram22.Length < 4 Then
                        gb = "MB"
                    End If
                    Dim ram1 As Double = Math.Round(CDbl(Val(Format(total, "###,###"))), 1)

                    Dim ram2 As Double = Math.Round(CDbl(Val(Format(free, "###,###"))), 1)
                    ram11 = ram1
                    ram22 = ram2

                    If CStr(ram11).Contains(",") = False Then
                        ram11 = ram11 & ",0"
                    End If
                    If CStr(ram22).Contains(",") = False And gb.ToLower <> "mb" Then
                        ram22 = ram22 & ",0"
                    End If
                    Label9.Text = "Disco C: " & ram11 & " GB / " & ram22 & " " & gb


                End If
            Catch ex As Exception
                Me.Label9.Text = "Disoc C: N/D"
            End Try

            Try
                Dim winzozz2 As String = ""
                Try
                    winzozz2 = CStr(CreateObject("WScript.Shell").RegRead("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\DisplayVersion"))
                Catch ex As Exception
                End Try

                Dim x64 As String = "32bit"
                If Environment.Is64BitOperatingSystem Then
                    x64 = "64bit"
                End If

                Dim os1 As String = (My.Computer.Info.OSFullName)
                os1 = os1.Replace("Microsoft", "").Trim.Replace("Windows", "Win").Replace("Enterprise", "Ent").Trim
                Label10.Text = "OS: " & os1 & " " & winzozz2 & " a " & x64
            Catch ex As Exception
                Me.Label10.Text = "OS: N/D"
            End Try


            Me.aggiornaposizione()


        End If
        ''''''''''''''''''''''''''''''FINE REFRESH OGNI TOT SECONDI'''''''''''''''''''''''

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ''''''''''''''''''''''''''''''INIZIO REFRESH OGNI 1 SECONDO'''''''''''''''''''''''

        BandwidthPerSec()

        Try
            label11.Text = bandwidth

        Catch ex As Exception
            label11.Text = ""

        End Try

        ''''''''''''''''''''''''''''''FINE REFRESH OGNI 1 SECONDO'''''''''''''''''''''''


        If temporizza > temporizzalimit Then
            contarefresh = contarefresh + 1
            If contarefresh > 120 Then
                contarefresh = 1
            End If
        Else
            contarefresh = 0
        End If



        Application.DoEvents()


    End Sub

    Public _NetworkInterface As NetworkInterface

    Public Function BytesConverter(ByVal bytes As Long) As String
        Dim KB As Long = 1024
        Dim MB As Long = KB * KB
        Dim GB As Long = KB * KB * KB
        Dim TB As Long = KB * KB * KB * KB
        Dim returnVal As String = "0 Mb"

        ' Select Case bytes
        'Case Is <= KB
        'returnVal = bytes & " Bytes"
        'Case Is > TB
        'urnVal = (bytes / KB / KB / KB / KB).ToString("0.00") & " TB"
        'Case Is > GB
        'returnVal = (bytes / KB / KB / KB).ToString("0.00") & " GB"
        'Case Is > MB
        returnVal = (bytes / KB / KB * 8).ToString("0.00") & " Mb"
        ' Case Is > KB
        'returnVal = (bytes / KB).ToString("0.00") & " KB"
        'End Select

        Return returnVal.ToString
    End Function

    Dim LastUpload As Long
    Dim LastDownload As Long

    Public net As NetworkInterface

    Private Sub BandwidthPerSec()
        Try

            Dim NicStats As IPv4InterfaceStatistics = net.GetIPv4Statistics



            Dim Up = NicStats.BytesSent - LastUpload
            Dim Down = NicStats.BytesReceived - LastDownload

            LastUpload = NicStats.BytesSent
            LastDownload = NicStats.BytesReceived
            Try
                bandwidth = "█ ↓" & BytesConverter(If(Down < 0, 0, Down)) & "/s" & " - ↑" & BytesConverter(If(Up < 0, 0, Up)) & "/s"

            Catch ex As Exception
                bandwidth = ""
            End Try



        Catch ex As Exception

        End Try

    End Sub

    Dim mycpu As String


    Dim cx As Integer = 0
    Dim num As Integer = 0
    Sub aggiornaposizione()


        If temporizza <= temporizzalimit Then
            temporizza = temporizza + 1
        End If



        If temporizza < temporizzalimit Then

            label11.Text = "█ ↓0,00 Mb/s - ↑0,00 Mb/s"
            Dim c1, c2, c3, c4, c6, c7, c8, c9, c10, c11 As Integer
            Dim spazio As Integer = 1

            Me.Label1.Left = 0
            Me.label2.Left = 0
            Me.Label3.Left = 0
            Label4.Left = 0
            Label5.Left = Me.Width - Label5.Width - 5
            Label6.Left = 0
            Label7.Left = 0
            Label8.Left = 0
            Label9.Left = 0
            Label10.Left = 0
            label11.Left = 0
            ' cx = CInt(Label1.Font.Size * 2 + spazio)
            cx = CInt(Label1.Height + spazio)

            c1 = cx
            c2 = cx
            c3 = cx
            c4 = cx
            c6 = cx
            c7 = cx
            c8 = cx
            c9 = cx
            c10 = cx
            c11 = cx
            'Label1.Width = CInt(Label1.Text.Count * Label1.Font.Size)
            'Label1.Width = Label1.Width * scalex
            'Label1.Height = Label1.Height * scaley
            labelh(Label1)
            labelh(label2)
            labelh(Label3)
            labelh(Label4)
            labelh(Label5)
            labelh(Label6)
            labelh(Label7)
            labelh(Label8)
            labelh(Label9)
            labelh(Label10)
            labelh(label11)


            labelw(Label1)
            labelw(label2)
            labelw(Label3)
            labelw(Label4)
            labelw(Label5)
            labelw(Label6)
            labelw(Label7)
            labelw(Label8)
            labelw(Label9)
            labelw(Label10)
            labelw(label11)


            Dim width1 As Integer = Me.Label1.Width + Me.Label5.Width + 5
            Dim width2 As Integer = Me.label2.Width
            Dim width3 As Integer = Me.Label3.Width
            Dim width4 As Integer = Me.Label4.Width
            Dim width6 As Integer = Me.Label6.Width
            Dim width7 As Integer = Me.Label7.Width
            Dim width8 As Integer = Me.Label8.Width
            Dim width9 As Integer = Me.Label9.Width
            Dim width10 As Integer = Me.Label10.Width
            Dim width11 As Integer = Me.label11.Width

            If Label1.Visible = False Then
                width1 = 0
                c1 = 0
            End If

            If label2.Visible = False Then
                width2 = 0
                c2 = 0
            End If

            If Label3.Visible = False Then
                width3 = 0
                c3 = 0
            End If

            If Label4.Visible = False Then
                width4 = 0
                c4 = 0
            End If

            If Label6.Visible = False Then
                width6 = 0
                c6 = 0
            End If

            If Label7.Visible = False Then
                width7 = 0
                c7 = 0
            End If

            If Label8.Visible = False Then
                width8 = 0
                c8 = 0
            End If

            If Label9.Visible = False Then
                width9 = 0
                c9 = 0
            End If
            If Label10.Visible = False Then
                width10 = 0
                c10 = 0
            End If
            If label11.Visible = False Then
                width11 = 0
                c11 = 0
            End If


            Label1.Top = 5

            label2.Top = c1 + spazio
            Label3.Top = c1 + c2 + spazio
            Label4.Top = c1 + c2 + c3 + spazio
            Label6.Top = c1 + c2 + c3 + c4 + spazio
            Label7.Top = c1 + c2 + c3 + c4 + c6 + spazio
            Label8.Top = c1 + c2 + c3 + c4 + c6 + c7 + spazio
            Label9.Top = c1 + c2 + c3 + c4 + c6 + c7 + c8 + spazio
            Label10.Top = c1 + c2 + c3 + c4 + c6 + c7 + c8 + c9 + spazio
            label11.Top = c1 + c2 + c3 + c4 + c6 + c7 + c8 + c9 + c10 + spazio

            ' If temporizza = 1 Then
            num = New Integer() {width1, width2, width3, width4, width6, width7, width8, width9, width10, width11}.Max
            num = num + 5
            '  End If

            Dim x As Integer
            Dim y As Integer
            Dim r As Rectangle

            Dim cc As Integer = c1 + c2 + c3 + c4 + c6 + c7 + c8 + c9 + c10 + c11
            r = Screen.PrimaryScreen.WorkingArea
            x = CInt(r.Width / 2 - num / 2)
            y = CInt(r.Height / 2 - ((cc) / 2))

            Select Case posizione
                Case 1
                    pos.X = 0
                    pos.Y = 0
                Case 2
                    pos.X = x
                    pos.Y = 0
                Case 3
                    pos.X = r.Width - num
                    pos.Y = 0


                Case 4
                    pos.X = 0
                    pos.Y = y

                Case 5
                    pos.X = x
                    pos.Y = y

                Case 6
                    pos.X = r.Width - num
                    pos.Y = y

                Case 7
                    pos.X = 0
                    pos.Y = r.Height - (cc)

                Case 8
                    pos.X = x
                    pos.Y = r.Height - (cc)

                Case 9
                    pos.X = r.Width - num
                    pos.Y = r.Height - (cc)

                Case Else
                    pos.X = r.Width - num
                    pos.Y = 0

            End Select

            Me.Location = pos
            Me.Width = num
            Label3.Width = num - 25
            Label4.Width = num - 25
            Label5.Top = 3
            Label5.Left = Me.Width - Label5.Width - 5
            label11.Text = "█ ↓0,00 Mb/s - ↑0,00 Mb/s"
            bandwidth = "█ ↓0,00 Mb/s - ↑0,00 Mb/s"
            Me.Height = cc + spazio

        ElseIf temporizza = temporizzalimit Then

            num = 0
            Me.Enabled = True
            Label5.Visible = visualizzami
            label11.Width = Me.Width
            timermenu.Enabled = True

        End If



    End Sub
    Sub labelh(ctrl As Label)
        Dim txtHght As Int32 = 1
        Dim txtSize As Int32 = ctrl.Height
        Dim flg As Boolean = True
        While flg
            Using gr As Graphics = ctrl.CreateGraphics
                txtSize = CInt(gr.MeasureString(ctrl.Text, ctrl.Font).Height)
            End Using
            If txtSize > ctrl.Height / scaley Then
                ctrl.Height += txtHght
            Else
                flg = False
            End If
        End While
        'ctrl.Height = ctrl.Height * scaley
    End Sub
    Sub labelw(ctrl As Label)
        Dim txtHght As Int32 = 1
        Dim txtSize As Int32 = ctrl.Width
        Dim flg As Boolean = True
        While flg
            Using gr As Graphics = ctrl.CreateGraphics
                txtSize = CInt(gr.MeasureString(ctrl.Text, ctrl.Font).Width)

            End Using
            If txtSize > ctrl.Width / scalex Then
                ctrl.Width += txtHght
            Else
                flg = False
            End If
        End While
        '''ctrl.Width = ctrl.Width * scalex
    End Sub
    Dim temporizza As Integer = 0
    Dim temporizzalimit As Integer = 3

    Dim pos As New Point
    Dim posizione As Integer = 0
    Dim fontx As Font

    Dim label1color As Color = Color.White
    Dim label2color As Color = Color.White
    Dim label3color As Color = Color.White
    Dim label4color As Color = Color.White
    Dim label5color As Color = Color.White
    Dim label6color As Color = Color.White
    Dim label7color As Color = Color.White
    Dim label8color As Color = Color.White
    Dim label9color As Color = Color.White
    Dim label10color As Color = Color.White
    Dim pingokcolor As Color = Color.Orange
    Dim pingerrorcolor As Color = Color.Red
    Dim shadowcolor As Color = Color.Gray

    Dim pingami As Boolean = True
    Dim viewiptoping As Boolean = False
    Dim refreshami As Integer = 3
    Dim allwayson As Boolean = True

    Public Shared folder As String = ""
    Public Shared usershortcut As Boolean = False

    Dim visualizzami As Boolean = False


    Dim aspetta As Integer = 0
    Public Shared riavvio As Boolean = False
    Public Shared riavviosecondi As Integer = 0
    Dim letto As Boolean = False
    Dim spegni As Boolean = False

    Dim sizeold As Rectangle = Nothing

    Dim lastedit As DateTime = Nothing

    Dim date1 As DateTime = Nothing

    Dim contacpu As Integer = 0
    Sub caricaconfig()

        posizione = 3
        fontx = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)

        folder = ""

        cls.messaggiutenti = ""
        cls.rispostautenti = ""
        cls.pingip = ""
        Form1.usershortcut = False
        cls.errori = ""
        ''' cls.pingip = ""

        lastedit = IO.File.GetLastWriteTime(Application.StartupPath & "\viewmyip.cfg")

        If (Not IO.File.Exists(String.Concat(Application.StartupPath, "\viewmyip.cfg"))) Then
            folder = ""
            cls.pingip = dammiip()
            Return
        End If


        Dim streamReader As System.IO.StreamReader = New System.IO.StreamReader(String.Concat(Application.StartupPath, "\viewmyip.cfg"))
        While streamReader.Peek() <> -1
            Dim str As String = streamReader.ReadLine().Trim()
            If (str.StartsWith("'")) Then
                Continue While
            End If
            If str.StartsWith("[iptoping]") Then
                str = Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim
                If (Not str.Contains(".")) Then
                    cls.pingip = ""
                End If

                Dim pp() As String = Split(str, ".")

                Dim buono As Boolean = True
                If pp.Length = 4 Then
                    For x As Integer = 0 To pp.Length - 1
                        If IsNumeric(pp(x)) = False Then
                            buono = False
                        End If
                    Next
                    If buono Then
                        cls.pingip = str
                    Else
                        cls.pingip = ""
                    End If

                Else
                    cls.pingip = ""
                End If
            End If


            If str.StartsWith("[pingokcolor]") Then
                Try
                    str = Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim
                    pingokcolor = Color.FromName(str)
                Catch ex As Exception
                    pingokcolor = Color.DarkRed
                End Try
            End If

            If str.StartsWith("[pingerrorcolor]") Then
                Try
                    str = Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim
                    pingerrorcolor = Color.FromName(str)
                Catch ex As Exception
                    pingerrorcolor = Color.Red
                End Try
            End If

            If str.StartsWith("[label1color]") Then
                Try
                    str = Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim
                    If str.ToLower = "black" Then
                        Label1.ForeColor = Color.FromArgb(5, 5, 5, 0)
                    Else
                        Label1.ForeColor = Color.FromName(str)
                    End If
                    label1color = Label1.ForeColor
                Catch ex As Exception

                End Try
                If str.ToLower = "hide" Then
                    Label1.Visible = False
                Else
                    Label1.Visible = True
                End If

            End If

            If str.StartsWith("[label2color]") Then
                Try
                    str = Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim
                    If str.ToLower = "black" Then
                        label2.ForeColor = Color.FromArgb(5, 5, 5, 0)
                    Else
                        label2.ForeColor = Color.FromName(str)
                    End If
                    label2color = label2.ForeColor
                Catch ex As Exception

                End Try
                If str.ToLower = "hide" Then
                    label2.Visible = False
                Else
                    label2.Visible = True
                End If
            End If

            If str.StartsWith("[label3color]") Then
                Try
                    str = Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim
                    If str.ToLower = "black" Then
                        Label3.ForeColor = Color.FromArgb(5, 5, 5, 0)

                    Else
                        Label3.ForeColor = Color.FromName(str)
                    End If
                    label3color = Label3.ForeColor

                Catch ex As Exception

                End Try
                If str.ToLower = "hide" Then
                    Label3.Visible = False
                Else
                    Label3.Visible = True
                End If

            End If

            If str.StartsWith("[label4color]") Then
                Try
                    str = Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim
                    If str.ToLower = "black" Then
                        Label4.ForeColor = Color.FromArgb(5, 5, 5, 0)

                    Else
                        Label4.ForeColor = Color.FromName(str)
                    End If
                    label4color = Label4.ForeColor
                Catch ex As Exception

                End Try
                If str.ToLower = "hide" Then
                    Label4.Visible = False
                Else
                    Label4.Visible = True
                End If
            End If

            Dim invisibile As Boolean = False

            If str.StartsWith("[label5color]") Then
                Try
                    str = Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim
                    If str.ToLower = "black" Then
                        Label5.BackColor = Color.FromArgb(5, 5, 5, 0)

                    Else
                        Label5.BackColor = Color.FromName(str)
                    End If
                    label5color = Label5.BackColor
                Catch ex As Exception

                End Try

                If str.ToLower = "hide" Then
                    visualizzami = False
                    Label5.ForeColor = Color.Black

                Else
                    visualizzami = True
                    Label5.ForeColor = Color.DarkRed

                End If
            End If
            '''''''''''''''''''''''''''''''''''
            If str.StartsWith("[label6color]") Then
                Try
                    str = Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim
                    If str.ToLower = "black" Then
                        Label6.ForeColor = Color.FromArgb(5, 5, 5, 0)

                    Else
                        Label6.ForeColor = Color.FromName(str)
                    End If
                    label6color = Label6.ForeColor
                Catch ex As Exception

                End Try

                If str.ToLower = "hide" Then
                    Label6.Visible = False
                Else
                    Label6.Visible = True
                End If
            End If
            '''''''''''''''''''''''''''''''''''
            If str.StartsWith("[label7color]") Then
                Try
                    str = Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim
                    If str.ToLower = "black" Then
                        Label7.ForeColor = Color.FromArgb(5, 5, 5, 0)

                    Else
                        Label7.ForeColor = Color.FromName(str)
                    End If
                    label7color = Label7.ForeColor
                Catch ex As Exception

                End Try

                If str.ToLower = "hide" Then
                    Label7.Visible = False
                Else
                    Label7.Visible = True
                End If
            End If
            '''''''''''''''''''''''''''''''''''
            If str.StartsWith("[label8color]") Then
                Try
                    str = Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim
                    If str.ToLower = "black" Then
                        Label8.ForeColor = Color.FromArgb(5, 5, 5, 0)

                    Else
                        Label8.ForeColor = Color.FromName(str)
                    End If
                    label8color = Label8.ForeColor
                Catch ex As Exception

                End Try

                If str.ToLower = "hide" Then
                    Label8.Visible = False
                Else
                    Label8.Visible = True
                End If
            End If

            If str.StartsWith("[label9color]") Then
                Try
                    str = Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim
                    If str.ToLower = "black" Then
                        Label9.ForeColor = Color.FromArgb(5, 5, 5, 0)

                    Else
                        Label9.ForeColor = Color.FromName(str)
                    End If
                    label9color = Label9.ForeColor
                Catch ex As Exception

                End Try

                If str.ToLower = "hide" Then
                    Label9.Visible = False
                Else
                    Label9.Visible = True
                End If
            End If

            If str.StartsWith("[label10color]") Then
                Try
                    str = Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim
                    If str.ToLower = "black" Then
                        Label10.ForeColor = Color.FromArgb(5, 5, 5, 0)

                    Else
                        Label10.ForeColor = Color.FromName(str)
                    End If
                    label10color = Label10.ForeColor
                Catch ex As Exception

                End Try

                If str.ToLower = "hide" Then
                    Label10.Visible = False
                Else
                    Label10.Visible = True
                End If
            End If


            If str.StartsWith("[label11color]") Then
                Try
                    str = Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim
                    If str.ToLower = "black" Then
                        label11.ForeColor = Color.FromArgb(5, 5, 5, 0)

                    Else
                        label11.ForeColor = Color.FromName(str)
                    End If
                    label10color = label11.ForeColor
                Catch ex As Exception

                End Try

                If str.ToLower = "hide" Then
                    label11.Visible = False
                Else
                    label11.Visible = True
                End If
            End If





            If str.StartsWith("[pingami]") Then
                Try
                    Dim pinga As String = (Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim.ToLower)
                    If pinga.StartsWith("s") Then
                        pingami = True
                    Else
                        pingami = False
                    End If

                Catch ex As Exception
                    pingami = True
                End Try
            End If

            If str.StartsWith("[refresh]") Then
                Try
                    Dim r As String = (Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim.ToLower)
                    If r.Contains("s") Then
                        r = Mid(r, 1, r.IndexOf("s"))
                    End If
                    If IsNumeric(r) Then
                        refreshami = CInt(r)
                    Else
                        refreshami = 3
                    End If

                Catch ex As Exception
                    refreshami = 3
                End Try
            End If


            If str.StartsWith("[posizione]") Then
                Try
                    posizione = Convert.ToInt32(Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim)
                Catch ex As Exception
                    posizione = 3
                End Try
            End If

            If str.StartsWith("[folder]") Then

                Try
                    folder = (Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim)
                Catch ex As Exception
                    folder = ""
                End Try
            End If

            If str.StartsWith("[usershortcut]") Then

                Try
                    Dim s As String = (Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim)
                    If s.ToLower.Trim.StartsWith("s") Then
                        usershortcut = True
                        If IsAdministrator = False Then
                            CreateShortCut()
                        End If

                    Else
                        usershortcut = False
                        If IsAdministrator = False Then
                            CreateShortCut()
                        End If
                    End If
                Catch ex As Exception
                    usershortcut = False
                    If IsAdministrator = False Then
                        CreateShortCut()
                    End If
                End Try
            End If


            If str.StartsWith("[viewiptoping]") Then

                Try
                    Dim s As String = (Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim)
                    If s.ToLower.Trim.StartsWith("s") Then
                        viewiptoping = True
                    Else
                        viewiptoping = False
                    End If
                Catch ex As Exception
                    viewiptoping = False
                End Try
            End If

            'allwayson
            If str.StartsWith("[allwayson]") Then

                Try
                    Dim s As String = (Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim)
                    If s.ToLower.Trim.StartsWith("s") Then
                        allwayson = True
                    Else
                        allwayson = False
                    End If
                Catch ex As Exception
                    allwayson = True
                End Try
            End If

            If str.StartsWith("[shadowcolor]") Then
                Try
                    str = Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim

                    If str.ToLower = "black" Then
                        shadowcolor = Color.FromArgb(5, 5, 5, 0)
                    Else
                        shadowcolor = Color.FromName(str)
                    End If

                Catch ex As Exception
                    shadowcolor = Color.FromName("gray")
                End Try

                If str.ToLower = "hide" Then
                    shadowcolor = Color.Black
                End If
            End If



            If str.StartsWith("[font]") Then
                Dim fontf As String = ""
                Dim font2() As String
                Try

                    fontf = (Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim.ToLower)
                    If fontf.Contains(",") Then
                        font2 = Split(fontf, ",")
                        If font2.Length = 4 Then
                            fontx = CreateFont(font2(0), CInt(font2(1)), font2(2), font2(3))
                        ElseIf font2.Length = 3 Then
                            fontx = CreateFont(font2(0), CInt(font2(1)), font2(2))
                        ElseIf font2.Length = 2 Then
                            fontx = CreateFont(font2(0), CInt(font2(1)))
                        End If

                    Else
                        fontx = CreateFont(fontf)
                    End If
                Catch ex As Exception
                    '''fontsize = 12
                End Try

                Me.Font = fontx
                Label1.Font = fontx
                label2.Font = fontx
                Label3.Font = fontx
                Label4.Font = fontx
                Label5.Font = fontx
                Label6.Font = fontx
                Label7.Font = fontx
                Label8.Font = fontx
                Label9.Font = fontx
                Label10.Font = fontx
                label11.Font = fontx

                Label1.ShadowColor = shadowcolor
                label2.ShadowColor = shadowcolor
                Label3.ShadowColor = shadowcolor
                Label4.ShadowColor = shadowcolor
                Label5.ShadowColor = shadowcolor
                Label6.ShadowColor = shadowcolor
                Label7.ShadowColor = shadowcolor
                Label8.ShadowColor = shadowcolor
                Label9.ShadowColor = shadowcolor
                Label10.ShadowColor = shadowcolor
                label11.ShadowColor = shadowcolor

            End If

        End While

        streamReader.Close()
        streamReader.Dispose()

        If folder <> "" Then
            cls.messaggiutenti = folder & "\messaggiutenti"
            cls.rispostautenti = folder & "\rispostautenti"
            cls.errori = folder & "\rispostautenti\errori"
        End If

        If cls.pingip = "" Then
            cls.pingip = dammiip()
        End If

    End Sub
    Function dammiip() As String

        If cls.pingip = "" Then
            Dim ip As String = ""

            Dim hostName = System.Net.Dns.GetHostName()
            For Each hostAdr In System.Net.Dns.GetHostEntry(hostName).AddressList()

                Dim toping As String = hostAdr.ToString
                If toping.Contains(".") = False Or toping.EndsWith(".1") Then
                    Continue For
                End If
                toping = Mid(toping, 1, toping.LastIndexOf("."))
                toping = toping & ".1"
                Dim pingalo As Boolean = False
                If My.Computer.Network.Ping(toping, 1000) Then
                    pingalo = True
                End If
                If pingalo Then
                    Return toping
                End If
            Next
        End If
        Return ""
    End Function
    Public Function CreateFont(Optional fontName As String = "Microsoft Sans Serif", Optional fontSize As Integer = 12, Optional tipo As String = "", Optional tipo2 As String = "") As Drawing.Font
        fontName = fontName.Trim
        tipo = tipo.Trim
        tipo2 = tipo2.Trim


        Dim styles As FontStyle = FontStyle.Regular
        tipo = tipo.ToLower.Trim
        Select Case tipo
            Case "bold"
                styles = styles Or FontStyle.Bold
            Case "italic"
                styles = styles Or FontStyle.Italic
        End Select

        Select Case tipo2
            Case "bold"
                styles = styles Or FontStyle.Bold
            Case "italic"
                styles = styles Or FontStyle.Italic
        End Select

        Dim newFont As New Font(fontName, fontSize, styles)
        Return newFont

    End Function
    Private Sub timerurgente_Tick(sender As Object, e As EventArgs) Handles timerurgente.Tick



        If Val(GetPingMs(cls.pingip)) < 0 Then
            Return
        End If

        cls.verificamessaggiurgenti()

        cls.urgente = 0

        cls.mostramessaggi()

    End Sub

    Private Sub timermessaggi_Tick(sender As Object, e As EventArgs) Handles timermessaggi.Tick

        Try

            Me.ShowInTaskbar = False
            Me.ShowIcon = False


        Catch ex As Exception
        End Try
        timerurgente.Enabled = False

        If Val(GetPingMs(cls.pingip)) < 0 Then
            timermessaggi.Interval = 6000
            timermessaggi.Enabled = True
            Return
        End If
        timermessaggi.Enabled = False
        timerurgente.Enabled = True

        cls.verificamessaggiutenti()
        cls.messaggio = 0
        cls.quota = 0

        cls.mostramessaggi()

    End Sub



    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If temporizza > temporizzalimit Then
            Me.Top = -10000
            Me.Left = -10000
            temporizza = 0
            contarefresh = 0
        End If

    End Sub



    Private Sub LEggiUltimoMessaggioRicevutoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LEggiUltimoMessaggioRicevutoToolStripMenuItem.Click

        cls.leggiultimi(1)


    End Sub

    Private Sub LEggiUltimi5MessaggiRicevutiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LEggiUltimi5MessaggiRicevutiToolStripMenuItem.Click

        cls.leggiultimi(3)


    End Sub

    Private Sub LeggiUltimi5MessaggiRicevutiToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LeggiUltimi5MessaggiRicevutiToolStripMenuItem1.Click
        cls.leggiultimi(5)
    End Sub



    Private Sub Label3_MouseMove(sender As Object, e As MouseEventArgs) Handles Label3.MouseMove
        If aspetta > 0 Or pingami = False Then
            Return
        End If
        aspetta = aspetta + 1
        Dim s As String = ""
        s = GetPingMs(cls.pingip)
        Dim ss As String = s

        If Val(ss) = 0 Then
            ss = "<1"
        End If
        Dim ip As String = ""
        If viewiptoping Then
            ip = " (" & cls.pingip & ")"
        End If
        Label3.Text = "ping:" & ss & "ms" & ip
        If Val(s) < 1000 And Val(s) >= 0 Then
            Label3.ForeColor = pingokcolor
        Else
            Label3.ForeColor = pingerrorcolor
        End If

        If s = "-1" Then
            Label3.Text = "NON CONNESSO!"
        End If
    End Sub


    Private Sub Label5_MouseClick(sender As Object, e As MouseEventArgs) Handles Label5.MouseClick
        If e.Button = MouseButtons.Right And msgform.Visible = False Then
            ContextMenuStrip1.Show(Me.Left, Me.Top + Label5.Top + Label5.Height)
        Else

        End If
    End Sub

    Dim contamenu As Integer = 0
    Private Sub timermenu_Tick(sender As Object, e As EventArgs) Handles timermenu.Tick

        If ContextMenuStrip1.Visible = True Then
            contamenu = contamenu + 1
            If contamenu = 3 Then
                ContextMenuStrip1.Hide()
                ''' timermenu.Enabled = False
                contamenu = 0
            End If

        End If

    End Sub


    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim s() As String = Split(Label1.Text, ":")
            Clipboard.SetText(s(1).Trim)
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub label11_Click(sender As Object, e As EventArgs) Handles label11.Click

    End Sub

    Private Sub label2_MouseDown(sender As Object, e As MouseEventArgs) Handles label2.MouseDown

        If e.Button = MouseButtons.Right Then
            Dim s() As String = Split(label2.Text, ":")
            Clipboard.SetText(s(1).Trim)

        End If
    End Sub

    Private Sub label11_MouseClick(sender As Object, e As MouseEventArgs) Handles label11.MouseClick

    End Sub

    Private Sub label11_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles label11.MouseDoubleClick
        If e.Button = MouseButtons.Right Then
            Dim triami As Boolean = False
            Try
                Process.Start(New ProcessStartInfo("microsoft-edge:http://10.111.253.2") With {.WindowStyle = ProcessWindowStyle.Maximized})
                triami = True
            Catch ex As Exception

            End Try
            If triami = False Then
                Try
                    Process.Start(New ProcessStartInfo("microsoft-edge:https://10.111.253.2") With {.WindowStyle = ProcessWindowStyle.Maximized})
                    triami = True
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Private Sub loadnic()

        Try
            Dim Adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            For Each network As NetworkInterface In Adapters
                If network.OperationalStatus = 1 Then
                    If GetLocalIPAddress() <> "" And (network.NetworkInterfaceType = 6 Or network.NetworkInterfaceType = 71) Then

                        Dim ip = network.GetIPProperties().UnicastAddresses(1).Address.ToString
                            net = network
                            Exit Sub

                    End If


                End If
            Next




        Catch exception As System.Exception
            Throw
        End Try
    End Sub
End Class


