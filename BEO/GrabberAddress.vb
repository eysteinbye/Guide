Imports System.Globalization
Imports System.Text

Public Class GrabberAddress

    Public Property URL As String
    Public Sub New(channelId As String, programDate As Date)
        ' http://data.epg.no/xmltv/sporthd.viasat.no_2012-08-24.xml.gz
        Dim baseUrl As String = My.Settings.BaseUrl
        Dim extention As String = My.Settings.XmlExtention

        Dim urlString As New StringBuilder
        urlString.Append(baseUrl)
        urlString.Append(channelId)
        urlString.Append("_")
        urlString.Append(GrabberDate.GetFileNameDateString(programDate)) ' "2012-08-24"
        urlString.Append(extention)
        Me.URL = urlString.ToString
    End Sub


End Class
