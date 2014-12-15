using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Perbaffo.Presenter.Model
{
    /// <summary>
    /// Filtro Ricerca prodotti
    /// </summary>
    [Serializable()]
    public class FiltroProdotto
    {
        #region PUBLIC PROPERTY
        /// <summary>
        /// Identificativo categoria
        /// </summary>
        public int IDCategoria { get; set; }
        /// <summary>
        /// Codice Prodotto
        /// </summary>
        public string CodiceProdotto { get; set; }
        /// <summary>
        /// Descrizione Prodotto
        /// </summary>
        public string DescrizioneProdotto { get; set; }
        /// <summary>
        /// E' nella home page
        /// </summary>
        public bool IsHomePage { get; set; }
        /// <summary>
        /// E' nelle novita
        /// </summary>
        public bool IsNovita { get; set; }
        /// <summary>
        /// E' nelle offerte
        /// </summary>
        public bool IsOfferta { get; set; }
        /// <summary>
        /// E' un omaggio
        /// </summary>
        public bool IsOmaggio { get; set; }
        #endregion
    }
}
