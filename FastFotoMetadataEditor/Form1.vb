Imports System.IO
Imports System.Diagnostics
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Drawing.Imaging

Public Class Form1
    Dim loaded_image_filepath As String = ""
    Dim loaded_secondary_image_filepath As String = ""

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = "C:\Users\Anthony\Desktop\FastFoto pics for testing\1989_for_testing"

    End Sub


    Private Sub GetFilesInDirectory()
        FileListView.Items.Clear()
        FileListView.Items.Add("Loading folder contents...")

        Dim strFileSize As String = ""
        Dim di As New IO.DirectoryInfo(TextBox1.Text)
        Dim aryFi As IO.FileInfo() = di.GetFiles("*.jpg")
        Dim fi As IO.FileInfo

        Dim directoryDateTakenStrings As String = ExifGetImageDateTaken(TextBox1.Text)

        Dim regexString As String
        Dim regex As Regex

        FileListView.Items.Clear()
        For Each fi In aryFi
            If fi.Name.Substring(fi.Name.Length - 6, 2) <> "_b" Then
                Debug.WriteLine(fi.Name)

                Dim item = New ListViewItem(fi.Name)

                'Parse results
                regexString = "(?<=" & fi.Name & "\r\nDateTimeOriginal: )[0-9]{2}/[0-9]{2}/[0-9]{4}"
                regex = New Regex(regexString)
                Dim match As Match = regex.Match(directoryDateTakenStrings)
                If match.Success Then
                    item.SubItems.Add(match.Value)
                Else
                    item.SubItems.Add("")
                End If

                item.SubItems.Add("")

                FileListView.Items.Add(item)
            End If

        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GetFilesInDirectory()
        'ExifGetImageDateTaken(DirectoryTextBox.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Debug.WriteLine(FileListView.Items(0).SubItems(2).Text)
        'FileListView.Items(0).SubItems(2).Text = "Yes"
        RotateImageRight(loaded_image_filepath)
        DisplayImages()
    End Sub


    Private Shared Function ExifGetImageDateTaken(directory As String) As String
        If directory(directory.Length - 1) <> "\" Then
            directory &= "\"
        End If

        Dim processOutput As New StringBuilder()

        Dim ExifToolGetDateTaken As New Process

        ExifToolGetDateTaken.StartInfo.FileName = "C:\WINDOWS\exiftool.exe"
        ExifToolGetDateTaken.StartInfo.Arguments = "-if ""$DateTimeOriginal"" -DateTimeOriginal -fast -S -ext jpg -d ""%m/%d/%Y"" """ + directory + "."""
        ExifToolGetDateTaken.StartInfo.UseShellExecute = False
        ExifToolGetDateTaken.StartInfo.RedirectStandardOutput = True
        ExifToolGetDateTaken.StartInfo.CreateNoWindow = True

        ExifToolGetDateTaken.Start()
        Dim result As String = ExifToolGetDateTaken.StandardOutput.ReadToEnd()
        'pbx.Image = New Bitmap(ExifTool.StandardOutput.BaseStream).GetThumbnailImage(120, 80, Nothing, Nothing)
        ExifToolGetDateTaken.Close()

        Debug.WriteLine(result)
        Return result

    End Function

    Private Sub BrowseButton_Click(sender As Object, e As EventArgs) Handles BrowseButton.Click
        FolderBrowserDialog1.InitialDirectory = TextBox1.Text
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub DirectoryTextBox_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'If Not TextBox1.Focused Then
        '    GetFilesInDirectory()
        'End If
        Debug.WriteLine("event")

    End Sub

    Private Sub LoadFolderButton_Click(sender As Object, e As EventArgs) Handles LoadFolderButton.Click
        GetFilesInDirectory()
    End Sub

    Private Sub FileListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FileListView.SelectedIndexChanged
        'Display photo when selected
        If FileListView.SelectedItems.Count > 0 Then
            DisplayImages()
        End If
    End Sub

    Public Shared Function GetMemoryBitmapFromFile(path As String) As Bitmap
        Dim bm As Bitmap
        Using img As Image = Image.FromFile(path)
            'Rotate image if EXIF orientation data exists (https://stackoverflow.com/questions/19306564/correcting-image-orientation-server-side-in-vb-net)
            Dim rft As RotateFlipType = RotateFlipType.RotateNoneFlipNone
            For Each p As PropertyItem In img.PropertyItems
                If p.Id = 274 Then
                    Dim orientation As Short = BitConverter.ToInt16(p.Value, 0)
                    Select Case orientation
                        Case 1
                            rft = RotateFlipType.RotateNoneFlipNone
                        Case 3
                            rft = RotateFlipType.Rotate180FlipNone
                        Case 6
                            rft = RotateFlipType.Rotate90FlipNone
                        Case 8
                            rft = RotateFlipType.Rotate270FlipNone
                    End Select
                End If
            Next
            If rft <> RotateFlipType.RotateNoneFlipNone Then
                img.RotateFlip(rft)
            End If

            'Create a copy of the image. The original image is released when the "Using" block is exited, so that the file will no longer be locked for editing.
            bm = New Bitmap(img)
        End Using
        Return bm
    End Function

    Private Sub DisplayImages()
        'Display main photo
        Dim filename = FileListView.SelectedItems(0).Text
        Dim directory = TextBox1.Text
        If directory(directory.Length - 1) <> "\" Then
            directory &= "\"
        End If

        Dim fullFilepath As String = directory & filename
        PictureBox1.Image = GetMemoryBitmapFromFile(fullFilepath)
        loaded_image_filepath = fullFilepath

        'Display "_b" photo if it exists
        fullFilepath = fullFilepath.Replace(".jpg", "_b.jpg")
        Dim secondary_image_exists As Boolean = File.Exists(fullFilepath)
        If secondary_image_exists Then
            loaded_secondary_image_filepath = fullFilepath
            PictureBox2.Image = GetMemoryBitmapFromFile(fullFilepath)
        Else
            loaded_secondary_image_filepath = ""
            PictureBox2.Image = Nothing
        End If
    End Sub

    Private Function GetImageOrientation(fullFilepath As String) As Integer
        ' Returns the EXIF data for the orientation of a JPG image
        ' 0 = no metadata exists
        ' 1 = Horizontal (normal)
        ' 2 = Mirror horizontal
        ' 3 = Rotate 180
        ' 4 = Mirror vertical
        ' 5 = Mirror horizontal And rotate 270 CW
        ' 6 = Rotate 90 CW
        ' 7 = Mirror horizontal And rotate 90 CW
        ' 8 = Rotate 270 CW

        Dim processOutput As New StringBuilder()

        Dim ExifToolGetDateTaken As New Process

        ExifToolGetDateTaken.StartInfo.FileName = "C:\WINDOWS\exiftool.exe"
        ExifToolGetDateTaken.StartInfo.Arguments = "-orientation# -S """ + fullFilepath + """"
        ExifToolGetDateTaken.StartInfo.UseShellExecute = False
        ExifToolGetDateTaken.StartInfo.RedirectStandardOutput = True
        ExifToolGetDateTaken.StartInfo.CreateNoWindow = True

        ExifToolGetDateTaken.Start()
        Dim result As String = ExifToolGetDateTaken.StandardOutput.ReadToEnd()
        ExifToolGetDateTaken.Close()

        'Parse result
        Dim regex As Regex
        regex = New Regex("(?<=Orientation: )[1-8]")
        Dim match As Match = regex.Match(result)
        If match.Success Then
            Return Convert.ToInt32(match.Value)
        Else
            Return 0
        End If

    End Function

    Private Function SetImageOrientation(fullFilepath As String, new_orientation As Integer) As Boolean
        ' Set the EXIF data for the orientation of a JPG image
        ' 1 = Horizontal (normal)
        ' 2 = Mirror horizontal
        ' 3 = Rotate 180
        ' 4 = Mirror vertical
        ' 5 = Mirror horizontal And rotate 270 CW
        ' 6 = Rotate 90 CW
        ' 7 = Mirror horizontal And rotate 90 CW
        ' 8 = Rotate 270 CW

        Dim processOutput As New StringBuilder()

        Dim ExifToolGetDateTaken As New Process

        ExifToolGetDateTaken.StartInfo.FileName = "C:\WINDOWS\exiftool.exe"
        ExifToolGetDateTaken.StartInfo.Arguments = "-orientation#=" & new_orientation.ToString("0") & " -S """ + fullFilepath + """ -overwrite_original"
        ExifToolGetDateTaken.StartInfo.UseShellExecute = False
        ExifToolGetDateTaken.StartInfo.RedirectStandardOutput = True
        ExifToolGetDateTaken.StartInfo.CreateNoWindow = True

        ExifToolGetDateTaken.Start()
        Dim result As String = ExifToolGetDateTaken.StandardOutput.ReadToEnd()
        ExifToolGetDateTaken.Close()

        Return result.Contains("1 image files updated")
    End Function

    Private Function RotateImageRight(fullFilepath As String) As Boolean
        Dim orientation As Integer
        Dim new_orientation As Integer
        orientation = GetImageOrientation(fullFilepath)
        Select Case orientation
            Case 0
                new_orientation = 6
            Case 1
                new_orientation = 6
            Case 2
                new_orientation = 7
            Case 3
                new_orientation = 8
            Case 4
                new_orientation = 5
            Case 5
                new_orientation = 2
            Case 6
                new_orientation = 3
            Case 7
                new_orientation = 4
            Case 8
                new_orientation = 1
        End Select

        Dim success As Boolean = SetImageOrientation(fullFilepath, new_orientation)
        Return success
    End Function

    Private Function RotateImageLeft(fullFilepath As String) As Boolean
        Dim orientation As Integer
        Dim new_orientation As Integer
        orientation = GetImageOrientation(fullFilepath)
        Select Case orientation
            Case 0
                new_orientation = 8
            Case 1
                new_orientation = 8
            Case 2
                new_orientation = 5
            Case 3
                new_orientation = 6
            Case 4
                new_orientation = 7
            Case 5
                new_orientation = 4
            Case 6
                new_orientation = 1
            Case 7
                new_orientation = 2
            Case 8
                new_orientation = 3
        End Select


        Dim success As Boolean = SetImageOrientation(fullFilepath, new_orientation)
        Return success
    End Function

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub RotateLeftButton1_Click(sender As Object, e As EventArgs) Handles RotateLeftButton1.Click
        If File.Exists(loaded_image_filepath) Then
            RotateImageLeft(loaded_image_filepath)
            DisplayImages()
        End If
    End Sub

    Private Sub RotateRightButton1_Click(sender As Object, e As EventArgs) Handles RotateRightButton1.Click
        If File.Exists(loaded_image_filepath) Then
            RotateImageRight(loaded_image_filepath)
            DisplayImages()
        End If
    End Sub

    Private Sub RotateLeftButton2_Click(sender As Object, e As EventArgs) Handles RotateLeftButton2.Click
        If File.Exists(loaded_secondary_image_filepath) Then
            RotateImageLeft(loaded_secondary_image_filepath)
            DisplayImages()
        End If
    End Sub

    Private Sub RotateRightButton2_Click(sender As Object, e As EventArgs) Handles RotateRightButton2.Click
        If File.Exists(loaded_secondary_image_filepath) Then
            RotateImageRight(loaded_secondary_image_filepath)
            DisplayImages()
        End If
    End Sub
End Class



