Imports System.IO.Compression
Imports System.Xml
Imports System.Net
Imports System.Globalization

Public Class demo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            DropDownList1.DataSource = {"motor.viasat.no", "sporthd.viasat.no", "tv2.no"}
            DropDownList1.DataBind()

            Calendar1.SelectedDate = Date.Today
        End If
    End Sub

    Private Sub Calendar1_SelectionChanged(sender As Object, e As System.EventArgs) Handles Calendar1.SelectionChanged
        Call Populate()
    End Sub

    Private Sub DropDownList1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Call Populate()
    End Sub

    Private Sub Populate()
        Dim channelName As String = DropDownList1.SelectedValue
        Dim programDate As Date = Calendar1.SelectedDate
        Dim ch As New BEO.Channel(channelName, programDate)

        grid.DataSource = ch.Programs
        grid.DataBind()
    End Sub

End Class