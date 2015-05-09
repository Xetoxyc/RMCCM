Imports System.Threading
Imports System.Net
Imports System.IO

Public Class RMCCM
    Private BAD_PROCESSES As String() = {"javaw.exe", "jcef_helper.exe.exe"}
    Private BAD_FOLDERS As String() = {"Flan", "mods"}
    Const SERVER_URI As String = "http://dl.redmc.de/"
    Const FILE_MAP_URI As String = "http://dl.redmc.de/installer_files/"

    Private strAppDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
    Private strMinecraftPath = "\.minecraft\"
    Private bIsRunning As Boolean = False
    Private oThread As Thread

    Private Sub RMCCM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtMinecraftPath.Text = strAppDataPath & strMinecraftPath

        ProgressBar.Minimum = 0
        ProgressBar.Value = 0
        ProgressBar.Step = 1
    End Sub

    Private Sub RMCCM_Close(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If bIsRunning AndAlso Not StopWarning() Then
            e.Cancel = True
        End If
    End Sub

    Private Sub btnChooseCustomDirectory_Click(sender As Object, e As EventArgs) Handles btnChooseCustomDirectory.Click
        Dim oFolderDialog As New FolderBrowserDialog
        oFolderDialog.RootFolder = System.Environment.SpecialFolder.ApplicationData

        If oFolderDialog.ShowDialog() = DialogResult.OK Then
            txtMinecraftPath.Text = oFolderDialog.SelectedPath
        End If
    End Sub

    Private Function StopWarning() As Boolean
        Return MsgBox("The patching progess is not finished now." & vbCrLf & vbCrLf & "Are you sure you want to quit patching? " & vbCrLf & "(Maybe some of your files will be damaged then)", MsgBoxStyle.OkCancel, "Quit Patching") = MsgBoxResult.Ok
    End Function

    Private Sub btnStartPatching_Click(sender As Object, e As EventArgs) Handles btnStartPatching.Click
        If bIsRunning Then
            If StopWarning() Then
                oThread.Abort()

                btnStartPatching.Text = "Start patching"
            End If
        Else
            If CloseProcessesForPatching() AndAlso MoveMinecraftFolder() Then
                oThread = New Thread(AddressOf StartPatching)
                oThread.Start()

                ProgressBar.Value = 0
                btnStartPatching.Text = "Stop patching"
            Else
                MsgBox("Patching stoped!")
            End If
        End If
    End Sub

    Public Function CloseProcessesForPatching() As Boolean
        For Each strProcessName As String In BAD_PROCESSES
            Dim oProcesses() As Process = Process.GetProcessesByName(strProcessName)

            If oProcesses.Count > 0 Then
                If MsgBox("To start the patching you need to close the process """ & strProcessName & """." & vbCrLf & "Should """ & strProcessName & """ be closed automatically?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    For Each oProcess As Process In oProcesses
                        oProcess.CloseMainWindow()

                        While Not oProcess.HasExited
                            Select Case MsgBox("The process could not be closed automatically. Should it be forced to close?", MsgBoxStyle.YesNoCancel)
                                Case MsgBoxResult.Ok : oProcess.Kill()
                                Case MsgBoxResult.Retry : oProcess.CloseMainWindow()
                                Case MsgBoxResult.Cancel : Return False
                            End Select
                        End While
                    Next
                Else
                    Return False
                End If
            End If
        Next

        Return True
    End Function

    Public Function MoveMinecraftFolder() As Boolean
        Directory.Move(txtMinecraftPath.Text, txtMinecraftPath.Text & "_Bak_" & Date.Today.ToString("yyyy_MM_dd"))
        
        Return True
    End Function

    Public Sub StartPatching()
        Try
            bIsRunning = True

            Dim bAll As Boolean = False
            Dim bOverride As Boolean = False

            Dim oWebClient As New WebClient()

            Dim strFileMap As String = oWebClient.DownloadString(FILE_MAP_URI)
            Dim strFiles() As String = strFileMap.Split(vbLf)

            Me.Invoke(Sub() ProgressBar.Maximum = strFiles.Length)

            For i As Integer = 0 To strFiles.Length - 1
                Dim strFile As String = txtMinecraftPath.Text & strFiles(i).Substring(strFiles(i).IndexOf("/") + 1)
                Dim oFileInfo As New FileInfo(System.Web.HttpUtility.HtmlDecode(strFile))

                If String.IsNullOrEmpty(oFileInfo.Extension) Then
                    If Not Directory.Exists(oFileInfo.FullName) Then
                        Directory.CreateDirectory(oFileInfo.FullName)
                    End If
                Else
                    If File.Exists(oFileInfo.FullName) Then
                        If Not bAll Then
                            Dim oFileOverwriteDialog As New FileOverwriteDialog(oFileInfo.Name)
                            Select Case oFileOverwriteDialog.ShowDialog()
                                Case Windows.Forms.DialogResult.Yes : bOverride = True
                                Case Windows.Forms.DialogResult.Cancel : bOverride = False
                                Case Windows.Forms.DialogResult.OK : bOverride = True : bAll = True
                                Case Windows.Forms.DialogResult.No : bOverride = False : bAll = True
                            End Select
                        End If

                        If bOverride Then
                            Dim nRetry As Integer = 5
                            While File.Exists(oFileInfo.FullName) AndAlso nRetry > 0
                                nRetry -= 1
                                File.Delete(oFileInfo.FullName)
                                System.Threading.Thread.Sleep(2500)
                            End While

                            If nRetry = 0 Then
                                Throw New Exception("Data """ & strFile & """ could not be overwritten!")
                            End If
                        End If
                    End If

                    If Not File.Exists(oFileInfo.FullName) Then
                        Try
                            oWebClient.DownloadFile(SERVER_URI & strFiles(i), oFileInfo.FullName)
                        Catch ex As Exception
                            MsgBox("Missing file """ & oFileInfo.Name & """ please contact the developer.")
                        End Try
                    End If
                End If

                IncrementProgressBar()
            Next

            MsgBox("Finished")
        Catch ex As Exception
            If Not TypeOf ex Is System.Threading.ThreadAbortException Then
                MsgBox("ERROR Please report the following to the developer." & vbCrLf & vbCrLf & ex.Message)
            End If
        Finally
            Me.Invoke(Sub() btnStartPatching.Text = "Start patching")
            bIsRunning = False
        End Try
    End Sub

    Public Sub IncrementProgressBar()
        Me.Invoke(Sub() ProgressBar.PerformStep())
    End Sub
End Class