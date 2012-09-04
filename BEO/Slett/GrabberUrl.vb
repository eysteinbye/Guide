Imports System.Text.RegularExpressions

Public Class GrabberUrlX

    Public Shared Function FindUniqueLinksInString(str As String) As List(Of String)
        Dim tagList As MatchCollection = FindLinkTagsInString(str)
        Dim linkList As List(Of String) = FindAddressInTag(tagList)
        Dim uniqueList As List(Of String) = UniqueLinks(linkList)
        Return uniqueList
    End Function

    Private Shared Function FindLinkTagsInString(message As String) As MatchCollection
        '<a href="action.canalplus.no_2012-09-01.xml.gz">action.canalplus.no_..&gt;</a>
        Dim anchorPattern As String = "<a[\s]+[^>]*?href[\s]?=[\s\""']+(?<href>.*?)[\""\']+.*?>(?<fileName>[^<]+|.*?)?<\/a>"
        Dim matches As MatchCollection = Regex.Matches(message, anchorPattern, RegexOptions.IgnorePatternWhitespace Or RegexOptions.IgnoreCase Or RegexOptions.Multiline Or RegexOptions.Compiled)
        If matches.Count > 0 Then
            Return matches
        End If
        Return Nothing
    End Function

    Private Shared Function FindAddressInTag(linkTags As MatchCollection) As List(Of String)
        'action.canalplus.no_2012-09-01.xml.gz
        Dim uris As New List(Of String)()
        For Each link As Match In linkTags
            Dim regex As Regex = New Regex("a\s+href=""(.*?)""")
            Dim match As Match = regex.Match(link.ToString)
            If match.Success Then
                If match.Groups.Count > 0 Then
                    If match.Groups(1).Value.EndsWith(".xml.gz") Then
                        uris.Add(match.Groups(1).Value)
                    End If
                End If
            End If
        Next
        Return uris
    End Function

    Private Shared Function UniqueLinks(listOfLinks As List(Of String)) As List(Of String)
        Dim result As New List(Of String)
        Dim tmp As String
        For Each link As String In listOfLinks
            tmp = RemoveAfter(link, "_")
            If Not result.Exists(Function(x) x.ToString = tmp) Then
                result.Add(tmp)
            End If
        Next
        Return result
    End Function

    Private Shared Function RemoveAfter(str As String, delim As String) As String
        If str.IndexOf(delim) > 0 Then
            str = str.Substring(0, str.IndexOf(delim))
        End If
        Return str
    End Function

End Class
