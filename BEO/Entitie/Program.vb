Imports System.Text.RegularExpressions

Public Class Program

    Public Property StartTime As DateTime
    Public Property StopTime As DateTime
    Public Property Channel As String
    Public Property Title As String
    Public Property Category As String
    Public Property Description As String

    Public Function GetAllChanels() As List(Of String)
        Dim grabber As New BEO.GrabberFile("http://data.epg.no/xmltv/")
        Dim indexSource As String = grabber.GetContent()
        'action.canalplus.no_2012-09-01.xml.gz
        Dim listOfLinks As List(Of String) = findUris(indexSource)

        Return UniqueLinks(listOfLinks)
    End Function

    Private Function findUris(message As String) As List(Of String)
        Dim anchorPattern As String = "<a[\s]+[^>]*?href[\s]?=[\s\""']+(?<href>.*?)[\""\']+.*?>(?<fileName>[^<]+|.*?)?<\/a>"
        Dim matches As MatchCollection = Regex.Matches(message, anchorPattern, RegexOptions.IgnorePatternWhitespace Or RegexOptions.IgnoreCase Or RegexOptions.Multiline Or RegexOptions.Compiled)
        If matches.Count > 0 Then
            Dim uris As New List(Of String)()
            For Each m As Match In matches
                '<a href="action.canalplus.no_2012-09-01.xml.gz">action.canalplus.no_..&gt;</a>
                Dim regex As Regex = New Regex("a\s+href=""(.*?)""")
                Dim match As Match = regex.Match(m.ToString)
                If match.Success Then
                    If match.Groups.Count > 0 Then
                        If match.Groups(1).Value.EndsWith(".xml.gz") Then
                            uris.Add(match.Groups(1).Value)
                        End If
                    End If
                End If
            Next
            Return uris
        End If
        Return Nothing
    End Function

    Private Function UniqueLinks(listOfLinks As List(Of String)) As List(Of String)
        Dim result As New List(Of String)
        Dim tmp As String
        For Each link As String In listOfLinks
            If link.IndexOf("_") > 0 Then
                tmp = link.Substring(0, link.IndexOf("_"))
                If Not result.Exists(Function(x) x.ToString = tmp) Then
                    result.Add(tmp)
                End If
            End If
        Next
        Return result
    End Function

End Class
