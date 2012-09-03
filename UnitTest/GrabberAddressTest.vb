Imports System.Text

<TestClass()>
Public Class GrabberAddressTest

    <TestMethod()>
    Public Sub IsURLCorrect()
        Dim prog As New BEO.GrabberAddress(TestChannelName, New Date(2012, 8, 23))
        Assert.AreEqual("http://data.epg.no/xmltv/sporthd.viasat.no_2012-08-23.xml.gz", prog.URL)
    End Sub

 
End Class
