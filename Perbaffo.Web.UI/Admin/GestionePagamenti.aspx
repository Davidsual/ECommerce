<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="PerbaffoMaster.Master" CodeBehind="GestionePagamenti.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.GestionePagamenti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
    function fCheckValue() {
        var field;
        field = document.getElementById('ctl00_ContentPlaceHolder1_chkAttivo');
        if (field != null) {
            if (!field.checked)
                return confirm("Stai disattivando questa modalità di pagamento, sei sicuro?");
        }
        return true;
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
                            Gestione Tipo Pagamento
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
    <asp:UpdatePanel ID="updPnlColori" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table border="0" align="center" style="font-size: 10px; font-family: Verdana; font-weight: bold">
                <tr>
                    <td style="width: 45%;" align="center">
                    <div style="width:640px;height:200px;overflow-y:scroll">
                    
                        <asp:GridView ID="grdListaPagamenti" runat="server" AutoGenerateColumns="False" BorderColor="White"
                            CellPadding="4" ForeColor="#333333" GridLines="None" CellSpacing="2" 
                            EmptyDataText="Nessun Tipo di pagamento censito" 
                            AutoGenerateSelectButton="True" 
                            onselectedindexchanged="grdListaPagamenti_SelectedIndexChanged">
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdentificativo" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Descrizione" DataField="DescrizionePagamento" />
                                <asp:BoundField HeaderText="Costo" DataField="Costo" />
                                <asp:BoundField HeaderText="Stato" DataField="Attivo" />
                            </Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        
                        </div>
                    </td>
                </tr>
            </table>
            <br />
            <table border="0" align="center" style="font-size: 10px; font-family: Verdana; font-weight: bold">
                <tr>
                    <td width="50%" align="right">
                        Tipo Pagamento</td>
                    <td width="50%" align="left">
                        <asp:TextBox ID="txtDescrPagamento" runat="server" Width="221px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtDescrPagamento" ErrorMessage="!" 
                            ValidationGroup="Pagamento"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="50%" align="right">
                        Costo</td>
                    <td width="50%" align="left">
                        <asp:TextBox ID="txtCosto" runat="server" Width="221px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtCosto" ErrorMessage="!" ValidationGroup="Pagamento"></asp:RequiredFieldValidator>
                    </td>
                </tr>    
                <tr>
                    <td width="50%" align="right">
                        Attivo</td>
                    <td width="50%" align="left">
                        <asp:CheckBox ID="chkAttivo" runat="server" />
                    </td>
                </tr>                              
                <tr>
                    <td width="50%" align="right">
                        <asp:Button ID="btnSalva" runat="server" Text="Salva" OnClientClick="return fCheckValue();"
                            onclick="btnSalva_Click" ValidationGroup="Pagamento" />
                    </td>
                    <td width="50%" align="left">
                        <asp:Button ID="btnAnnulla" runat="server" Text="Annulla" 
                            onclick="btnAnnulla_Click" />
                    </td>
                </tr>
                <tr>
                                    <td colspan="2" align="right"> 
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="Pagamento" />
                    <asp:Button ID="btnDelete" runat="server" Text="Cancella" OnClientClick="return confirm('Attenzione stai per cancellare in maniera definitiva questo tipo di pagamento, se questo è legato a qualche ordine non sarà possibile cancellarlo. Continuare?');"
                            style="background-color:#BD0000;color:White;" onclick="btnDelete_Click"/></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
