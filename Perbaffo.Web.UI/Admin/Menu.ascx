<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="Perbaffo.Web.UI.Admin.Menu" %>
<table border="0" height="100%" cellpadding="0" cellspacing="0" style="border-collapse: collapse;background-color:#D6DFF7;">
  <tr>
    <td align="center" valign="top">
			<table border="0" width="115" cellpadding="2" cellspacing="0" style="border-collapse: collapse; ">
			  <tr>
			    <td width="12" align="right">
			    <img border="0" src="img/house.gif"></td>
			    <td align="left"><asp:LinkButton ID="lnkHome" runat="server" CommandName="HOME" 
                        onclick="lnkAction_Click">Home</asp:LinkButton></td>
			  </tr>
			  <tr>
			    <td width="12" align="right">
			    <img border="0" src="img/bricks.gif"></td>
			    <td align="left"><asp:LinkButton ID="lnkProdotti" runat="server" CommandName="PRODOTTI" 
                        onclick="lnkAction_Click">Prodotti (<asp:Label ID="lblCountProdotti" runat="server" Text=""></asp:Label>)</asp:LinkButton></td>
			  </tr>
			  <tr>
			    <td width="12" align="right">
			    <img border="0" src="img/bricks.gif"></td>
			    <td align="left"><asp:LinkButton ID="lnkNovita" runat="server" CommandName="NOVITA" onclick="lnkAction_Click">Novita</asp:LinkButton></td>
			  </tr>			
			  <tr>
			    <td width="12" align="right">
			    <img border="0" src="img/bricks.gif"></td>
			    <td align="left"><asp:LinkButton ID="lnkOfferte" runat="server" CommandName="OFFERTE" onclick="lnkAction_Click">Offerte</asp:LinkButton></td>
			  </tr>		
			  <tr>
			    <td width="12" align="right">
			    <img border="0" src="img/bricks.gif"></td>
			    <td align="left"><asp:LinkButton ID="lnkOmaggi" runat="server" CommandName="OMAGGI" onclick="lnkAction_Click">Omaggi</asp:LinkButton></td>
			  </tr>				  
			  <tr>
			    <td width="12" align="right">
			    <img border="0" src="img/warning.gif"></td>
			    <td align="left"><asp:LinkButton ID="lnkProdScorta" runat="server" CommandName="SCORTA" onclick="lnkAction_Click">Prod.scorta (<asp:Label ID="lblScorta" runat="server" Text=""></asp:Label>)</asp:LinkButton></td>
			  </tr>					  			    
			  <tr>
			    <td width="12" align="right">
			    <img border="0" src="img/folder_table.gif"></td>
			    <td align="left"><asp:LinkButton ID="lnkCategorie" runat="server" CommandName="CATEGORIE" 
                        onclick="lnkAction_Click">Categorie</asp:LinkButton></td>
			  </tr>
			  <tr>
			    <td width="12" align="right">
			    <img border="0" src="img/modtaglie16.gif"></td>
			    <td align="left"><asp:LinkButton ID="lnkColori" runat="server" CommandName="COLORI" 
                        onclick="lnkAction_Click">Variazioni</asp:LinkButton></td>
			  </tr>
			  <tr>
			    <td width="12" align="right">
			    <img border="0" src="img/group.gif"></td>
			    <td align="left"><asp:LinkButton ID="LinkButton1" runat="server" CommandName="UTENTI" 
                        onclick="lnkAction_Click">Utenti</asp:LinkButton></td>
			  </tr>
			  <tr>
			    <td width="12" align="right">
			    <img border="0" src="img/cart_put.gif"></td>
			    <td align="left"><asp:LinkButton ID="LinkButton2" runat="server" CommandName="ORDINI" 
                        onclick="lnkAction_Click">Ordini</asp:LinkButton></td>
			  </tr>
			  <tr>
			    <td width="12" align="right">
			    <img border="0" src="img/money.gif"></td>
			    <td align="left"><asp:LinkButton ID="lnkPagamenti" runat="server" CommandName="PAGAMENTI" 
                        onclick="lnkAction_Click">Pagamenti</asp:LinkButton></td>
			  </tr>
			  <tr>
			    <td width="12" align="right">
			    <img border="0" src="img/package.gif"></td>
			    <td align="left"><asp:LinkButton ID="lnkSpedizioni" runat="server" CommandName="SPEDIZIONI" 
                        onclick="lnkAction_Click">Spedizioni</asp:LinkButton></td>
			  </tr>
			  <tr>
			    <td width="12" align="right">
			    <img border="0" src="img/aspetto.gif"></td>
			    <td align="left"><asp:LinkButton ID="LinkButton3" runat="server" CommandName="NEWS" 
                        onclick="lnkAction_Click">Notizie</asp:LinkButton></td>
			  </tr>
			  <tr>
			    <td width="12" align="right">
			    <img border="0" src="img/aspetto.gif"></td>
			    <td align="left"><asp:LinkButton ID="LinkButton5" runat="server" CommandName="CURIOSITA" 
                        onclick="lnkAction_Click">Curiosità</asp:LinkButton></td>
			  </tr>			  
			  <tr>
			    <td width="12" align="right">
			    <img border="0" src="img/email.gif" /></td>
			    <td align="left"><asp:LinkButton ID="LinkButton4" runat="server" CommandName="NEWSLETTER" 
                        onclick="lnkAction_Click">Newsletter</asp:LinkButton></td>
			  </tr>
			</table>
    </td>
  </tr>
  <tr>
    <td valign="bottom" align="center" style="font-family: Verdana; font-size: 7pt; color: #3366CC">
			<span id="lblLastAccesso" runat="server"></span>
			<br/><br/><br/>
			<table border="0" width="100%" cellpadding="2" cellspacing="0" style="border-collapse: collapse; ">
			  <tr>
			    <td align="center"><a href="Logout.aspx">
			    <img border="0" src="img/exit.gif"></a></td>
			  </tr>
			  <tr>
			    <td align="center"><a href="Logout.aspx">Esci</a></td>
			  </tr>
			</table>
    </td>
  </tr>
</table>
