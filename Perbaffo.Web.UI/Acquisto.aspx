<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acquisto.aspx.cs" Inherits="Perbaffo.Web.UI.Acquisto" %>

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

    <script language="javascript" type="text/javascript">


        fInit();
        function fInit() {
            try {
                $(function() {
                    $("img[src*='L.jpg']").thumbPopup({
                        imgSmallFlag: "L",
                        imgLargeFlag: "H"
                    });
                });
            }
            catch (err) {
                return;
            }
        }
    </script>

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
                        <b>Dettagli pagamento</b></h1>
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
                        width: 800px; height: 429px;">
                        <tbody>
                            <tr>
                                <td class="bodycopyy" bgcolor="#cddded">
                                    <b>Dettagli Pagamento</b>
                                </td>
                            </tr>
                            <tr>
                                <td class="bodycopy" align="left" valign="top">
                                    <table cellspacing="0" cellpadding="4" width="100%" style="border-color: #000000;
                                        border-width: 0px; border-style: solid;">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <b>Ordine n° <span id="lblCodOrdine" runat="server"></span></b>
                                                </td>
                                                <td align="right" style="padding-right: 20px;">
                                                    <a href="javascript:window.print();" title="">
                                                        <img src="images/print.gif" width="42" height="42" style="border-color: #CDDDED;
                                                            border-style: solid; border-width: 1px;" alt="Stampa questa pagina" /></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bodycopy" style="padding-left: 4px;" valign="top" colspan="2">
                                                    <span class="med_text" style="color: Black;" id="lblTipoPagamento" runat="server">
                                                    </span>
                                                    <br />
                                                    <span class="med_text" style="color: Black;" id="lblDatiPagamento" runat="server">
                                                    </span>
                                                    <br />
                                                    <span class="med_text" style="color: Black;" id="lblImportoTotale" runat="server">
                                                    </span>
                                                    <div id="divPayPal" runat="server" visible="false">
                                                        <br />
                                                        <form action="https://www.paypal.com/cgi-bin/webscr" method="post">
                                                        <input type="hidden" name="cmd" value="_xclick" />
                                                        <input type="hidden" name="business" value="info@perbaffo.it" />
                                                        <input type="hidden" name="currency_code" value="EUR">
                                                        <input type="hidden" name="item_name" id="item_name" value="Ordine" runat="server" />
                                                        <input type="hidden" name="amount" id="amount" value="" runat="server" />
                                                        <input type="image" src="images/btn_buynowCC_LG.gif" style="border-width: 0px;" name="submit"
                                                            alt="PayPal - Il sistema di pagamento online più facile e sicuro!">
                                                        <img alt="" border="0" src="images/pixel.gif" width="1" height="1">
                                                        </form>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bodycopy" colspan="2">
                                                    <span class="med_text" style="color: Black;">Le è stata inviata un E-Mail riepilogativa
                                                        dell'ordine. </span>
                                                    <br />
                                                    <span class="med_text" style="color: Black;">Una volta ricevuto il pagamento provvederemo
                                                        in breve tempo a spedire l'ordine<br />
                                                        (max 5 giorni lavorativi dal ricevimento del pagamento).<br />
                                                        La contatteremo telefonicamento solo per avvertirla in merito a problemi o ritardi
                                                        di consegna.<br />
                                                        <br />
                                                        Cordiali saluti.<br />
                                                        Lo staff di Perbaffo </span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
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
