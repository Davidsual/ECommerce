<%@ Page Title="" Language="C#" MasterPageFile="PerbaffoMaster.Master" ValidateRequest="false"
    AutoEventWireup="true" CodeBehind="GestioneUtenti.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.GestioneUtenti" %>

<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="userControl" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                    Gestione Utenti
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
            <table align="center" cellpadding="2" style="font-size: 10px; font-family: Verdana;
                border: 1px solid #D6DFF5;">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        Nome\Cognome\E-Mail:
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtUtente" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnSearch" runat="server" Text="Visualizza" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
            <center>
                <asp:GridView ID="grdListUtenti" runat="server" AutoGenerateColumns="False" BorderColor="White"
                    CellPadding="4" ForeColor="#333333" GridLines="None" Width="700px" CellSpacing="2"
                    EmptyDataText="&lt;p&gt;&lt;b&gt;Non ci sono utenti registrati&lt;/b&gt;&lt;/p&gt;"
                    OnRowCommand="grdListUtenti_RowCommand" OnRowEditing="grdListUtenti_RowEditing">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField HeaderText="Nome" DataField="Nome" />
                        <asp:BoundField HeaderText="Cognome" DataField="Cognome" />
                        <asp:TemplateField HeaderText="EMail">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnlDescr" CommandName="EDIT" CommandArgument='<%# Eval("ID") %>'
                                    runat="server"><%# Eval("EMail")%> </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                        <asp:BoundField HeaderText="Attivo" DataField="IsAttivo" />
                        <asp:BoundField HeaderText="Data Iscr." DataField="DataCreazioneUtente" />
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
            </center>

        </ContentTemplate>
    </asp:UpdatePanel>
            <br />
            <table border="0" width="100%">
                <tr>
                    <td align="center" width="128">
                        <a href="DettagliUtente.aspx" style="font-size: 10px; font-family: Verdana; font-weight: normal">
                            <img border="0" src="img/filenew.gif"><br/>
                                Aggiungi un nuovo utente<br/>
                            </img>
                        </a>
                    </td>
                </tr>
            </table>    
</asp:Content>
