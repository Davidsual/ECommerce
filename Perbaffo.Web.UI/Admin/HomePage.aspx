<%@ Page Title="" Language="C#" MasterPageFile="PerbaffoMaster.Master" AutoEventWireup="true"
    CodeBehind="HomePage.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" width="100%" bgcolor="#F0F0F0" style="font-family: Verdana; font-size: 16pt;
        font-weight: bold; border: 1px solid #D6DFF5">
        <tr>
            <td rowspan="2" width="48" height="48" align="center">
                <img border="0" src="img/desktop.gif" width="48" height="48">
            </td>
            <td>
                <table border="0" width="100%" style="font-family: Verdana; font-size: 16pt; font-weight: bold;
                    font-style: italic; padding: 0">
                    <tr>
                        <td align="left" valign="middle" style="color: #3366CC">
                            Benvenuto nel tuo e-shop!
                            <div style="font-family: Verdana; font-size: 8pt; color: #0A64C8; font-weight: normal">
                                Ecco il resoconto della situazione</div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table border="0" width="100%" align="right">
        <tr>
            <td valign="top" width="50%">
                <table border="0">
                    <tr>
                        <td height="5">
                        </td>
                    </tr>
                </table>
                <table border="0" width="100%" style="font-family: Verdana; font-size: 8pt; font-weight: bold">
                    <tr>
                        <td rowspan="2" width="32" height="32" align="center">
                            <a href="Prodotti.aspx">
                                <img border="0" src="img/prodotti32.gif" width="32" height="32">
                            </a>
                        </td>
                        <td align="left">
                            <table border="0" width="100%" style="border-bottom: 1px solid #D6DFF5; padding: 0">
                                <tr>
                                    <td align="left" valign="middle" style="color: #3366CC">
                                        <a href="Prodotti.aspx" style="font-family: Verdana; font-size: 10pt; font-weight: bold">
                                            Prodotti </a>
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
                <table border="0" width="100%" style="font-family: Verdana; font-size: 10pt; color: #0A64C8">
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="Prodotti.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="Prodotti.aspx">
                                <asp:Label ID="lblTotProdotti" runat="server" Text=""></asp:Label></a>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="GestioneOmaggi.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="GestioneOmaggi.aspx">
                                <asp:Label ID="lblTotOmaggi" runat="server" Text=""></asp:Label></a>
                        </td>
                    </tr>                    
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="GestioneProdottiSottoScorta.aspx">
                                <img border="0" src="img/warning.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="GestioneProdottiSottoScorta.aspx">
                                <asp:Label ID="lblProdottiScorta" runat="server" Text=""></asp:Label></a>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="ProdottiNonAttivi.aspx">
                                <img border="0" src="img/warning.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="ProdottiNonAttivi.aspx">
                                <asp:Label ID="lblTotProdNonAttivi" runat="server" Text=""></asp:Label></a>
                        </td>
                    </tr>                     
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="GestioneProdottiCategoria.aspx">
                                <img border="0" src="img/warning.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="GestioneProdottiCategoria.aspx">
                                <asp:Label ID="lblProdSenzaCategoria" runat="server" Text=""></asp:Label></a>
                        </td>
                    </tr>              
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="GestioneProdottiSenzaImmagine.aspx">
                                <img border="0" src="img/warning.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="GestioneProdottiSenzaImmagine.aspx">
                                <asp:Label ID="lblProdSenzaImmagine" runat="server" Text=""></asp:Label></a>
                        </td>
                    </tr>                             
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="GestioneOfferte.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="GestioneOfferte.aspx">
                                <asp:Label ID="lblOfferta" runat="server" Text=""></asp:Label></a>
                        </td>
                    </tr>
                </table>
                <table border="0">
                    <tr>
                        <td height="5">
                        </td>
                    </tr>
                </table>
                <table border="0" width="100%" style="font-family: Verdana; font-size: 8pt; font-weight: bold">
                    <tr>
                        <td rowspan="2" width="32" height="32" align="center">
                            <a href="GestioneCategorie.aspx">
                                <img border="0" src="img/categorie32.gif" width="32" height="32">
                            </a>
                        </td>
                        <td align="left">
                            <table border="0" width="100%" style="border-bottom: 1px solid #D6DFF5; padding: 0">
                                <tr>
                                    <td align="left" valign="middle" style="color: #3366CC">
                                        <a href="GestioneCategorie.aspx" style="font-family: Verdana; font-size: 10pt; font-weight: bold">
                                            Categorie </a>
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
                <table border="0" width="100%" style="font-family: Verdana; font-size: 10pt; color: #0A64C8">
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="GestioneCategorie.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16" alt="" /></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="GestioneCategorie.aspx">
                                <asp:Label ID="lblTotaleCategorie" runat="server" Text=""></asp:Label></a>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="GestioneCategorie.aspx">
                                <img border="0" src="img/warning.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="GestioneCategorie.aspx">
                                <asp:Label ID="lblCategorieVuote" runat="server" Text=""></asp:Label></a>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="Notizie.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16" alt="" /></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="Notizie.aspx">
                                Gestione notizie</a>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="Notizie.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16" alt="" /></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="GestCuriosita.aspx">
                                Gestione Curiosita</a>
                        </td>
                    </tr>                    
                </table>
                <table border="0">
                    <tr>
                        <td height="5">
                        </td>
                    </tr>
                </table>
                <table border="0" width="100%" style="font-family: Verdana; font-size: 8pt; font-weight: bold">
                    <tr>
                        <td rowspan="2" width="32" height="32" align="center">
                            <a href="GestioneUtenti.aspx">
                                <img border="0" src="img/utenti32.gif" width="32" height="32" alt=""/>
                            </a>
                        </td>
                        <td align="left">
                            <table border="0" width="100%" style="border-bottom: 1px solid #D6DFF5; padding: 0">
                                <tr>
                                    <td align="left" valign="middle" style="color: #3366CC">
                                        <a href="GestioneUtenti.aspx" style="font-family: Verdana; font-size: 10pt; font-weight: bold">
                                            Utenti </a>
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
                <table border="0" width="100%" style="font-family: Verdana; font-size: 10pt; color: #0A64C8">
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="GestioneUtenti.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="GestioneUtenti.aspx">
                                <asp:Label ID="lblTotaleUtenti" runat="server" Text=""></asp:Label></a>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="GestioneUtentiFoto.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="GestioneUtentiFoto.aspx">Gestione Foto Utenti <span id="lblTotUtentiFoto" runat="server"></span></a>
                        </td>
                    </tr>                    
                </table>
                <br/>
            </td>
            <td valign="top" width="50%">
                <table border="0">
                    <tr>
                        <td height="5">
                        </td>
                    </tr>
                </table>
                <table border="0" width="100%" style="font-family: Verdana; font-size: 8pt; font-weight: bold">
                    <tr>
                        <td rowspan="2" width="32" height="32" align="center">
                            <a href="ordini/ordini.asp">
                                <img border="0" src="img/ordini32.gif" width="32" height="32">
                            </a>
                        </td>
                        <td align="left">
                            <table border="0" width="100%" style="border-bottom: 1px solid #D6DFF5; padding: 0">
                                <tr>
                                    <td align="left" valign="middle" style="color: #3366CC">
                                        <a href="ordini/ordini.asp" style="font-family: Verdana; font-size: 10pt; font-weight: bold">
                                            Ordini </a>
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
                <table border="0" width="100%" style="font-family: Verdana; font-size: 10pt; color: #0A64C8">
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="Ordini.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="Ordini.aspx">Ordini in fase di accettazione (<span id="lblTotOrdiniAperti" runat="server"></span>)</a>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="Ordini_Confermati.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="Ordini_Confermati.aspx">Ordini confermati (<span id="lblOrdiniConfermati" runat="server"></span>)</a>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="Ordini_Spediti.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="Ordini_Spediti.aspx">Ordini Spediti (<span id="lblSpediti" runat="server"></span>)</a>
                        </td>
                    </tr>                    
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="Ordini_Archiviati.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="Ordini_Archiviati.aspx">Ordini Archiviati (<span id="lblTotaleOrdiniArchiviati" runat="server"></span>)</a>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="Ordini_Annullati.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="Ordini_Annullati.aspx">Ordini Annullati</a>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="OrdiniStatistiche.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="OrdiniStatistiche.aspx">Ordini Statistiche</a>
                        </td>
                    </tr>     
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="StatistichePerbaffo.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="StatistichePerbaffo.aspx">Statistiche Perbaffo</a>
                        </td>
                    </tr>                                     
                </table>
                <table border="0">
                    <tr>
                        <td height="5">
                        </td>
                    </tr>
                </table>
                <table border="0" width="100%" style="font-family: Verdana; font-size: 8pt; font-weight: bold">
                    <tr>
                        <td rowspan="2" width="32" height="32" align="center">
                            <a href="newsletter/newsletter.asp">
                                <img border="0" src="img/mail32.gif" width="32" height="32">
                            </a>
                        </td>
                        <td align="left">
                            <table border="0" width="100%" style="border-bottom: 1px solid #D6DFF5; padding: 0">
                                <tr>
                                    <td align="left" valign="middle" style="color: #3366CC">
                                        <a href="newsletter/newsletter.asp" style="font-family: Verdana; font-size: 10pt;
                                            font-weight: bold">Newsletter </a>
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
                <table border="0" width="100%" style="font-family: Verdana; font-size: 10pt; color: #0A64C8">
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="GestioneNewsLetter.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16"/></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="GestioneNewsLetter.aspx">Gestione NewsLetter</a>
                        </td>
                    </tr>
                </table>
                <table border="0">
                    <tr>
                        <td height="5">
                        </td>
                    </tr>
                </table>
                <table border="0" width="100%" style="font-family: Verdana; font-size: 8pt; font-weight: bold">
                    <tr>
                        <td rowspan="2" width="32" height="32" align="center">
                            <a href="javascript:void(0);">
                                <img border="0" src="img/statistiche32.gif" width="32" height="32" alt=""/>
                            </a>
                        </td>
                        <td align="left">
                            <table border="0" width="100%" style="border-bottom: 1px solid #D6DFF5; padding: 0">
                                <tr>
                                    <td align="left" valign="middle" style="color: #3366CC">
                                        <a href="javascript:void(0);" style="font-family: Verdana; font-size: 10pt;
                                            font-weight: bold">Promozioni </a>
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
                <table border="0" width="100%" style="font-family: Verdana; font-size: 10pt; color: #0A64C8">
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="CodiciPromozioni.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="CodiciPromozioni.aspx">Codici - Promozioni</a>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="UtentePromozioni.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="UtentePromozioni.aspx">Utenti - Promozioni</a>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="CodiciAffiliazione.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="CodiciAffiliazione.aspx">Affiliazioni</a>
                        </td>
                    </tr>    
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="16" valign="top">
                            <a href="OrdiniAffiliazione.aspx">
                                <img border="0" src="img/info.gif" width="16" height="16"></a>
                        </td>
                        <td valign="top" style="font-size: 8pt">
                            <a href="OrdiniAffiliazione.aspx"><asp:Label ID="lblOrdiniAffiliazione" runat="server" Text=""></asp:Label></a>
                        </td>
                    </tr>                                      
                </table>
                <br/>
            </td>
        </tr>
        <tr>
            <td valign="top" width="50%">
                <table border="0" width="100%" cellspacing="0" cellpadding="0" style="font-size: 14pt;
                    font-weight: bold">
                    <tr>
                        <td width="100%" valign="top" height="30">
                            Scegli un'operazione
                        </td>
                    </tr>
                </table>
                <table border="0" width="100%" style="font-family: Verdana; font-size: 8pt; color: #0A64C8">
                    <tr>
                        <td>
                            <a href="DettaglioProdotto.aspx">
                                <img border="0" src="img/tasto.gif" width="16" height="16"></a>
                        </td>
                        <td width="100%">
                            <a href="DettaglioProdotto.aspx">Aggiungi un nuovo prodotto</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a href="GestioneCategorie.aspx">
                                <img border="0" src="img/tasto.gif" width="16" height="16"></a>
                        </td>
                        <td width="100%">
                            <a href="GestioneCategorie.aspx">Aggiungi una nuova categoria</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a href="spedizioni/addspedizione.asp">
                                <img border="0" src="img/tasto.gif" width="16" height="16"></a>
                        </td>
                        <td width="100%">
                            <a href="GestioneSpedizioni.aspx">Crea un nuovo sistema di spedizione</a>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" width="50%">
                <table border="0" width="100%" cellspacing="0" cellpadding="0" style="font-size: 14pt;
                    font-weight: bold">
                    <tr>
                        <td width="100%" height="30" valign="top">
                            Operazioni relative al tuo account
                        </td>
                    </tr>
                </table>
                <table border="0" width="100%" style="font-family: Verdana; font-size: 8pt; color: #0A64C8">
                    <tr>
                        <td>
                            <a href="Account.aspx">
                                <img border="0" src="img/tasto.gif" width="16" height="16"></a>
                        </td>
                        <td width="100%">
                            <a href="Account.aspx">Modifica i tuoi dati di accesso</a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
