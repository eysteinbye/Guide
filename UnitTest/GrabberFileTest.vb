Imports System.Text
Imports System.Xml
Imports System.IO

<TestClass()>
Public Class GrabberFileTest

    Private program As New BEO.GrabberAddress(TestChannelName, TestDate)
    Private xmlFile As New BEO.GrabberFile(program.URL)

    <TestMethod()>
    Public Sub FileContentIsXML()
        Dim contents As String = xmlFile.GetContentFromZip()

        Dim expectedStart As String = "<?xml version"
        Assert.IsTrue(contents.StartsWith(expectedStart))
    End Sub

    <TestMethod()>
    Public Sub IsValidXml()
        Dim contents As XDocument = xmlFile.GetXmlContentFromZip()
        Dim systemId As String = contents.Document.DocumentType.SystemId
        Assert.AreEqual("xmltv.dtd", systemId)
    End Sub

End Class
