using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Perbaffo.Presenter.Model;
using System.Data.Common;

namespace Perbaffo.Presenter
{
    public partial class Controller : IDisposable
    {
        #region PUBLIC METHODS
        /// <summary>
        /// Restituisce il dettaglio della categoria
        /// </summary>
        /// <param name="IDCategoria"></param>
        /// <returns></returns>
        public Categorie GetCategoriaByIDCategoria(int IDCategoria)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                return _model.Categories.Where(categ => categ.ID == IDCategoria).SingleOrDefault();
            }
        }
        /// <summary>
        /// Inserisce una nuova categoria
        /// </summary>
        /// <param name="categ"></param>
        public void InsertCategoria(Categorie categ)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                if (categ.IDCategoriaPadre == 0)
                    categ.IDCategoriaPadre = null;
                if (string.IsNullOrEmpty(categ.UrlImmagine))
                    categ.UrlImmagine = "no-image.jpg";
                _model.Categories.InsertOnSubmit(categ);
                _model.SubmitChanges();
            }
        }
        /// <summary>
        /// Aggiorna una categoria esistente
        /// </summary>
        /// <param name="categ"></param>
        public void UpdateCategoria(Categorie categ)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                Categorie _categoria = _model.Categories.Where(cat => cat.ID == categ.ID).SingleOrDefault();
                if (_categoria != null)
                {
                    _categoria.DescrizioneBreve = categ.DescrizioneBreve;
                    _categoria.DescrizioneCategoria = categ.DescrizioneCategoria;
                    _categoria.DescrizioneEstesa = categ.DescrizioneEstesa;
                    _categoria.Keywords = categ.Keywords;
                    _model.SubmitChanges();
                }
            }
        }
        /// <summary>
        /// Inserisco un errore
        /// </summary>
        /// <param name="currentErrore"></param>
        public void SetErrore(Errori currentErrore)
        {
            if (currentErrore == null)
                return;

            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                try
                {
                    _model.Erroris.InsertOnSubmit(currentErrore);
                    _model.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }
        /// <summary>
        /// Restituisce la lista di categorie
        /// </summary>
        /// <returns></returns>
        public List<Categorie> GetCategorie()
        {
            List<Categorie> _lstCategorie;
            List<Categorie> _lstReturn;
            try
            {
                using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
                {
                    _model.DeferredLoadingEnabled = false;
                    _lstCategorie = _model.Categories.OrderBy(cat => cat.DescrizioneBreve).ToList();
                }
                _lstReturn = _lstCategorie.Where(cat => cat.IDCategoriaPadre == null).ToList();

                _lstReturn.ForEach(cat =>
                    {
                        this.SetCategorieFiglie(cat, _lstCategorie);
                    });
                return _lstReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Per ogni categoria aggancia in maniera ricorsiva le categorie figlie
        /// </summary>
        /// <param name="Cat"></param>
        /// <param name="lstCategorieTotali"></param>
        private void SetCategorieFiglie(Categorie Cat, List<Categorie> lstCategorieTotali)
        {
            if (Cat == null)
                return;
            Cat.CategorieFiglie = lstCategorieTotali.Where(cat => cat.IDCategoriaPadre == Cat.ID).ToList();
            if (Cat.CategorieFiglie != null && Cat.CategorieFiglie.Count > 0)
            {
                Cat.CategorieFiglie.ForEach(Categ =>
                    {
                        this.SetCategorieFiglie(Categ, lstCategorieTotali);
                    });
            }
        }
        /// <summary>
        /// Cancella il legame prodotto categoria
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="CategToDelete"></param>
        private void DeleteProdottiCategoria(ConfigurazioniDataContext _model, Categorie CategToDelete)
        {
            if (CategToDelete == null || CategToDelete.ID == 0)
                return;

            List<DettagliProdottiCategorie> _lstProdCat = _model.DettagliProdottiCategories.Where(prodCat => prodCat.IDCategoria == CategToDelete.ID).ToList();
            if (_lstProdCat != null && _lstProdCat.Count > 0)
                _model.DettagliProdottiCategories.DeleteAllOnSubmit(_lstProdCat);

            _model.Categories.DeleteOnSubmit(CategToDelete);

            CategToDelete.CategorieFiglie.ForEach(cat =>
                {
                    this.DeleteProdottiCategoria(_model, cat);
                });
        }
        /// <summary>
        /// Cancella una categoria
        /// </summary>
        /// <param name="IDCategoria"></param>
        public void DeleteCategoria(int IDCategoria)
        {
            DbTransaction _trans = null;
            List<Categorie> _lstCategorie;
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                try
                {
                    _model.DeferredLoadingEnabled = false;
                    // OPERA IN TRANSAZIONE
                    _model.Connection.Open();
                    _trans = _model.Connection.BeginTransaction();
                    _model.Transaction = _trans;

                    ///Cancello
                    _lstCategorie = _model.Categories.OrderBy(cat => cat.DescrizioneBreve).ToList();
                    Categorie _categorie = _model.Categories.Where(cat => cat.ID == IDCategoria).SingleOrDefault();
                    List<Categorie> _lstCateg = new List<Categorie>();
                    _lstCateg.Add(_categorie);

                    _lstCateg.ForEach(cat =>
                    {
                        this.SetCategorieFiglie(cat, _lstCategorie);
                    });
                    _lstCateg.ForEach(cat =>
                        {
                            this.DeleteProdottiCategoria(_model, cat);
                        });
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
        /// Numero di categoire e sottocategorie
        /// </summary>
        /// <returns></returns>
        public int GetCountCategorie()
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                return _model.Categories.Count();
            }
        }
        /// <summary>
        /// Numero di categorie vuote
        /// </summary>
        /// <returns></returns>
        public int GetCountCategorieVuote()
        {
            int _totCategorie = 0;
            int _categProdotti = 0;
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                _totCategorie = _model.Categories.Count();
            }
            using (ProdottiModelDataContext _modelProd = new ProdottiModelDataContext())
            {
                _categProdotti = _modelProd.ProdottiCategories.Select(cat => cat.IDCategoria).Distinct().Count();
            }

            return _totCategorie - _categProdotti;
        }
        /// <summary>
        /// Inserisce un immagine ad una categoria
        /// </summary>
        /// <param name="categ"></param>
        public void SetCategoriaImmagine(Categorie categ)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                Categorie _categoria = _model.Categories.Where(cat => cat.ID == categ.ID).SingleOrDefault();
                if (_categoria != null)
                {
                    _categoria.UrlImmagine = categ.UrlImmagine;
                    _model.SubmitChanges();
                }
            }
        }

        #region news
        /// <summary>
        /// Ottiene tutte le news trovate
        /// </summary>
        /// <param name="descrNews"></param>
        /// <returns></returns>
        public List<News> GetNewsByFilter(int startRowIndex, int maximumRows, string descrNews)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                if (string.IsNullOrEmpty(descrNews))
                {
                    return _model.News.OrderByDescending(news => news.DataInserimento).Skip(startRowIndex).Take(maximumRows).ToList();
                }
                else
                {
                    return _model.News.Where(news => news.Titolo.ToUpper().Contains(descrNews.ToUpper()) || news.Notizia.Contains(descrNews)).OrderByDescending(news => news.DataInserimento).Skip(startRowIndex).Take(maximumRows).ToList();
                }
            }
        }
        /// <summary>
        /// Notizia dato il suo id
        /// </summary>
        /// <param name="IDNotizia"></param>
        /// <returns></returns>
        public News GetNewsByIDNews(int IDNotizia)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                return _model.News.Where(news => news.ID == IDNotizia).SingleOrDefault();
            }
        }
        /// <summary>
        /// Totale news estratte
        /// </summary>
        /// <param name="descrNews"></param>
        /// <returns></returns>
        public int GetCountNewsByFilter(string descrNews)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                if (string.IsNullOrEmpty(descrNews))
                {
                    return _model.News.Count();
                }
                else
                {
                    return _model.News.Where(news => news.Titolo.ToUpper().Contains(descrNews.ToUpper()) || news.Notizia.Contains(descrNews)).Count();
                }
            }
        }
        /// <summary>
        /// Restituisce tutte le news
        /// </summary>
        /// <returns></returns>
        public News SetNews(News notizia)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                notizia.DataInserimento = DateTime.Now;
                _model.News.InsertOnSubmit(notizia);
                _model.SubmitChanges();

                try
                {
                    using (StatisticheModelDataContext _modelStat = new StatisticheModelDataContext())
                    {
                        RSSFeed _feed = new RSSFeed()
                        {
                            Categoria = "NEWS",
                            Contenuto = (notizia.Notizia.Length > 100)? notizia.Notizia.Substring(0,90) + "...":notizia.Notizia,
                            DataCreazione = DateTime.Now,
                            Titolo = notizia.Titolo + " (" + notizia.DataInserimento.ToShortDateString() + ")",
                            UrlDettaglio = "http://www.perbaffo.it/Dettaglio-Notizia.aspx?IDNotizia=" + notizia.ID.ToString()
                        };
                        _modelStat.RSSFeeds.InsertOnSubmit(_feed);
                        _modelStat.SubmitChanges();
                    }
                }
                catch
                {
                }

                return notizia;
            }
        }
        /// <summary>
        /// Cancella una notizia
        /// </summary>
        /// <param name="IDNews"></param>
        /// <returns></returns>
        public bool DeleteNews(int IDNews)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                News _notizia = _model.News.Where(not => not.ID == IDNews).SingleOrDefault();
                if (_notizia != null)
                {
                    _model.News.DeleteOnSubmit(_notizia);
                    _model.SubmitChanges();
                }
                return true;
            }
        }
        /// <summary>
        /// Restituisce tutte le news
        /// </summary>
        /// <returns></returns>
        public News UpdateNews(News notizia)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                News _notizia = _model.News.Where(not => not.ID == notizia.ID).SingleOrDefault();
                if (_notizia != null)
                {
                    _notizia.Notizia = notizia.Notizia;
                    _notizia.Titolo = notizia.Titolo;
                    _notizia.UrlFonte = notizia.UrlFonte;
                    _notizia.DescrioneFonte = notizia.DescrioneFonte;

                    _model.SubmitChanges();
                }
                return _notizia;
            }
        }
        /// <summary>
        /// Aggiunge un immagine alla news
        /// </summary>
        /// <param name="IDNews"></param>
        /// <param name="urlImmagine"></param>
        /// <returns></returns>
        public bool AggiungiImmagineNews(int IDNews, string urlImmagine)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                News _notizia = _model.News.Where(not => not.ID == IDNews).SingleOrDefault();
                if (_notizia != null)
                {
                    _notizia.UrlImmagine = urlImmagine;
                    _model.SubmitChanges();
                }
                return true;
            }
        } 
        #endregion

        #region curiosità
        /// <summary>
        /// Inserisce una curiosita
        /// </summary>
        /// <param name="curiosita"></param>
        /// <returns></returns>
        public Curiosita SetCuriosita(Curiosita curiosita)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                curiosita.DataInserimento = DateTime.Now;
                _model.Curiositas.InsertOnSubmit(curiosita);
                _model.SubmitChanges();
                return curiosita;
            }
        }
        /// <summary>
        /// Aggiorna una curiosita
        /// </summary>
        /// <param name="curiosita"></param>
        /// <returns></returns>
        public Curiosita UpdateCuriosita(Curiosita curiosita)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                Curiosita _curiosit = _model.Curiositas.Where(cur => cur.ID == curiosita.ID).SingleOrDefault();
                if (_curiosit != null)
                {
                    _curiosit.Categoria = curiosita.Categoria;
                    _curiosit.DescrCuriosita = curiosita.DescrCuriosita;
                }
                _model.SubmitChanges();
                return curiosita;
            }
        }
        /// <summary>
        /// Cancella curiosita
        /// </summary>
        /// <param name="curiosita"></param>
        public void DeleteCuriosita(int IDCuriosita)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                Curiosita _curiosit = _model.Curiositas.Where(cur => cur.ID == IDCuriosita).SingleOrDefault();
                if (_curiosit != null)
                {
                    _model.Curiositas.DeleteOnSubmit(_curiosit);
                }
                _model.SubmitChanges();
            }
        }
        /// <summary>
        /// Restituisce le curiosita data la categoria
        /// CAT
        /// DOG
        /// BIRD
        /// FISH
        /// RABBIT
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public List<Curiosita> GetCuriositaByCategoria(string categoria, int startRowIndex, int maximumRows)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                return _model.Curiositas.Where(cur => cur.Categoria == categoria).OrderBy(data => data.DataInserimento).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }
        /// <summary>
        /// Totale delle curiosita divise per la categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public int GetCountCuriositaByCategoria(string categoria)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                return _model.Curiositas.Where(cur => cur.Categoria == categoria).Count();
            }
        }
        /// <summary>
        /// Ottiene una curiosita dato il suo ID
        /// </summary>
        /// <param name="IDCuriosita"></param>
        /// <returns></returns>
        public Curiosita GetCuriositaByID(int IDCuriosita)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                return _model.Curiositas.Where(cur => cur.ID == IDCuriosita).SingleOrDefault();
            }
        }
        #endregion

        #region affiliazione
        /// <summary>
        /// Inserisce un codice affiliazione
        /// </summary>
        /// <param name="codAffiliazione"></param>
        /// <returns></returns>
        public CodiceAffiliazione SetCodiceAffiliazione(CodiceAffiliazione codAffiliazione)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                codAffiliazione.DataInserimento = DateTime.Now;
                _model.CodiceAffiliaziones.InsertOnSubmit(codAffiliazione);
                _model.SubmitChanges();
                return codAffiliazione;
            }
        }
        /// <summary>
        /// Aggiorna un codice affiliazione
        /// </summary>
        /// <param name="codAffiliazione"></param>
        /// <returns></returns>
        public CodiceAffiliazione UpdateCodiceAffiliazione(CodiceAffiliazione codAffiliazione)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                CodiceAffiliazione _codAffiliazione = _model.CodiceAffiliaziones.Where(c => c.ID == codAffiliazione.ID).SingleOrDefault();
                if (_codAffiliazione != null)
                {
                    _codAffiliazione.Sito = codAffiliazione.Sito;
                    _codAffiliazione.Codice = codAffiliazione.Codice;
                    _model.SubmitChanges();
                }

                return _codAffiliazione;
            }
        }
        /// <summary>
        /// Inserisce un codice affiliazione
        /// </summary>
        /// <param name="codAffiliazione"></param>
        /// <returns></returns>
        public bool DeleteCodiceAffiliazione(CodiceAffiliazione codAffiliazione)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                CodiceAffiliazione _codAffiliazione = _model.CodiceAffiliaziones.Where(c => c.ID == codAffiliazione.ID).SingleOrDefault();
                if (_codAffiliazione != null)
                {
                    _model.CodiceAffiliaziones.DeleteOnSubmit(_codAffiliazione);
                    _model.SubmitChanges();
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Aggiorna un codice affiliazione
        /// </summary>
        /// <param name="codAffiliazione"></param>
        /// <returns></returns>
        public CodiceAffiliazione GetCodiceAffiliazioneByID(int idCodAffiliazione)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.CodiceAffiliaziones.Where(c => c.ID == idCodAffiliazione).SingleOrDefault();
            }
        }
        /// <summary>
        /// Aggiorna un codice affiliazione
        /// </summary>
        /// <param name="codAffiliazione"></param>
        /// <returns></returns>
        public List<CodiceAffiliazione> GetCodiceAffiliazione()
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.CodiceAffiliaziones.OrderBy(c=> c.Sito).OrderBy(c => c.DataInserimento).ToList();
            }
        }
        #endregion

        #endregion
    }
}
