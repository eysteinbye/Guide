
Public Class Guide
    Inherits System.Web.UI.Page

    Private Sub Guide_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim str As New StringBuilder

        Dim cl As New BEO.ChannelList


        For Each gg In cl.List

            str.Append(gg.Value & "<br>")
        Next


        For Each gg In cl.List


            Dim channel As New BEO.Channel(gg.Key, DateTime.Today)
            'channel.Info.Name

            If Not channel.Programs.Count = 0 Then

                '                Dim aa As BEO.Program = channel.Programs.Where(Function(x) x.StartTime <= DateTime.Now And x.StopTime >= DateTime.Now).FirstOrDefault
                Dim aa As BEO.Program = channel.Programs.FirstOrDefault
                If Not IsNothing(aa) Then
                    'Går
                    Try
                        str.Append(gg.Value & " - " & aa.Title & "<br>")
                    Catch ex As Exception
                        ex = ex
                    End Try

                Else

                    Dim bb As BEO.Program = channel.Programs.FirstOrDefault


                    str.Append(gg.Value & " ### " & bb.Title & "<br>")
                End If
            End If
            '

            '
        Next

        out.Text = str.ToString

    End Sub
End Class