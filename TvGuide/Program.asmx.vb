Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Program
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetAllChannels() As List(Of String)
        Dim prg As New BEO.Program
        Return prg.GetAllChanels()
    End Function

    <WebMethod()> _
    Public Function GetProgramForChannel(channelName As String, programDate As Date) As List(Of BEO.Program)
        Dim ch As New BEO.Channel(channelName, programDate)
        Return ch.Programs
    End Function

    <WebMethod()> _
    Public Function GetTodaysProgramForChannels(channelNames As List(Of String)) As List(Of BEO.Program)
        Dim result As New List(Of BEO.Program)
        For Each channel In channelNames
            Dim ch As New BEO.Channel(channel, DateTime.Today)
            result.AddRange(ch.Programs)
        Next
        Return result
    End Function

End Class