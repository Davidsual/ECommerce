<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Veterinari.aspx.cs" Inherits="Perbaffo.Web.UI.Veterinari" %>
<%@ Register Src="WidgetAssistenza.ascx" TagName="Assistenza" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNewsletter.ascx" TagName="Newsletter" TagPrefix="UserControl" %>
<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="UserControl" %>
<%@ Register src="WidgetRegistrazione.ascx" TagName="Registrazione" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffoWorld.ascx" TagName="PerbaffoWorld" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffo.ascx" TagName="Perbaffo" TagPrefix="UserControl" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="UserControl" %>
<%@ Register Src="WidgetFoto.ascx" TagName="Foto" TagPrefix="UserControl" %>
<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="UserControl" %>
<%@ Register Src="MenuCategorie.ascx" TagName="Menu" TagPrefix="UserControl" %>
<%@ Register Src="WidgetCarrello.ascx" TagName="Carrello" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNews.ascx" TagName="News" TagPrefix="UserControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>
        <%=TitoloPagina%></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />        
    <link rel="shortcut icon" href="images/favicon.ico" />
    <meta name="Title" content="<%=TitoloPagina%>" /> 
    <meta name="description" content="<%=DescrizionePagina %>" />
    <meta name="keywords" content="<%=KeywordsPagina %>" />
    <meta name="Robots" content="index,follow" />
    <meta name="Author" content="Davide Trotta" />    
    <link rel="alternate" type="application/rss+xml" title="RSS" href="RssHandler.ashx" />
    <link rel="Stylesheet" type="text/css"  href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />

    <script type="text/javascript" src="script/Perbaffo.Web.UI.Function.js"></script>

</head>
<body>
    <form id="frmPerbaffoPetShop" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <UserControl:Header ID="Header1" runat="server" />
    <table border="0" cellpadding="0" cellspacing="0" width="1000px">
        <tr>
            <td align="left" valign="top">
                <UserControl:Menu ID="MenuPerbaffo" runat="server" />
                <img src="images/pixel.gif" width="1px" height="5px" border="0" alt="" /><br />
            </td>
            <td width="5" valign="top">
                <img src="images/pixel.gif" height="50" width="5" border="0" alt="" />
            </td>
            <td valign="top">
                <table border="0" cellspacing="0" cellpadding="0" style="width:590px;background-color:#cddded;height:35px;">
                    <tbody>
                        <tr>
                            <td align="left" class="topLeftStyle">
                            </td>
                            <td rowspan="2" align="right">
                                <h1>
                                    Veterinari</h1>
                            </td>
                            <td align="right" class="topRightStyle">
                            </td>
                        </tr>
                        <tr>
                            <td valign="bottom" width="11">
                            </td>
                            <td width="11">
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td width="12" class="yellow_left" bgcolor="#f5f5f5">
                            </td>
                            <td>
                                <table border="0" cellspacing="0" cellpadding="0" style="width: 100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <table border="0" cellspacing="0" cellpadding="0" width="90%" bgcolor="#CDDDED">
                                                    <tbody>
                                                        <tr>
                                                            <td align="left" class="topLeftStyle">
                                                            </td>
                                                            <td class="bodycopy">                  
                                                            </td>
                                                            <td align="right" class="topRightStyle">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="bottom" width="12" align="right" style="background-image: url(images/botleft.gif);
                                                                background-repeat: no-repeat; background-position: bottom;">
                                                            </td>
                                                            <td align="left">
                                                                <span class="med_text_dodici" style="color:Black;line-height:17px;">
                                                                Se hai uno studio veterinario o una clinica veterinaria e vuoi inserire gratuitamente i tuoi dati nel nostro database per essere raggiunto più facilmente da nuovi clienti, clicca sul link sottostante per scaricare il modulo e dopo averlo compilato, inviacelo via email <a href="mailto:info@perbaffo.it?subject=Affiliazione Veterinari" class="dark_red" title="Manda l'E-Mail per affiliazione veterinari"><b>info@perbaffo.it</b></a> o mezzo fax.
                                                                </span>
                                                                <br /><br />
                                                                <a href="Documents/modulo-iscrizione-studio-veterinario.pdf" class="dark_red" title="Modulo iscrizione studio veterinario" target="_blank"><b>Modulo iscrizione studio veterinario (.pdf)</b></a>
                                                            </td>
                                                            <td valign="bottom" width="12" align="right" style="background-image: url(images/botright.gif);
                                                                background-repeat: no-repeat; background-position: bottom;">
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <br />
                                                <table border="0" width="90%" cellpadding="0" cellspacing="0">
                                                <tbody>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Ambulatorio veterinario Sismondi</b></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text">Via Sismondi n° 67 - 20123 Milano(MI)</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Tel:</b> 02-73955676</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>E-Mail:</b> <a href="mailto:ambulatoriosismondi@yahoo.it?subject=Informazioni" title="Contattaci">ambulatoriosismondi@yahoo.it</a></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Sito:</b> <a href="http://www.ambulatorioveterinariosismondi.eu" target="_blank" title="Ambulatorio Sismondi">www.ambulatorioveterinariosismondi.eu</a></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Prestazioni:</b> Medicina generale,Chirurgia,Radiologia,Consulenza e visite comportamentali,Medicina omeopatica ed olistica</span></td>
                                                    </tr>
                                                </tbody>
                                                </table>
                                                <br />
                                                <table border="0" width="90%" cellpadding="0" cellspacing="0">
                                                <tbody>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Officina Olistica Veterinaria del Benessere del Dr. Filippo Pilati</b></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text">Via Don Giovanni Fornasini n°43 - 40128 - Bologna</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Tel:</b>051-355066</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>E-Mail:</b> <a href="mailto:info@dottorPilati.com?subject=Informazioni" title="Contattaci">info@dottorPilati.com</a></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Sito:</b> <a href="http://www.dottorpilati.com" target="_blank" title="Officina olistica veterinaria del benessere del Dr. Filippo Pilati">http://www.dottorpilati.com</a></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Prestazioni:</b>Visite di base e omotossicologiche,vaccinazioni cane e gatto,test filaria e profilassi; Inserimento Microchip;Detartrasi;Visite comportamentali;cardiologiche (ecocardio ed ecodoppler),ortopediche con possibilità di terapie omotossicologiche;chirurgia con anestesia gassosa e monitoraggio del paziente;possibilità di gestire i pazienti che hanno necessità di fluidoterapia e continuativa in day-hospital..</span></td>
                                                    </tr>
                                                </tbody>
                                                </table>      
                                                <br />
                                                <table border="0" width="90%" cellpadding="0" cellspacing="0">
                                                <tbody>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Arca Group srl</b></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text">Via Roma 2 - 10091 Alpignano (TO) Aperto tutti i giorni</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text">Piazzale Europa 719 - 10044 Pianezza (TO)</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Tel:</b>011-9663990 (Aplignano) / 011-9787160 (Pianezza) Reperibilità continua 3358148799</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>E-Mail:</b> <a href="mailto:clinicavet@hotmail.it?subject=Informazioni" title="Contattaci">clinicavet@hotmail.it</a></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Sito:</b> <a href="http://www.arcagroupvet.eu/" target="_blank" title="Arca Group srl">http://www.arcagroupvet.eu/</a></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Prestazioni:</b>Laboratorio Analisi,Neurologia,Chirurgia specialistica,Esami radiografici,Ortopedia,Oncologia,Enooscopia,Cardiologia,Reperibilità continua,Ecografia,Visite domiciliari,Dermatologia</span></td>
                                                    </tr>
                                                </tbody>
                                                </table>    
                                                <br />     
                                                <table border="0" width="90%" cellpadding="0" cellspacing="0">
                                                <tbody>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Ambulatorio Veterinario San Prospero</b></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text">Via Piero Strozzi 47-49 Siena</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Tel:</b>0577-289103 / 0577-564458</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>E-Mail:</b> <a href="mailto:donatella.piccini@tin.it?subject=Informazioni" title="Contattaci">donatella.piccini@tin.it</a></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Sito:</b> <a href="http://www.veterinariosanprospero.it/" target="_blank" title="Ambulatorio veterinario San Prospero">http://www.veterinariosanprospero.it/</a></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Prestazioni:</b>Visite,Chirurgia,Tessuti molli e ortopedica,Esami di laboratorio,Ecografie,visite a domicilio</span></td>
                                                    </tr>
                                                </tbody>
                                                </table>       
                                                
                                                                                               <br />     
                                                <table border="0" width="90%" cellpadding="0" cellspacing="0">
                                                <tbody>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Veterinaria Vigna Murata</b></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text">Via Elio lampridio cerva 141/143 -00143 Roma</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Tel:</b>06 5043090</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>E-Mail:</b> <a href="mailto:info@veterinariavignamurata.it?subject=Informazioni" title="Contattaci">info@veterinariavignamurata.it</a></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Sito:</b> <a href="http://www.veterinariavignamurata.it/" target="_blank" title="Veterinaria Vigna Murata">http://www.veterinariavignamurata.it/</a></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Prestazioni:</b>Attività ambulatoriali,visite a domicilio,chirurgia ambulatoriale e specialistica,Ecografia,Radiologia,Ematologia e Diagnostica di laboratorio,Visite specialistiche su appuntamento</span></td>
                                                    </tr>
                                                </tbody>
                                                </table>                                
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                            <td width="12" align="right" class="yellow_right">
                            </td>
                        </tr>
                        <tr>
                            <td valign="bottom" align="left" class="bottomLeftStyle">
                            </td>
                            <td class="yellow_bottom">
                            </td>
                            <td valign="bottom" align="right" class="bottomRightStyle">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
            <td>
                <img src="images/pixel.gif" width="5px" height="1px" alt="" />
            </td>
            <td valign="top">
                <UserControl:Registrazione ID="regist" runat="server" />
                <UserControl:Newsletter ID="WidgetNewsletter" runat="server" />
                <UserControl:Foto ID="WidgetFoto" runat="server" Visible="false" />
                <UserControl:Carrello ID="usrCarrello" runat="server" />
                <UserControl:Assistenza ID="WidgetAssistenza" runat="server" />                
                <UserControl:Perbaffo ID="WidgetPerbaffo" runat="server" />
                <UserControl:PerbaffoWorld ID="WidgetPerbaffoWorld" runat="server" />
                <UserControl:News ID="Notizie" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <UserControl:Footer ID="FooterPerbaffo" runat="server" />
            </td>
        </tr>
    </table>
    </form>
    <script language="javascript" type="text/javascript">
        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
        document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>

    <script language="javascript" type="text/javascript">
        try {
            var pageTracker = _gat._getTracker("UA-3824773-1");
            pageTracker._trackPageview();
        } catch (err) { }
    </script>      
</body>
</html>