﻿<%@ Page Language="C#" MasterPageFile="PerbaffoMaster.Master" AutoEventWireup="true"
    CodeBehind="ProdottoVariazione.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.ProdottoVariazione" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .hide
        {
            display: none;
        }
    </style>
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
                            Gestione prodotti - Aggiunta Variazioni
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
    <asp:UpdatePanel ID="updPnlColors" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table border="0" align="center" style="font-size: 10px; font-family: Verdana; font-weight: bold">
                <tr>
                    <td style="width: 45%;" align="left">
                        <asp:GridView ID="grdListaColori" runat="server" AutoGenerateColumns="False" BorderColor="White"
                            CellPadding="4" ForeColor="#333333" GridLines="None" CellSpacing="2">
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdentificativo" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Descrizione" DataField="Descrizione" />
                                <asp:TemplateField HeaderText="Scegli">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkScegli" runat="server" />
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
                    <td style="width: 10%;" align="center" valign="middle">
                        <asp:Button ID="btnAggiungi" runat="server" Text=">>" OnClick="btnAggiungi_Click" />
                    </td>
                    <td style="width: 45%;" align="left">
                        <asp:GridView ID="grdListaColoriProdotto" runat="server" AutoGenerateColumns="False"
                            BorderColor="White" CellPadding="4" ForeColor="#333333" GridLines="None" CellSpacing="2"
                            OnRowCommand="grdListaColoriProdotto_RowCommand" EmptyDataText="Nessun colore censito"
                            OnRowDeleting="grdListaColoriProdotto_RowDeleting">
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdentificativo" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Descrizione" DataField="Descrizione" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
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
</asp:Content>
