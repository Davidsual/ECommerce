<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PagerFull.ascx.cs" Inherits="Perbaffo.Web.UI.PagerFull" %>
<asp:HyperLink ID="LinkButtonFirst"  runat="server" NavigateUrl="" Text="Primo" Style="font-size: 11px;"></asp:HyperLink>
&nbsp;<asp:HyperLink ID="LinkButtonPrevious"  runat="server" NavigateUrl="" Text="&lt;" Style="font-size: 11px;"></asp:HyperLink>
&nbsp;<asp:Repeater ID="RepeaterNumbers" runat="server" OnItemDataBound="RepeaterNumbers_ItemDataBound">
    <ItemTemplate>
 <%--       <asp:LinkButton ID="LinkButtonNumber" runat="server" Enabled="<%#!IsCurrentPage((int)Container.DataItem) %>"
            CssClass="<%#CssClass%>" Text="<%#(int)Container.DataItem%>" OnClick="LinkButtonNumber_Click"
            Style="font-size: 11px;" />--%>
            
        <asp:HyperLink ID="lnkPagina" CssClass="<%#CssClass%>" runat="server" NavigateUrl="" Text="<%#(int)Container.DataItem%>"></asp:HyperLink>
            </ItemTemplate>
    <SeparatorTemplate>
        <%#Separator%></SeparatorTemplate>
</asp:Repeater>
&nbsp;
<asp:HyperLink ID="LinkButtonNext"  runat="server" NavigateUrl="" Text="&gt;" Style="font-size: 11px;"></asp:HyperLink>
&nbsp;
<asp:HyperLink ID="LinkButtonLast"  runat="server" NavigateUrl="" Text="Ultimo" Style="font-size: 11px;"></asp:HyperLink>
&nbsp;<asp:TextBox ID="TextBoxGoTo" runat="server" Width="30px" Style="font-size: 11px;
    height: 20px;" /><asp:Button ID="ButtonGoTo" runat="server" Text="Vai a" OnClick="ButtonGoTo_Click"
        ToolTip="Vai alla pagina" Style="font-size: 11px;" />
