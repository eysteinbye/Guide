Imports System.Net
Imports System.IO.Compression
Imports System.Xml
Imports System.IO

Public Class GrabberFile

    Public Property FileStream As System.IO.Stream

    Public Sub New(url As String)
        Dim wb As New WebClient()
        Try
            FileStream = wb.OpenRead(url.ToString)
        Catch ex As WebException
            FileStream = Nothing
        End Try
    End Sub

    Private Function GetFileStreamZIP() As GZipStream
        Dim zip As GZipStream = Nothing
        If Not IsNothing(FileStream) Then
            zip = New GZipStream(FileStream, CompressionMode.Decompress)
        End If
        Return zip
    End Function

    Public Function GetContentFromZip() As String
        Dim contents As String = String.Empty
        If Not IsNothing(GetFileStreamZIP()) Then
            Dim responseReader = New IO.StreamReader(GetFileStreamZIP())
            contents = responseReader.ReadToEnd()
        End If
        Return contents
    End Function

    Public Function GetContent() As String
        Dim contents As String = String.Empty
        If Not IsNothing(FileStream) Then
            Dim responseReader = New IO.StreamReader(FileStream)
            contents = responseReader.ReadToEnd()
        End If
        Return contents
    End Function

    Public Function GetXmlContentFromZip() As XDocument
        Dim xmlDocument As XDocument = Nothing
        If Not IsNothing(GetFileStreamZIP()) Then
            xmlDocument = XDocument.Parse(GetContentFromZip())
        End If
        Return xmlDocument
    End Function

End Class
