Public Class ChannelMapperX

    Private Channels As Dictionary(Of String, String)


    Public Function GetChannelName(Id As String) As String
        Dim gg As New GrabberFile("http://data.epg.no/xmltv/channels.xml.gz")
        Dim xmlDocument As XDocument = gg.GetXmlContentFromZip()

        Dim displayName As String = ""
        If Not IsNothing(xmlDocument) Then
            Dim products = From product In xmlDocument.Element("tv").Elements("channel").ToList
            For Each product In products
                If product.Attribute("id").Value = Id Then
                    displayName = product.Element("display-name").Value
                End If
            Next
        End If

        If displayName = String.Empty Then
            ' Dette burde ikke være nødvendig.. men en fall-back
            Return CalcChannelName(Id)
        Else
            Return displayName
        End If


    End Function

    Private Function CalcChannelName(channelId As String) As String
        If Channels.ContainsKey(channelId) Then
            If Channels.Item(channelId) <> String.Empty Then
                Return Channels.Item(channelId)
            Else
                Return CreateNameFromId(channelId)
                ' Send waring on mail
            End If
        Else
            Return CreateNameFromId(channelId)
            ' Send waring on mail
        End If
    End Function

    Private Function CreateNameFromId(channelId As String) As String
        Dim result As String = String.Empty
        Dim name As String = channelId.Replace(".no", "")

        If name.Contains(".") Then
            Dim arr As String() = Split(name, ".")
            ' Only keep the two first
            Array.Resize(arr, 2)
            ' Reverse
            Array.Reverse(arr)
            For Each item As String In arr
                result &= UpCaseFirstLetter(item) & " "
            Next
        Else
            result = UpCaseFirstLetter(name)
        End If
        Return result
    End Function


    Private Function UpCaseFirstLetter(word As String) As String
        ' Convert to character array.
        Dim array() As Char = word.ToCharArray
        ' Uppercase first character.
        array(0) = Char.ToUpper(array(0))
        ' Return new string.
        Return New String(array)
    End Function

    Public Sub New()
        Channels = New Dictionary(Of String, String)
        Channels.Add("action.canalplus.no", "Canal+ Action")
        Channels.Add("action.tv1000.viasat.no", "")
        Channels.Add("animalplanet.discovery.no", "")
        Channels.Add("channels.xml.gz", "")
        Channels.Add("civilization.discovery.no", "")
        Channels.Add("classic.tv1000.viasat.no", "")
        Channels.Add("discovery.no", "")
        Channels.Add("disneychannel.no", "")
        Channels.Add("drama.canalplus.no", "")
        Channels.Add("drama.tv1000.viasat.no", "")
        Channels.Add("explorer.viasat.no", "")
        Channels.Add("family.tv1000.viasat.no", "")
        Channels.Add("fem.no", "")
        Channels.Add("filmhd.canalplus.no", "")
        Channels.Add("filmkanalen.tv2.no", "")
        Channels.Add("first.canalplus.no", "")
        Channels.Add("fotball.viasat.no", "")
        Channels.Add("golf.viasat.no", "Viasat Golf")
        Channels.Add("hd.animalplanet.discovery.no", "")
        Channels.Add("hd.discovery.no", "")
        Channels.Add("hd.tv1000.viasat.no", "")
        Channels.Add("history.viasat.no", "")
        Channels.Add("hits.canalplus.no", "")
        Channels.Add("max.no", "Max")
        Channels.Add("motor.viasat.no", "")
        Channels.Add("nature.viasat.no", "")
        Channels.Add("nordic.tv1000.viasat.no", "")
        Channels.Add("nrk1.nrk.no", "")
        Channels.Add("nrk2.nrk.no", "NRK 2")
        Channels.Add("nrk3.nrk.no", "")
        Channels.Add("nrk3super.nrk.no", "")
        Channels.Add("nrksuper.nrk.no", "")
        Channels.Add("nyhetskanalen.tv2.no", "")
        Channels.Add("pl1.tv2.no", "")
        Channels.Add("pl2.tv2.no", "")
        Channels.Add("pl3.tv2.no", "")
        Channels.Add("playhouse.disneychannel.no", "")
        Channels.Add("science.discovery.no", "")
        Channels.Add("series.canalplus.no", "")
        Channels.Add("sfkanalen.canalplus.no", "")
        Channels.Add("sport.tv2.no", "")
        Channels.Add("sport.viasat.no", "")
        Channels.Add("sport1.canalplus.no", "")
        Channels.Add("sport2.canalplus.no", "")
        Channels.Add("sport2.tv2.no", "")
        Channels.Add("sport3.tv2.no", "")
        Channels.Add("sport4.tv2.no", "")
        Channels.Add("sport5.tv2.no", "")
        Channels.Add("sportextra.canalplus.no", "")
        Channels.Add("sporthd.canalplus.no", "")
        Channels.Add("sporthd.viasat.no", "")
        Channels.Add("svt1.svt.se", "")
        Channels.Add("svt2.svt.se", "")
        Channels.Add("travel.discovery.no", "")
        Channels.Add("tv2.no", "")
        Channels.Add("tv3.viasat.dk", "")
        Channels.Add("tv3.viasat.no", "")
        Channels.Add("tv3.viasat.se", "")
        Channels.Add("tv4.se", "")
        Channels.Add("tv1000.viasat.no", "")
        Channels.Add("tvnorge.no", "")
        Channels.Add("viasat4.viasat.no", "")
        Channels.Add("voxtv.no", "")
        Channels.Add("xd.disneychannel.no", "")
        Channels.Add("zebra.tv2.no", "")
    End Sub

End Class
