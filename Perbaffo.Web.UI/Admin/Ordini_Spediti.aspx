<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="PerbaffoMaster.master" CodeBehind="Ordini_Spediti.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.Ordini_Spediti" %>
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
                                    Gestione Ordini Spediti
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
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td><a href="Ordini.aspx" style="font-size: 8pt; font-weight: normal">Ordini Nuovi</a> </td>
                        <td><a href="Ordini_Confermati.aspx" style="font-size: 8pt; font-weight: normal">Ordini Confermati</a></td>
                        <td><a href="Ordini_Archiviati.aspx" style="font-size: 8pt; font-weight: normal">Ordini Archiviati</a></td>
                        <td><a href="Ordini_Annullati.aspx" style="font-size: 8pt; font-weight: normal">Ordini Annullati</a></td>
                    </tr>
                    </table>                      
                    </td>
                </tr>
            </table>
            <center>
                <asp:GridView ID="grdListProdotti" runat="server" AutoGenerateColumns="False" BorderColor="White"
                    CellPadding="4" ForeColor="#333333" GridLines="None" Width="800px" CellSpacing="2"
                    OnRowCommand="grdListProdotti_RowCommand" OnRowEditing="grdListProdotti_RowEditing"
                    EmptyDataText="&lt;p&gt;&lt;b&gt;Nessun Ordine trovato&lt;/b&gt;&lt;/p&gt;" OnRowDataBound="grdListProdotti_RowDataBound">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField HeaderText="Codice" DataField="ID" />
                        <asp:TemplateField HeaderText="Descrizione">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnlDescr" CommandName="EDIT" CommandArgument='<%# Eval("ID") %>'
                                    runat="server">Ordine del: <%# Eval("DataOrdine")%> </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Utente">
                            <ItemTemplate>
                                <asp:Label ID="lblUtente" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField> 
                        <asp:BoundField HeaderText="Codice Sped" DataField="CodiceSpedizione" />
                        <asp:TemplateField HeaderText="Stato">
                            <ItemTemplate>
                                <span id="lblStato" runat="server"></span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Totale">
                            <ItemTemplate>
                                €&nbsp;<span><%# Eval("TotaleOrdine")%></span>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <br />
                <userControl:Pager ID="Pager" runat="server" Separator=" | " FirstText="Primo" PreviousText="<"
                    NextText=">" LastText="Ultimo" PageSize="10" NumberOfPages="50" ShowGoTo="True"
                    OnChange="Pager_Changed" />
                <hr color="#D6DFF5" size="1" width="100%"></hr>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
