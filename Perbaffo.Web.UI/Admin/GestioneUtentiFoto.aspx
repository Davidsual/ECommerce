<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestioneUtentiFoto.aspx.cs"
    MasterPageFile="PerbaffoMaster.Master" Inherits="Perbaffo.Web.UI.Admin.GestioneUtentiFoto" %>

<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="UserControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function fSubmit() {
            __doPostBack('Load', 'Reload');
        }
    </script>

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
                            Gestione Foto Utenti
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
    <asp:UpdatePanel ID="updPnlPhotoGallery" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <center>
                <UserControl:Pager ID="PagerHeader" runat="server" Separator=" | " FirstText="Primo"
                    PreviousText="&lt;" NextText="&gt;" LastText="Ultimo" PageSize="24" NumberOfPages="15"
                    ShowGoTo="True" OnChange="Pager_Changed" />
            </center>
            <br />
            <div style="width: 100%; height: 500px; overflow-y: scroll;">
                <table border="0" align="center" style="font-size: 10px; font-family: Verdana; font-weight: bold">
                    <tr>
                        <td>
                            <asp:DataList ID="rptPhoto" runat="server" RepeatDirection="Horizontal" BorderWidth="1"
                                Width="700px" OnItemCommand="rptPhoto_ItemCommand" RepeatColumns="6">
                                <ItemTemplate>
                                    <div style="width: 130px; height: 100px; text-align: center;">
                                        <img src='<%# CurrentPathFoto + "/" + Eval("ImgFriend") %>' alt='<%# Eval("NomeFriend") %>'
                                            width="100px" height="100px" />
                                        <asp:ImageButton ID="btnDelete" CommandName="DELETE" CommandArgument='<%# Eval("ID") %>'
                                            runat="server" ImageUrl="img/delete16.gif" Width="16px" Height="16px" />
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                </table>
                <br />
                <center>
                    <UserControl:Pager ID="PagerFooter" runat="server" Separator=" | " FirstText="Primo"
                        PreviousText="&lt;" NextText="&gt;" LastText="Ultimo" PageSize="24" NumberOfPages="15"
                        ShowGoTo="True" OnChange="Pager_Changed" />
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
