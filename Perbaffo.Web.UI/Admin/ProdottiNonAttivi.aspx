<%@ Page Language="C#" MasterPageFile="PerbaffoMaster.master" AutoEventWireup="true"
    CodeBehind="ProdottiNonAttivi.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.ProdottiNonAttivi" %>

<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="userControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updPnlListProdotti" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table border="0" width="100%" style="font-family: Verdana; font-size: 16pt; font-weight: bold;">
                <tr>
                    <td rowspan="2" width="80" height="64" align="center">
                        <img border="0" src="img/prodotti.gif" width="48" height="48">
                    </td>
                    <td>
                        <table border="0" width="100%" style="font-family: Verdana; font-size: 16pt; font-weight: bold;
                            border-bottom: 1px solid #D6DFF5; padding: 0">
                            <tr>
                                <td align="left" valign="middle" style="color: #3366CC">
                                    Gestione prodotti
                                </td>
                                <td align="right" valign="top">
                                    <table border="0" style="padding: 0">
                                        <tr>
                                            <td align="right" valign="top">
                                                <a href="Homepage.aspx" style="font-size: 8pt; font-weight: normal">Livello superiore</a>
                                            </td>
                                            <td width="22">
                                                <a href="Homepage.aspx">
                                                    <img border="0" src="img/up2.gif" width="22" height="22" alt="Livello superiore"></a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
            <center>
                <asp:GridView ID="grdListProdotti" runat="server" AutoGenerateColumns="False" BorderColor="White"
                    CellPadding="4" ForeColor="#333333" GridLines="None" Width="700px" CellSpacing="2"
                    OnRowCommand="grdListProdotti_RowCommand" OnRowEditing="grdListProdotti_RowEditing"
                    EmptyDataText="&lt;p&gt;&lt;b&gt;Nessun prodotto trovato&lt;/b&gt;&lt;/p&gt;">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField HeaderText="Codice" DataField="Codice" />
                        <asp:TemplateField HeaderText="Descrizione">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnlDescr" CommandName="EDIT" CommandArgument='<%# Eval("ID") %>'
                                    runat="server"><%# Eval("Nome") %> </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Prezzo" DataField="Prezzo" />
                        <asp:BoundField HeaderText="Sconto (%)" DataField="ScontoPercent" />
                        <asp:BoundField HeaderText="Sconto (€)" DataField="ScontoEuro" />
                        <asp:BoundField HeaderText="Prezzo Totale" DataField="Totale" />
                        <asp:BoundField HeaderText="Omaggio" DataField="IsOmaggio" />
                        <asp:BoundField HeaderText="Attivo" DataField="Attivo" />
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <br />
                <table border="0" cellpadding="0" cellspacing="0" width="80%">
                    <tr>
                        <td>
                            <userControl:Pager ID="Pager" runat="server" Separator=" | " FirstText="Primo" PreviousText="<"
                                NextText=">" LastText="Ultimo" PageSize="10" NumberOfPages="200" ShowGoTo="True"
                                OnChange="Pager_Changed" />
                        </td>
                    </tr>
                </table>
                <table border="0" width="100%">
                    <tr>
                        <td align="center" valign="middle">
                            <hr color="#D6DFF5" size="1" width="20"></hr>
                        </td>
                        <td align="center" style="font-size: 10px; font-family: Verdana; font-weight: bold">
                            Operazioni
                        </td>
                        <td align="center" valign="middle" width="100%">
                            <hr color="#D6DFF5" size="1"></hr>
                        </td>
                    </tr>
                </table>
                <table border="0" width="100%">
                    <tr>
                        <td align="center">
                            <a href="DettaglioProdotto.aspx" style="font-size: 10px; font-family: Verdana; font-weight: normal">
                                <img border="0" src="img/filenew.gif"><br />
                                    Aggiungi un nuovo prodotto<br />
                                </img>
                            </a>
                        </td>
                    </tr>
                </table>
                <hr color="#D6DFF5" size="1" width="100%"></hr>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
