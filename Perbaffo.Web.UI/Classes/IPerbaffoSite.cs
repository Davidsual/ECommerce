using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Perbaffo.Web.UI.Classes
{
    interface IPerbaffoSite
    {
        #region PUBLIC PROPERTY
        /// <summary>
        /// Titolo della pagina tag <title></title>
        /// </summary>
        string TitoloPagina { get; set; }
        /// <summary>
        /// Keywords della pagina tag <keywords></keywords>
        /// </summary>
        string KeywordsPagina { get; set; }
        /// <summary>
        /// Descrizione della pagina tag <description></description>
        /// </summary>
        string DescrizionePagina { get; set; }
        /// <summary>
        /// Nome dell'utente loggato
        /// </summary>
        string UtenteCorrente { get; set; }
        #endregion
    }
}
