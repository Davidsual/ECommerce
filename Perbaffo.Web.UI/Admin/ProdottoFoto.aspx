<%@ Page Title="" Language="C#" MasterPageFile="PerbaffoMaster.Master" AutoEventWireup="true"
    CodeBehind="ProdottoFoto.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.ProdottoFoto" %>
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
                            Gestione prodotti - Aggiunta immagini
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
    <asp:UpdatePanel ID="updPnlPreviewFoto" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table border="0" align="center" style="font-size: 10px; font-family: Verdana; font-weight: bold">
                <tr>
                    <td width="50%" align="right">
                        Immagine piccola (80 X 80):
                    </td>
                    <td width="50%" align="left">
                        <asp:Image ID="imgPiccola" runat="server" Width="80px" Height="80px" />
                        <asp:ImageButton ID="btnEliminaImagePiccola" runat="server" ImageUrl="img/delete16.gif"
                            Width="16px" Height="16px" OnClick="btnEliminaImage_Click" 
                            CommandName="PICCOLA" ToolTip="Elimina foto piccola" />
                    </td>
                </tr>
                <tr>
                    <td width="50%" align="right">
                        Immagine grande (240 X 240):
                    </td>
                    <td width="50%" align="left">
                        <asp:Image ID="imgGrande" runat="server" Width="240px" Height="240px" />
                        <asp:ImageButton ID="btnEliminaImageGrande" runat="server" ImageUrl="img/delete16.gif"
                            Width="16px" Height="16px" OnClick="btnEliminaImage_Click" 
                            CommandName="GRANDE" ToolTip="Elimina foto grande" />
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <table border="0" align="center" style="font-size: 10px; font-family: Verdana; font-weight: bold">
        <tr>
            <td>
                <iframe id="Load" width="500px" height="100px" runat="server" frameborder="0" marginwidth="0">
                </iframe>
            </td>
        </tr>
    </table>
</asp:Content>
