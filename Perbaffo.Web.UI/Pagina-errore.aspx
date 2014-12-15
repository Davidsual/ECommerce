<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pagina-errore.aspx.cs" Inherits="Perbaffo.Web.UI.Pagina_errore" %>
<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="UserControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>
        <%=TitoloPagina%></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />        
    <link rel="shortcut icon" href="images/favicon.ico" />
    <meta name="Title" content="<%=TitoloPagina%>" /> 
    <meta name="description" content="<%=DescrizionePagina %>" />
    <meta name="keywords" content="<%=KeywordsPagina %>" />
    <meta name="Robots" content="index,follow" />
    <meta name="Author" content="Davide Trotta" />    
    <link rel="Stylesheet" type="text/css"  href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />
    
    <script type="text/javascript" src="script/Perbaffo.Web.UI.Function.js"></script>
   
</head>
<body>
<form runat="server" id="frmLogin">
    <UserControl:Header ID="Header1" runat="server" />
    
    <table border="0" cellspacing="0" cellpadding="0" style="width:1000px; background-color:#cddded;height:35px;">
        <tbody>
            <tr>
                <td align="left" class="topLeftStyle">
                </td>
                <td align="right" valign="middle">
                    <h1>
                        <b>Errore</b></h1>
                </td>
                <td align="right" class="topRightStyle">
                </td>
            </tr>
        </tbody>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="1000px">
        <tbody>
            <tr>
                <td class="ppmainleftline" width="10">
                    <img src="images/pixel.gif" width="12" height="12" alt="" />
                </td>
                <td class="bodycopy" align="center">
                    <br />
                    Ci scusiamo per l'errore, abbiamo provveduto a tracciare quest'errore in modo che non si verifichi più in futuro<br />
                    Grazie<br />
                    Lo Staff di Perbaffo<br /><br />
                    <table class="boundingbox" border="0" cellspacing="0" cellpadding="30" style="margin:20 0 0 0;width:450px">
                        <tbody>
                            <tr>
                                <td class="bodycopyy" style="background-color:#cddded;">
                                    <b>Errore durante le operazioni</b>
                                </td>
                            </tr>
                            <tr>
                                <td class="bodycopyy">
                                per eventuali informazioni contatta <a href="mailto:info@perbaffo.it?subject=Informazioni">info@perbaffo.it</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    
                    <img border="0" src="/images/pixel.gif" width="1" height="5" alt="" /><br />
                    <img border="0" src="/images/pixel.gif" width="1" height="5" alt="" /><br />
                </td>
                <td class="ppmainrightline" width="10">
                    <img src="images/pixel.gif" width="12" height="12" alt="" />
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 12px; height: 12px; background-image: url(images/main_botleft.gif);
                    background-repeat: no-repeat;">
                </td>
                <td class="ppmainbotline" style="height: 12px;">
                </td>
                <td align="right" style="width: 12px; height: 12px; background-image: url(images/main_botright.gif);
                    background-repeat: no-repeat;">
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
