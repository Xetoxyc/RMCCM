Imports System.Threading
Imports System.Net
Imports System.IO

Public Class RMCCM
    Const SERVER_URI As String = "http://dl.redmc.de/"
    Const FILE_MAP_URI As String = "http://dl.redmc.de/installer_files/"

    Dim strAppDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
    Dim strMinecraftPath = "\.minecraft"
    Dim bIsRunning As Boolean = False

    Dim oThread As Thread

    Private Sub RMCCM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtMinecraftPath.Text = strAppDataPath & strMinecraftPath
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
            oThread = New Thread(AddressOf StartPatching)
            oThread.Start()

            txtLog.Text = String.Empty
            btnStartPatching.Text = "Stop patching"
        End If
    End Sub

    Public Sub StartPatching()
        Try
            bIsRunning = True

            Dim bAll As Boolean = False
            Dim bOverride As Boolean = False

            Dim oWebClient As New WebClient()

            Dim strFileMap As String = oWebClient.DownloadString(FILE_MAP_URI)
            Dim strFiles() As String = strFileMap.Split(vbLf)

            For i As Integer = 0 To strFiles.Length - 1
                Dim strFile As String = txtMinecraftPath.Text & strFiles(i).Substring(strFiles(i).IndexOf("/"))
                Dim oFileInfo As New FileInfo(strFile)

                AddLogEntry(vbCrLf & "Checking File " & i + 1 & "/" & strFiles.Length & "   -   " & oFileInfo.Name)

                If String.IsNullOrEmpty(oFileInfo.Extension) Then
                    If Not Directory.Exists(oFileInfo.FullName) Then
                        Directory.CreateDirectory(oFileInfo.FullName)
                        AddLogEntry(vbTab & "Creating Directory")
                    Else
                        AddLogEntry(vbTab & "Directory already exists")
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
                        AddLogEntry(vbTab & "Downloading File")
                        Try
                            oWebClient.DownloadFile(SERVER_URI & strFiles(i), oFileInfo.FullName)
                        Catch ex As Exception
                            AddLogEntry(vbTab & ex.Message)
                            AddLogEntry(vbTab & ex.InnerException.Message)
                        End Try
                    Else
                        AddLogEntry(vbTab & "File already exists")
                    End If
                End If
            Next
        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Me.Invoke(Sub() btnStartPatching.Text = "Start patching")
            Else
                MsgBox("ERROR Please report the following to the developer." & vbCrLf & vbCrLf & ex.Message)

                bIsRunning = False
            End If
        Finally
            bIsRunning = False
        End Try
    End Sub

    Public Sub AddLogEntry(ByVal strText As String)
        Me.Invoke(Sub()
                      txtLog.Text &= strText & vbCrLf
                      txtLog.SelectionStart = txtLog.Text.Length
                      txtLog.ScrollToCaret()
                  End Sub)
    End Sub
End Class