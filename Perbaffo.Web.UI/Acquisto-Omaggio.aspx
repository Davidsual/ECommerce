<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acquisto-Omaggio.aspx.cs"
    Inherits="Perbaffo.Web.UI.Acquisto_Omaggio" %>

<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="UserControl" %>
<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="UserControl" %>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" LoadScriptsBeforeUI="true">
    </asp:ScriptManager>
    <UserControl:Header ID="Header1" runat="server" />
    <table border="0" cellspacing="0" cellpadding="0" style="width: 1000px; background-color: #cddded;
        height: 35px;">
        <tbody>
            <tr>
                <td align="left" class="topLeftStyle">
                </td>
                <td align="right" valign="middle">
                    <h1>
                        <b>Scegli un omaggio</b></h1>
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
                    <img src="images/ordine_step_3.gif" title="Seleziona il tuo omaggio" width="479"
                        height="59" border="0" style="display: block" />
                    <span>Scegli il tuo omaggio e clicca su 'continua' a fondo pagina</span>
                    <asp:UpdatePanel ID="updPnlUtente" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table class="boundingbox" border="0" cellspacing="0" cellpadding="10" style="margin: 20 0 0 0;
                                width: 800px">
                                <tbody>
                                    <tr>
                                        <td class="bodycopyy" bgcolor="#cddded">
                                            <b>Scegli il tuo omaggio</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="bodycopy" align="center">
                                            <span class="med_text" style="color: Black;">Omaggio selezionato:&nbsp;</span><span
                                                id="lblNomeProdottoSceltoHeader" runat="server" class="med_text" style="color: Black;"></span>
                                            <UserControl:Pager ID="PagerHeader" runat="server" Separator=" | " FirstText="Primo"
                                                PreviousText="&lt;" NextText="&gt;" LastText="Ultimo" PageSize="10" NumberOfPages="15"
                                                ShowGoTo="True" OnChange="Pager_Changed" />
                                            <asp:Repeater ID="rptOfferte" runat="server" OnItemCommand="rptOfferte_ItemCommand">
                                                <ItemTemplate>
                                                    <table border="0" cellspacing="0" cellpadding="0" style="margin-top: 5px; width: 100%;">
                                                        <tbody>
                                                            <tr>
                                                                <td valign="top">
                                                                    <table border="0" cellspacing="0" cellpadding="0" style="width: 100%; height: 100%;">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td valign="top" align="center" style="width: 100px;">
                                                                                    <img src="<%= UrlImmagine %><%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).UrlImmagine%>"
                                                                                        alt="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrImmagine%>"
                                                                                        border="0" width="80px" height="80px" />
                                                                                </td>
                                                                                <td rowspan="2" width="1">
                                                                                    <img src="images/spacer.gif" width="5" height="140" alt="" />
                                                                                </td>
                                                                                <td valign="top" align="left">
                                                                                    <span class="med_text" id="lblNomeProdotto" runat="server"><b>
                                                                                        <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Nome%></b></span>
                                                                                    <br />
                                                                                    <span class="small_text" style="display: block;">
                                                                                        <%# TagliaStringa(((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrizioneLunga)%></span>
                                                                                    <br />
                                                                                    <span style="color: black; margin-right: 10px; font-size: 12px; background-color: Yellow;">
                                                                                        <b>Prodotto in omaggio per acquisti superiori a:</b></span> <span style="font-family: Verdana, sans-serif, arial,helvettica;
                                                                                            color: black; font-size: 12px;"><b>€
                                                                                                <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).RangeOmaggio%></b></span>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top" align="left" colspan="3">
                                                                                    <table border="0" cellspacing="0" cellpadding="2">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <img src="images/pixel.gif" width="1" height="20" alt="" />
                                                                                                </td>
                                                                                                <td bgcolor="#f5f5f5" valign="middle" align="center">
                                                                                                    <asp:Button class="standardsubmit" ID="btnScegli" CommandName="SCEGLI" CommandArgument="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>"
                                                                                                        runat="server" Text="Scegli" Style="cursor: pointer;" ToolTip="Scegli questo omaggio" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3">
                                                                                    <img src="/images/pixel.gif" width="1" height="4" alt="" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3" style="background-image: url(images/bar_red.gif); background-repeat: repeat-x"
                                                                                    align="center">
                                                                                    <img src="/images/pixel.gif" width="1" height="4" alt="" />
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <UserControl:Pager ID="PagerFooter" runat="server" Separator=" | " FirstText="Primo"
                                                PreviousText="&lt;" NextText="&gt;" LastText="Ultimo" PageSize="10" NumberOfPages="15"
                                                ShowGoTo="True" OnChange="Pager_Changed" />
                                            <span class="med_text" style="color: Black;">Omaggio selezionato:&nbsp;</span><span
                                                id="lblNomeProdottoSceltoFooter" runat="server" class="med_text" style="color: Black;"></span>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table border="0" cellspacing="0" cellpadding="0" style="margin: 20 0 0 0; width: 800px">
                                <tbody>
                                    <tr>
                                        <td class="bodycopyy" align="right">
                                            <asp:Button ID="btnContinua" runat="server" Text="Continua &gt;&gt;" CssClass="standardsubmitCancella"
                                                TabIndex="19" ToolTip="Vai al riepilogo per confermare l'ordine" ValidationGroup="ORDINE"
                                                OnClick="btnContinua_Click" />
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="ORDINE" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
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
