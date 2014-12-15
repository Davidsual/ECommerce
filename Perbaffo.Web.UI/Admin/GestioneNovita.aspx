<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="PerbaffoMaster.Master"
    CodeBehind="GestioneNovita.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.GestioneNovita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updPnlListProdotti" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table border="0" width="98%" style="font-family: Verdana; font-size: 16pt; font-weight: bold">
                <tr>
                    <td rowspan="2" width="80" height="64" align="center">
                        <img border="0" src="img/prodotti.gif" width="48" height="48"/>
                    </td>
                    <td>
                        <table border="0" width="100%" style="font-family: Verdana; font-size: 16pt; font-weight: bold;
                            border-bottom: 1px solid #D6DFF5; padding: 0">
                            <tr>
                                <td align="left" valign="middle" style="color: #3366CC">
                                    Gestione Novita
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
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
            <center>
                <asp:GridView ID="grdListProdotti" runat="server" AutoGenerateColumns="False" BorderColor="White"
                    CellPadding="4" ForeColor="#333333" GridLines="None" Width="700px" 
                    CellSpacing="2" 
                    EmptyDataText="&lt;p&gt;&lt;b&gt;Non ci sono prodotti nuovi&lt;/b&gt;&lt;/p&gt;" 
                    onrowcommand="grdListProdotti_RowCommand" 
                    onrowediting="grdListProdotti_RowEditing">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                    <asp:BoundField HeaderText="Codice" DataField="Codice" />
                    <asp:TemplateField HeaderText="Descrizione">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnlDescr" CommandName="EDIT" CommandArgument='<%# Eval("ID") %>'
                                runat="server"><%# Eval("Nome") %> </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Prezzo Totale" DataField="Totale" />
                    <asp:BoundField HeaderText="Omaggio" DataField="IsOmaggio" />
                    <asp:BoundField HeaderText="Data Inserimento" DataField="DataInserimento" />
                    <asp:BoundField HeaderText="Attivo" DataField="Attivo" />
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <br/>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
