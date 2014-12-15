using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Presenter
{
    public partial class Controller : IDisposable
    {
        #region PRIVATE METHODS
        public string GetConnectionString()
        {
            ProdottiModelDataContext _model = new ProdottiModelDataContext();
            return _model.Connection.ConnectionString;
        }
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
