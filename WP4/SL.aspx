<%@ Page Language="C#" Inherits="SLPage" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title> GiantDad </title>
    <link rel="stylesheet" type="text/css" href="SL.css">
</head>
<body>
    <hr />
    <h1> Welcome to GiantDad.com! </h1>
    <hr />

    <form runat="server">
        <h3> Current Records </h3>
        <asp:Table ID="RecordTable" Border="3" runat="server" />
        <br />
        <asp:Button ID="NewRecord" Text="Create Record" runat="server" />
        &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Button ID="ModRecord" Text="Modify Record" runat="server" />
        &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Button ID="DelRecord" Text="Delete Record" runat="server" />
    </form>
</body>
</html>
