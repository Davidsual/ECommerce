<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Perbaffo.Web.UI.Header" %>
<table border="0" cellspacing="0" cellpadding="0" width="1000px">
    <tr>
        <td rowspan="2" valign="top" width="100px" bgcolor="#cddded">
            <a href="Default.aspx" title="">
                <img src="images/pp_logo.gif" height="100" width="100" border="0" alt="http://www.perbaffo.it" /></a>
        </td>
        <td class="ppcorner">
            <table width="888px" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="width:402px;background-color:#cddded;height:68px;">
                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                            <tr>
                                <td align="center" >
                                    <a href="Default.aspx" title="Torna all'HomePage">
                                        <img src="images/PERBAFFO-BANNER.jpg" alt="Perbaffo Petshop" width="325" height="51" style="border: 0;" /></a>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 486px;padding-top: 4px;" align="left" class="ppmainbuttonsbg">
                        <table border="0" cellspacing="0" cellpadding="0" width="90%">
                            <tbody>
                                <tr>
                                    <td align="center">
                                        <a href="Dettaglio-Categoria.aspx?Categoria=20" title="Visita la categoria dedicata ai prodotti per Cani">
                                            <img border="0" width="60" height="60" alt="Visita la categoria cani" src="images/categoria-cani.gif" onmouseover="this.src = 'images/categoria-cani-sel.gif';" onmouseout="this.src = 'images/categoria-cani.gif';" /></a>
                                    </td>
                                    <td align="center">
                                        <a href="Dettaglio-Categoria.aspx?Categoria=1" title="Visita la categoria dedicata ai prodotti per Gatti">
                                            <img border="0" alt="Visita la categoria Gatti" src="images/categoria-gatti.gif"
                                                width="60" height="60" onmouseover="this.src = 'images/categoria-gatti-sel.gif';" onmouseout="this.src = 'images/categoria-gatti.gif';"/></a>
                                    </td>
                                    <td align="center">
                                        <a href="Dettaglio-Categoria.aspx?Categoria=18" title="Visita la cateogoria dedicata ai prodotti per Roditori">
                                            <img border="0" alt="Visita la cateogoria Roditori" src="images/categoria-roditori.gif"
                                                width="60" height="60" onmouseover="this.src = 'images/categoria-roditori-sel.gif';" onmouseout="this.src = 'images/categoria-roditori.gif';"/></a>
                                    </td>
                                    <td align="center">
                                        <a href="Dettaglio-Categoria.aspx?Categoria=9" title="Visita la categoria dedicata ai prodotti per Voltatili">
                                            <img border="0" alt="Visita la categoria Volatili" src="images/categoria-volatili.gif"
                                                width="60" height="60" onmouseover="this.src = 'images/categoria-volatili-sel.gif';" onmouseout="this.src = 'images/categoria-volatili.gif';"/></a>
                                    </td>
                                    <td align="center">
                                        <a href="Dettaglio-Categoria.aspx?Categoria=168" title="Visita la categoria dedicata ai prodotti per Pesci">
                                            <img border="0" alt="Visita la categoria Pesci" src="images/categoria-pesci.gif"
                                                width="60" height="60"  onmouseover="this.src = 'images/categoria-pesci-sel.gif';" onmouseout="this.src = 'images/categoria-pesci.gif';"/></a>
                                    </td>
                                    <td align="center">
                                        <a href="Dettaglio-Categoria.aspx?Categoria=443" title="Visita la categoria dedicata ai prodotti per Rettili">
                                            <img border="0" alt="Visita la categoria Pesci" src="images/categoria-rettili.gif"
                                                width="60" height="60"  onmouseover="this.src = 'images/categoria-rettili-sel.gif';" onmouseout="this.src = 'images/categoria-rettili.gif';"/></a>
                                    </td>                                    
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="ppcornertopright" valign="bottom" style="background-color:#cddded;height:35px;">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td id="home" style='<%= Home%>;'>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="9">
                                    <img src="images/nav_left.gif" height="28" width="9" border="0" alt="" />
                                </td>
                                <td class="petnav" align="center">
                                    <a href="Default.aspx" title="Torna all'Home page di Perbaffo">Home</a>
                                </td>
                                <td width="8">
                                    <img src="images/nav_centre_right.gif" height="28" width="8" border="0" alt="" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td id="taglia" style='<%= Taglia%>;'>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="8">
                                    <img src="images/nav_centre_left.gif" height="28" width="8" border="0" alt="" />
                                </td>
                                <td class="petnav" align="center">
                                    <a href="Scelta-della-taglia.aspx" title="Come scegliere la taglia per l'abbigliamento del tuo cane" onmouseover="javascript:overmCell('taglia','#ffffff')"
                                        onmouseout="javascript:outmCell('taglia','#cddded')">Scegliere<br />la taglia giusta</a>
                                </td>
                                <td width="8">
                                    <img src="images/nav_centre_right.gif" height="28" width="8" border="0" alt="" />
                                </td>
                            </tr>
                        </table>
                    </td>                    
                    <td id="news" style='<%= News%>;'>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="8">
                                    <img src="images/nav_centre_left.gif" height="28" width="8" border="0" alt="" />
                                </td>
                                <td class="insurancenav" align="center">
                                    <a href="Lista-Notizie.aspx" title="Tutte le Notizie" onmouseover="javascript:overmCell('news','#ffffff')"
                                        onmouseout="javascript:outmCell('news','#cddded')">Pet<br />
                                        News</a>
                                </td>
                                <td width="8">
                                    <img src="images/nav_centre_right.gif" height="28" width="8" border="0" alt="" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td id="InfoAnimali" style='<%= InfoAnimali%>;'>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="8">
                                    <img src="images/nav_centre_left.gif" height="28" width="8" border="0" alt="" />
                                </td>
                                <td class="petnav" align="center">
                                    <a href="Curiosita-Animali.aspx" title="Curiosità &amp; Info" onmouseover="javascript:overmCell('InfoAnimali','#ffffff')"
                                        onmouseout="javascript:outmCell('InfoAnimali','#cddded')">Curiosità</a>
                                </td>
                                <td width="8">
                                    <img src="images/nav_centre_right.gif" height="28" width="8" border="0" alt="" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td id="viaggiare" style='<%= Viaggiare%>;'>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="8">
                                    <img src="images/nav_centre_left.gif" height="28" width="8" border="0" alt="" />
                                </td>
                                <td class="petnav" align="center">
                                    <a href="Viaggiare-con-Animali.aspx" title="Viaggiare con animali" onmouseover="javascript:overmCell('viaggiare','#ffffff')"
                                        onmouseout="javascript:outmCell('viaggiare','#cddded')">Viaggiare<br />
                                        con animali</a>
                                </td>
                                <td width="8">
                                    <img src="images/nav_centre_right.gif" height="28" width="8" border="0" alt="" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td id="veterinari" style='<%= Veterinari%>;'>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="8">
                                    <img src="images/nav_centre_left.gif" height="28" width="8" border="0" alt="" />
                                </td>
                                <td class="petnav" align="center">
                                    <a href="Veterinari.aspx" title="Animali da adottare" onmouseover="javascript:overmCell('veterinari','#ffffff')"
                                        onmouseout="javascript:outmCell('veterinari','#cddded')">Veterinari</a>
                                </td>
                                <td width="8">
                                    <img src="images/nav_centre_right.gif" height="28" width="8" border="0" alt="" />
                                </td>
                            </tr>
                        </table>
                    </td>

                    <td id="animaliDaAdottare" style='<%= AnimaliDaAdottare%>;'>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="8">
                                    <img src="images/nav_centre_left.gif" height="28" width="8" border="0" alt="" />
                                </td>
                                <td class="petnav" align="center">
                                    <a href="Animali-da-adottare.aspx" title="Animali da adottare" onmouseover="javascript:overmCell('animaliDaAdottare','#ffffff')"
                                        onmouseout="javascript:outmCell('animaliDaAdottare','#cddded')">Animali da adottare</a>
                                </td>
                                <td width="8">
                                    <img src="images/nav_centre_right.gif" height="28" width="8" border="0" alt="" />
                                </td>
                            </tr>
                        </table>
                    </td>                    
                    <td id="amici" style='<%= SitiAmici%>;'>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="8">
                                    <img src="images/nav_centre_left.gif" height="28" width="8" border="0" alt="" />
                                </td>
                                <td class="petnav" align="center">
                                    <a href="Siti-Amici.aspx" title="Siti amici" onmouseover="javascript:overmCell('amici','#ffffff')" onmouseout="javascript:outmCell('amici','#cddded')">
                                        Siti<br />
                                        amici</a>
                                </td>
                                <td width="8">
                                    <img src="images/nav_centre_right.gif" height="28" width="8" border="0" alt="" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="2">
                        <img src="images/pixel.gif" height="24" width="2" border="0" alt="" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table width="1000" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="10" align="left">
                        <img src="images/subnav_left.gif" width="10px" height="35px" border="0" alt="" />
                    </td>
                    <td class="ppsubnav" align="left">
                        <a href="Login-Utente.aspx" runat="server" id="lnkHeaderLoginUtente" title="Accedi o iscriviti a Perbaffo">
                            <b>Accedi a Perbaffo</b></a>
                    </td>
                    <td class="ppsubnav" align="center">
                        <div id="divHome" runat="server" visible="true">
                            <table border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="ppsubnavx" align="center">
                                        <a href="Lista-Desideri.aspx" title="I miei prodotti preferiti" id="lnkHeaderPreferiti">
                                            Lista dei desideri</a>
                                    </td>
                                    <td class="ppsubnavx" align="center">
                                        &nbsp;|&nbsp;
                                    </td>
                                    <td class="ppsubnavx" align="center">
                                        <a href="Dettaglio-Ordini-Effettuati.aspx" title="I miei ordini precedenti"
                                            id="lnkHeaderOrdiniPrecedenti">Ordini precedenti</a>
                                    </td>
                                    <td class="ppsubnavx" align="center">
                                        &nbsp;|&nbsp;
                                    </td>
                                    <td class="ppsubnavx" align="center">
                                        <a href="Controlla-Spedizione.aspx" title="Controlla dove si trova il tuo ordine"
                                            id="lnkHeaderSpedizione">Controlla spedizione</a>
                                    </td>
                                    <td class="ppsubnavx" align="center">
                                        &nbsp;|&nbsp;
                                    </td>
                                    <td class="ppsubnavx" align="center">
                                        <a href="Carrello-Prodotti.aspx" title="I prodotti attualmente inseriti nel carrello"
                                            id="lnkHeaderCarrello">Carrello</a>
                                    </td>                                   
                                </tr>
                            </table>
                        </div>
                        <div id="divNews" runat="server" visible="false">
                            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                <tr>
                                    <td class="ppsubnavx" align="left">
                                        <a href="Lista-Notizie.aspx" title="Lista di tutte le notizie">Lista
                                            Notizie</a>
                                    </td>
                                </tr>
                            </table>
                        </div>                      
                        <div id="divSitiAmici" runat=server visible="false">
                              <table border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="ppsubnavx" align="center">
                                        <a href="Siti-Amici.aspx?Link=Informazioni" title="informazioni sugli animali">
                                            Link informazioni sugli animali</a>
                                    </td>
                                    <td class="ppsubnavx" align="center">
                                        &nbsp;|&nbsp;
                                    </td>
                                    <td class="ppsubnavx" align="center">
                                        <a href="Siti-Amici.aspx?Link=Forum" title="Forum">
                                            Link Forum</a>
                                    </td>
                                    <td class="ppsubnavx" align="center">
                                        &nbsp;|&nbsp;
                                    </td>
                                    <td class="ppsubnavx" align="center">
                                        <a href="Siti-Amici.aspx?Link=Blog" title="Blog">
                                            Link Blog</a>
                                    </td>         
                                    <td class="ppsubnavx" align="center">
                                        &nbsp;|&nbsp;
                                    </td>
                                    <td class="ppsubnavx" align="center">
                                        <a href="Siti-Amici.aspx?Link=Negozi" title="Negozi">
                                            Link Negozi</a>
                                    </td>        
                                    <td class="ppsubnavx" align="center">
                                        &nbsp;|&nbsp;
                                    </td>
                                    <td class="ppsubnavx" align="center">
                                        <a href="Siti-Amici.aspx?Link=Varie" title="Varie">
                                            Link Varie</a>
                                    </td>    
                                    <td class="ppsubnavx" align="center">
                                        &nbsp;|&nbsp;
                                    </td>
                                    <td class="ppsubnavx" align="center">
                                        <a href="Siti-Amici.aspx?Link=Allevamenti" title="Allevamenti">
                                            Link Allevamenti</a>
                                    </td>                                                                                                                                
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td align="right" width="10">
                        <img src="images/subnav_right.gif" height="35px" width="10px" border="0" alt="" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<br />
