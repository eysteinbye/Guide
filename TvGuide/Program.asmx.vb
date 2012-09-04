Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Services

<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tv-guide.apphb.com/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Program
    Inherits System.Web.Services.WebService

    Private serialize As New Script.Serialization.JavaScriptSerializer()

    <WebMethod()> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function GetAllChanels() As String
        Dim channelList As New BEO.ChannelList
        'Dim list As List(Of KeyValuePair(Of String, String)) = list.List.ToList
        Return serialize.Serialize(channelList.List.ToArray)
    End Function

    <WebMethod()> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function GetInfoForChannel(channelId As String) As String
        Return serialize.Serialize(New BEO.ChannelInfo(channelId))
    End Function

    <WebMethod()> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function GetProgramForChannel(channelName As String, programDate As Date) As String
        Dim ch As New BEO.Channel(channelName, programDate)
        Return serialize.Serialize(ch.Programs)
    End Function

    <WebMethod()> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function GetTodaysProgramForChannels(channelNames As List(Of String)) As String
        Dim result As New List(Of BEO.Program)
        For Each channel In channelNames
            Dim ch As New BEO.Channel(channel, DateTime.Today)
            result.AddRange(ch.Programs)
        Next
        Return serialize.Serialize(result)
    End Function

End Class