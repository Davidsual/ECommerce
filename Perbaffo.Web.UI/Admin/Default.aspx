<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Perbaffo.Web.UI.Admin._Default" %>

<%@ Register TagPrefix="Menu" TagName="Menu" Src="Menu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        <!
        -- a
        {
            font-family: Verdana;
            color: #3366CC;
            text-decoration: none;
            font-size: 8pt;
        }
        -- ></style>
    <style>
        div.lm_tipBox
        {
            position: absolute;
            width: 0px;
            height: 0px;
            z-index: 10000000;
            border: 1pt black solid;
            background: #FFFFCC;
            visibility: hidden;
        }
    </style>
</head>
<body style="border: 0; margin: 0; padding: 0;font-family: Verdana; font-size: 8pt">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 1024px; height: 768px;">
        <tr>
            <td style="height: 80px; width: 100%; background-image: url(img/testa.jpg);" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 130px; height: 688px;">
                <Menu:Menu runat="server" ID="MenuControl" />
            </td>
            <td style="width: 894px; height: 688px;" valign="top">
                <asp:Panel ID="pnlDettaglio" runat="server">
                </asp:Panel>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
