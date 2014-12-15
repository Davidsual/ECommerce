using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Perbaffo.Presenter.Model;
using System.Data.Linq;

namespace Perbaffo.Presenter
{
    public partial class ControllerPresentation : IDisposable
    {
        #region PUBLIC MEMBERS
        public enum OrderType
        {
            Nome,
            Prezzo
        }
        #endregion

        #region PRIVATE MEMBERS
        private const int ID_CATEGORIA_CANI = 20;
        private const int ID_CATEGORIA_GATTI = 1;
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// Ottiene tutti i prodotti della categoria cani filtrati per lettera iniziale
        /// </summary>
        /// <param name="categorie"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        public List<ProdottoImmagine> GetProdottiByNomeCategoria(List<int> categorie, string nome)
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return (from ProdottoImmagine _prod in _model.ProdottoImmagines
                        join ProdCateg _cat in _model.ProdCategs on _prod.ID equals _cat.IDProdotto
                        where categorie.Contains(_cat.IDCategoria) && _prod.Attivo == true && _prod.Nome.ToLower().StartsWith(nome.ToLower())
                        select _prod).Distinct().OrderBy(pr => pr.Nome).ToList();
            }
        }
        /// <summary>
        /// Ottiene tutti i prodotti della categoria cani filtrati per fascia
        /// </summary>
        /// <param name="categorie"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        public List<ProdottoImmagine> GetProdottiByRangePrezzo(List<int> categorie, decimal startTotale,decimal endTotale)
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return (from ProdottoImmagine _prod in _model.ProdottoImmagines
                        join ProdCateg _cat in _model.ProdCategs on _prod.ID equals _cat.IDProdotto
                        where categorie.Contains(_cat.IDCategoria) && _prod.Attivo == true && (_prod.Totale >= startTotale && _prod.Totale <= endTotale)
                        select _prod).Distinct().OrderBy(pr => pr.Totale).ThenBy(pr => pr.Totale).ToList();
            }
        }
        /// <summary>
        /// Aggiorna la giacenza di un prodotto a seguito di un ordine
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <param name="quantita"></param>
        public void UpdateProdottiGiacenza(int IDProdotto, int quantita)
        {
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    Prodotti _prod = _model.Prodottis.Where(prod => prod.Attivo == true && prod.ID == IDProdotto).SingleOrDefault();
                    if (_prod != null)
                    {
                        _prod.Giacenza = (_prod.Giacenza.HasValue) ? _prod.Giacenza -= quantita : 0;
                        ///Disattivo il prodotto che ha giacenza 0
                        if (_prod.Giacenza <= 0)
                            _prod.Attivo = false;
                        _model.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        /// <summary>
        /// Indica se può o meno inserire una recensione
        /// </summary>
        /// <param name="IDUtente"></param>
        /// <returns></returns>
        public bool ExistRecensioneByIDUtente(int IDUtente,int IDProdotto)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return _model.ProdottiRecensionis.Where(rec => rec.IDUtente == IDUtente && rec.IDProdotto == IDProdotto).Count() > 0;
            }
        }
        /// <summary>
        /// Restituisce tutte le recensioni per un prodotto
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public List<ProdottiRecensioni> GetRecensioniByIDProdotto(int IDProdotto)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return _model.ProdottiRecensionis.Where(rec => rec.IDProdotto == IDProdotto).OrderByDescending(rec => rec.Voto).ToList();
            }
        }
        /// <summary>
        /// Restituisce tutte le recnesioni per un prodotto con la possibilità di dire quante recensioni si vuol visualizzare
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <param name="NumRecensioni"></param>
        /// <returns></returns>
        public List<ProdottiRecensioni> GetRecensioniByIDProdotto(int IDProdotto,int NumRecensioni)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return _model.ProdottiRecensionis.Where(rec => rec.IDProdotto == IDProdotto).OrderByDescending(rec => rec.DataInserimento).Take(NumRecensioni).ToList();
            }
        }
        /// <summary>
        /// totale dei prodotti votati
        /// </summary>
        /// <returns></returns>
        public int GetCountProdottiVotati()
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return (from tbl in (from ProdottiRecensioni _rec in _model.ProdottiRecensionis
                            group _rec by new
                            {
                                _rec.IDProdotto
                            }
                            into gruppo select new { dummy = "x"}                         
                            )select tbl).Count();
            }
        }
        /// <summary>
        /// Otttiene una lista di prodotti votati paginati
        /// </summary>
        /// <returns></returns>
        public List<ProdottoImmagine> GetProdottiPiuVotati(int startRowIndex, int maximumRows)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                var query = from ProdottiRecensioni _rec in _model.ProdottiRecensionis
                            group _rec by new
                            {
                                _rec.IDProdotto
                            }
                                into gruppo
                                select new
                                {
                                    IDProdotto = gruppo.Select(i => i.IDProdotto).FirstOrDefault(),
                                    valore = gruppo.Sum(i => i.Voto) / gruppo.Count()
                                };

                ProdottoImmagine _prodotto = null;
                List<ProdottoImmagine> _lstProdotti = new List<ProdottoImmagine>();
                using (ProdottiPresentationDataContext _modelProdotti = new ProdottiPresentationDataContext())
                {
                    query.OrderByDescending(val => val.valore).Skip(startRowIndex).Take(maximumRows).ToList().ForEach(item =>
                    {
                        _prodotto = _modelProdotti.ProdottoImmagines.Where(pro => pro.Attivo == true && pro.ID == item.IDProdotto).SingleOrDefault();
                        if (_prodotto != null)
                        {
                            _prodotto.Voto = item.valore;
                            _lstProdotti.Add(_prodotto);
                        }
                    });
                }
                return _lstProdotti;
            }
        }
        /// <summary>
        /// Otttiene una lista di prodotti votati
        /// </summary>
        /// <returns></returns>
        public List<ProdottoImmagine> GetProdottiPiuVotati()
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                var query = from ProdottiRecensioni _rec in _model.ProdottiRecensionis
                            group _rec by new
                            {
                                _rec.IDProdotto
                            }
                            into gruppo                          
                            select new
                            {
                                IDProdotto = gruppo.Select(i => i.IDProdotto).FirstOrDefault(),
                                valore = gruppo.Sum(i => i.Voto) / gruppo.Count()
                            };

                ProdottoImmagine _prodotto = null;
                List<ProdottoImmagine> _lstProdotti = new List<ProdottoImmagine>();
                using (ProdottiPresentationDataContext _modelProdotti = new ProdottiPresentationDataContext())
                {
                    query.OrderByDescending(val => val.valore).Take(15).ToList().ForEach(item =>
                    {
                        _prodotto = _modelProdotti.ProdottoImmagines.Where(pro => pro.Attivo == true && pro.ID == item.IDProdotto).SingleOrDefault();
                        if (_prodotto != null)
                        {
                            _prodotto.Voto = item.valore;
                            _lstProdotti.Add(_prodotto);
                        }
                    });
                }
                return _lstProdotti;
            }
        }
        /// <summary>
        /// Ottiene il voto del prodotto dato il suo id
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public int GetVotoProdottoByIDProdotto(int IDProdotto)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                var query = from ProdottiRecensioni _rec in _model.ProdottiRecensionis
                            where _rec.IDProdotto == IDProdotto
                            group _rec by new
                            {
                                _rec.IDProdotto
                            } 
                            into gruppo
                            select new
                            {
                                valore = gruppo.Sum(i => i.Voto) / gruppo.Count()
                            };
                return query.Select(i => i.valore).FirstOrDefault();
            }
        }
        /// <summary>
        /// Salva una recensione
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="titolo"></param>
        /// <param name="voto"></param>
        /// <param name="recensione"></param>
        public void SetRecensioneProdotto(int IDProdotto,int IDUtente,string nome, string titolo, int voto, string recensione)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                //_model.ObjectTrackingEnabled = false;
                //_model.DeferredLoadingEnabled = false;
                ProdottiRecensioni _prodRecensione = new ProdottiRecensioni()
                {
                     DataInserimento = DateTime.Now,
                     IDProdotto = IDProdotto,
                     IDUtente = IDUtente,
                     Titolo = titolo,
                     Nome = nome,
                     Recensione = recensione,
                     Voto = voto
                };
                _model.ProdottiRecensionis.InsertOnSubmit(_prodRecensione);
                _model.SubmitChanges();
            }
        }
        /// <summary>
        /// Restituisce il prodotto dato il suo ID
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public Prodotti GetProdottoLightByIDProdotto(int IDProdotto)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return _model.Prodottis.Where(prod => prod.ID == IDProdotto).SingleOrDefault();
            }
        }
        /// <summary>
        /// Numero di prodotti in omaggio per il range
        /// </summary>
        /// <param name="Range"></param>
        /// <returns></returns>
        public int GetCountProdottoOmaggioByRange(decimal Range)
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && prod.IsOmaggio == true && prod.RangeOmaggio <= Range).Count();
            }
        }
        /// <summary>
        /// Prodotti da mettere in vetrina
        /// </summary>
        /// <param name="numProdotti"></param>
        /// <returns></returns>
        public List<ProdottoImmagine> GetProdottiOmaggioByRange(int startRowIndex, int maximumRows,decimal Range)
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && prod.IsOmaggio == true && prod.RangeOmaggio <= Range).OrderByDescending(prod => prod.RangeOmaggio).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }
        /// <summary>
        /// Numero totale di prodotti trovati per quel criterio di ricerca
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public int GetCountProdottiByDescription(string description)
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                string _filter = string.Empty;
                string[] _ricerca = description.Split(' ');
                _model.DeferredLoadingEnabled = false;
                _model.ObjectTrackingEnabled = false;

                if (_ricerca != null && _ricerca.Count() == 1 && _ricerca[0].Length > 3)
                {
                    _filter = _ricerca[0].Substring(0, _ricerca[0].Length - 1);
                    //return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && (prod.Codice.ToLower().Contains(_filter.ToLower()) || prod.Nome.ToLower().Contains(_filter.ToLower()) || prod.DescrizioneLunga.Contains(_filter))).Distinct().Count();
                    return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && (prod.Codice.ToLower().Contains(_filter.ToLower()) || prod.Nome.ToLower().Contains(_filter.ToLower()))).Distinct().Count();

                }
                else
                {
                    //return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && (prod.Codice.ToLower().Contains(description.ToLower()) || prod.Keywords.ToLower().Contains(description.ToLower()) || prod.Nome.ToLower().Contains(description.ToLower()) || prod.DescrizioneLunga.Contains(description))).Distinct().Count();
                    return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && (prod.Codice.ToLower().Contains(description.ToLower()) || prod.Keywords.ToLower().Contains(description.ToLower()) || prod.Nome.ToLower().Contains(description.ToLower()) )).Distinct().Count();
                }
            }
        }
        /// <summary>
        /// Ricerca di un prodotto
        /// </summary>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public List<ProdottoImmagine> FindProdottiByDescription(int startRowIndex, int maximumRows, string description)
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                
                string _filter = string.Empty;
                string[] _ricerca = description.Split(' ');
                _model.DeferredLoadingEnabled = false;
                _model.ObjectTrackingEnabled = false;

                if (_ricerca != null && _ricerca.Count() == 1 && _ricerca[0].Length > 3)
                {
                    _filter = _ricerca[0].Substring(0, _ricerca[0].Length - 1);
                    //return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && (prod.Codice.ToLower().Contains(_filter.ToLower()) || prod.Nome.ToLower().Contains(_filter.ToLower()) || prod.DescrizioneLunga.Contains(_filter))).Distinct().OrderBy(prod => prod.Nome).Skip(startRowIndex).Take(maximumRows).ToList();
                    return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && (prod.Codice.ToLower().Contains(_filter.ToLower()) || prod.Nome.ToLower().Contains(_filter.ToLower()))).Distinct().OrderBy(prod => prod.Nome).Skip(startRowIndex).Take(maximumRows).ToList();
                }
                else
                {
                    //return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && (prod.Codice.ToLower().Contains(description.ToLower()) || prod.Keywords.ToLower().Contains(description.ToLower()) || prod.Nome.ToLower().Contains(description.ToLower()) || prod.DescrizioneLunga.Contains(description))).Distinct().OrderBy(prod => prod.Nome).Skip(startRowIndex).Take(maximumRows).ToList();
                    return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && (prod.Codice.ToLower().Contains(description.ToLower()) || prod.Keywords.ToLower().Contains(description.ToLower()) || prod.Nome.ToLower().Contains(description.ToLower()) )).Distinct().OrderBy(prod => prod.Nome).Skip(startRowIndex).Take(maximumRows).ToList();

                }
            }
        }
        /// <summary>
        /// Ritorna tre prodotti scelti a caso tra le novità
        /// </summary>
        /// <returns></returns>
        public List<ProdottoNovita> GetTreProdottiNovita()
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return _model.ProdottoNovitas.OrderByDescending(prod => _model.GetNewID()).Take(3).ToList();
            }
        }
        /// <summary>
        /// Ritorna novità 20 prodotti
        /// </summary>
        /// <returns></returns>
        public List<ProdottoNovita> GetProdottiNovita()
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return _model.ProdottoNovitas.ToList();
            }
        }
        /// <summary>
        /// Prodotti da mettere in vetrina
        /// </summary>
        /// <param name="numProdotti"></param>
        /// <returns></returns>
        public List<ProdottoImmagine> GetProdottiVetrina(int numProdotti)
        {
            //CompiledQuery
            Func<ProdottiPresentationDataContext,int, IEnumerable<ProdottoImmagine>> func =
               CompiledQuery.Compile<ProdottiPresentationDataContext, int, IEnumerable<ProdottoImmagine>>
               ((ProdottiPresentationDataContext _model,int numProd) => _model.ProdottoImmagines.
                  Where(prod => prod.Attivo == true).OrderByDescending(prod => _model.GetNewID()).Take(numProd));
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return func(_model, numProdotti).ToList();
                //return _model.ProdottoImmagines.Where(prod => prod.Attivo == true).OrderByDescending(prod => _model.GetNewID()).Take(numProdotti).ToList();
            }
        }
        /// <summary>
        /// Prodotti da mettere in vetrina
        /// </summary>
        /// <param name="numProdotti"></param>
        /// <returns></returns>
        public List<ProdottoImmagine> GetProdottiOmaggio(int startRowIndex, int maximumRows)
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && prod.IsOmaggio == true).OrderByDescending(prod => prod.RangeOmaggio).ThenBy(c => c.Nome).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }
        /// <summary>
        /// Totale dei prodotti in omaggio
        /// </summary>
        /// <returns></returns>
        public int GetCountProdottiOmaggio()
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && prod.IsOmaggio == true).Count();
            }
        }
        /// <summary>
        /// Prodotti in offerta
        /// </summary>
        /// <param name="numProdotti"></param>
        /// <returns></returns>
        public List<ProdottoImmagine> GetProdottiOfferta(int numProdotti)
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && ((prod.ScontoPercent != 0) || (prod.ScontoEuro != new decimal(0.00)))).OrderByDescending(prod => _model.GetNewID()).Take(numProdotti).ToList();
            }
        }
        /// <summary>
        /// Numero totale dei prodotti in offerta
        /// </summary>
        /// <returns></returns>
        public int GetCountProdottiOfferta()
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && ((prod.ScontoPercent != 0) || (prod.ScontoEuro != new decimal(0.00)))).Count();
            }
        }
        /// <summary>
        /// Prodotti in offerta paginati
        /// </summary>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <returns></returns>
        public List<ProdottoImmagine> GetProdottiOfferta(int startRowIndex, int maximumRows)
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && ((prod.ScontoPercent != 0) || (prod.ScontoEuro != new decimal(0.00)))).OrderBy(prod => prod.Nome).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }
        /// <summary>
        /// Prodotti in offerta paginati e ordinati
        /// </summary>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <returns></returns>
        public List<ProdottoImmagine> GetProdottiOfferta(int startRowIndex, int maximumRows,OrderType ordinamento)
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                _model.ObjectTrackingEnabled = false;
                switch (ordinamento)
                {
                    case OrderType.Nome:
                        return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && prod.Giacenza > 0 && ((prod.ScontoPercent != 0) || (prod.ScontoEuro != new decimal(0.00)))).OrderBy(prod => prod.Nome).Skip(startRowIndex).Take(maximumRows).ToList();
                        break;
                    case OrderType.Prezzo:
                        return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && prod.Giacenza > 0 && ((prod.ScontoPercent != 0) || (prod.ScontoEuro != new decimal(0.00)))).OrderBy(prod => prod.Totale).Skip(startRowIndex).Take(maximumRows).ToList();
                        break;
                    default:
                        return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && prod.Giacenza > 0 && ((prod.ScontoPercent != 0) || (prod.ScontoEuro != new decimal(0.00)))).OrderBy(prod => prod.Nome).Skip(startRowIndex).Take(maximumRows).ToList();
                        break;
                }
                
            }
        }
        /// <summary>
        /// Ottiene le taglie dato un id prodotto
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public List<ProdottiTaglie> GetProdottiTaglieByIDProdotto(int IDProdotto)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return _model.ProdottiTaglies.Where(tag => tag.IDProdotto == IDProdotto).OrderBy(c => c.Totale).ToList();
            }
        }
        /// <summary>
        /// Totale dei prodotti in base alla categoria
        /// </summary>
        /// <param name="IDCategoria"></param>
        /// <returns></returns>
        public int GetCountProdottiByIDCategoria(int IDCategoria)
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                _model.ObjectTrackingEnabled = false;
                return (from ProdottoImmagine _prod in _model.ProdottoImmagines
                        join ProdCateg _cat in _model.ProdCategs on _prod.ID equals _cat.IDProdotto
                        where _cat.IDCategoria == IDCategoria && _prod.Attivo == true
                        select _prod).Count();
            }
        }
        /// <summary>
        /// Tutti i prodotti per una cerca categoria
        /// </summary>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <param name="IDCategoria"></param>
        /// <returns></returns>
        public List<ProdottoImmagine> GetProdottiByIDCategoria(int startRowIndex, int maximumRows, int IDCategoria)
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                _model.ObjectTrackingEnabled = false;
                return (from ProdottoImmagine _prod in _model.ProdottoImmagines
                        join ProdCateg _cat in _model.ProdCategs on _prod.ID equals _cat.IDProdotto
                        where _cat.IDCategoria == IDCategoria && _prod.Attivo == true
                        select _prod).OrderBy(prod => prod.Nome).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }
        /// <summary>
        /// Tutti i prodotti per una cerca categoria e ordinamento
        /// </summary>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <param name="IDCategoria"></param>
        /// <returns></returns>
        public List<ProdottoImmagine> GetProdottiByIDCategoriaAndOrder(int startRowIndex, int maximumRows, int IDCategoria,OrderType ordinamento)
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                _model.ObjectTrackingEnabled = false;
                switch (ordinamento)
                {
                    case OrderType.Nome:
                        return (from ProdottoImmagine _prod in _model.ProdottoImmagines
                                join ProdCateg _cat in _model.ProdCategs on _prod.ID equals _cat.IDProdotto
                                where _cat.IDCategoria == IDCategoria && _prod.Attivo == true
                                select _prod).OrderBy(prod => prod.Nome).Skip(startRowIndex).Take(maximumRows).ToList();
                        break;
                    case OrderType.Prezzo:
                        return (from ProdottoImmagine _prod in _model.ProdottoImmagines
                                join ProdCateg _cat in _model.ProdCategs on _prod.ID equals _cat.IDProdotto
                                where _cat.IDCategoria == IDCategoria && _prod.Attivo == true
                                select _prod).OrderBy(prod => prod.Totale).Skip(startRowIndex).Take(maximumRows).ToList();
                        break;
                    default:
                        return (from ProdottoImmagine _prod in _model.ProdottoImmagines
                                join ProdCateg _cat in _model.ProdCategs on _prod.ID equals _cat.IDProdotto
                                where _cat.IDCategoria == IDCategoria && _prod.Attivo == true
                                select _prod).OrderBy(prod => prod.Nome).Skip(startRowIndex).Take(maximumRows).ToList();
                        break;
                }

            }
        }
        /// <summary>
        /// Restituisce dei prodotti recensiti nella categoria e nelle sue sotto categorie
        /// </summary>
        /// <param name="IDCategoria"></param>
        /// <param name="NumProdotti"></param>
        /// <returns></returns>
        public List<ProdottoImmagine> GetProdottiCasualiByIDCategoria(int IDCategoria, int NumProdotti)
        {
            List<int> _list = this.GetIDCategorieByIDCategoria(IDCategoria);
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                _model.ObjectTrackingEnabled = false;
                if (_list != null && _list.Count > 0)
                {
                    return (from ProdottoImmagine _prod in _model.ProdottoImmagines
                            join ProdCateg _cat in _model.ProdCategs on _prod.ID equals _cat.IDProdotto
                            where _list.Contains(_cat.IDCategoria) && _prod.Attivo == true
                            select _prod).OrderBy(prod => _model.GetNewID()).Take(NumProdotti).ToList();
                }
                else
                    return null;
            }
        }
        /// <summary>
        /// Restituisco i prodotti presi dalla categoria e sua sotto cateogoria
        /// </summary>
        /// <param name="IDCategoria"></param>
        /// <returns></returns>
        public List<ProdottoImmagine> GetProdottiCategSottoCategByIDCateg(int IDCategoria)
        {
            List<int> _list = this.GetIDCategorieByIDCategoria(IDCategoria);
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                _model.ObjectTrackingEnabled = false;
                if (_list != null && _list.Count > 0)
                {
                    return (from ProdottoImmagine _prod in _model.ProdottoImmagines
                            join ProdCateg _cat in _model.ProdCategs on _prod.ID equals _cat.IDProdotto
                            where _list.Contains(_cat.IDCategoria) && _prod.Attivo == true
                            select _prod).OrderBy(prod => prod.Prezzo).ToList();
                }
                else
                    return null;
            }
        }
        /// <summary>
        /// Restituisco i prodotti presi dalla categoria e sua sotto cateogoria
        /// </summary>
        /// <param name="IDCategoria"></param>
        /// <returns></returns>
        public List<ProdottoImmagine> GetProdottiCategSottoCategDistinctByIDCateg(int IDCategoria)
        {
            List<int> _list = this.GetIDCategorieByIDCategoria(IDCategoria);
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                _model.ObjectTrackingEnabled = false;
                if (_list != null && _list.Count > 0)
                {
                    return (from ProdottoImmagine _prod in _model.ProdottoImmagines
                            join ProdCateg _cat in _model.ProdCategs on _prod.ID equals _cat.IDProdotto
                            where _list.Contains(_cat.IDCategoria) && _prod.Attivo == true
                            select _prod).Distinct().OrderBy(prod => prod.Prezzo).ToList();
                }
                else
                    return null;
            }
        }
        /// <summary>
        /// Totale dei prodotti in promozione per cani
        /// </summary>
        /// <returns></returns>
        public int GetCoutProdottiPromozioniCani()
        {
            List<int> _list = this.GetIDCategorieByIDCategoria(ID_CATEGORIA_CANI);
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return (from ProdottoImmagine _prod in _model.ProdottoImmagines
                        join ProdCateg _cat in _model.ProdCategs on _prod.ID equals _cat.IDProdotto
                        where _list.Contains(_cat.IDCategoria) && _prod.Attivo == true && ((_prod.ScontoPercent != 0) || (_prod.ScontoEuro != new decimal(0.00)))
                        select _prod).Distinct().Count();
            }
        }
        /// <summary>
        /// Totale dei prodotti in promozione per gatti
        /// </summary>
        /// <returns></returns>
        public int GetCoutProdottiPromozioniGatti()
        {
            List<int> _list = this.GetIDCategorieByIDCategoria(ID_CATEGORIA_GATTI);
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return (from ProdottoImmagine _prod in _model.ProdottoImmagines
                        join ProdCateg _cat in _model.ProdCategs on _prod.ID equals _cat.IDProdotto
                        where _list.Contains(_cat.IDCategoria) && _prod.Attivo == true && ((_prod.ScontoPercent != 0) || (_prod.ScontoEuro != new decimal(0.00)))
                        select _prod).Distinct().Count();
            }
        }
        /// <summary>
        /// Prodotti in promozioni per gatti paginati
        /// </summary>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <returns></returns>
        public List<ProdottoImmagine> GetProdottiPromozioniGatti(int startRowIndex, int maximumRows)
        {
            List<int> _list = this.GetIDCategorieByIDCategoria(ID_CATEGORIA_GATTI);
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return (from ProdottoImmagine _prod in _model.ProdottoImmagines
                        join ProdCateg _cat in _model.ProdCategs on _prod.ID equals _cat.IDProdotto
                        where _list.Contains(_cat.IDCategoria) && _prod.Attivo == true && ((_prod.ScontoPercent != 0) || (_prod.ScontoEuro != new decimal(0.00)))
                        select _prod).Distinct().OrderByDescending(prod => prod.ScontoPercent).ThenBy(prod => prod.ScontoEuro).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }
        /// <summary>
        /// Prodotti in promozioni per cani paginati
        /// </summary>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <returns></returns>
        public List<ProdottoImmagine> GetProdottiPromozioniCani(int startRowIndex, int maximumRows)
        {
            List<int> _list = this.GetIDCategorieByIDCategoria(ID_CATEGORIA_CANI);
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return (from ProdottoImmagine _prod in _model.ProdottoImmagines
                        join ProdCateg _cat in _model.ProdCategs on _prod.ID equals _cat.IDProdotto
                        where _list.Contains(_cat.IDCategoria) && _prod.Attivo == true && ((_prod.ScontoPercent != 0) || (_prod.ScontoEuro != new decimal(0.00)))
                        select _prod).Distinct().OrderByDescending(prod => prod.ScontoPercent).ThenBy(prod => prod.ScontoEuro).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }
        /// <summary>
        /// Restituisce il colore dato il suo id
        /// </summary>
        /// <param name="IDColore"></param>
        /// <returns></returns>
        public Colori GetColoreByIDColore(int IDColore)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return _model.Coloris.Where(col => col.ID == IDColore).SingleOrDefault();
            }
        }
        /// <summary>
        /// Totale dei prodotti nella lista dei preferiti
        /// </summary>
        /// <param name="IDUtente"></param>
        /// <returns></returns>
        public int GetCountProdottiPreferitiByIDUtente(int IDUtente)
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return (from ProdottoImmagine _prod in _model.ProdottoImmagines
                        join ProdottiPreferiti _pref in _model.ProdottiPreferitis on _prod.ID equals _pref.IDProdotto
                        where _pref.IDUtente == IDUtente && _prod.Attivo == true
                        select _prod).Distinct().Count();
            }
        }
        /// <summary>
        /// Ottiene tutti i prodotti di un utente
        /// </summary>
        /// <param name="IDUtente"></param>
        /// <returns></returns>
        public List<ProdottoImmagine> GetProdottiPreferitiByIDUtente(int startRowIndex, int maximumRows,int IDUtente)
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return (from ProdottoImmagine _prod in _model.ProdottoImmagines
                        join ProdottiPreferiti _pref in _model.ProdottiPreferitis on _prod.ID equals _pref.IDProdotto
                        where _pref.IDUtente == IDUtente && _prod.Attivo == true
                        select _prod).Distinct().OrderBy(prod => prod.Nome).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }

        #region DETTAGLIO PRODOTTO
        /// <summary>
        /// Restituisce la taglia dato il suo ID
        /// </summary>
        /// <param name="IDTaglia"></param>
        /// <returns></returns>
        public ProdottiTaglie GetTagliaByIDTaglia(int IDTaglia,int IDProdotto)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return _model.ProdottiTaglies.Where(tag => tag.ID == IDTaglia && tag.IDProdotto == IDProdotto).SingleOrDefault();
            }
        }
        /// <summary>
        /// Ottiene la descrizione della taglia del prodotto
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public ProdottoImmagine GetDescrizioneTagliaProdottoByIDProdotto(int IDProdotto)
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return _model.ProdottoImmagines.Where(prod => prod.ID == IDProdotto).SingleOrDefault();
            }
        }
        /// <summary>
        /// Ottiene il prodotto dato il suo id
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public ProdottoImmagine GetProdottoByIDProdotto(int IDProdotto)
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && prod.ID == IDProdotto).SingleOrDefault();
            }
        }
        /// <summary>
        /// Ottiene il prodotto dato il suo id
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public ProdottoImmagine GetProdottoByIDProdotto(int IDProdotto,bool IgnoreActive)
        {
            using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                if(IgnoreActive)
                    return _model.ProdottoImmagines.Where(prod => prod.ID == IDProdotto).SingleOrDefault();
                else
                    return _model.ProdottoImmagines.Where(prod => prod.Attivo == true && prod.ID == IDProdotto).SingleOrDefault();
            }
        }
        /// <summary>
        /// Restituisce tutti i colori disponibili per il prodotto
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public List<Colori> GetProdottoColoriByIDProdotto(int IDProdotto)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return (from Colori _col in _model.Coloris
                        join ProdottiColori _prodCol in _model.ProdottiColoris on _col.ID equals _prodCol.IDColore
                        where _prodCol.IDProdotto == IDProdotto
                        select _col).OrderBy(col => col.Descrizione).ToList();
            }
        }
        /// <summary>
        /// Ottiene Tutte le taglie di un prodotto
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public List<ProdottiTaglie> GetProdottoTaglieByIDProdotto(int IDProdotto)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return (from ProdottiTaglie _tagl in _model.ProdottiTaglies
                        join Prodotti _prod in _model.Prodottis on _tagl.IDProdotto equals _prod.ID
                        where _prod.ID == IDProdotto && _prod.Attivo == true
                        select _tagl).OrderByDescending(_tagl => _tagl.Totale).ToList();
            }
        }
        /// <summary>
        /// Ottiene le eventuali fotogallery di un prodotto
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public List<ProdottiFotogallery> GetProdottoFotoGalleryByIDProdotto(int IDProdotto)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                return (from ProdottiFotogallery _foto in _model.ProdottiFotogalleries
                        join Prodotti _prod in _model.Prodottis on _foto.IDProdotto equals _prod.ID
                        where _prod.ID == IDProdotto && _prod.Attivo == true
                        select _foto).ToList();
            }
        }
        /// <summary>
        /// Ottiene gli eventuali prodotti allegati
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public List<ProdottoImmagine> GetProdottiAllegatiByIDProdotto(int IDProdotto)
        {
            List<int> _listAlleg = null;
            List<ProdottoImmagine> _return = null;
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _model.ObjectTrackingEnabled = false;
                _listAlleg = (from ProdottiAllegati _alleg in _model.ProdottiAllegatis
                        join Prodotti _prod in _model.Prodottis on _alleg.IDProdottoPrincipale equals _prod.ID
                        where _prod.ID == IDProdotto && _prod.Attivo == true
                        select _alleg.IDProdottoAllegato).ToList();
            }
            if (_listAlleg != null && _listAlleg.Count > 0)
            {
                using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
                {
                    _model.ObjectTrackingEnabled = false;
                    _return = (from ProdottoImmagine _prod in _model.ProdottoImmagines
                               where _listAlleg.Distinct().Contains(_prod.ID) && _prod.Attivo == true
                               select _prod).OrderBy(prod => prod.Nome).ToList();
                }
            }
            return _return;
        }
        #endregion

        #region SET
        /// <summary>
        /// Cancella un prodotto dalla lista dei preferiti
        /// </summary>
        /// <param name="IDUtente"></param>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public bool CancellaProdottoPreferito(int IDUtente, int IDProdotto)
        {
            try
            {
                using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
                {
                    ProdottiPreferiti _pref = _model.ProdottiPreferitis.Where(prod => prod.IDUtente == IDUtente && prod.IDProdotto == IDProdotto).SingleOrDefault();
                    if (_pref != null)
                    {
                        _model.ProdottiPreferitis.DeleteOnSubmit(_pref);
                        _model.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Aggiunge un prodotto ai preferiti
        /// </summary>
        /// <param name="IDUtente"></param>
        /// <param name="IDProdotto"></param>
        /// <param name="IDTaglia"></param>
        /// <returns></returns>
        public bool AggiungiProdottoPreferito(int IDUtente, int IDProdotto)
        {
            if (IDUtente <= 0 || IDProdotto <= 0)
                return false;
            try
            {
                using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
                {
                    int _count = _model.ProdottiPreferitis.Where(prod => prod.IDUtente == IDUtente).Count();
                    if (_count == 30)
                        return false;
                    _count = 0;
                    _count = _model.ProdottiPreferitis.Where(prod => prod.IDProdotto == IDProdotto).Count();
                    if (_count > 0)
                        return true;

                    ProdottiPreferiti _preferito = new ProdottiPreferiti()
                    {
                        IDProdotto = IDProdotto,
                        IDUtente = IDUtente,
                        DataInserimento = DateTime.Now
                    };
                    _model.ProdottiPreferitis.InsertOnSubmit(_preferito);
                    _model.SubmitChanges();
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Rimuove un prodotto ai preferiti
        /// </summary>
        /// <param name="IDUtente"></param>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public bool RimuoviProdottoPreferito(int IDUtente, int IDProdotto)
        {
            if (IDUtente <= 0 || IDProdotto <= 0)
                return false;
            try
            {
                using (ProdottiPresentationDataContext _model = new ProdottiPresentationDataContext())
                {
                    ProdottiPreferiti _prodotto = _model.ProdottiPreferitis.Where(prod => prod.IDUtente == IDUtente && prod.IDProdotto == IDProdotto).SingleOrDefault();
                    if (_prodotto != null)
                    {
                        _model.ProdottiPreferitis.DeleteOnSubmit(_prodotto);
                        _model.SubmitChanges();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region EXPORT PRODOTTI
        /// <summary>
        /// Risultato dell'esportazione prezzi
        /// </summary>
        /// <returns></returns>
        public List<ExportProdottiIPrezziResult> ExportProdottiIPrezzi()
        {
            using (ExportProdottiDataContext _model = new ExportProdottiDataContext())
            {
                return _model.ExportProdottiIPrezzi().ToList();
            }
        }

        /// <summary>
        /// Risultato dell'esportazione BuyPlaza
        /// </summary>
        /// <returns></returns>
        public List<ExportProdottiBuyPlazaResult> ExportProdottiBuyPlaza()
        {
            using (ExportProdottiDataContext _model = new ExportProdottiDataContext())
            {
                return _model.ExportProdottiBuyPlaza().ToList();
            }
        }
        /// <summary>
        /// Risultato dell'esportazione  per Excel EBay
        /// </summary>
        /// <returns></returns>
        public List<ExportProdottiIPrezziResult> ExportProdottiExcel()
        {
            List<ExportProdottiIPrezziResult> _result = null;
            using (ExportProdottiDataContext _model = new ExportProdottiDataContext())
            {
                _result = _model.ExportProdottiIPrezzi().ToList();
                _result.ForEach(item =>
                    {
                        if (item.url.Contains("Taglia"))
                        {
                            item.marca = this.GetVariazioneByIdTaglia(item.ID - 10000);
                            item.marca += "|";
                            item.marca += this.GetTagliaByIdTaglia(item.ID - 10000);
                        }
                        else
                        {
                            ProdottoImmagine _prod = this.GetProdottoByIDProdotto(item.ID);
                            if (_prod != null && !string.IsNullOrEmpty(_prod.Codice))
                            {
                                item.marca = _prod.Codice;
                                item.marca += "|";
                                item.marca += this.GetVariazioneByIdProdotto(item.ID);
                                item.marca += "|";
                                string _taglia = this.GetTagliaByIdProdotto(item.ID);
                                if (!string.IsNullOrEmpty(_taglia))
                                    item.marca += _taglia;
                                else
                                {
                                    ProdottoImmagine _prodImg = this.GetProdottoByIDProdotto(item.ID);
                                    if (_prodImg != null && !string.IsNullOrEmpty(_prodImg.DescrTaglia))
                                        item.marca += _prodImg.DescrTaglia;
                                }
                                 
                            }                            
                        }
                    });
            }

            return _result.Where(item => item.marca.ToLower() != "trixie" && !string.IsNullOrEmpty(item.url)).ToList();
        }
        #endregion

        /// <summary>
        /// Restituisce taglia e variazione dato id prodotto
        /// </summary>
        /// <param name="idProdotto"></param>
        /// <returns></returns>
        private string GetVariazioneByIdProdotto(int idProdotto)
        {
            //List<ProdottiTaglie> _lst = this.GetProdottiTaglieByIDProdotto(idProdotto);
            List<Colori> _variazioni = this.GetProdottoColoriByIDProdotto(idProdotto);
            StringBuilder _str = new StringBuilder();
            if (_variazioni != null && _variazioni.Count > 0)
            {
                _str.Append("Variazioni Disponibili:   ");
                _variazioni.ForEach(item => _str.Append(item.Descrizione + "  "));
                return _str.ToString();
            }
            else
                return string.Empty;
        }
        /// <summary>
        /// Ottiene le variazioni per prodottoTaglia
        /// </summary>
        /// <param name="idProdotto"></param>
        /// <returns></returns>
        private string GetVariazioneByIdTaglia(int idProdottoTaglia)
        {
            ProdottiTaglie _prod = null;
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _prod = _model.ProdottiTaglies.Where(item => item.ID == idProdottoTaglia).SingleOrDefault();
            }
            StringBuilder _str = new StringBuilder();

            _str.Append(_prod.Codice);
            _str.Append("|");
            List<Colori> _variazioni = this.GetProdottoColoriByIDProdotto(_prod.IDProdotto);

            if (_variazioni != null && _variazioni.Count > 0)
            {
                _str.Append("Variazioni Disponibili:   ");
                _variazioni.ForEach(item => _str.Append(item.Descrizione + "  "));
                return _str.ToString();
            }
            else
                return _str.ToString();
        }
        /// <summary>
        /// Restituisce la string della taglia
        /// </summary>
        /// <param name="idProdotto"></param>
        /// <returns></returns>
        private string GetTagliaByIdTaglia(int idProdottoTaglia)
        {
            ProdottiTaglie _prod = null;
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _prod = _model.ProdottiTaglies.Where(item => item.ID == idProdottoTaglia).SingleOrDefault();
            }
            if (_prod == null)
                return string.Empty;
            StringBuilder _str = new StringBuilder();
            if (_prod != null)
            {
                _str.Append("Taglia   ");
                _str.Append(_prod.DescrTaglia + " " + _prod.Prezzo.ToString() + " ");
                return _str.ToString();
            }
            else
                return string.Empty;
        }
        /// <summary>
        /// Restituisce la string della taglia
        /// </summary>
        /// <param name="idProdotto"></param>
        /// <returns></returns>
        private string GetTagliaByIdProdotto(int idProdotto)
        {
            List<ProdottiTaglie> _prod = null;
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _prod = _model.ProdottiTaglies.Where(item => item.IDProdotto == idProdotto).OrderBy(c => c.Prezzo).ToList();
            }
            if (_prod == null)
                return string.Empty;
            StringBuilder _str = new StringBuilder();
            if (_prod != null && _prod.Count > 0)
            {
                _str.Append("Taglie   ");
                _prod.ForEach(item => _str.Append(item.DescrTaglia + " " + item.Prezzo.ToString() + " "));
                return _str.ToString();
            }
            else
            {

                return string.Empty;
            }
        }
        #endregion

    }
}
