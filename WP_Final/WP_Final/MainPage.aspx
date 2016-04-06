<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="WP_Final.MainPage" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> ForumPoster </title>
    <style>
        body {
            background-color: lightgray;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <h1> Welcome to the ForumPoster Main Page! </h1>
    <div>
        <asp:Button ID="PostBtn" Text="Make a Post" runat="server" />
        <asp:Button ID="LogInBtn" Text="Log In" runat="server" />
        <asp:GridView ID="ForumView" BorderColor="Black" BorderWidth="2" Font-Name="Verdana" Font-Size="12pt"
            Gridlines="Horizontal" Width="90%" Border="double" AutoGenerateColumns="false"  runat="server"
            DataKeyNames="forum_id">
            <HeaderStyle BackColor="ForestGreen" />
            <Columns>
                <asp:BoundField HeaderText="Posted By" DataField="username" />
                <asp:BoundField HeaderText="Post Title" DataField="post_title" />
                <asp:BoundField HeaderText="Time Posted" DataField="post_time" />
            </Columns>
            <HeaderStyle BackColor="ForestGreen" ForeColor="White" Font-Bold="true" />
            <RowStyle BackColor="White" ForeColor="Black" />
            <AlternatingRowStyle BackColor="LightSalmon" ForeColor="Black" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
