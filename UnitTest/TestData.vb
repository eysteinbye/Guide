Module TestData

    Private Pattern As String = "yyyy-MM-dd"

    Public Property TestDate As Date = Date.Today

    Public Property TestDateString As String = TestDate.ToString(Pattern)

    Public Property TestChannelName As String = "sporthd.viasat.no"



End Module
