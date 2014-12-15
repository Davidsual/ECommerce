using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Presenter
{
    public partial class ControllerPresentation : IDisposable
    {
        #region PUBLIC METHODS
        /// <summary>
        /// Ricerca tutte le categorie che contengono una certa descrizione
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public List<Categorie> FindAdvancedCategorieByDescription(string description)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {

                string[] _ricerca = description.Split(' ');
                _model.DeferredLoadingEnabled = false;
                _model.ObjectTrackingEnabled = false;

                if (_ricerca != null && _ricerca[0].Length > 3)
                {
                    string _filter = _ricerca[0].Substring(0, _ricerca[0].Length - 1);
                    return _model.Categories.Where(cat => cat.DescrizioneBreve.ToLower().Contains(_filter.ToLower()) || cat.DescrizioneCategoria.ToLower().Contains(_filter.ToLower())).OrderBy(c => c.ID).ThenBy(c => c.DescrizioneBreve).Distinct().ToList();
                }
                else
                    return null;// _model.Categories.Where(cat => cat.DescrizioneBreve.ToLower().Contains(description.ToLower()) || cat.DescrizioneCategoria.ToLower().Contains(description.ToLower())).Distinct().ToList();
            }
        }
        /// <summary>
        /// Ricerca tutte le categorie che contengono una certa descrizione
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public List<Categorie> FindCategorieByDescription(string description)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                return _model.Categories.Where(cat => cat.DescrizioneBreve.ToLower().Contains(description.ToLower()) || cat.DescrizioneCategoria.ToLower().Contains(description.ToLower())).Distinct().ToList();
            }
        }
        /// <summary>
        /// Ritorna la lista delle categorie
        /// </summary>
        /// <returns></returns>
        public List<Categorie> GetCategorie()
        {
            using (Controller _controller = new Controller())
            {
                return _controller.GetCategorie();
            }
        }
        ///// <summary>
        ///// Restituisce le categorie filtrate
        ///// </summary>
        ///// <param name="IDCategoria"></param>
        ///// <returns></returns>
        //public List<Categorie> GetCategorieFiltrataByIDCategoria(int IDCategoria)
        //{
        //    using (Controller _controller = new Controller())
        //    {
        //        return _controller.GetCategorieFiltrataByIDCategoria(IDCategoria);
        //    }
        //}

        /// <summary>
        /// Ottiene la categoria scelta e le sue sotto categorie
        /// </summary>
        /// <param name="IDCategoria"></param>
        /// <returns></returns>
        public Categorie GetCategoriaByIDCategoria(int IDCategoria)
        {
            Categorie _categ = null;
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                _model.ObjectTrackingEnabled = false;
                _categ = _model.Categories.Where(cat => cat.ID == IDCategoria).SingleOrDefault();
                if (_categ != null)
                {
                    _categ.CategorieFiglie = _model.Categories.Where(cat => cat.IDCategoriaPadre == IDCategoria).OrderBy(cat => cat.DescrizioneBreve).ToList();
                }
            }
            return _categ;
        }
        /// <summary>
        /// Ottiene l'eventuale terzo livello
        /// </summary>
        /// <param name="IDCategoria"></param>
        /// <returns></returns>
        public List<Categorie> GetTerzoLivelloCategorie(int IDCategoria)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                _model.ObjectTrackingEnabled = false;
                return _model.Categories.Where(cat => cat.IDCategoriaPadre == IDCategoria).OrderBy(cat => cat.DescrizioneBreve).ToList();
            }
        }
        /// <summary>
        /// Ottiene il path su quattro livelli della categoria
        /// </summary>
        /// <param name="IDCategoria"></param>
        /// <returns></returns>
        public List<Categorie> GetPathCategoriaByIDCategoria(int IDCategoria)
        {
            List<Categorie> _categ = new List<Categorie>(4);
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                _model.ObjectTrackingEnabled = false;
                Categorie _cat = _model.Categories.Where(cat => cat.ID == IDCategoria).SingleOrDefault();
                if (_cat != null)
                {
                    _categ.Add(_cat);
                    if (_cat.IDCategoriaPadre == null || _cat.IDCategoriaPadre == 0)
                    {
                        return _categ;
                    }
                    else
                    {
                        _cat = _model.Categories.Where(cat => cat.ID == _cat.IDCategoriaPadre).SingleOrDefault();
                        if (_cat != null)
                            _categ.Add(_cat);
                        if (_cat.IDCategoriaPadre == null || _cat.IDCategoriaPadre == 0)
                        {
                            return _categ;
                        }
                        else
                        {
                            _cat = _model.Categories.Where(cat => cat.ID == _cat.IDCategoriaPadre).SingleOrDefault();
                            if (_cat != null)
                                _categ.Add(_cat);
                            if (_cat.IDCategoriaPadre == null || _cat.IDCategoriaPadre == 0)
                            {
                                return _categ;
                            }
                            else
                            {
                                _cat = _model.Categories.Where(cat => cat.ID == _cat.IDCategoriaPadre).SingleOrDefault();
                                if (_cat != null)
                                    _categ.Add(_cat);
                                if (_cat.IDCategoriaPadre == null || _cat.IDCategoriaPadre == 0)
                                {
                                    return _categ;
                                }
                                else
                                {
                                    _cat = _model.Categories.Where(cat => cat.ID == _cat.IDCategoriaPadre).SingleOrDefault();
                                    if (_cat != null)
                                        _categ.Add(_cat);
                                    if (_cat.IDCategoriaPadre == null || _cat.IDCategoriaPadre == 0)
                                    {
                                        return _categ;
                                    }
                                    else
                                    {
                                        _cat = _model.Categories.Where(cat => cat.ID == _cat.IDCategoriaPadre).SingleOrDefault();
                                        if (_cat != null)
                                            _categ.Add(_cat);
                                        if (_cat.IDCategoriaPadre == null || _cat.IDCategoriaPadre == 0)
                                        {
                                            return _categ;
                                        }
                                        else
                                        {
                                            _cat = _model.Categories.Where(cat => cat.ID == _cat.IDCategoriaPadre).SingleOrDefault();
                                            if (_cat != null)
                                                _categ.Add(_cat);
                                            if (_cat.IDCategoriaPadre == null || _cat.IDCategoriaPadre == 0)
                                            {
                                                return _categ;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return _categ;
        }
        /// <summary>
        /// Restituisce un array di interi con l'id della categoria passata e di quelle figlie
        /// </summary>
        /// <param name="IDCategoria"></param>
        /// <returns></returns>
        private List<int> GetIDCategorieByIDCategoria(int IDCategoria)
        {
            List<int> _list = new List<int>(10);
            _list.Add(IDCategoria);
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                List<int> _result = _model.Categories.Where(cat => cat.IDCategoriaPadre == IDCategoria).Select(cat => cat.ID).ToList();
                if (_result != null && _result.Count > 0)
                {
                    _result.ForEach(item =>
                        {
                            this.AggiungiIDCategoriaByIDCategoria(_model, item, _list);
                        });
                }

            }
            return _list;
        }
        /// <summary>
        /// Aggiunge in maniera ricorsiva gli id
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="IDCategoria"></param>
        /// <param name="output"></param>
        private void AggiungiIDCategoriaByIDCategoria(ConfigurazioniDataContext _model, int IDCategoria, List<int> output)
        {
            if (!output.Contains(IDCategoria))
                output.Add(IDCategoria);
            List<int> _result = _model.Categories.Where(cat => cat.IDCategoriaPadre == IDCategoria).Select(cat => cat.ID).ToList();
            if (_result != null && _result.Count > 0)
            {
                _result.ForEach(item =>
                {
                    this.AggiungiIDCategoriaByIDCategoria(_model, item, output);
                });
            }
        }
        /// <summary>
        /// Ottiene tutte le categorie di cui fà parte un prodotto
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public List<Categorie> GetCategorieDelProdottoByIDProdotto(int IDProdotto)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                _model.ObjectTrackingEnabled = false;
                return (from Categorie _categ in _model.Categories
                        join DettagliProdottiCategorie _prodCat in _model.DettagliProdottiCategories on _categ.ID equals _prodCat.IDCategoria
                        where _prodCat.IDProdotto == IDProdotto
                        select _categ).OrderBy(categ => categ.DescrizioneBreve).ToList();
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
        #endregion
    }
}
