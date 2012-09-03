<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="demo.aspx.vb" Inherits="TvGuide.demo" %>

<!DOCTYPE>

<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true"></asp:DropDownList>
    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>

    <asp:GridView runat="server" id="grid" AutoGenerateColumns="false">

    <Columns>
        <asp:BoundField HeaderText="Start" DataField="StartTime" DataFormatString="{0:t}" />
        <asp:BoundField HeaderText="End" DataField="StopTime" DataFormatString="{0:t}" />
        <asp:BoundField HeaderText="Title" DataField="Title" />
        <asp:BoundField HeaderText="Description" DataField="Description" />
    </Columns>
    
    </asp:GridView>
    </div>
    </form>
</body>
</html>
