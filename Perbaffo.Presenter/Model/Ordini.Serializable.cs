using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Perbaffo.Presenter.Model
{
    [Serializable()]
    public partial class Ordini
    {
        /// <summary>
        /// Lista dei dettagli dell'ordine
        /// </summary>
        public List<DettagliOrdini> DettagliOrdini { get; set; }
        /// <summary>
        /// Totale senza spese di spedzione/pagamento
        /// </summary>
        public decimal TotaleParziale { get; set; }
    }
    [Serializable()]
    public partial class TipoPagamento { }

    [Serializable()]
    public partial class TipoSpedizioni { }

    [Serializable()]
    public partial class Categorie
    {
        public List<Categorie> CategorieFiglie { get; set; }
    }
}
