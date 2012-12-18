<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="HolyAngels.Web.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Simple Test
    <asp:TextBox ID="t" runat="server" />
    <asp:Button CausesValidation="true" runat="server" /><br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ErrorMessage="at least 1 lower, 1 upper, 1 number and 1 special character" 
            ControlToValidate="t" runat="server" EnableClientScript="true" 
            ValidationExpression="((?=.*[^a-zA-Z])(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{6,})" />
    </div>
    </form>
</body>
</html>
