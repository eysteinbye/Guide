Public Class Channel

    Public Property Programs As New List(Of Program)
    Public Property Info As ChannelInfo

    Private Sub New()

    End Sub

    Public Sub New(channelId As String, programDate As Date)
        Info = New ChannelInfo(channelId)

        Dim grabberAdr As New GrabberAddress(channelId, programDate)
        Dim grabber As New GrabberFile(grabberAdr.URL)

        Call Populate(grabber.GetXmlContentFromZip())
    End Sub

    Private Sub Populate(xmlContent As XDocument)
        If Not IsNothing(xmlContent) Then
            Dim products = From product In xmlContent.Element("tv").Elements("programme").ToList
            For Each product In products
                Dim tmpProg As New BEO.Program
                tmpProg.Title = product.Element("title").Value

                If Not IsNothing(product.Element("desc")) Then
                    tmpProg.Description = product.Element("desc").Value
                End If

                If Not IsNothing(product.Element("category")) Then
                    tmpProg.Category = product.Element("category").Value
                End If

                tmpProg.Channel = product.Attribute("channel").Value
                tmpProg.StartTime = BEO.GrabberDate.GetXmlContentDate(product.Attribute("start").Value)
                tmpProg.StopTime = BEO.GrabberDate.GetXmlContentDate(product.Attribute("stop").Value)
                Programs.Add(tmpProg)
            Next
        End If
    End Sub

End Class
