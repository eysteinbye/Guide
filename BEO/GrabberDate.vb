Imports System.Globalization

Public Class GrabberDate

    Public Shared Function GetFileNameDateString(programDate As Date) As String
        Dim pattern As String = "yyyy-MM-dd"
        Return programDate.ToString(pattern)
    End Function

    Public Shared Function GetXmlContentDate(contentDate As String) As DateTime
        '20120825125500 +0200
        ' todo: From GMT
        contentDate = contentDate.Replace(" +0200", "")

        Dim progTime As DateTime
        Try
            progTime = DateTime.ParseExact(contentDate, "yyyyMMddHHmmss", CultureInfo.InvariantCulture)
        Catch ex As Exception
            ex = ex
        End Try

        Return progTime
    End Function

End Class
