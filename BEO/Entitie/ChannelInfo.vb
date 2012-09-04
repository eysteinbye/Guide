Public Class ChannelInfo

    Public Property Name As String
    Public Property LogoSmalUrl As String
    Public Property LogoBigUrl As String

    Public Sub New()

    End Sub

    Public Sub New(channelId As String)
        Dim channelMapper As New BEO.ChannelList
        Name = channelMapper.GetFullName(channelId)
        LogoSmalUrl = "http://www.loqal.no/uploads/images/kanalpakker/Golf.png"
    End Sub

End Class
