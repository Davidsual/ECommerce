<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WidgetNewsletter.ascx.cs" EnableViewState="false"
    Inherits="Perbaffo.Web.UI.WidgetNewsletter" %>
<table border="0" cellpadding="0" cellspacing="0" class="headerCellContornoDuecento">
    <tr>
        <td align="left" class="topLeftStyle">
        </td>
        <td align="center" valign="bottom">
            <h2>
                <b>Iscriviti per ricevere le offerte speciali</b></h2>
        </td>
        <td align="right" class="topRightStyle">
        </td>
    </tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" width="200px">
    <tr>
        <td class="yellow_left" width="11">
        </td>
        <td class="dark_red" width="178px">
            <table border="0" cellpadding="0" cellspacing="0" width="176">
                <tr>
                    <td>
                        <img src="images/spacer.gif" width="1px" height="10px" alt="" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table border="0" cellpadding="0" cellspacing="5" width="100%">
                            <tr>
                                <td align="center">
                                    <input class="pp_box_max" type="text" name="email" id="email" size="18" value="Inserisci E-Mail"
                                        onclick="(this.value == 'Inserisci E-Mail')?this.value = '':this.value = this.value;" onblur="(this.value == '')?this.value = 'Inserisci E-Mail':this.value = this.value;" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button class="standardsubmit" ID="btnNewsLetter" CommandName="NEWSLETTER" 
                            runat="server" Text="Iscriviti" 
                            ToolTip="Iscritivi alla Newsletter per ricevere le novità e le offerte di Perbaffo" 
                            onclick="btnNewsLetter_Click"  />
                    </td>
                </tr>
            </table>
        </td>
        <td class="yellow_right" width="11" align="right">
        </td>
    </tr>
    <tr>
        <td align="left" class="bottomLeftStyle">
        </td>
        <td class="yellow_bottom" style="height: 12px;">
        </td>
        <td align="right" class="bottomRightStyle">
        </td>
    </tr>
    <tr>
        <td>
            <img src="images/spacer.gif" width="1px" height="5px" alt="" />
        </td>
    </tr>    
</table>
