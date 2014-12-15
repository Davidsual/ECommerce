<%@ Page Title="" Language="C#" MasterPageFile="PerbaffoMaster.Master" AutoEventWireup="true"
    CodeBehind="ProdottoCategoria.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.ProdottoCategoria" %>

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
                            Gestione prodotti - Aggiunta categoria
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
    <asp:UpdatePanel ID="updPnlTree" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table border="0" align="left" style="font-size: 10px; font-family: Verdana; font-weight: bold"
                >
                <tr>
                    <td style="width:200px;">
                        <asp:TreeView ID="treeCategorie" runat="server">
                            <ParentNodeStyle Font-Bold="False" />
                            <SelectedNodeStyle BackColor="#D6DFF7" Font-Underline="False" HorizontalPadding="0px"
                                VerticalPadding="0px" />
                        </asp:TreeView>
                    </td>
                </tr>
            </table>
            <table border="0" align="left" style="font-size: 10px; font-family: Verdana; font-weight: bold"
                >
                <tr>
                    <td style="width:100px;" align="center">
                        <asp:Button ID="btnAggiungiCategoria" runat="server" Text="+" OnClick="btnAggiungiCategoria_Click" Width="30px"/>
                    </td>
                </tr>
                <tr>
                    <td style="width:100px;" align="center">
                        <asp:Button ID="btnEliminaCategoria" runat="server" Text="-" OnClick="btnEliminaCategoria_Click" Width="30px"/>
                    </td>
                </tr>
            </table>
            <table border="0" align="left" style="font-size: 10px; font-family: Verdana; font-weight: bold"
                >
                <tr>
                    <td style="width:150px;">
                        <asp:ListBox ID="lstProdottoCategorie" runat="server" Width="150px" Height="200px"></asp:ListBox>
                    </td>
                </tr>
            </table>
    <table border="0" style="font-size: 10px; font-family: Verdana; font-weight: bold">
        <tr>
            <td align="right" style="width:100px;">
                <asp:Button ID="btnSalva" runat="server" Text="Salva" OnClick="btnSalva_Click" />
            </td>
            <td align="left" style="width:100px;">
                <asp:Button ID="btnAnnulla" runat="server" Text="Annulla" OnClick="btnAnnulla_Click" />
            </td>
        </tr>
    </table>            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
