<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="PerbaffoMaster.Master"
    CodeBehind="GestioneNewsLetter.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.GestioneNewsLetter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 688px; overflow: scroll;">
        <table border="0" width="98%" style="font-family: Verdana; font-size: 16pt; font-weight: bold">
            <tr>
                <td rowspan="2" width="80" height="64" align="center">
                    <img border="0" src="img/prodotti.gif" width="48" height="48">
                </td>
                <td>
                    <table border="0" width="100%" style="font-family: Verdana; font-size: 16pt; font-weight: bold;
                        border-bottom: 1px solid #D6DFF5; padding: 0">
                        <tr>
                            <td align="left" valign="middle" style="color: #3366CC">
                                Gestione NewsLetter - Export
                            </td>
                            <td align="right" valign="top">
                                <table border="0" style="padding: 0">
                                    <tr>
                                        <td align="right" valign="top">
                                            <asp:LinkButton ID="returnLink" runat="server" Style="font-size: 8pt; font-weight: normal"
                                                OnClick="returnLink_Click">Livello superiore</asp:LinkButton>
                                        </td>
                                        <td width="22">
                                            <asp:LinkButton ID="returnLink2" runat="server" OnClick="returnLink_Click"> <img border="0" src="img/up2.gif" width="22" height="22" alt="Livello superiore"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <asp:UpdatePanel ID="updPnlTotale" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table border="0" cellpadding="1" cellspacing="2" align="center" style="font-size: 10px;
                    width: 750px; font-family: Verdana; font-weight: bold">
                    <tr>
                        <td width="35%" align="right">
                            Newsletter Cani utenti Registrati:
                        </td>
                        <td align="left">
                            <asp:Label ID="lblNewsletterCani" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            &nbsp;&nbsp;<asp:Button ID="btnCani" runat="server" Text="Esporta" CommandName="CANI" OnClick="btnAction_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" align="right">
                            Newsletter Gatti utenti Registrati:
                        </td>
                        <td align="left">
                            <asp:Label ID="lblNewsletterGatti" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            &nbsp;&nbsp;<asp:Button ID="btnGatti" runat="server" Text="Esporta" CommandName="GATTI" OnClick="btnAction_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" align="right">
                            Newsletter Roditori utenti Registrati:
                        </td>
                        <td align="left">
                            <asp:Label ID="lblNewsletterRoditori" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            &nbsp;&nbsp;<asp:Button ID="btnRoditori" runat="server" Text="Esporta" CommandName="RODITORI" OnClick="btnAction_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" align="right">
                            Newsletter Voltatili utenti Registrati:
                        </td>
                        <td align="left">
                            <asp:Label ID="lblNewsletterVoltatili" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            &nbsp;&nbsp;<asp:Button ID="btnVolatili" runat="server" Text="Esporta" CommandName="VOLATILI" OnClick="btnAction_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" align="right">
                            Newsletter Pesci utenti Registrati:
                        </td>
                        <td align="left">
                            <asp:Label ID="lblNewsletterPesci" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            &nbsp;&nbsp;<asp:Button ID="btnPesci" runat="server" Text="Esporta" CommandName="PESCI" OnClick="btnAction_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
