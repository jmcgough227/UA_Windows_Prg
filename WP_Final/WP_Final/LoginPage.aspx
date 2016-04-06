<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="WP_Final.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Please Log In</h1>
    <hr>
    <form runat="server">
      <table cellpadding="8">
        <tr>
          <td>
            User Name:
          </td>
          <td>
            <asp:TextBox ID="UserName" RunAt="server" />
          </td>
        </tr>
        <tr>	
          <td>
            Password:
          </td>
          <td>
            <asp:TextBox ID="Password" TextMode="password" runat="server" />
          </td>
        </tr>
        <tr>
          <td>
            <asp:Button Text="Log In" OnClick="OnLogIn" runat="server" />
          </td>
          <td>
            <asp:CheckBox Text="Keep me signed in" ID="Persistent"
              RunAt="server" />
          </td>
        </tr>
		<tr>
		  <td>
		    <asp:Button Text="Create New Account" OnClick="CreateNew" RunAt="Server" />
		  </td>
		</tr>
      </table>
    </form>
    <hr>
    <h3><asp:Label ID="Output" RunAt="server" /></h3>
  </body>
</html>
