Public Class ChannelList

    Public List As New Dictionary(Of String, String)
    '  Public ChannelIdList As List(Of String)

    Public Sub New()


        Dim gf As New GrabberFile(My.Settings.ChannelListUrl)
        Dim xmlDocument As XDocument = gf.GetXmlContentFromZip()

        If Not IsNothing(xmlDocument) Then
            Dim channelIdList = From product In xmlDocument.Element("tv").Elements("channel").ToList
            For Each channelId As XElement In channelIdList
                List.Add(channelId.Attribute("id").Value, channelId.Element("display-name").Value)
            Next
        End If
    End Sub

    Public Function GetFullName(channelId As String) As String
        Dim fullName As String = String.Empty
        If List.ContainsKey(channelId) Then
            If List.Item(channelId) <> String.Empty Then
                fullName = List.Item(channelId)
            End If
        End If
        Return fullName
    End Function

End Class
