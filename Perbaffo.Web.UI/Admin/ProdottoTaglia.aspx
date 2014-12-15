<%@ Page Title="" Language="C#" MasterPageFile="PerbaffoMaster.Master" AutoEventWireup="true"
    CodeBehind="ProdottoTaglia.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.ProdottoTaglia" %>

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
                            Gestione prodotti - Aggiunta taglia
                        </td>
                        <td align="right" valign="top">
                            <table border="0" style="padding: 0">
                                <tr>
                                    <td align="right" valign="top">
                                        <asp:LinkButton ID="returnLink" runat="server" Style="font-size: 8pt; font-weight: normal"
                                            OnClick="returnLink_Click">Livello superiore</asp:LinkButton>
                                    </td>
                                    <td width="22">
                                        <asp:LinkButton ID="returnLink2" runat="server" OnClick="returnLink_Click">
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
    <asp:UpdatePanel ID="updPnlListaTaglie" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table align="center" cellpadding="2" style="font-size: 10px; font-family: Verdana;
                border: 1px solid #D6DFF5;">
                <tr>
                    <td>
                        <asp:GridView ID="grdTaglie" runat="server" AutoGenerateColumns="False" BorderColor="White"
                            CellPadding="4" ForeColor="#333333" GridLines="None" CellSpacing="2" OnRowCommand="grdTaglie_RowCommand"
                            EmptyDataText="Nessuna taglia associata" OnRowDeleting="grdTaglie_RowDeleting"
                            Width="630px">
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdentificativo" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Codice" DataField="Codice" />
                                <asp:BoundField HeaderText="Taglia" DataField="DescrTaglia" />
                                <asp:BoundField HeaderText="Prezzo" DataField="Prezzo" />
                                <asp:BoundField HeaderText="Sconto (%)" DataField="ScontoPerc" />
                                <asp:BoundField HeaderText="Sconto (€)" DataField="ScontoEuro" />
                                <asp:BoundField HeaderText="Totale" DataField="Totale" />
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
                    </td>
                </tr>
            </table>
            <br />
            <table border="0" align="center" style="font-size: 10px; font-family: Verdana; font-weight: bold">
                            <tr>
                    <td width="50%" align="right">
                        Codice prodotto
                    </td>
                    <td width="50%" align="left">
                        <asp:TextBox ID="txtCodiceTaglia" runat="server" Width="221px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="txtCodiceTaglia" ErrorMessage="!" 
                            ValidationGroup="Taglia"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="50%" align="right">
                        Descrizione taglia
                    </td>
                    <td width="50%" align="left">
                        <asp:TextBox ID="txtDescrizioneTaglia" runat="server" Width="221px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtDescrizioneTaglia" ErrorMessage="!" 
                            ValidationGroup="Taglia"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="50%" align="right">
                        Prezzo
                    </td>
                    <td width="50%" align="left">
                        <asp:TextBox ID="txtPrezzo" runat="server" Width="221px">0,00</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtPrezzo" ErrorMessage="!" ValidationGroup="Taglia"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="50%" align="right">
                        Sconto (%)
                    </td>
                    <td width="50%" align="left">
                        <asp:TextBox ID="txtScontoPerc" runat="server" Width="221px">0</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtScontoPerc" ErrorMessage="!" ValidationGroup="Taglia"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="50%" align="right">
                        Sconto (€)
                    </td>
                    <td width="50%" align="left">
                        <asp:TextBox ID="txtScontoEuro" runat="server" Width="221px">0,00</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="txtScontoEuro" ErrorMessage="!" ValidationGroup="Taglia"></asp:RequiredFieldValidator>
                    </td>
                </tr>   
                <tr>
                    <td width="50%" align="right">
                        Totale
                    </td>
                    <td width="50%" align="left">
                            <asp:TextBox ID="txtTotale" runat="server" Text="da Calcolare" ReadOnly="true" Width="100px"></asp:TextBox>
                            <asp:Button ID="btnCalcola" runat="server" Text="Calcola" OnClick="btnCalcola_Click" />
                    </td>
                </tr>                       
                <tr>
                    <td width="50%" align="right">
                        <asp:Button ID="btnSalva" runat="server" Text="Salva" onclick="btnSalva_Click" 
                            />
                    </td>
                    <td width="50%" align="left">
                        <asp:Button ID="btnAnnulla" runat="server" Text="Annulla" onclick="btnAnnulla_Click" 
                             />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="Taglia" />
                    </td>
                </tr>                                                       
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
