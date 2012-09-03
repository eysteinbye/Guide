Imports System.Text

<TestClass()>
Public Class GrabberDateTest

    <TestMethod()>
    Public Sub GetFileNameDateString()
        Assert.AreEqual(TestDateString, BEO.GrabberDate.GetFileNameDateString(TestDate))
    End Sub

    <TestMethod()>
    Public Sub GetXmlContentDate()
        Dim testString As String = "20120825161000 +0200"
        Dim expected As New DateTime(2012, 8, 25, 16, 10, 0)

        Dim actual As DateTime = BEO.GrabberDate.GetXmlContentDate(testString)
        Assert.AreEqual(expected, actual)
    End Sub

End Class
