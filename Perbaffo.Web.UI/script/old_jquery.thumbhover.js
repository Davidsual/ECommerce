/***/
(function($) { $.fn.thumbPopup = function(options) { settings = jQuery.extend({ popupId: "thumbPopup", popupCSS: { 'border': '1px solid #000000', 'background': '#FFFFFF' }, imgSmallFlag: "L", imgLargeFlag: "H", cursorTopOffset: 15, cursorLeftOffset: 15, loadingHtml: "<span style='padding: 5px;'>Loading</span>" }, options); popup = $("<div />").css(settings.popupCSS).attr("id", settings.popupId).css("position", "absolute").appendTo("body").hide(); $(this).hover(setPopup).mousemove(updatePopupPosition).mouseout(hidePopup); function setPopup(event) { var fullImgURL = $(this).attr("src").replace(settings.imgSmallFlag, settings.imgLargeFlag); $(this).data("hovered", true); $("<img />").bind("load", { thumbImage: this }, function(event) { if ($(event.data.thumbImage).data("hovered") == true) { $(popup).empty().append(this); updatePopupPosition(event); $(popup).show() } $(event.data.thumbImage).data("cached", true) }).attr("src", fullImgURL); if ($(this).data("cached") != true) { $(popup).append($(settings.loadingHtml)); $(popup).show() } updatePopupPosition(event) } function updatePopupPosition(event) { var windowSize = getWindowSize(); var popupSize = getPopupSize(); if (windowSize.width + windowSize.scrollLeft < event.pageX + popupSize.width + settings.cursorLeftOffset) { $(popup).css("left", event.pageX - popupSize.width - settings.cursorLeftOffset) } else { $(popup).css("left", event.pageX + settings.cursorLeftOffset) } if (windowSize.height + windowSize.scrollTop < event.pageY + popupSize.height + settings.cursorTopOffset) { $(popup).css("top", event.pageY - popupSize.height - settings.cursorTopOffset) } else { $(popup).css("top", event.pageY + settings.cursorTopOffset) } } function hidePopup(event) { $(this).data("hovered", false); $(popup).empty().hide() } function getWindowSize() { return { scrollLeft: $(window).scrollLeft(), scrollTop: $(window).scrollTop(), width: $(window).width(), height: $(window).height()} } function getPopupSize() { return { width: $(popup).width(), height: $(popup).height()} } return this } })(jQuery);


function overmCell(a,b){var c if(document.layers){c="window.document."+a+".bgColor='"+b+"'"}else{c="document.getElementById('"+a+"').bgColor='"+b+"'"}eval(c)}function outmCell(a,b){var c if(document.layers){c="window.document."+a+".bgColor='"+b+"'"}else{c="document.getElementById('"+a+"').bgColor='"+b+"'"}eval(c)}function AddToFavorites(){var a="http://www.perbaffo.it";title="Perbaffo - Articoli e Accessori per animali";if(window.sidebar)window.sidebar.addPanel(title,a,"");else if(window.opera&&window.print){var b=document.createElement('a');b.setAttribute('href',a);b.setAttribute('title',title);b.setAttribute('rel','sidebar');b.click()}else if(document.all)window.external.AddFavorite(a,title)}function SocialBookmarks(a,b,c){var I=encodeURIComponent(b);var T=encodeURIComponent(c);with(document){write('<a target="_blank" href="http://digg.com/submit?phase=2&url='+I+'&title='+T+'"><img border="0" src="'+a+'images/ico/digg.gif" title="Segnala su Digg"></a> ');write('<a target="_blank" href="http://del.icio.us/post?url='+I+'&title='+T+'"><img border="0" src="'+a+'images/ico/delicious.gif" title="Segnala su Del.icio.us"></a> ');write('<a target="_blank" href="http://reddit.com/submit?url='+I+'&title='+T+'"><img border="0" src="'+a+'images/ico/reddit.gif" title="Segnala su reddit"></a> ');write('<a target="_blank" href="http://www.newsvine.com/_wine/save?popoff=0&url='+I+'&h='+T+'"><img border="0" src="'+a+'images/ico/newsvine.gif" title="Segnala su newsvine"></a> ');write('<a target="_blank" href="http://furl.net/storeIt.jsp?u='+I+'&t='+T+'"><img border="0" src="'+a+'images/ico/furl.gif" title="Segnala su Furl"></a> ');write('<a target="_blank" href="http://cgi.fark.com/cgi/fark/edit.pl?new_url='+I+'&new_comment='+T+'"><img border="0" src="'+a+'images/ico/fark.gif" title="Segnala su Fark"></a> ');write('<a target="_blank" href="http://www.spurl.net/spurl.php?url='+I+'&title='+T+'"><img border="0" src="'+a+'images/ico/spurl.gif" title="Segnala su Spurl"></a> ');write('<a target="_blank" href="http://www.blinklist.com/index.php?Action=Blink/addblink.php&description=&url='+I+'&title='+T+'"><img border="0" src="'+a+'images/ico/blinklist.gif" title="Segnala su BlinkList"></a> ');write('<a target="_blank" href="http://www.blinkbits.com/bookmarklets/save.php?v=1&source_url='+I+'&title='+T+'"><img border="0" src="'+a+'images/ico/blinkbits.gif" title="Segnala su BlinkBits"></a> ');write('<a target="_blank" href="http://www.connotea.org/addpopup?continue=confirm&uri='+I+'&title='+T+'"><img border="0" src="'+a+'images/ico/connotea.gif" title="Segnala su Connotea"></a> ');write('<a target="_blank" href="http://www.simpy.com/simpy/LinkAdd.do?href='+I+'&title='+T+'"><img border="0" src="'+a+'images/ico/simpy.gif" title="Segnala su Simpy"></a> ');write('<a target="_blank" href="http://www.stumbleupon.com/submit?url=href='+I+'&title='+T+'"><img border="0" src="'+a+'images/ico/strumblepon.gif" title="Segnala su StumbleUpon"></a> ');write('<a target="_blank" href="http://linkroll.com/insert.php?url=href='+I+'&title='+T+'"><img border="0" src="'+a+'images/ico/linkroll.gif" title="Segnala su Linkroll"></a> ');write('<a target="_blank" href="http://blogmarks.net/my/new.php?mini=1&url='+I+'&title='+T+'"><img border="0" src="'+a+'images/ico/blogmarks.gif" title="Segnala su BlogMarks"></a> ');write('<a target="_blank" href="http://www.facebook.com/sharer.php?u='+I+'&t='+T+'"><img border="0" src="'+a+'images/ico/facebook.gif" title="Segnala su FaceBook"></a> ');write('<a target="_blank" href="http://www.sphere.com/search?q=sphereit:'+I+'"><img border="0" src="'+a+'images/ico/sphere.gif" title="Segnala su SphereIt"></a> ');write('<a target="_blank" href="http://www.google.it/bookmarks/mark?op=add&bkmk='+I+'&title='+T+'"><img border="0" src="'+a+'images/ico/google.gif" title="Aggiungi su Google Bookmark"></a> ');write('<a target="_blank" href="http://myweb2.search.yahoo.com/myresults/bookmarklet?u='+I+'&t='+T+'"><img border="0" src="'+a+'images/ico/myweb.gif" title="Segnala su MyWeb"></a> ');write('<a target="_blank" href="http://favorites.live.com/quickadd.aspx?marklet=1&url='+I+'&title='+T+'"><img border="0" src="'+a+'images/ico/live.gif" title="Aggiungi su Live.com"></a> ');write('<a target="_blank" href="http://bookmarks.excite.eu/add?url='+I+'&title='+T+'"><img border="0" src="'+a+'images/ico/excite.gif" title="Aggiungi su Excite Bookmark"></a> ');write('<a target="_blank" href="http://technorati.com/faves/?add='+I+'"><img border="0" src="'+a+'images/ico/technorati.gif" title="Segnala su Technorati"></a> ');write('<a target="_blank" href="http://segnalo.com/post.html.php?url='+I+'&title='+T+'"><img border="0" src="'+a+'images/ico/segnalo_it.gif" title="Segnala su Segnalo.it"></a> ');write('<a target="_blank" href="http://oknotizie.alice.it/post.html.php?url='+I+'&title='+T+'"><img border="0" src="'+a+'images/ico/oknotizie.gif" title="Segnala su OKNotizie"></a> ');write('<a target="_blank" href="http://fai.informazione.it/submit.aspx?url='+I+'&title='+T+'"><img border="0" src="'+a+'images/ico/informazione_it.gif" title="Segnala su Informazione.it"></a> ');write('<a target="_blank" href="http://www.upnews.it/submit?url='+I+'&title='+T+'"><img border="0" src="'+a+'images/ico/upnews.gif" title="Segnala su Upnews"></a>')}}function fCheckSearch(){try{var a=document.getElementById("MenuPerbaffo_txtCerca");if(a==null){return true}var b=trim(a.value);if(b==null||b==""||b.length<3){alert('Inserire almeno 3 caratteri nel campo ricerca!');return false}return true}catch(err){return true}}function trim(a){a=a+"";return a.replace(/^ */,"").replace(/ *$/,"")}