using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Presenter
{
    public partial class ControllerPresentation : IDisposable
    {
        public enum TipoInvioMail
        {
            NuovoUtente,
            RecuperoPassword
        }

        #region PUBLIC METHODS
        /// <summary>
        /// Capitaliza la stringa
        /// </summary>
        /// <param name="toCapitalize"></param>
        /// <returns></returns>
        public string Capitalize(string toCapitalize)
        {
            try
            {
                if (toCapitalize.Length > 1)
                {
                    toCapitalize = toCapitalize.Substring(0, 1).ToUpper() + toCapitalize.Substring(1);
                }
            }
            catch (Exception ex)
            {
                return toCapitalize;
            }
            return toCapitalize;
        }
        /// <summary>
        /// Ottiene tutte le news trovate
        /// </summary>
        /// <param name="descrNews"></param>
        /// <returns></returns>
        public List<News> GetNews(int startRowIndex, int maximumRows)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                return _model.News.OrderByDescending(news => news.DataInserimento).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }
        /// <summary>
        /// Totale news estratte
        /// </summary>
        /// <param name="descrNews"></param>
        /// <returns></returns>
        public int GetCountNews()
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                return _model.News.Count();
            }
        }
        /// <summary>
        /// Restituisce le top 5 news
        /// </summary>
        /// <returns></returns>
        public List<News> GetTopNews(int numNews)
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                return _model.News.OrderByDescending(news => news.DataInserimento).Take(numNews).ToList();
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
        /// Restituisce tutte le news
        /// </summary>
        /// <returns></returns>
        public List<News> GetNews()
        {
            using (ConfigurazioniDataContext _model = new ConfigurazioniDataContext())
            {
                return _model.News.OrderByDescending(news => news.DataInserimento).ToList();
            }
        }
        /// <summary>
        /// Numero di elementi data la categoria
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

        #region PRIVATE METHODS

        /// <summary>
        /// Encode una stringa in base 64
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Encode(string str)
        {
            byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(encbuff);
        }
        /// <summary>
        /// Decodifica da base 64 a string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Decode(string str)
        {
            byte[] decbuff = Convert.FromBase64String(str);
            return System.Text.Encoding.UTF8.GetString(decbuff);
        }
        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            
        }

        #endregion
    }
}
