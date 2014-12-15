<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tracking-SDA.aspx.cs" Inherits="Perbaffo.Web.UI.Tracking_SDA" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <p style="font-size:12px;">
        Controlla dove si trova la tua spedizione tramite il sistema di tracciamento pacchi SDA<br />inserisci il tuo codice di spedizione</p>
    <form name="test" action="http://wwww.sda.it/ResourceServlet.html?execute2=ActionTracking.doGetTrackingHome"
    method="post">
    <p>
        <input style="text-transform: uppercase" maxlength="13" size="23" id="id_ldv" name="id_ldv"
            runat="server" />
        <input type="hidden" value="home" name="invoker" />
        <input type="hidden" name="LEN" />
        <input type="submit" value="Vai" name="button" />
    </p>
    </form>
</body>
</html>
