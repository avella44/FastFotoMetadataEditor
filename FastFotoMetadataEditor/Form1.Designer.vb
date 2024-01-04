<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        BrowseButton = New Button()
        FileListView = New ListView()
        Filename1 = New ColumnHeader()
        DateTaken1 = New ColumnHeader()
        Modified1 = New ColumnHeader()
        Button1 = New Button()
        Button2 = New Button()
        FileSystemWatcher1 = New IO.FileSystemWatcher()
        TextBox1 = New TextBox()
        LoadFolderButton = New Button()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        DateTimePicker1 = New DateTimePicker()
        RotateLeftButton1 = New Button()
        RotateLeftButton2 = New Button()
        RotateRightButton1 = New Button()
        RotateRightButton2 = New Button()
        CType(FileSystemWatcher1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BrowseButton
        ' 
        BrowseButton.Location = New Point(1042, 27)
        BrowseButton.Name = "BrowseButton"
        BrowseButton.Size = New Size(75, 23)
        BrowseButton.TabIndex = 1
        BrowseButton.Text = "Browse"
        BrowseButton.UseVisualStyleBackColor = True
        ' 
        ' FileListView
        ' 
        FileListView.Columns.AddRange(New ColumnHeader() {Filename1, DateTaken1, Modified1})
        FileListView.Location = New Point(39, 88)
        FileListView.Name = "FileListView"
        FileListView.Size = New Size(380, 571)
        FileListView.TabIndex = 3
        FileListView.UseCompatibleStateImageBehavior = False
        FileListView.View = View.Details
        ' 
        ' Filename1
        ' 
        Filename1.Text = "Filename"
        Filename1.Width = 200
        ' 
        ' DateTaken1
        ' 
        DateTaken1.Text = "Date taken"
        DateTaken1.Width = 100
        ' 
        ' Modified1
        ' 
        Modified1.Text = "Edited"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(1149, 12)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 4
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(1230, 12)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 23)
        Button2.TabIndex = 5
        Button2.Text = "Button2"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' FileSystemWatcher1
        ' 
        FileSystemWatcher1.EnableRaisingEvents = True
        FileSystemWatcher1.SynchronizingObject = Me
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(39, 27)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(997, 23)
        TextBox1.TabIndex = 7
        ' 
        ' LoadFolderButton
        ' 
        LoadFolderButton.Location = New Point(39, 56)
        LoadFolderButton.Name = "LoadFolderButton"
        LoadFolderButton.Size = New Size(134, 23)
        LoadFolderButton.TabIndex = 8
        LoadFolderButton.Text = "Load Folder Contents"
        LoadFolderButton.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
        PictureBox1.Location = New Point(515, 88)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(580, 580)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 9
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BorderStyle = BorderStyle.FixedSingle
        PictureBox2.Location = New Point(1124, 88)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(580, 580)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 10
        PictureBox2.TabStop = False
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.CustomFormat = ""
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.Location = New Point(194, 56)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(112, 23)
        DateTimePicker1.TabIndex = 11
        ' 
        ' RotateLeftButton1
        ' 
        RotateLeftButton1.Location = New Point(715, 59)
        RotateLeftButton1.Name = "RotateLeftButton1"
        RotateLeftButton1.Size = New Size(80, 23)
        RotateLeftButton1.TabIndex = 12
        RotateLeftButton1.Text = "Rotate Left"
        RotateLeftButton1.TextImageRelation = TextImageRelation.ImageAboveText
        RotateLeftButton1.UseVisualStyleBackColor = True
        ' 
        ' RotateLeftButton2
        ' 
        RotateLeftButton2.Location = New Point(1335, 59)
        RotateLeftButton2.Name = "RotateLeftButton2"
        RotateLeftButton2.Size = New Size(80, 23)
        RotateLeftButton2.TabIndex = 12
        RotateLeftButton2.Text = "Rotate Left"
        RotateLeftButton2.TextImageRelation = TextImageRelation.ImageAboveText
        RotateLeftButton2.UseVisualStyleBackColor = True
        ' 
        ' RotateRightButton1
        ' 
        RotateRightButton1.Location = New Point(801, 59)
        RotateRightButton1.Name = "RotateRightButton1"
        RotateRightButton1.Size = New Size(80, 23)
        RotateRightButton1.TabIndex = 12
        RotateRightButton1.Text = "Rotate Right"
        RotateRightButton1.TextImageRelation = TextImageRelation.ImageAboveText
        RotateRightButton1.UseVisualStyleBackColor = True
        ' 
        ' RotateRightButton2
        ' 
        RotateRightButton2.Location = New Point(1421, 59)
        RotateRightButton2.Name = "RotateRightButton2"
        RotateRightButton2.Size = New Size(80, 23)
        RotateRightButton2.TabIndex = 12
        RotateRightButton2.Text = "Rotate Right"
        RotateRightButton2.TextImageRelation = TextImageRelation.ImageAboveText
        RotateRightButton2.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1784, 861)
        Controls.Add(RotateLeftButton2)
        Controls.Add(RotateRightButton2)
        Controls.Add(RotateRightButton1)
        Controls.Add(RotateLeftButton1)
        Controls.Add(DateTimePicker1)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Controls.Add(LoadFolderButton)
        Controls.Add(TextBox1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(FileListView)
        Controls.Add(BrowseButton)
        Name = "Form1"
        Text = "Form1"
        CType(FileSystemWatcher1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents BrowseButton As Button
    Friend WithEvents FileListView As ListView
    Friend WithEvents Filename1 As ColumnHeader
    Friend WithEvents DateTaken1 As ColumnHeader
    Friend WithEvents Modified1 As ColumnHeader
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents FileSystemWatcher1 As IO.FileSystemWatcher
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents LoadFolderButton As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents RotateLeftButton1 As Button
    Friend WithEvents RotateLeftButton2 As Button
    Friend WithEvents RotateRightButton2 As Button
    Friend WithEvents RotateRightButton1 As Button

End Class
