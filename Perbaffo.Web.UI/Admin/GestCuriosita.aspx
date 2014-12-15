<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="PerbaffoMaster.Master"
    CodeBehind="GestCuriosita.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.GestCuriosita" %>
<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="userControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updPnlCuriosita" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table border="0" width="98%" style="font-family: Verdana; font-size: 16pt; font-weight: bold">
                <tr>
                    <td rowspan="2" width="80" height="64" align="center">
                        <img border="0" src="img/prodotti.gif" width="48" height="48" />
                    </td>
                    <td>
                        <table border="0" width="100%" style="font-family: Verdana; font-size: 16pt; font-weight: bold;
                            border-bottom: 1px solid #D6DFF5; padding: 0">
                            <tr>
                                <td align="left" valign="middle" style="color: #3366CC">
                                    Gestione Curiosità
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
                    <td height="10" align="center">
                        <font style="font-size: 12px;">Categoria curiosità&nbsp;&nbsp;<asp:DropDownList ID="ddlCategorie"
                            runat="server" Width="200" AutoPostBack="True" OnSelectedIndexChanged="ddlCategorie_SelectedIndexChanged">
                        </asp:DropDownList>
                        </font>
                    </td>
                </tr>
            </table>
            <center>
                <asp:GridView ID="grdCuriosita" runat="server" AutoGenerateColumns="False" BorderColor="White"
                    CellPadding="4" ForeColor="#333333" GridLines="None" Width="700px" CellSpacing="2"
                    EmptyDataText="Non ci sono curiosità" OnRowCommand="grdListProdotti_RowCommand"
                    OnRowEditing="grdListProdotti_RowEditing">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                        <asp:TemplateField HeaderText="Descrizione" ControlStyle-Width="250">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnlDescr" CommandName="EDIT" CommandArgument='<%# Eval("ID") %>'
                                    runat="server"><%# Eval("DescrCuriosita")%> </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Data Inserimento" DataField="DataInserimento" />
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
                            <usercontrol:pager id="Pager" runat="server" separator=" | " firsttext="Primo" previoustext="<"
                                nexttext=">" lasttext="Ultimo" pagesize="10" numberofpages="200" showgoto="True"
                                onchange="Pager_Changed" />
                        </td>
                    </tr>
                </table>
        </ContentTemplate>
    </asp:UpdatePanel>
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
                <a href="DettaglioCuriosita.aspx" style="font-size: 10px; font-family: Verdana; font-weight: normal">
                    <img border="0" src="img/filenew.gif"><br />
                        Aggiungi una curiosità<br />
                    </img>
                </a>
            </td>
        </tr>
    </table>
</asp:Content>
