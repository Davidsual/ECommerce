<%@ Page Title="" Language="C#" MasterPageFile="PerbaffoMaster.Master" AutoEventWireup="true"
    CodeBehind="ProdottoRelazione.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.ProdottoRelazione" %>

<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="userControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                            Gestione prodotti - Aggiunta relazioni prodotti
                        </td>
                        <td align="right" valign="top">
                            <table border="0" style="padding: 0">
                                <tr>
                                    <td align="right" valign="top">
                                        <asp:LinkButton ID="returnLink" runat="server" 
                                            style="font-size: 8pt; font-weight: normal" onclick="returnLink_Click">Livello superiore</asp:LinkButton>
                                    </td>
                                    <td width="22">
                                        <asp:LinkButton ID="returnLink2" runat="server" onclick="returnLink_Click">
                                            <img border="0" src="img/up2.gif" width="22" height="22" alt="Livello superiore"></asp:LinkButton>
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
    <asp:UpdatePanel ID="updPnlListProdotti" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table align="center" cellpadding="1" style="font-size: 10px;
                font-family: Verdana;border: 1px solid #D6DFF5;">
                <tr>
                    <td>
                        Categoria:
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;<asp:DropDownList ID="ddCategorie" runat="server" Width="300px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Codice - Descrizione:
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCodiceDescrizione" runat="server" Width="301px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>                
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnSearch" runat="server" Text="Visualizza" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
            <center>
                <asp:GridView ID="grdListProdotti" runat="server" AutoGenerateColumns="False" BorderColor="White"
                    CellPadding="4" ForeColor="#333333" GridLines="None" Width="700px" CellSpacing="2"
                    OnRowCommand="grdListProdotti_RowCommand" 
                    OnRowEditing="grdListProdotti_RowEditing" 
                    EmptyDataText="&lt;p&gt;&lt;b&gt;Nessun prodotto trovato&lt;/b&gt;&lt;/p&gt;">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIdentificativo" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:BoundField HeaderText="Codice" DataField="Codice" />
                    <asp:BoundField HeaderText="Descrizione" DataField="Nome" />
                    <asp:BoundField HeaderText="Prezzo" DataField="Prezzo" />
                    <asp:BoundField HeaderText="Sconto (%)" DataField="ScontoPercent" />
                    <asp:BoundField HeaderText="Sconto (€)" DataField="ScontoEuro" />
                    <asp:BoundField HeaderText="Prezzo Totale" DataField="Totale" />
                    <asp:BoundField HeaderText="Omaggio" DataField="IsOmaggio" />
                    <asp:BoundField HeaderText="Attivo" DataField="Attivo" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnDelete" CommandName="ADD" CommandArgument='<%# Eval("ID") %>'
                                    runat="server" ImageUrl="img/add.gif" Width="16px" Height="16px" />
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
                <br/>
                <table border="0" cellpadding="0" cellspacing="0" width="80%">
                    <tr>
                        <td>
                            <userControl:Pager ID="Pager" runat="server" Separator=" | " FirstText="Primo" PreviousText="<"
                                NextText=">" LastText="Ultimo" PageSize="10" NumberOfPages="200" ShowGoTo="True"
                                OnChange="Pager_Changed" />
                        </td>
                    </tr>
                </table>
                <br />
                <center>
                <hr />
                    <p><b>Prodotti associati</b></p>
                    <asp:GridView ID="grdListaProdAssoc" runat="server" AutoGenerateColumns="False" BorderColor="White"
                        CellPadding="4" ForeColor="#333333" GridLines="None" CellSpacing="2" OnRowCommand="grdListaProdAssoc_RowCommand"
                        EmptyDataText="&lt;p&gt;&lt;b&gt;Nessun prodotto associato&lt;/b&gt;&lt;/p&gt;" 
                        OnRowDeleting="grdListaProdAssoc_RowDeleting" Width="700px">
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdentificativo" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Codice" DataField="Codice" />
                            <asp:BoundField HeaderText="Descrizione" DataField="Nome" />
                            <asp:BoundField HeaderText="Prezzo" DataField="Prezzo" />
                            <asp:BoundField HeaderText="Sconto (%)" DataField="ScontoPercent" />
                            <asp:BoundField HeaderText="Sconto (€)" DataField="ScontoEuro" />
                            <asp:BoundField HeaderText="Prezzo Totale" DataField="Totale" />
                            <asp:BoundField HeaderText="Omaggio" DataField="IsOmaggio" />
                            <asp:BoundField HeaderText="Attivo" DataField="Attivo" />
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDelete" CommandName="DELETE" CommandArgument='<%# Eval("ID") %>'
                                        runat="server" ImageUrl="img/delete16.gif" Width="16px" Height="16px" />
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
                    <table border="0" align="center" style="font-size: 10px; font-family: Verdana; font-weight: bold">
                        <tr>
                            <td>
                                <asp:Button ID="btnSalva" runat="server" Text="Salva" OnClick="btnSalva_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnAnnulla" runat="server" Text="Annulla" OnClick="btnAnnulla_Click" />
                            </td>
                        </tr>
                    </table>
                </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
