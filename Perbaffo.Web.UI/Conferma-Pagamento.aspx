<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Conferma-Pagamento.aspx.cs" Inherits="Perbaffo.Web.UI.Conferma_Pagamento" %>
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
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
    <link rel="Stylesheet" type="text/css"  href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />
    <script language="javascript" type="text/javascript" src="HttpCombinerHandler.ashx?s=Set_JavascriptThumb&amp;t=text/javascript&amp;v=1" ></script>
</head>
<body>
    <form runat="server" id="frmLogin">
    <UserControl:Header ID="Header1" runat="server" />
    </form>
    <table border="0" cellspacing="0" cellpadding="0" style="width: 1000px; background-color: #cddded;
        height: 35px;">
        <tbody>
            <tr>
                <td align="left" class="topLeftStyle">
                </td>
                <td align="right" valign="middle">
                    <h1>
                        <b>Risultato Pagamento Paypal</b></h1>
                </td>
                <td align="right" class="topRightStyle">
                </td>
            </tr>
        </tbody>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="1000">
        <tbody>
            <tr>
                <td class="ppmainleftline" width="10">
                    <img src="images/pixel.gif" width="12" height="12" alt="" />
                </td>
                <td class="bodycopy" align="center">
                    <table class="boundingbox" border="0" cellspacing="0" cellpadding="10" style="margin: 20 0 0 0;
                        width: 500px;">
                        <tbody>
                            <tr>
                                <td class="bodycopyy" bgcolor="#cddded">
                                    <b>Risultato Pagamento - <span id="lblResult" runat="server"></span></b>  
                                </td>
                            </tr>
                            <tr>
                                <td class="bodycopy" align="left" valign="top">
                                    <div id="divSuccess" runat="server" visible="false">
                                        <table border="0" cellpadding="0" cellspacing="2" width="100%">
                                            <tbody>
                                                <tr>
                                                    <td><strong>Il tuo pagamento è stato confermato!</strong></td>
                                                </tr>
                                                <tr>
                                                    <td><span id="lblNome" runat="server"></span></td>
                                                </tr>
                                                <tr>
                                                    <td><span id="lblOrdine" runat="server"></span></td>
                                                </tr>    
                                                <tr>
                                                    <td><span id="lblTotale" runat="server"></span></td>
                                                </tr>     
                                                <tr>
                                                    <td>La ringraziamo ancora per la fiducia accordataci</td>
                                                </tr>     
                                                <tr>
                                                    <td>Lo Staff di Perbaffo</td>
                                                </tr>                                                                                                                                                                                         
                                            </tbody>
                                        </table>
                                    </div>
                                    <div id="divFail" runat="server" visible="false">
                                        <table border="0" cellpadding="0" cellspacing="2" width="100%">
                                            <tbody>
                                                <tr>
                                                    <td><strong>Siamo spiacenti ma il suo pagamento risulta non essere andato a buon fine!</strong></td>
                                                </tr>                                                         
                                                <tr>
                                                    <td>Per eventuali chiarimenti non esiti a contattare l'assistenza</td>
                                                </tr>    
                                                <tr>
                                                    <td>Contatti: <a href="Contatti.aspx" title="Contatta l'assistenza" class="dark_red"><b>Contatti</b></a></td>
                                                </tr>        
                                                <tr>
                                                    <td>Mail: <a href="mailto:info@perbaffo.it?subject=Pagamento ordine PayPal" class="dark_red" title="Contatta l'assistenza"><b>info@perbaffo.it</b></a></td>
                                                </tr>     
                                                <tr>
                                                    <td>Lo Staff di Perbaffo</td>
                                                </tr>                                                                                                                                                                                                                                 
                                            </tbody>
                                        </table>
                                    </div>                                    
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table border="0" cellspacing="0" cellpadding="0" style="margin: 20 0 0 0; width: 800px">
                        <tbody>
                            <tr>
                                <td class="bodycopyy" align="center">
                                    <a id="linkHomePage" runat="server" href="Default.aspx" title="Torna all'Home Page di Perbaffo"
                                        class="standardsubmitLink" style="color: #c61818; text-decoration: none;">Torna
                                        all'HomePage</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
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
</body>
</html>
