﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="choczero_wms.view" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:GridView ID="GridView1" runat="server" OnRowCreated="OnRowCreated">
            </asp:GridView>
            
        </div>
    </form>
</body>
</html>
