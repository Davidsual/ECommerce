using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Perbaffo.Presenter.Model;
using System.Data.Common;
using SNIntegration;

namespace Perbaffo.Presenter
{
    public partial class Controller : IDisposable
    {
        #region PRIVATE MEMBERS
        private const string CATEGORIA_PRODOTTO = "PRODOTTI";
        #endregion

        #region PUBLIC MEMBERS
        public enum TypeImage
        {
            Grande,
            Piccola
        }
        #endregion

        #region PUBLIC METHODS

        #region GET
        /// <summary>
        /// Aggiorna la giacenza di un prodotto a seguito di un ordine
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <param name="quantita"></param>
        public void UpdateProdottiRipristinaGiacenza(int IDProdotto, int quantita)
        {
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    Prodotti _prod = _model.Prodottis.Where(prod => prod.Attivo == true && prod.ID == IDProdotto).SingleOrDefault();
                    if (_prod != null)
                    {
                        _prod.Giacenza = (_prod.Giacenza.HasValue) ? _prod.Giacenza += quantita : 0;
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
        /// Prodotti senza categoria
        /// </summary>
        /// <returns></returns>
        public List<Prodotti> GetProdottiSenzaImmagini(int startRowIndex, int maximumRows)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                return _model.Prodottis.Where(prod => !(_model.ProdottiImmaginis.Select(pr => pr.IDProdotto).ToList().Contains(prod.ID))).OrderBy(pr => pr.Nome).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }
        /// <summary>
        /// Prodotti senza categoria
        /// </summary>
        /// <returns></returns>
        public int GetCountProdottiSenzaImmagini()
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                return _model.Prodottis.Where(prod => !(_model.ProdottiImmaginis.Select(pr => pr.IDProdotto).ToList().Contains(prod.ID))).Count();
            }
        }
        /// <summary>
        /// Prodotti senza categoria
        /// </summary>
        /// <returns></returns>
        public int GetCountProdottiSenzaCategoria()
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                return _model.Prodottis.Where(prod => !(_model.ProdottiCategories.Select(pr => pr.IDProdotto).ToList().Contains(prod.ID))).Count();
            }
        }
        /// <summary>
        /// Prodotti senza categoria
        /// </summary>
        /// <returns></returns>
        public List<Prodotti> GetProdottiSenzaCategoria(int startRowIndex, int maximumRows)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                return _model.Prodottis.Where(prod => !(_model.ProdottiCategories.Select(pr => pr.IDProdotto).ToList().Contains(prod.ID))).OrderBy(pr => pr.Nome).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }
        /// <summary>
        /// Totale dei prodotti in omaggio
        /// </summary>
        /// <param name="prodottoAttivo"></param>
        /// <returns></returns>
        public int GetCountProdottiOmaggio(bool prodottoAttivo)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                return _model.Prodottis.Where(prod => prod.IsOmaggio == true && prod.Attivo == prodottoAttivo).Count();
            }
        }
        /// <summary>
        /// Restituisce la lista dei prodotti in omaggio
        /// </summary>
        /// <param name="prodottoAttivo"></param>
        /// <returns></returns>
        public List<Prodotti> GetProdottiOmaggio(bool prodottoAttivo)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                return _model.Prodottis.Where(prod => prod.IsOmaggio == true && prod.Attivo == prodottoAttivo).OrderByDescending(prod => prod.RangeOmaggio).ToList();
            }
        }
        /// <summary>
        /// Lista dei prodotti sotto scorta
        /// </summary>
        /// <returns></returns>
        public List<Prodotti> GetProdottiSottoScortaPaging(int startRowIndex, int maximumRows, bool attivi)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                return _model.Prodottis.Where(prod => prod.Giacenza <= prod.LivRiordino && prod.Attivo == attivi).OrderBy(prod => prod.DataInserimento).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }
        /// <summary>
        /// Totale dei prodotti sotto scorta
        /// </summary>
        /// <returns></returns>
        public int GetCountProdottiSottoScorta(bool attivi)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                return _model.Prodottis.Where(prod => prod.Giacenza <= prod.LivRiordino && prod.Attivo == attivi).Count();
            }
        }
        /// <summary>
        /// Restituisce tutti i prodotti attivi/disattivi a seconda del flag
        /// </summary>
        /// <param name="attivi"></param>
        /// <returns></returns>
        public IEnumerable<Prodotti> GetProdotti(bool attivi)
        {
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    return _model.Prodottis.Where(prod => prod.Attivo == attivi).OrderBy(prod => prod.ID).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Restituisce tutti i prodotti attivi
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Prodotti> GetProdotti()
        {
            try
            {
                return this.GetProdotti(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Totale numero prodotti attivi
        /// </summary>
        /// <returns></returns>
        public int GetCountProdotti()
        {
            try
            {
                return this.GetCountProdotti(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Totale numero prodotti
        /// </summary>
        /// <returns></returns>
        public int GetCountProdotti(bool attivi)
        {
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    return _model.Prodottis.Where(prod => prod.Attivo == attivi).Count();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Restituisce i prodotti paginati
        /// </summary>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <returns></returns>
        public List<Prodotti> GetProdottiPaging(int startRowIndex, int maximumRows)
        {
            try
            {
                return this.GetProdottiPaging(startRowIndex, maximumRows, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Restituisce i prodotti paginati
        /// </summary>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <param name="attivi"></param>
        /// <returns></returns>
        public List<Prodotti> GetProdottiPaging(int startRowIndex, int maximumRows, bool attivi)
        {
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    _model.DeferredLoadingEnabled = false;
                    return _model.Prodottis.Where(prod => prod.Attivo == attivi).OrderBy(prod => prod.ID).Skip(startRowIndex).Take(maximumRows).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Restituisce il prodotto dato il suo id
        /// </summary>
        /// <param name="IdProdotto"></param>
        /// <returns></returns>
        public Prodotti GetProdottoByID(int IdProdotto)
        {
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    _model.DeferredLoadingEnabled = false;
                    _model.ObjectTrackingEnabled = false;
                    return _model.Prodottis.Where(prod => prod.ID == IdProdotto).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lista di aliquota iva
        /// </summary>
        /// <returns></returns>
        public List<AliquotaIva> GetAliquotaIva()
        {
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    return _model.AliquotaIvas.OrderByDescending(iva => iva.ValoreAliquotaIva).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Restituisce  le immagini allegate
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public ProdottiImmagini GetImmaginiByIdProdotto(int IDProdotto)
        {
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    return _model.ProdottiImmaginis.Where(prod => prod.IDProdotto == IDProdotto).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Restituisce i colori del prodotto
        /// </summary>
        /// <param name="IdProdotto"></param>
        /// <returns></returns>
        public List<Colori> GetColoriByIdProdotto(int IdProdotto)
        {
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    _model.DeferredLoadingEnabled = false;
                    _model.ObjectTrackingEnabled = false;
                    return (from Colori col in _model.Coloris
                     join ProdottiColori prodCol in _model.ProdottiColoris on col.ID equals prodCol.IDColore
                     where prodCol.IDProdotto == IdProdotto
                     select col).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Restituisce i variazioni del prodotto
        /// </summary>
        /// <param name="IdProdotto"></param>
        /// <returns></returns>
        public List<Variazioni> GetVariazioniByIdProdotto(int IdProdotto)
        {
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    _model.DeferredLoadingEnabled = false;
                    _model.ObjectTrackingEnabled = false;
                    return (from Variazioni variaz in _model.Variazionis
                            join ProdottiVariazioni prodCol in _model.ProdottiColoris on variaz.ID equals prodCol.IDVariazioni
                            where prodCol.IDProdotto == IdProdotto
                            select variaz).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Restituisce i colori recensiti
        /// </summary>
        /// <returns></returns>
        public Colori GetColoreByIDColore(int IDColore)
        {
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    return _model.Coloris.Where(color => color.ID == IDColore).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Ottiene una variazione data la sua lettera
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public List<Colori> GetVariazioniByLettera(string letter)
        {
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    return _model.Coloris.Where(col => col.Descrizione.ToLower().StartsWith(letter.ToLower())).OrderBy(color => color.Descrizione).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Restituisce i colori recensiti
        /// </summary>
        /// <returns></returns>
        public List<Colori> GetColori()
        {
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    return _model.Coloris.OrderBy(color => color.Descrizione).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Restituisce tutte le variazioni
        /// </summary>
        /// <returns></returns>
        public List<Variazioni> GetVariazioni()
        {
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    return _model.Variazionis.OrderBy(var => var.Descrizione).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lista dei prodotti associati
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public List<Prodotti> GetProdottiAssociatiByIDProdotto(int IDProdotto)
        {
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    _model.DeferredLoadingEnabled = false;
                    _model.ObjectTrackingEnabled = false;
                    return (from Prodotti _prod in _model.Prodottis
                                  join ProdottiAllegati _prodAlleg in _model.ProdottiAllegatis on _prod.ID equals _prodAlleg.IDProdottoAllegato
                                  where _prodAlleg.IDProdottoPrincipale == IDProdotto
                                  select _prod).ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Restituisce il totale dei prodotti filtrati
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public int GetCountProdottiByFilter(FiltroProdotto filtro)
        {
            int _return = 0;
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    if (!string.IsNullOrEmpty(filtro.CodiceProdotto))
                    {
                        if (filtro.IDCategoria != 0 && filtro.IDCategoria != int.MinValue)
                        {
                            _return = (from Prodotti _prod in _model.Prodottis
                                            join ProdottiCategorie _cat in _model.ProdottiCategories on _prod.ID equals _cat.IDProdotto
                                            where _cat.IDCategoria == filtro.IDCategoria &&
                                            _prod.Codice.ToUpper().Contains(filtro.CodiceProdotto.ToUpper()) || _prod.Nome.ToUpper().Contains(filtro.CodiceProdotto.ToUpper()) || _prod.DescrizioneLunga.Contains(filtro.CodiceProdotto)
                                       select _prod).Distinct().Count();
                        }
                        else
                            _return = _model.Prodottis.Where(prod => prod.Codice.ToUpper().Contains(filtro.CodiceProdotto.ToUpper()) || prod.Nome.ToUpper().Contains(filtro.CodiceProdotto.ToUpper()) || prod.DescrizioneLunga.Contains(filtro.CodiceProdotto)).Distinct().Count();
                    }
                    else if (string.IsNullOrEmpty(filtro.CodiceProdotto) && string.IsNullOrEmpty(filtro.DescrizioneProdotto) && filtro.IDCategoria != 0)
                    {
                        _return = (from Prodotti _prod in _model.Prodottis
                                        join ProdottiCategorie _cat in _model.ProdottiCategories on _prod.ID equals _cat.IDProdotto
                                        where _cat.IDCategoria == filtro.IDCategoria
                                   select _prod).Distinct().Count();
                    }
                    else
                    {
                        ///Estraggo tutto
                        _return = _model.Prodottis.Count();
                    }
                    return _return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Prodotti filtrati se attivi o no
        /// </summary>
        /// <param name="Attivi"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <returns></returns>
        public List<Prodotti> GetProdottiByIsAttivo(bool Attivi, int startRowIndex, int maximumRows)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                return _model.Prodottis.Where(prod => prod.Attivo == Attivi).Distinct().Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }
        /// <summary>
        /// Ricerca dei prodotti tramite il filtro
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<Prodotti> GetProdottiByFilter(FiltroProdotto filtro, int startRowIndex, int maximumRows)
        {
            List<Prodotti> _lstProdotti;
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    if (!string.IsNullOrEmpty(filtro.CodiceProdotto))
                    {
                        if (filtro.IDCategoria != 0 && filtro.IDCategoria != int.MinValue)
                        {
                            _lstProdotti = (from Prodotti _prod in _model.Prodottis
                                            join ProdottiCategorie _cat in _model.ProdottiCategories on _prod.ID equals _cat.IDProdotto
                                            where _cat.IDCategoria == filtro.IDCategoria &&
                                            _prod.Codice.ToUpper().Contains(filtro.CodiceProdotto.ToUpper()) || _prod.Nome.ToUpper().Contains(filtro.CodiceProdotto.ToUpper()) || _prod.DescrizioneLunga.Contains(filtro.CodiceProdotto)
                                            select _prod).Distinct().Skip(startRowIndex).Take(maximumRows).ToList();
                        }
                        else
                            _lstProdotti = _model.Prodottis.Where(prod => prod.Codice.ToUpper().Contains(filtro.CodiceProdotto.ToUpper()) || prod.Nome.ToUpper().Contains(filtro.CodiceProdotto.ToUpper()) || prod.DescrizioneLunga.Contains(filtro.CodiceProdotto)).Distinct().Skip(startRowIndex).Take(maximumRows).ToList();
                    }
                    else if (string.IsNullOrEmpty(filtro.CodiceProdotto) && string.IsNullOrEmpty(filtro.DescrizioneProdotto) && filtro.IDCategoria != 0)
                    {
                        _lstProdotti = (from Prodotti _prod in _model.Prodottis
                                        join ProdottiCategorie _cat in _model.ProdottiCategories on _prod.ID equals _cat.IDProdotto
                                        where _cat.IDCategoria == filtro.IDCategoria
                                        select _prod).Distinct().Skip(startRowIndex).Take(maximumRows).ToList();
                    }
                    else
                    {
                        ///Estraggo tutto
                        _lstProdotti = _model.Prodottis.Skip(startRowIndex).Take(maximumRows).ToList();
                    }

                    return _lstProdotti;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Restituisce tutte le categorie a cui è associato il prodotto
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public List<Categorie> GetProdottiCategoriaByIDProdotto(int IDProdotto)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                return (from Categorie _categ in _model.Categories
                        join DettagliProdottiCategorie _prodCat in _model.DettagliProdottiCategories on _categ.ID equals _prodCat.IDCategoria
                        where _prodCat.IDProdotto == IDProdotto
                        select _categ).OrderBy(c => c.DescrizioneBreve).ToList();
            }
        }
        /// <summary>
        /// Lista dei prodotti inseriti come novita
        /// </summary>
        /// <returns></returns>
        public List<Prodotti> GetProdottiNovita(bool prodottiAttivi)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                return _model.Prodottis.Where(prod => prod.DataInserimento != null && prod.Attivo == prodottiAttivi).OrderByDescending(prod => prod.DataInserimento).Take(20).ToList();
            }
        }
        /// <summary>
        /// Totale dei prodotti in offerta 
        /// </summary>
        /// <returns></returns>
        public int GetCountProdottiOfferte(bool prodottiAttivi)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                return _model.Prodottis.Where(prod => prod.ScontoEuro != new Decimal(0.00) || prod.ScontoPercent != 0 && prod.Attivo == prodottiAttivi).OrderBy(prod => prod.DataInserimento).Count();
            }
        }
        /// <summary>
        /// Lista dei prodotti recensiti come offerte
        /// </summary>
        /// <returns></returns>
        public List<Prodotti> GetProdottiOffertePaging(bool prodottiAttivi,int startRowIndex, int maximumRows)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                return _model.Prodottis.Where(prod => prod.ScontoEuro != new Decimal(0.00) || prod.ScontoPercent != 0 && prod.Attivo == prodottiAttivi).OrderBy(prod => prod.DataInserimento).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }
        /// <summary>
        /// Ottiene tutte le taglie per il prodotto
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public List<ProdottiTaglie> GetProdottiTaglieByIDProdotto(int IDProdotto)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                return _model.ProdottiTaglies.Where(tag => tag.IDProdotto == IDProdotto).OrderBy(c => c.Totale).ToList();
            }
        }
        /// <summary>
        /// Ottiene tutte le taglie per il prodotto
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public ProdottiTaglie GetProdottiTaglieByIDTaglia(int IDTaglia)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                return _model.ProdottiTaglies.Where(tag => tag.ID == IDTaglia).SingleOrDefault();
            }
        }
        /// <summary>
        /// Restituisce tutte le immagini dell'eventuale Fotogallery
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public List<ProdottiFotogallery> GetProdottiFotogallery(int IDProdotto)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                return _model.ProdottiFotogalleries.Where(pho => pho.IDProdotto == IDProdotto).ToList();
            }
        }
        /// <summary>
        /// Nome immagine dato il suo ID
        /// </summary>
        /// <param name="IDImmagine"></param>
        /// <returns></returns>
        public string GetNomeImmagineFotogalleryByIDImmagine(int IDImmagine)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                return _model.ProdottiFotogalleries.Where(prod => prod.ID == IDImmagine).Select(c => c.UrlImmagine).SingleOrDefault();
            }
        }
        #endregion

        #region SET
        /// <summary>
        /// Inserimento su twitter
        /// </summary>
        /// <param name="titoloProdotto"></param>
        /// <param name="urlProdotto"></param>
        public void SetTwitter(string titoloProdotto,string urlProdotto)
        {
            try
            {
                using (ITwitter _twitter = SocialNetwork.GetTwitterInstance("aKya6maUuOBbaYiEucLTw",
            "Qj0e7Wyo7aYR2D4J4P6fVK5TuLOF1q2eloDKF75byQ",
            "197481167-abzpsUg87SS8xbDS1Gz9sFNRG3qwhebuq1xufbAz",
            "XFFbLUDLVFYx52IAJPg1DCNqct4qUm6o1Glnt5t6UU"))
                {
                    _twitter.SetStatus(string.Format("{0}, {1}", titoloProdotto, urlProdotto));
                }
            }
            catch (Exception ex)
            {
                Errori _errore = new Errori();
                _errore.CurrentIDUtenteLoggato = -1;
                _errore.DataErrore = DateTime.Now;
                _errore.DescrException = "SetTwitter " + ex.Message;
                _errore.DescrStackTrace = ex.StackTrace;
                if (ex.InnerException != null)
                {
                    _errore.DescrInnerException = ex.InnerException.Message;
                }
                _errore.PathPagina = "SetTwitter";
                this.SetErrore(_errore);
            }
        }
        /// <summary>
        /// Inserimento su facebook
        /// </summary>
        public void SetFaceBook(string messaggio,string urlLink,string urlPhoto,string descrizione,string caption)
        {
            try
            {
                using (IFacebook _facebook = SocialNetwork.GetFacebookInstance("134318019957428|25619edbbbfb51d6075dd06b-100000286916247|6w5cknHC9CnegzU2R-b1lYUMPLM"))
                {
                    _facebook.PublishStreamOnFeed(messaggio, urlLink, urlPhoto, descrizione, caption);
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        /// <summary>
        /// Salva una variazione
        /// </summary>
        /// <param name="Descrizione"></param>
        public void SetVariazione(string Descrizione)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                int _count = _model.Variazionis.Where(col => col.Descrizione.ToUpper().Equals(Descrizione.ToUpper())).Count();
                if (_count > 0)
                    return;

                Variazioni _variazioni = new Variazioni() { Descrizione = Descrizione };
                _model.Variazionis.InsertOnSubmit(_variazioni);
                _model.SubmitChanges();
            }
        }
        /// <summary>
        /// Cancella una variaz<ione
        /// </summary>
        /// <param name="IDColore"></param>
        /// <returns></returns>
        public bool DeleteVariazione(int IDVariazione)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                int _count = (from Variazioni variaz in _model.Variazionis
                              join ProdottiVariazioni _prodCol in _model.ProdottiColoris on variaz.ID equals _prodCol.IDVariazioni
                              where variaz.ID == IDVariazione
                              select variaz).Count();

                if (_count > 0)
                    return false;

                Variazioni _variazioni = _model.Variazionis.Where(col => col.ID == IDVariazione).SingleOrDefault();
                if (_variazioni == null)
                    return false;
                else
                {
                    _model.Variazionis.DeleteOnSubmit(_variazioni);
                    _model.SubmitChanges();
                }
                return true;
            }
        }

        /// <summary>
        /// Salva un colore
        /// </summary>
        /// <param name="Descrizione"></param>
        public void SetColore(string Descrizione)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                int _count = _model.Coloris.Where(col => col.Descrizione.ToUpper().Equals(Descrizione.ToUpper())).Count();
                if(_count > 0)
                    return;

                Colori _color = new Colori() {Descrizione = Descrizione };
                _model.Coloris.InsertOnSubmit(_color);
                _model.SubmitChanges();
            }
        }
        /// <summary>
        /// Cancella un colore
        /// </summary>
        /// <param name="IDColore"></param>
        /// <returns></returns>
        public bool DeleteColore(int IDColore)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                int _count = (from Colori col in _model.Coloris
                              join ProdottiColori _prodCol in _model.ProdottiColoris on col.ID equals _prodCol.IDColore
                              where col.ID == IDColore
                              select col).Count();

                if (_count > 0)
                    return false;

                Colori _color = _model.Coloris.Where(col => col.ID == IDColore).SingleOrDefault();
                if (_color == null)
                    return false;
                else
                {
                    _model.Coloris.DeleteOnSubmit(_color);
                    _model.SubmitChanges();
                }
                return true;
            }
        }
        /// <summary>
        /// Inserisce una nuova foto allegata al prodotto
        /// </summary>
        /// <param name="immagine"></param>
        /// <param name="IDProdotto"></param>
        public void SetProdottiFotogallery(ProdottiFotogallery immagine, int IDProdotto)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                immagine.IDProdotto = IDProdotto;
                _model.ProdottiFotogalleries.InsertOnSubmit(immagine);
                _model.SubmitChanges();
            }
        }
        /// <summary>
        /// Identificativo univoco del prodotto
        /// </summary>
        /// <param name="IDImmagine"></param>
        /// <param name="IDProdotto"></param>
        public void DeleteProdottiFotogallery(int IDImmagine, int IDProdotto)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                ProdottiFotogallery _immagine = _model.ProdottiFotogalleries.Where(foto => foto.ID == IDImmagine && foto.IDProdotto == IDProdotto).SingleOrDefault();
                if (_immagine != null)
                {
                    _model.ProdottiFotogalleries.DeleteOnSubmit(_immagine);
                    _model.SubmitChanges();
                }
            }
        }
        /// <summary>
        /// Aggiorna il prezzo del prodotto offerta
        /// </summary>
        /// <param name="IDProdottoOfferta"></param>
        /// <param name="Prezzo"></param>
        public void UpdateProdottiOfferta(int IDProdottoOfferta, decimal Prezzo)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                OfferteTabella _offerta = _model.OfferteTabellas.Where(c => c.ID == IDProdottoOfferta).SingleOrDefault();
                if (_offerta != null)
                {
                    _offerta.Prezzo = Prezzo;
                    _model.SubmitChanges();
                }
            }
        }
        /// <summary>
        /// Cancella un prodotto dalle offerte
        /// </summary>
        /// <param name="IDProdotto"></param>
        public void DeleteProdottiOfferta(int IDOfferta)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                OfferteTabella _offerta = _model.OfferteTabellas.Where(c => c.ID == IDOfferta).SingleOrDefault();
                if (_offerta != null)
                {
                    _model.OfferteTabellas.DeleteOnSubmit(_offerta);
                    _model.SubmitChanges();
                }
            }
        }
        /// <summary>
        /// Salva un prodotto in Prodotti offerta
        /// </summary>
        /// <param name="IDProdotto"></param>
        public void SetProdottiOfferta(int IDProdotto)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                Prodotti _prod = _model.Prodottis.Where(c => c.ID == IDProdotto).SingleOrDefault();
                if (_prod != null)
                {
                    OfferteTabella _off = new OfferteTabella();
                    _off.DataInserimentoOfferta = DateTime.Now;
                    _off.IDProdotto = IDProdotto;
                    _off.Prezzo = _prod.Prezzo;
                    _model.OfferteTabellas.InsertOnSubmit(_off);
                    _model.SubmitChanges();
                }
            }
        }
        /// <summary>
        /// Aggiunge un prodotto a delle categorie
        /// </summary>
        /// <param name="lstCateg"></param>
        /// <param name="IDProdotto"></param>
        public void SetProdottiCategoria(List<Categorie> lstCateg, int IDProdotto)
        {
            if (IDProdotto == 0 || IDProdotto == int.MinValue)
                return;
            DbTransaction _trans = null;
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                try
                {
                    _model.DeferredLoadingEnabled = false;
                    // OPERA IN TRANSAZIONE
                    _model.Connection.Open();
                    _trans = _model.Connection.BeginTransaction();
                    _model.Transaction = _trans;

                    List<DettagliProdottiCategorie> _lstProdCatToDelete = _model.DettagliProdottiCategories.Where(c => c.IDProdotto == IDProdotto).ToList();
                    if (_lstProdCatToDelete != null && _lstProdCatToDelete.Count > 0)
                    {
                        _model.DettagliProdottiCategories.DeleteAllOnSubmit(_lstProdCatToDelete);
                        _model.SubmitChanges();
                    }
                    if (lstCateg != null && lstCateg.Count > 0)
                    {
                        List<DettagliProdottiCategorie> _lstDettCateg = new List<DettagliProdottiCategorie>(lstCateg.Count);
                        lstCateg.ForEach(c =>
                            {
                                _lstDettCateg.Add(new DettagliProdottiCategorie()
                                {
                                     IDCategoria = c.ID,
                                     IDProdotto = IDProdotto
                                });
                            });
                        _model.DettagliProdottiCategories.InsertAllOnSubmit(_lstDettCateg);
                        _model.SubmitChanges();
                    }

                    _model.SubmitChanges();
                    // COMMITTA LA TRANSAZIONE E CHIUDE
                    _trans.Commit();
                    _model.Connection.Close();
                }
                catch (Exception ex)
                {
                    // SE E' RIUSCITO AD APRIRE LA TRANSAZIONE FA ROLLBACK
                    if (_trans != null)
                    {
                        _trans.Rollback();
                    }
                    // CHIUDE LA CONNESSIONE
                    _model.Connection.Close();
                    throw ex;
                }

            }
        }
        /// <summary>
        /// Salvataggio del prodotto
        /// </summary>
        /// <param name="prodotti"></param>
        /// <returns></returns>
        public Prodotti SetProdotti(Prodotti prodotti)
        {
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    if (prodotti.ID != int.MinValue && prodotti.ID > 0)
                    {
                        ///Modifica
                        Prodotti _prod = _model.Prodottis.Where(prod => prod.ID == prodotti.ID).SingleOrDefault();
                        _prod.Codice = prodotti.Codice;
                        _prod.Keywords = prodotti.Keywords;
                        _prod.DescrizioneLunga = prodotti.DescrizioneLunga;
                        _prod.Giacenza = prodotti.Giacenza;
                        _prod.IDAliquotaIva = prodotti.IDAliquotaIva;
                        _prod.LivRiordino = prodotti.LivRiordino;
                        _prod.Nome = prodotti.Nome;
                        _prod.Prezzo = prodotti.Prezzo;
                        _prod.UnitaDiMisura = prodotti.UnitaDiMisura;
                        _prod.ScontoPercent = prodotti.ScontoPercent;
                        _prod.ScontoEuro = prodotti.ScontoEuro;
                        _prod.Totale = prodotti.Totale;
                        _prod.IsOmaggio = prodotti.IsOmaggio;
                        _prod.RangeOmaggio = prodotti.RangeOmaggio;
                        _prod.Attivo = prodotti.Attivo;
                        _prod.DescrTaglia = prodotti.DescrTaglia;
                        _model.SubmitChanges();
                    }
                    else
                    {
                        ///Inserimento
                        prodotti.DataInserimento = DateTime.Now; 
                        _model.Prodottis.InsertOnSubmit(prodotti);
                        _model.SubmitChanges();

                        try
                        {
                            using (StatisticheModelDataContext _modelStat = new StatisticheModelDataContext())
                            {
                                RSSFeed _feed = new RSSFeed()
                                {
                                    Categoria = CATEGORIA_PRODOTTO,
                                    Contenuto = "Su Perbaffo c'è un nuovo prodotto: " + prodotti.Nome,
                                    DataCreazione = DateTime.Now,
                                    Titolo = "Novità: " + prodotti.Nome,
                                    UrlDettaglio = "http://www.perbaffo.it/Dettaglio-Prodotto.aspx?Prodotto=" + prodotti.ID.ToString()
                                };
                                _modelStat.RSSFeeds.InsertOnSubmit(_feed);
                                _modelStat.SubmitChanges();
                            }
                            
                            /////Inserisco su facebook
                            //this.SetFaceBook(string.Empty,
                            //    "http://www.perbaffo.it/Dettaglio-Prodotto.aspx?Prodotto=" + prodotti.ID.ToString(),
                            //    "http://www.perbaffo.it/ImmaginiPerbaffo/" + prodotti.ID.ToString()+"H.jpg",
                            //    prodotti.DescrizioneLunga,
                            //    "www.perbaffo.it");
                            /////inserisco su twitter
                            //this.SetTwitter(prodotti.Nome,"http://www.perbaffo.it/Dettaglio-Prodotto.aspx?Prodotto=" + prodotti.ID.ToString());

                        }
                        catch(Exception ex)
                        {
                            this.SetErrore(new Errori() { DescrException = ex.Message, DescrStackTrace = ex.StackTrace, DataErrore = DateTime.Now, Browser = "GG" });

                        }
                    }
                    
                    return prodotti;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Salva un prodotto come se fosse nuovo (SOLO UPDATE)
        /// </summary>
        /// <param name="prodotti"></param>
        /// <returns></returns>
        public Prodotti SetProdottiAsNew(Prodotti prodotti)
        {
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    if (prodotti.ID != int.MinValue && prodotti.ID > 0)
                    {
                        ///Modifica
                        Prodotti _prod = _model.Prodottis.Where(prod => prod.ID == prodotti.ID).SingleOrDefault();
                        _prod.Codice = prodotti.Codice;
                        _prod.Keywords = prodotti.Keywords;
                        _prod.DescrizioneLunga = prodotti.DescrizioneLunga;
                        _prod.Giacenza = prodotti.Giacenza;
                        _prod.IDAliquotaIva = prodotti.IDAliquotaIva;
                        _prod.LivRiordino = prodotti.LivRiordino;
                        _prod.Nome = prodotti.Nome;
                        _prod.Prezzo = prodotti.Prezzo;
                        _prod.UnitaDiMisura = prodotti.UnitaDiMisura;
                        _prod.ScontoPercent = prodotti.ScontoPercent;
                        _prod.ScontoEuro = prodotti.ScontoEuro;
                        _prod.Totale = prodotti.Totale;
                        _prod.IsOmaggio = prodotti.IsOmaggio;
                        _prod.RangeOmaggio = prodotti.RangeOmaggio;
                        _prod.Attivo = prodotti.Attivo;
                        _prod.DescrTaglia = prodotti.DescrTaglia;
                        ///Aggiorna alla data odierna come se fosse un nuovo inserimento
                        _prod.DataInserimento = DateTime.Now;
                        _model.SubmitChanges();
                        ///CANCELLO EVENTUALI RECENSIONI
                        try
                        {
                            ///CANCELLO EVENTUALI RECENSIONI
                            _model.ProdottiRecensionis.DeleteAllOnSubmit(_model.ProdottiRecensionis.Where(c => c.IDProdotto == prodotti.ID).ToList());
                        }
                        catch
                        { }
                        try
                        {
                            using (StatisticheModelDataContext _modelStat = new StatisticheModelDataContext())
                            {
                                RSSFeed _feed = new RSSFeed()
                                {
                                    Categoria = CATEGORIA_PRODOTTO,
                                    Contenuto = "Su Perbaffo c'è un nuovo prodotto: " + prodotti.Nome,
                                    DataCreazione = DateTime.Now,
                                    Titolo = "Novità: " + prodotti.Nome,
                                    UrlDettaglio = "http://www.perbaffo.it/Dettaglio-Prodotto.aspx?Prodotto=" + prodotti.ID.ToString()
                                };
                                _modelStat.RSSFeeds.InsertOnSubmit(_feed);
                                _modelStat.SubmitChanges();
                            }
                            
                            ///Inserisco su facebook
                            this.SetFaceBook(string.Empty,
                                "http://www.perbaffo.it/Dettaglio-Prodotto.aspx?Prodotto=" + prodotti.ID.ToString(),
                                "http://www.perbaffo.it/ImmaginiPerbaffo/" + prodotti.ID.ToString() + "H.jpg",
                                prodotti.DescrizioneLunga,
                                "www.perbaffo.it");
                            ///inserisco su twitter
                            this.SetTwitter(prodotti.Nome, "http://www.perbaffo.it/Dettaglio-Prodotto.aspx?Prodotto=" + prodotti.ID.ToString());
                            
                        }
                        catch(Exception ex)
                        {
                            this.SetErrore(new Errori() { DescrException = ex.Message, DescrStackTrace = ex.StackTrace, DataErrore = DateTime.Now, Browser = "GG" });

                        }
                    }
                    return prodotti;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Inserisce/aggiorna immagini per il prodotto
        /// </summary>
        /// <param name="prodImmagini"></param>
        /// <returns></returns>
        public ProdottiImmagini SetProdottiImmagini(ProdottiImmagini prodImmagini)
        {
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    int _count = _model.ProdottiImmaginis.Where(img => img.IDProdotto == prodImmagini.IDProdotto).Count();
                    if (_count > 0)
                    {
                        ///Modifica
                        ProdottiImmagini _prodImg = _model.ProdottiImmaginis.Where(img => img.IDProdotto == prodImmagini.IDProdotto).SingleOrDefault();
                        if (!string.IsNullOrEmpty(prodImmagini.UrlImmagine))
                            _prodImg.UrlImmagine = prodImmagini.UrlImmagine;
                        if (!string.IsNullOrEmpty(prodImmagini.UrlImmagineHQ))
                            _prodImg.UrlImmagineHQ = prodImmagini.UrlImmagineHQ;
                        _prodImg.DescrImmagine = prodImmagini.DescrImmagine;
                    }
                    else
                    {
                        ///insert
                        _model.ProdottiImmaginis.InsertOnSubmit(prodImmagini);
                    }
                    _model.SubmitChanges();
                    return prodImmagini;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Cancella URL Immagine
        /// </summary>
        /// <param name="tipoImmagine"></param>
        /// <param name="prodImmagini"></param>
        public void DeleteProdottiImmagini(TypeImage tipoImmagine,ProdottiImmagini prodImmagini)
        {
            try
            {
                using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
                {
                    ProdottiImmagini _prodImmagini = _model.ProdottiImmaginis.Where(img => img.IDProdotto == prodImmagini.IDProdotto).SingleOrDefault();
                    if (_prodImmagini == null)
                        return;
                    switch (tipoImmagine)
                    {
                        case TypeImage.Grande:
                            _prodImmagini.UrlImmagineHQ = null;
                            break;
                        case TypeImage.Piccola:
                            _prodImmagini.UrlImmagine = null;
                            break;
                        default:
                            break;
                    }
                    _model.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Salva i colori per il prodotto selezionato
        /// </summary>
        /// <param name="lstColori"></param>
        /// <param name="IDProdotto"></param>
        public void SetProdottiColori(List<ProdottiColori> ProdottiColori, int IDProdotto)
        {
            DbTransaction _trans = null;

            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                try
                {
                    _model.Connection.Open();
                    _trans = _model.Connection.BeginTransaction();
                    _model.Transaction = _trans;

                    List<ProdottiColori> _lstCol = _model.ProdottiColoris.Where(col => col.IDProdotto == IDProdotto).ToList();
                    _model.ProdottiColoris.DeleteAllOnSubmit(_lstCol);
                    _model.SubmitChanges();
                    _model.ProdottiColoris.InsertAllOnSubmit(ProdottiColori);
                    _model.SubmitChanges();

                    _trans.Commit();
                    _model.Connection.Close();
                }
                catch (Exception ex)
                {
                    // SE E' RIUSCITO AD APRIRE LA TRANSAZIONE FA ROLLBACK
                    if (_trans != null)
                    {
                        _trans.Rollback();
                    }
                    // CHIUDE LA CONNESSIONE
                    _model.Connection.Close();
                    throw ex;
                }
            }
        }
        /// <summary>
        /// Salva le variazioni per il prodotto selezionato
        /// </summary>
        /// <param name="lstColori"></param>
        /// <param name="IDProdotto"></param>
        public void SetProdottiVariazioni(List<ProdottiVariazioni> ProdottiVariazioni, int IDProdotto)
        {
            DbTransaction _trans = null;

            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                try
                {
                    _model.Connection.Open();
                    _trans = _model.Connection.BeginTransaction();
                    _model.Transaction = _trans;

                    List<ProdottiVariazioni> _lstCol = _model.ProdottiVariazionis.Where(col => col.IDProdotto == IDProdotto).ToList();
                    _model.ProdottiVariazionis.DeleteAllOnSubmit(_lstCol);
                    _model.SubmitChanges();
                    _model.ProdottiVariazionis.InsertAllOnSubmit(ProdottiVariazioni);
                    _model.SubmitChanges();

                    _trans.Commit();
                    _model.Connection.Close();
                }
                catch (Exception ex)
                {
                    // SE E' RIUSCITO AD APRIRE LA TRANSAZIONE FA ROLLBACK
                    if (_trans != null)
                    {
                        _trans.Rollback();
                    }
                    // CHIUDE LA CONNESSIONE
                    _model.Connection.Close();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Aggiorna o crea le relazioni tra prodotti
        /// </summary>
        /// <param name="lstProdotti"></param>
        /// <param name="IDProdotto"></param>
        public void SetProdottiRelazione(List<Prodotti> lstProdotti, int IDProdotto)
        {
            DbTransaction _trans = null;

            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                try
                {
                    _model.Connection.Open();
                    _trans = _model.Connection.BeginTransaction();
                    _model.Transaction = _trans;

                    List<ProdottiAllegati> _lstProdllegati = _model.ProdottiAllegatis.Where(prodAll => prodAll.IDProdottoPrincipale == IDProdotto).ToList();
                    if (_lstProdllegati.Count > 0)
                    {
                        _model.ProdottiAllegatis.DeleteAllOnSubmit(_lstProdllegati);
                        _model.SubmitChanges();
                    }
                    foreach (Prodotti item in lstProdotti)
                    {
                        _model.ProdottiAllegatis.InsertOnSubmit(new ProdottiAllegati()
                            {
                                IDProdottoAllegato = item.ID,
                                IDProdottoPrincipale = IDProdotto
                            }
                            );
                    }
                    
                    _model.SubmitChanges();

                    _trans.Commit();
                    _model.Connection.Close();
                }
                catch (Exception ex)
                {
                    // SE E' RIUSCITO AD APRIRE LA TRANSAZIONE FA ROLLBACK
                    if (_trans != null)
                    {
                        _trans.Rollback();
                    }
                    // CHIUDE LA CONNESSIONE
                    _model.Connection.Close();
                    throw ex;
                }
            }
        }
        /// <summary>
        /// Inserisce una nuova taglia
        /// </summary>
        /// <param name="taglia"></param>
        /// <param name="IDProdotto"></param>
        public void SetProdottiTaglia(ProdottiTaglie taglia, int IDProdotto)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            { 
                taglia.IDProdotto = IDProdotto;
                _model.ProdottiTaglies.InsertOnSubmit(taglia);
                _model.SubmitChanges();
            }
        }
        /// <summary>
        /// cancella una taglia
        /// </summary>
        /// <param name="IDTaglia"></param>
        /// <param name="IDProdotto"></param>
        public void DeleteProdottiTaglia(int IDTaglia, int IDProdotto)
        {
            using (ProdottiModelDataContext _model = new ProdottiModelDataContext())
            {
                ProdottiTaglie _taglia = _model.ProdottiTaglies.Where(tag => tag.ID == IDTaglia && tag.IDProdotto == IDProdotto).SingleOrDefault();
                if (_taglia != null)
                {
                    _model.ProdottiTaglies.DeleteOnSubmit(_taglia);
                    _model.SubmitChanges();
                }
            }
        }
        #endregion

        #endregion
    }
}
