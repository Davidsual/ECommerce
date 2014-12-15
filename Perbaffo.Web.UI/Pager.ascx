<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pager.ascx.cs" Inherits="Perbaffo.Web.UI.Pager" %>
<asp:UpdatePanel ID="updPager" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:LinkButton ID="LinkButtonFirst" runat="server" Text="|&lt;" OnClick="LinkButtonFirst_Click" style="font-size:11px;"/>
        &nbsp;<asp:LinkButton ID="LinkButtonPrevious" runat="server" Text="&lt;" OnClick="LinkButtonPrevious_Click" style="font-size:11px;"/>
        &nbsp;<asp:Repeater ID="RepeaterNumbers" runat="server" 
            onitemdatabound="RepeaterNumbers_ItemDataBound">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButtonNumber" runat="server" Enabled="<%#!IsCurrentPage((int)Container.DataItem) %>"
                    CssClass="<%#CssClass%>" Text="<%#(int)Container.DataItem%>" OnClick="LinkButtonNumber_Click" style="font-size:11px;"/></ItemTemplate>
            <SeparatorTemplate>
                <%#Separator%></SeparatorTemplate>
        </asp:Repeater>
        &nbsp;<asp:LinkButton ID="LinkButtonNext" runat="server" Text="&gt;"  OnClick="LinkButtonNext_Click" style="font-size:11px;"></asp:LinkButton>
        &nbsp;<asp:LinkButton ID="LinkButtonLast" runat="server" Text="&gt;|" OnClick="LinkButtonLast_Click" style="font-size:11px;"/>
        &nbsp;<asp:TextBox ID="TextBoxGoTo" runat="server" Width="30px" style="font-size:11px;height:20px;" /><asp:Button ID="ButtonGoTo"
            runat="server" Text="Vai a" OnClick="ButtonGoTo_Click" ToolTip="Vai alla pagina" style="font-size:11px;"/>
    </ContentTemplate>
</asp:UpdatePanel>
