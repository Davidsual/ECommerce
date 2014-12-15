<%@ Page Language="C#" MasterPageFile="PerbaffoMaster.Master" AutoEventWireup="true"
    CodeBehind="ProdottoColore.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.ProdottoColore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .hide
        {
            display: none;
        }
        .dark_red
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
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
                            Gestione prodotti - Aggiunta colori
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
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tbody>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkA" title="Cerca tutti i prodotti che iniziano per A" CssClass="dark_red"
                                    runat="server" CommandName="a" OnClick="lnkSearch_Click" EnableViewState="false">(a)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkB" title="Cerca tutti i prodotti che iniziano per B" CssClass="dark_red"
                                    runat="server" CommandName="b" OnClick="lnkSearch_Click" EnableViewState="false">(b)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkC" title="Cerca tutti i prodotti che iniziano per C" CssClass="dark_red"
                                    runat="server" CommandName="c" OnClick="lnkSearch_Click" EnableViewState="false">(c)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkD" title="Cerca tutti i prodotti che iniziano per D" CssClass="dark_red"
                                    runat="server" CommandName="d" OnClick="lnkSearch_Click" EnableViewState="false">(d)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkE" title="Cerca tutti i prodotti che iniziano per E" CssClass="dark_red"
                                    runat="server" CommandName="e" OnClick="lnkSearch_Click" EnableViewState="false">(e)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkF" title="Cerca tutti i prodotti che iniziano per F" CssClass="dark_red"
                                    runat="server" CommandName="f" OnClick="lnkSearch_Click" EnableViewState="false">(f)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkG" title="Cerca tutti i prodotti che iniziano per G" CssClass="dark_red"
                                    runat="server" CommandName="g" OnClick="lnkSearch_Click" EnableViewState="false">(g)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkH" title="Cerca tutti i prodotti che iniziano per H" CssClass="dark_red"
                                    runat="server" CommandName="h" OnClick="lnkSearch_Click" EnableViewState="false">(h)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkI" title="Cerca tutti i prodotti che iniziano per I" CssClass="dark_red"
                                    runat="server" CommandName="i" OnClick="lnkSearch_Click" EnableViewState="false">(i)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkJ" title="Cerca tutti i prodotti che iniziano per J" CssClass="dark_red"
                                    runat="server" CommandName="j" OnClick="lnkSearch_Click" EnableViewState="false">(j)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkK" title="Cerca tutti i prodotti che iniziano per K" CssClass="dark_red"
                                    runat="server" CommandName="k" OnClick="lnkSearch_Click" EnableViewState="false">(k)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkL" title="Cerca tutti i prodotti che iniziano per L" CssClass="dark_red"
                                    runat="server" CommandName="l" OnClick="lnkSearch_Click" EnableViewState="false">(l)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkM" title="Cerca tutti i prodotti che iniziano per M" CssClass="dark_red"
                                    runat="server" CommandName="m" OnClick="lnkSearch_Click" EnableViewState="false">(m)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkN" title="Cerca tutti i prodotti che iniziano per N" CssClass="dark_red"
                                    runat="server" CommandName="n" OnClick="lnkSearch_Click" EnableViewState="false">(n)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkO" title="Cerca tutti i prodotti che iniziano per O" CssClass="dark_red"
                                    runat="server" CommandName="o" OnClick="lnkSearch_Click" EnableViewState="false">(o)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkP" title="Cerca tutti i prodotti che iniziano per P" CssClass="dark_red"
                                    runat="server" CommandName="p" OnClick="lnkSearch_Click" EnableViewState="false">(p)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkQ" title="Cerca tutti i prodotti che iniziano per Q" CssClass="dark_red"
                                    runat="server" CommandName="q" OnClick="lnkSearch_Click" EnableViewState="false">(q)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkR" title="Cerca tutti i prodotti che iniziano per R" CssClass="dark_red"
                                    runat="server" CommandName="r" OnClick="lnkSearch_Click" EnableViewState="false">(r)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkS" title="Cerca tutti i prodotti che iniziano per S" CssClass="dark_red"
                                    runat="server" CommandName="s" OnClick="lnkSearch_Click" EnableViewState="false">(s)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkT" title="Cerca tutti i prodotti che iniziano per T" CssClass="dark_red"
                                    runat="server" CommandName="t" OnClick="lnkSearch_Click" EnableViewState="false">(t)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkU" title="Cerca tutti i prodotti che iniziano per U" CssClass="dark_red"
                                    runat="server" CommandName="u" OnClick="lnkSearch_Click" EnableViewState="false">(u)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkV" title="Cerca tutti i prodotti che iniziano per V" CssClass="dark_red"
                                    runat="server" CommandName="v" OnClick="lnkSearch_Click" EnableViewState="false">(v)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkW" title="Cerca tutti i prodotti che iniziano per W" CssClass="dark_red"
                                    runat="server" CommandName="w" OnClick="lnkSearch_Click" EnableViewState="false">(w)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkY" title="Cerca tutti i prodotti che iniziano per Y" CssClass="dark_red"
                                    runat="server" CommandName="y" OnClick="lnkSearch_Click" EnableViewState="false">(y)</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkZ" title="Cerca tutti i prodotti che iniziano per Z" CssClass="dark_red"
                                    runat="server" CommandName="z" OnClick="lnkSearch_Click" EnableViewState="false">(z)</asp:LinkButton>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="updPnlColors" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table border="0" align="center" style="font-size: 10px; font-family: Verdana; font-weight: bold">
                <tr>
                    <td style="width: 45%;" align="left">
                        <asp:Panel ID="pnlRighe" runat="server" Visible="false">
                            <asp:Label ID="lblMessage" runat="server" CssClass="med_text" style="font-size:12;font-weight:bold;" Text="Nessuna variazione trovata" />
                         </asp:Panel>                      
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
