
function overmCell(celname, celcol) {
    var chgcell;
    if (document.layers) { // browser is NN
        chgcell = "window.document." + celname + ".bgColor='" + celcol + "'";
    }
    else //assume IE
    {
        chgcell = "document.getElementById('" + celname + "').bgColor='" + celcol + "'";
    }
    eval(chgcell);
}

function outmCell(celname, celcol) {
    var chgcell;
    if (document.layers) { // browser is NN
        chgcell = "window.document." + celname + ".bgColor='" + celcol + "'";
    }
    else //assume IE
    {
        chgcell = "document.getElementById('" + celname + "').bgColor='" + celcol + "'";
    }
    eval(chgcell);
}

function AddToFavorites() {
    var BaseUrl = "http://www.perbaffo.it";
    title = "Perbaffo - Articoli e Accessori per animali";
    if (window.sidebar) // firefox
        window.sidebar.addPanel(title, BaseUrl, "");
    else if (window.opera && window.print) { // opera
        var elem = document.createElement('a');
        elem.setAttribute('href', BaseUrl);
        elem.setAttribute('title', title);
        elem.setAttribute('rel', 'sidebar');
        elem.click();
    }
    else if (document.all)// ie
        window.external.AddFavorite(BaseUrl, title);
}

function SocialBookmarks(BaseUrl, Indirizzo, Titolo) {
    var I = encodeURIComponent(Indirizzo);
    var T = encodeURIComponent(Titolo);
    with (document) {
        write('<a target="_blank" href="http://digg.com/submit?phase=2&url=' + I + '&title=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/digg.gif" title="Segnala su Digg"></a> ');
        write('<a target="_blank" href="http://del.icio.us/post?url=' + I + '&title=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/delicious.gif" title="Segnala su Del.icio.us"></a> ');
        write('<a target="_blank" href="http://reddit.com/submit?url=' + I + '&title=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/reddit.gif" title="Segnala su reddit"></a> ');
        write('<a target="_blank" href="http://www.newsvine.com/_wine/save?popoff=0&url=' + I + '&h=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/newsvine.gif" title="Segnala su newsvine"></a> ');
        write('<a target="_blank" href="http://furl.net/storeIt.jsp?u=' + I + '&t=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/furl.gif" title="Segnala su Furl"></a> ');
        write('<a target="_blank" href="http://cgi.fark.com/cgi/fark/edit.pl?new_url=' + I + '&new_comment=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/fark.gif" title="Segnala su Fark"></a> ');
        write('<a target="_blank" href="http://www.spurl.net/spurl.php?url=' + I + '&title=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/spurl.gif" title="Segnala su Spurl"></a> ');
        write('<a target="_blank" href="http://www.blinklist.com/index.php?Action=Blink/addblink.php&description=&url=' + I + '&title=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/blinklist.gif" title="Segnala su BlinkList"></a> ');
        write('<a target="_blank" href="http://www.blinkbits.com/bookmarklets/save.php?v=1&source_url=' + I + '&title=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/blinkbits.gif" title="Segnala su BlinkBits"></a> ');
        write('<a target="_blank" href="http://www.connotea.org/addpopup?continue=confirm&uri=' + I + '&title=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/connotea.gif" title="Segnala su Connotea"></a> ');
        write('<a target="_blank" href="http://www.simpy.com/simpy/LinkAdd.do?href=' + I + '&title=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/simpy.gif" title="Segnala su Simpy"></a> ');
        write('<a target="_blank" href="http://www.stumbleupon.com/submit?url=href=' + I + '&title=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/strumblepon.gif" title="Segnala su StumbleUpon"></a> ');
        write('<a target="_blank" href="http://linkroll.com/insert.php?url=href=' + I + '&title=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/linkroll.gif" title="Segnala su Linkroll"></a> ');
        write('<a target="_blank" href="http://blogmarks.net/my/new.php?mini=1&url=' + I + '&title=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/blogmarks.gif" title="Segnala su BlogMarks"></a> ');
        write('<a target="_blank" href="http://www.facebook.com/sharer.php?u=' + I + '&t=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/facebook.gif" title="Segnala su FaceBook"></a> ');
        write('<a target="_blank" href="http://www.sphere.com/search?q=sphereit:' + I + '"><img border="0" src="' + BaseUrl + 'images/ico/sphere.gif" title="Segnala su SphereIt"></a> ');
        write('<a target="_blank" href="http://www.google.it/bookmarks/mark?op=add&bkmk=' + I + '&title=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/google.gif" title="Aggiungi su Google Bookmark"></a> ');
        write('<a target="_blank" href="http://myweb2.search.yahoo.com/myresults/bookmarklet?u=' + I + '&t=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/myweb.gif" title="Segnala su MyWeb"></a> ');
        //addded
        write('<a target="_blank" href="http://favorites.live.com/quickadd.aspx?marklet=1&url=' + I + '&title=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/live.gif" title="Aggiungi su Live.com"></a> ');
        write('<a target="_blank" href="http://bookmarks.excite.eu/add?url=' + I + '&title=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/excite.gif" title="Aggiungi su Excite Bookmark"></a> ');
        write('<a target="_blank" href="http://technorati.com/faves/?add=' + I + '"><img border="0" src="' + BaseUrl + 'images/ico/technorati.gif" title="Segnala su Technorati"></a> ');
        write('<a target="_blank" href="http://segnalo.com/post.html.php?url=' + I + '&title=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/segnalo_it.gif" title="Segnala su Segnalo.it"></a> ');
        write('<a target="_blank" href="http://oknotizie.alice.it/post.html.php?url=' + I + '&title=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/oknotizie.gif" title="Segnala su OKNotizie"></a> ');
        write('<a target="_blank" href="http://fai.informazione.it/submit.aspx?url=' + I + '&title=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/informazione_it.gif" title="Segnala su Informazione.it"></a> ');
        write('<a target="_blank" href="http://www.upnews.it/submit?url=' + I + '&title=' + T + '"><img border="0" src="' + BaseUrl + 'images/ico/upnews.gif" title="Segnala su Upnews"></a>');
    }
}

function fCheckSearch() {
    try {
        var _cerca = document.getElementById("MenuPerbaffo_txtCerca");

        if (_cerca == null) {
            return true;
        }
        var _value = trim(_cerca.value);
        if (_value == null || _value == "" || _value.length < 3) {
            alert('Inserire almeno 3 caratteri nel campo ricerca!');
            return false;
        }

        return true;
    }
    catch (err) {
        return true;
    }
}


function trim(stringa) {
    stringa = stringa + "";
    return stringa.replace(/^ */, "").replace(/ *$/, "");
}  
