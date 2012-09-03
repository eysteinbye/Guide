Imports System.Globalization
Imports System.Text

Public Class GrabberAddress

    Public Property URL As String
    Public Sub New(channelName As String, programDate As Date)
        ' http://data.epg.no/xmltv/sporthd.viasat.no_2012-08-24.xml.gz
        Dim baseUrl As String = "http://data.epg.no/xmltv/"
        Dim extention As String = ".xml.gz"

        Dim urlString As New StringBuilder
        urlString.Append(baseUrl)
        urlString.Append(channelName)
        urlString.Append("_")
        urlString.Append(GrabberDate.GetFileNameDateString(programDate)) ' "2012-08-24"
        urlString.Append(extention)
        Me.URL = urlString.ToString
    End Sub


End Class
