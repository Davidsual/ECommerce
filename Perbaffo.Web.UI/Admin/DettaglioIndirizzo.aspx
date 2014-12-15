<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DettaglioIndirizzo.aspx.cs"
    Inherits="Perbaffo.Web.UI.Admin.DettaglioIndirizzo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: #f5f5f5;overflow:auto;">
    <form id="form1" runat="server">
    <center>
        <table border="0" cellpadding="0" cellspacing="0" width="90%">
            <tr>
                <td align="left">
                    <asp:Label ID="lblIndirizzo" runat="server" Text="" Style="font-weight: bold; font-size: 9;
                        font-family: Verdana;"></asp:Label>
                </td>
            </tr>
        </table>
</center>        
        <br />
        <div style="width:100%;overflow-y:auto;height:400px;">
        <asp:GridView ID="grdListProdotti" runat="server" AutoGenerateColumns="False" BorderColor="White"
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="98%" CellSpacing="2"
            
            EmptyDataText="&lt;p&gt;&lt;b&gt;Nessun Ordine trovato&lt;/b&gt;&lt;/p&gt;" 
            OnRowDataBound="grdListProdotti_RowDataBound" Font-Names="Arial" 
            Font-Size="9pt" Font-Strikeout="False">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:TemplateField HeaderText="Codice" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <span id="lblCodiceProd" runat="server"></span>
                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Quantita" DataField="Quantita" ItemStyle-HorizontalAlign="Center"
                    ItemStyle-VerticalAlign="Middle" >
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Descrizione">
                    <ItemTemplate>
                        <asp:Label ID="lblDescrProd" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Totale" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <span id="lblTotale" runat="server"></span>
                    </ItemTemplate>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </div>
        <br />
        Totale Prodotto €&nbsp;<asp:Label ID="lblTotaleProdotti" runat="server" Text=""></asp:Label> 
        <br />
        <asp:Label ID="lblTotaleCarrello" runat="server" Text=""></asp:Label>
        <br />
        Pagamento:&nbsp;&nbsp;<asp:Label ID="lblPagamento" runat="server" Text=""></asp:Label>
        <br />
        Omaggio scelto:&nbsp;&nbsp;<b><asp:Label ID="lblOmaggio" runat="server" Text=""></asp:Label></b>
    </form>
</body>
</html>
