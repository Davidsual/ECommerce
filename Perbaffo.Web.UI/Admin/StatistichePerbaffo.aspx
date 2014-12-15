<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="PerbaffoMaster.Master"
    CodeBehind="StatistichePerbaffo.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.StatistichePerbaffo" %>

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
                                Statistiche Perbaffo
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
        <p style="color: Red;">
            Statistiche Utenti</p>
        <table border="0" cellpadding="1" cellspacing="2" align="center" style="font-size: 10px;
            width: 750px; font-family: Verdana; font-weight: bold">
            <asp:Repeater ID="rptUtenti" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("Cognome")%>&nbsp;<%# Eval("Nome")%>&nbsp;&nbsp;(Totale Ordini:
                            <%# Eval("NumeroOrdini")%>)
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <br />
        <p style="color: Red;">
            Statistiche Prodotti</p>
        <table border="0" cellpadding="1" cellspacing="2" align="center" style="font-size: 10px;
            width: 750px; font-family: Verdana; font-weight: bold">
            <asp:Repeater ID="rptProdotti" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("Nome")%>&nbsp;&nbsp;(E' stato acquistato:
                            <%# Eval("NumeroOrdini")%>
                            volte)
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <br />
        <p style="color: Red;">
            Statistiche Omaggi</p>
        <table border="0" cellpadding="1" cellspacing="2" align="center" style="font-size: 10px;
            width: 750px; font-family: Verdana; font-weight: bold">
            <asp:Repeater ID="rptOmaggi" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("Nome")%>&nbsp;&nbsp;(E' stato scelto:
                            <%# Eval("Totale")%>
                            volte)
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <br />
        <p style="color: Red;">
            Statistiche Province</p>
        <table border="0" cellpadding="1" cellspacing="2" align="center" style="font-size: 10px;
            width: 750px; font-family: Verdana; font-weight: bold">
            <asp:Repeater ID="rptProvince" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("Provincia")%>&nbsp;&nbsp;(Sono stati effettuati:
                            <%# Eval("NumeroOrdini")%>
                            ordini)
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>      
        <br />  
        <p style="color: Red;">
            Compleanno:</p>
        <asp:Label ID="lblCompleanno" runat="server" Text="" style="font-size: 10px;font-family: Verdana; font-weight: bold"></asp:Label>
    </div>
</asp:Content>
