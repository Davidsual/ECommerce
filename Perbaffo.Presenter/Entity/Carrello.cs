using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Presenter
{
    [Serializable()]
    public sealed class Carrello
    {
        #region PRIVATE MEMBERS
        private decimal _totale = new decimal(0.00);
        #endregion

        #region PUBLIC PROPERTY
        public Guid IDCarrello { get; set; }
        public int IDUtente { get; set; }
        public List<CarrelloItem> Prodotti { get; set; }
        public int IDCodicePromozione { get; set; }
        public int IDUtentePromozione { get; set; }
        public string CodiceSconto { get; set; }
        public decimal TotaleCodiceScontoEuro { get; set; }
        public int TotaleCodiceScontoPerc { get; set; }
        public decimal TotaleUtenteScontoEuro { get; set; }
        public int TotaleUtenteScontoPerc { get; set; }
        public decimal TotaleCarrello { get; set; }
        public DateTime DataCarrello { get; set; }
        public decimal TotaleScontoSpedizione { get; set; }
        #endregion
    }
    [Serializable()]
    public sealed class CarrelloItem
    {
        #region PRIVATE MEMBERS
        private decimal _totale = new decimal(0.00);
        #endregion

        #region PUBLIC PROPERTY
        public CarreloItemKey IDCarrelloItem { get; set; }
        public ProdottoImmagine Prodotto { get; set; }
        public ProdottiTaglie Taglia { get; set; }
        public Colori Colore { get; set; }
        public int Quantita { get; set; }
        public decimal Totale { get; set; }
        #endregion
    }
    [Serializable()]
    public sealed class CarreloItemKey
    {
        public int IDProdotto { get; set; }
        public int IDColore { get; set; }
        public int IDTaglia { get; set; }

        public override string ToString()
        {
            return string.Format("{0}${1}${2}",IDProdotto.ToString(),IDColore.ToString(),IDTaglia.ToString());
        }
    }
}
