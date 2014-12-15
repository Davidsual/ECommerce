using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Presenter
{
    public partial class Controller : IDisposable
    {
        /// <summary>
        /// Crea il catalogo in PDF per la categoria CANI
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool CreaCatalogoCani(string fileName)
        {
            Document currentDocument = null;
            PdfWriter writer = null;
            try
            {
                ///File.Delete(fileName);
                currentDocument = new Document();
                writer = PdfWriter.GetInstance(currentDocument, new
                FileStream(fileName, FileMode.Create));
                currentDocument.Open();

                #region header
                currentDocument.AddAuthor("Perbaffo Petshop");
                currentDocument.AddCreationDate();
                currentDocument.AddCreator("Perbaffo Petshop");
                currentDocument.AddHeader("Perbaffo Petshop", "Catalogo Prodotti - Cani");
                currentDocument.AddSubject("Perbaffo Petshop Catalogo Prodotti - Cani");
                currentDocument.AddTitle("Perbaffo Petshop Catalogo Prodotti - Cani");
                currentDocument.Add(new Paragraph("Perbaffo Catalogo Prodotti - Cani", FontFactory.GetFont("Verdana", 12)));
                currentDocument.Add(new Paragraph("Catalogo prodotti - Cani", FontFactory.GetFont("Helvetica", 9)));
                currentDocument.Add(new Paragraph(" "));
                #endregion

                #region column's definition
                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 94;
                // header
                PdfPCell cellDate = new PdfPCell(new Phrase("Foto Prodotto", FontFactory.GetFont("Helvetica", 10, 1,
                new iTextSharp.text.BaseColor(System.Drawing.Color.Black))));
                cellDate.BackgroundColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellDate.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellDate.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellDate);

                PdfPCell cellTotals = new PdfPCell(new Phrase("Descrizione", FontFactory.GetFont("Helvetica", 10, 1,
                new iTextSharp.text.BaseColor(System.Drawing.Color.Black))));
                cellTotals.BackgroundColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellTotals.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellTotals.HorizontalAlignment = Element.ALIGN_CENTER;
                cellTotals.Colspan = 3;
                table.AddCell(cellTotals);

                table.SpacingBefore = 8;
                table.HeaderRows = 1;
                #endregion

                List<ProdottoImmagine> _prodotti = null;
                using (ControllerPresentation _present = new ControllerPresentation())
                {
                    _prodotti = _present.GetProdottiCategSottoCategByIDCateg(20);
                }
                if (_prodotti == null)
                    return false;
                _prodotti = _prodotti.Distinct(new ProductComparer()).OrderBy(c => c.Codice).ToList();
                ///Creo le righe
                foreach (ProdottoImmagine item in _prodotti)
                {
                    List<ProdottiTaglie> _taglie = this.GetProdottiTaglieByIDProdotto(item.ID);
                    List<Colori> _colori = this.GetProdottoColoriByIDProdotto(item.ID);

                    StringBuilder _str = new StringBuilder();
                    if (_taglie != null)
                    {
                        _taglie.ForEach(c => _str.Append(c.DescrTaglia + " Prezzo: € " +c.Prezzo.ToString()+ Environment.NewLine));
                        _str.Append(Environment.NewLine);
                    }
                    if (_colori != null)
                    {
                        _colori.ForEach(c => _str.Append(c.Descrizione + Environment.NewLine));
                        _str.Append(Environment.NewLine);
                    }
                    
                    Paragraph pr = new Paragraph(item.Nome, FontFactory.GetFont("Helvetica", 8, 1));
                    pr.Alignment = Element.ALIGN_CENTER;
                    PdfPCell cellValue = new PdfPCell();
                    cellValue.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cellValue.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("http://www.perbaffo.it/ImmaginiPerbaffo/" + item.UrlImmagine);
                    img.Alt = item.DescrImmagine;

                    cellValue.AddElement(pr);
                    cellValue.AddElement(new Paragraph(" "));
                    cellValue.AddElement(img);
                    Paragraph pr2 = new Paragraph("Codice: " + item.Codice, FontFactory.GetFont("Helvetica", 8, 1));
                    pr2.Alignment = Element.ALIGN_CENTER;
                    cellValue.AddElement(pr2);
                    cellValue.AddElement(new Paragraph(" "));
                    table.AddCell(cellValue);

                    Phrase p = new Phrase(item.DescrizioneLunga + Environment.NewLine + Environment.NewLine,FontFactory.GetFont("Helvetica", 8));
                    
                    if(_taglie != null && _taglie.Count > 0)
                        p.Add(new Phrase(Environment.NewLine + "Prezzo per " + item.DescrTaglia + ": € " + item.Prezzo, FontFactory.GetFont("Helvetica", 9, 1)));
                    else
                        p.Add(new Phrase(Environment.NewLine + "Prezzo: € " + item.Prezzo, FontFactory.GetFont("Helvetica", 9, 1)));
                    if((_taglie != null && _taglie.Count >0) ||( _colori != null && _colori.Count > 0))
                        p.Add(new Phrase(Environment.NewLine + Environment.NewLine + "Taglie e colori: " + Environment.NewLine + _str.ToString(), FontFactory.GetFont("Helvetica", 9, 0)));
                    cellDate = new PdfPCell(new Paragraph(p));
                    cellDate.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    cellDate.VerticalAlignment = Element.ALIGN_TOP;
                    cellDate.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                    cellDate.Colspan = 3;
                    table.AddCell(cellDate);

                }
                currentDocument.Add(table);
                currentDocument.Close();
                writer.Close();

                return true;
            }
            catch(Exception ex)
            {
                
                return false;
            }
            finally
            {
                try
                {
                    currentDocument.Close();
                    writer.Close();
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// Crea il catalogo in PDF per la categoria GATTI
        /// </summary>
        /// <returns></returns>
        public bool CreaCatalogoGatti(string fileName)
        {
            Document currentDocument = null;
            PdfWriter writer = null;
            try
            {
                ///File.Delete(fileName);
                currentDocument = new Document();
                writer = PdfWriter.GetInstance(currentDocument, new
                FileStream(fileName, FileMode.Create));
                currentDocument.Open();

                #region header
                currentDocument.AddAuthor("Perbaffo Petshop");
                currentDocument.AddCreationDate();
                currentDocument.AddCreator("Perbaffo Petshop");
                currentDocument.AddHeader("Perbaffo Petshop", "Catalogo Prodotti - Cani");
                currentDocument.AddSubject("Perbaffo Petshop Catalogo Prodotti - Cani");
                currentDocument.AddTitle("Perbaffo Petshop Catalogo Prodotti - Cani");
                currentDocument.Add(new Paragraph("Perbaffo Catalogo Prodotti - Cani", FontFactory.GetFont("Verdana", 12)));
                currentDocument.Add(new Paragraph("Catalogo prodotti - Cani", FontFactory.GetFont("Helvetica", 9)));
                currentDocument.Add(new Paragraph(" "));
                #endregion

                #region column's definition
                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 94;
                // header
                PdfPCell cellDate = new PdfPCell(new Phrase("Foto Prodotto", FontFactory.GetFont("Helvetica", 10, 1,
                new iTextSharp.text.BaseColor(System.Drawing.Color.Black))));
                cellDate.BackgroundColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellDate.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellDate.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellDate);

                PdfPCell cellTotals = new PdfPCell(new Phrase("Descrizione", FontFactory.GetFont("Helvetica", 10, 1,
                new iTextSharp.text.BaseColor(System.Drawing.Color.Black))));
                cellTotals.BackgroundColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellTotals.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellTotals.HorizontalAlignment = Element.ALIGN_CENTER;
                cellTotals.Colspan = 3;
                table.AddCell(cellTotals);

                table.SpacingBefore = 8;
                table.HeaderRows = 1;
                #endregion

                List<ProdottoImmagine> _prodotti = null;
                using (ControllerPresentation _present = new ControllerPresentation())
                {
                    _prodotti = _present.GetProdottiCategSottoCategByIDCateg(1);
                }
                if (_prodotti == null)
                    return false;
                _prodotti = _prodotti.Distinct(new ProductComparer()).OrderBy(c => c.Codice).ToList();
                ///Creo le righe
                foreach (ProdottoImmagine item in _prodotti)
                {
                    List<ProdottiTaglie> _taglie = this.GetProdottiTaglieByIDProdotto(item.ID);
                    List<Colori> _colori = this.GetProdottoColoriByIDProdotto(item.ID);

                    StringBuilder _str = new StringBuilder();
                    if (_taglie != null)
                    {
                        _taglie.ForEach(c => _str.Append(c.DescrTaglia + " Prezzo: € " + c.Prezzo.ToString() + Environment.NewLine));
                        _str.Append(Environment.NewLine);
                    }
                    if (_colori != null)
                    {
                        _colori.ForEach(c => _str.Append(c.Descrizione + Environment.NewLine));
                        _str.Append(Environment.NewLine);
                    }

                    Paragraph pr = new Paragraph(item.Nome, FontFactory.GetFont("Helvetica", 8, 1));
                    pr.Alignment = Element.ALIGN_CENTER;
                    PdfPCell cellValue = new PdfPCell();
                    cellValue.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cellValue.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("http://www.perbaffo.it/ImmaginiPerbaffo/" + item.UrlImmagine);
                    img.Alt = item.DescrImmagine;

                    cellValue.AddElement(pr);
                    cellValue.AddElement(new Paragraph(" "));
                    cellValue.AddElement(img);
                    Paragraph pr2 = new Paragraph("Codice: " + item.Codice, FontFactory.GetFont("Helvetica", 8, 1));
                    pr2.Alignment = Element.ALIGN_CENTER;
                    cellValue.AddElement(pr2);
                    cellValue.AddElement(new Paragraph(" "));
                    table.AddCell(cellValue);

                    Phrase p = new Phrase(item.DescrizioneLunga + Environment.NewLine + Environment.NewLine, FontFactory.GetFont("Helvetica", 8));

                    if (_taglie != null && _taglie.Count > 0)
                        p.Add(new Phrase(Environment.NewLine + "Prezzo per " + item.DescrTaglia + ": € " + item.Prezzo, FontFactory.GetFont("Helvetica", 9, 1)));
                    else
                        p.Add(new Phrase(Environment.NewLine + "Prezzo: € " + item.Prezzo, FontFactory.GetFont("Helvetica", 9, 1)));
                    if ((_taglie != null && _taglie.Count > 0) || (_colori != null && _colori.Count > 0))
                        p.Add(new Phrase(Environment.NewLine + Environment.NewLine + "Taglie e colori: " + Environment.NewLine + _str.ToString(), FontFactory.GetFont("Helvetica", 9, 0)));
                    cellDate = new PdfPCell(new Paragraph(p));
                    cellDate.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    cellDate.VerticalAlignment = Element.ALIGN_TOP;
                    cellDate.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                    cellDate.Colspan = 3;
                    table.AddCell(cellDate);

                }
                currentDocument.Add(table);
                currentDocument.Close();
                writer.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                try
                {
                    currentDocument.Close();
                    writer.Close();
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// Crea il catalogo in PDF per la categoria Roditori
        /// </summary>
        /// <returns></returns>
        public bool CreaCatalogoRoditori(string fileName)
        {

            Document currentDocument = null;
            PdfWriter writer = null;
            try
            {
                ///File.Delete(fileName);
                currentDocument = new Document();
                writer = PdfWriter.GetInstance(currentDocument, new
                FileStream(fileName, FileMode.Create));
                currentDocument.Open();

                #region header
                currentDocument.AddAuthor("Perbaffo Petshop");
                currentDocument.AddCreationDate();
                currentDocument.AddCreator("Perbaffo Petshop");
                currentDocument.AddHeader("Perbaffo Petshop", "Catalogo Prodotti - Cani");
                currentDocument.AddSubject("Perbaffo Petshop Catalogo Prodotti - Cani");
                currentDocument.AddTitle("Perbaffo Petshop Catalogo Prodotti - Cani");
                currentDocument.Add(new Paragraph("Perbaffo Catalogo Prodotti - Cani", FontFactory.GetFont("Verdana", 12)));
                currentDocument.Add(new Paragraph("Catalogo prodotti - Cani", FontFactory.GetFont("Helvetica", 9)));
                currentDocument.Add(new Paragraph(" "));
                #endregion

                #region column's definition
                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 94;
                // header
                PdfPCell cellDate = new PdfPCell(new Phrase("Foto Prodotto", FontFactory.GetFont("Helvetica", 10, 1,
                new iTextSharp.text.BaseColor(System.Drawing.Color.Black))));
                cellDate.BackgroundColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellDate.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellDate.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellDate);

                PdfPCell cellTotals = new PdfPCell(new Phrase("Descrizione", FontFactory.GetFont("Helvetica", 10, 1,
                new iTextSharp.text.BaseColor(System.Drawing.Color.Black))));
                cellTotals.BackgroundColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellTotals.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellTotals.HorizontalAlignment = Element.ALIGN_CENTER;
                cellTotals.Colspan = 3;
                table.AddCell(cellTotals);

                table.SpacingBefore = 8;
                table.HeaderRows = 1;
                #endregion

                List<ProdottoImmagine> _prodotti = null;
                using (ControllerPresentation _present = new ControllerPresentation())
                {
                    _prodotti = _present.GetProdottiCategSottoCategByIDCateg(18);
                }
                if (_prodotti == null)
                    return false;
                _prodotti = _prodotti.Distinct(new ProductComparer()).OrderBy(c => c.Codice).ToList();
                ///Creo le righe
                foreach (ProdottoImmagine item in _prodotti)
                {
                    List<ProdottiTaglie> _taglie = this.GetProdottiTaglieByIDProdotto(item.ID);
                    List<Colori> _colori = this.GetProdottoColoriByIDProdotto(item.ID);

                    StringBuilder _str = new StringBuilder();
                    if (_taglie != null)
                    {
                        _taglie.ForEach(c => _str.Append(c.DescrTaglia + " Prezzo: € " + c.Prezzo.ToString() + Environment.NewLine));
                        _str.Append(Environment.NewLine);
                    }
                    if (_colori != null)
                    {
                        _colori.ForEach(c => _str.Append(c.Descrizione + Environment.NewLine));
                        _str.Append(Environment.NewLine);
                    }

                    Paragraph pr = new Paragraph(item.Nome, FontFactory.GetFont("Helvetica", 8, 1));
                    pr.Alignment = Element.ALIGN_CENTER;
                    PdfPCell cellValue = new PdfPCell();
                    cellValue.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cellValue.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("http://www.perbaffo.it/ImmaginiPerbaffo/" + item.UrlImmagine);
                    img.Alt = item.DescrImmagine;

                    cellValue.AddElement(pr);
                    cellValue.AddElement(new Paragraph(" "));
                    cellValue.AddElement(img);
                    Paragraph pr2 = new Paragraph("Codice: " + item.Codice, FontFactory.GetFont("Helvetica", 8, 1));
                    pr2.Alignment = Element.ALIGN_CENTER;
                    cellValue.AddElement(pr2);
                    cellValue.AddElement(new Paragraph(" "));
                    table.AddCell(cellValue);

                    Phrase p = new Phrase(item.DescrizioneLunga + Environment.NewLine + Environment.NewLine, FontFactory.GetFont("Helvetica", 8));

                    if (_taglie != null && _taglie.Count > 0)
                        p.Add(new Phrase(Environment.NewLine + "Prezzo per " + item.DescrTaglia + ": € " + item.Prezzo, FontFactory.GetFont("Helvetica", 9, 1)));
                    else
                        p.Add(new Phrase(Environment.NewLine + "Prezzo: € " + item.Prezzo, FontFactory.GetFont("Helvetica", 9, 1)));
                    if ((_taglie != null && _taglie.Count > 0) || (_colori != null && _colori.Count > 0))
                        p.Add(new Phrase(Environment.NewLine + Environment.NewLine + "Taglie e colori: " + Environment.NewLine + _str.ToString(), FontFactory.GetFont("Helvetica", 9, 0)));
                    cellDate = new PdfPCell(new Paragraph(p));
                    cellDate.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    cellDate.VerticalAlignment = Element.ALIGN_TOP;
                    cellDate.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                    cellDate.Colspan = 3;
                    table.AddCell(cellDate);

                }
                currentDocument.Add(table);
                currentDocument.Close();
                writer.Close();

                return true;
            }
            catch (Exception ex)
            {
                this.SetErrore(new Errori() { DescrException = ex.Message, DescrStackTrace = ex.StackTrace, DataErrore = DateTime.Now, Browser = "GG" });
                return false;
            }
            finally
            {
                try
                {
                    currentDocument.Close();
                    writer.Close();
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// Crea il catalogo in PDF per la categoria VOLATILI
        /// </summary>
        /// <returns></returns>
        public bool CreaCatalogoVolatili(string fileName)
        {
            Document currentDocument = null;
            PdfWriter writer = null;
            try
            {
                ///File.Delete(fileName);
                currentDocument = new Document();
                writer = PdfWriter.GetInstance(currentDocument, new
                FileStream(fileName, FileMode.Create));
                currentDocument.Open();

                #region header
                currentDocument.AddAuthor("Perbaffo Petshop");
                currentDocument.AddCreationDate();
                currentDocument.AddCreator("Perbaffo Petshop");
                currentDocument.AddHeader("Perbaffo Petshop", "Catalogo Prodotti - Cani");
                currentDocument.AddSubject("Perbaffo Petshop Catalogo Prodotti - Cani");
                currentDocument.AddTitle("Perbaffo Petshop Catalogo Prodotti - Cani");
                currentDocument.Add(new Paragraph("Perbaffo Catalogo Prodotti - Cani", FontFactory.GetFont("Verdana", 12)));
                currentDocument.Add(new Paragraph("Catalogo prodotti - Cani", FontFactory.GetFont("Helvetica", 9)));
                currentDocument.Add(new Paragraph(" "));
                #endregion

                #region column's definition
                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 94;
                // header
                PdfPCell cellDate = new PdfPCell(new Phrase("Foto Prodotto", FontFactory.GetFont("Helvetica", 10, 1,
                new iTextSharp.text.BaseColor(System.Drawing.Color.Black))));
                cellDate.BackgroundColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellDate.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellDate.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellDate);

                PdfPCell cellTotals = new PdfPCell(new Phrase("Descrizione", FontFactory.GetFont("Helvetica", 10, 1,
                new iTextSharp.text.BaseColor(System.Drawing.Color.Black))));
                cellTotals.BackgroundColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellTotals.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellTotals.HorizontalAlignment = Element.ALIGN_CENTER;
                cellTotals.Colspan = 3;
                table.AddCell(cellTotals);

                table.SpacingBefore = 8;
                table.HeaderRows = 1;
                #endregion

                List<ProdottoImmagine> _prodotti = null;
                using (ControllerPresentation _present = new ControllerPresentation())
                {
                    _prodotti = _present.GetProdottiCategSottoCategByIDCateg(9);
                }
                if (_prodotti == null)
                    return false;
                _prodotti = _prodotti.Distinct(new ProductComparer()).OrderBy(c => c.Codice).ToList();
                ///Creo le righe
                foreach (ProdottoImmagine item in _prodotti)
                {
                    List<ProdottiTaglie> _taglie = this.GetProdottiTaglieByIDProdotto(item.ID);
                    List<Colori> _colori = this.GetProdottoColoriByIDProdotto(item.ID);

                    StringBuilder _str = new StringBuilder();
                    if (_taglie != null)
                    {
                        _taglie.ForEach(c => _str.Append(c.DescrTaglia + " Prezzo: € " + c.Prezzo.ToString() + Environment.NewLine));
                        _str.Append(Environment.NewLine);
                    }
                    if (_colori != null)
                    {
                        _colori.ForEach(c => _str.Append(c.Descrizione + Environment.NewLine));
                        _str.Append(Environment.NewLine);
                    }

                    Paragraph pr = new Paragraph(item.Nome, FontFactory.GetFont("Helvetica", 8, 1));
                    pr.Alignment = Element.ALIGN_CENTER;
                    PdfPCell cellValue = new PdfPCell();
                    cellValue.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cellValue.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("http://www.perbaffo.it/ImmaginiPerbaffo/" + item.UrlImmagine);
                    img.Alt = item.DescrImmagine;

                    cellValue.AddElement(pr);
                    cellValue.AddElement(new Paragraph(" "));
                    cellValue.AddElement(img);
                    Paragraph pr2 = new Paragraph("Codice: " + item.Codice, FontFactory.GetFont("Helvetica", 8, 1));
                    pr2.Alignment = Element.ALIGN_CENTER;
                    cellValue.AddElement(pr2);
                    cellValue.AddElement(new Paragraph(" "));
                    table.AddCell(cellValue);

                    Phrase p = new Phrase(item.DescrizioneLunga + Environment.NewLine + Environment.NewLine, FontFactory.GetFont("Helvetica", 8));

                    if (_taglie != null && _taglie.Count > 0)
                        p.Add(new Phrase(Environment.NewLine + "Prezzo per " + item.DescrTaglia + ": € " + item.Prezzo, FontFactory.GetFont("Helvetica", 9, 1)));
                    else
                        p.Add(new Phrase(Environment.NewLine + "Prezzo: € " + item.Prezzo, FontFactory.GetFont("Helvetica", 9, 1)));
                    if ((_taglie != null && _taglie.Count > 0) || (_colori != null && _colori.Count > 0))
                        p.Add(new Phrase(Environment.NewLine + Environment.NewLine + "Taglie e colori: " + Environment.NewLine + _str.ToString(), FontFactory.GetFont("Helvetica", 9, 0)));
                    cellDate = new PdfPCell(new Paragraph(p));
                    cellDate.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    cellDate.VerticalAlignment = Element.ALIGN_TOP;
                    cellDate.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                    cellDate.Colspan = 3;
                    table.AddCell(cellDate);

                }
                currentDocument.Add(table);
                currentDocument.Close();
                writer.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                try
                {
                    currentDocument.Close();
                    writer.Close();
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// Crea il catalogo in PDF per la categoria ACQUARIOLOGIA
        /// </summary>
        /// <returns></returns>
        public bool CreaCatalogoAcquariologia(string fileName)
        {
            Document currentDocument = null;
            PdfWriter writer = null;
            try
            {
                ///File.Delete(fileName);
                currentDocument = new Document();
                writer = PdfWriter.GetInstance(currentDocument, new
                FileStream(fileName, FileMode.Create));
                currentDocument.Open();

                #region header
                currentDocument.AddAuthor("Perbaffo Petshop");
                currentDocument.AddCreationDate();
                currentDocument.AddCreator("Perbaffo Petshop");
                currentDocument.AddHeader("Perbaffo Petshop", "Catalogo Prodotti - Cani");
                currentDocument.AddSubject("Perbaffo Petshop Catalogo Prodotti - Cani");
                currentDocument.AddTitle("Perbaffo Petshop Catalogo Prodotti - Cani");
                currentDocument.Add(new Paragraph("Perbaffo Catalogo Prodotti - Cani", FontFactory.GetFont("Verdana", 12)));
                currentDocument.Add(new Paragraph("Catalogo prodotti - Cani", FontFactory.GetFont("Helvetica", 9)));
                currentDocument.Add(new Paragraph(" "));
                #endregion

                #region column's definition
                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 94;
                // header
                PdfPCell cellDate = new PdfPCell(new Phrase("Foto Prodotto", FontFactory.GetFont("Helvetica", 10, 1,
                new iTextSharp.text.BaseColor(System.Drawing.Color.Black))));
                cellDate.BackgroundColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellDate.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellDate.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellDate);

                PdfPCell cellTotals = new PdfPCell(new Phrase("Descrizione", FontFactory.GetFont("Helvetica", 10, 1,
                new iTextSharp.text.BaseColor(System.Drawing.Color.Black))));
                cellTotals.BackgroundColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellTotals.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                cellTotals.HorizontalAlignment = Element.ALIGN_CENTER;
                cellTotals.Colspan = 3;
                table.AddCell(cellTotals);

                table.SpacingBefore = 8;
                table.HeaderRows = 1;
                #endregion

                List<ProdottoImmagine> _prodotti = null;
                using (ControllerPresentation _present = new ControllerPresentation())
                {
                    _prodotti = _present.GetProdottiCategSottoCategByIDCateg(168);
                }
                if (_prodotti == null)
                    return false;
                _prodotti = _prodotti.Distinct(new ProductComparer()).OrderBy(c => c.Codice).ToList();
                ///Creo le righe
                foreach (ProdottoImmagine item in _prodotti)
                {
                    List<ProdottiTaglie> _taglie = this.GetProdottiTaglieByIDProdotto(item.ID);
                    List<Colori> _colori = this.GetProdottoColoriByIDProdotto(item.ID);

                    StringBuilder _str = new StringBuilder();
                    if (_taglie != null)
                    {
                        _taglie.ForEach(c => _str.Append(c.DescrTaglia + " Prezzo: € " + c.Prezzo.ToString() + Environment.NewLine));
                        _str.Append(Environment.NewLine);
                    }
                    if (_colori != null)
                    {
                        _colori.ForEach(c => _str.Append(c.Descrizione + Environment.NewLine));
                        _str.Append(Environment.NewLine);
                    }

                    Paragraph pr = new Paragraph(item.Nome, FontFactory.GetFont("Helvetica", 8, 1));
                    pr.Alignment = Element.ALIGN_CENTER;
                    PdfPCell cellValue = new PdfPCell();
                    cellValue.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cellValue.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("http://www.perbaffo.it/ImmaginiPerbaffo/" + item.UrlImmagine);
                    img.Alt = item.DescrImmagine;

                    cellValue.AddElement(pr);
                    cellValue.AddElement(new Paragraph(" "));
                    cellValue.AddElement(img);
                    Paragraph pr2 = new Paragraph("Codice: " + item.Codice, FontFactory.GetFont("Helvetica", 8, 1));
                    pr2.Alignment = Element.ALIGN_CENTER;
                    cellValue.AddElement(pr2);
                    cellValue.AddElement(new Paragraph(" "));
                    table.AddCell(cellValue);

                    Phrase p = new Phrase(item.DescrizioneLunga + Environment.NewLine + Environment.NewLine, FontFactory.GetFont("Helvetica", 8));

                    if (_taglie != null && _taglie.Count > 0)
                        p.Add(new Phrase(Environment.NewLine + "Prezzo per " + item.DescrTaglia + ": € " + item.Prezzo, FontFactory.GetFont("Helvetica", 9, 1)));
                    else
                        p.Add(new Phrase(Environment.NewLine + "Prezzo: € " + item.Prezzo, FontFactory.GetFont("Helvetica", 9, 1)));
                    if ((_taglie != null && _taglie.Count > 0) || (_colori != null && _colori.Count > 0))
                        p.Add(new Phrase(Environment.NewLine + Environment.NewLine + "Taglie e colori: " + Environment.NewLine + _str.ToString(), FontFactory.GetFont("Helvetica", 9, 0)));
                    cellDate = new PdfPCell(new Paragraph(p));
                    cellDate.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    cellDate.VerticalAlignment = Element.ALIGN_TOP;
                    cellDate.BorderColor = new iTextSharp.text.BaseColor(205, 221, 237);
                    cellDate.Colspan = 3;
                    table.AddCell(cellDate);

                }
                currentDocument.Add(table);
                currentDocument.Close();
                writer.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                try
                {
                    currentDocument.Close();
                    writer.Close();
                }
                catch
                {
                }
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
    }
    /// <summary>
    /// Comparatore per i prodotti immagine
    /// </summary>
    public class ProductComparer : IEqualityComparer<ProdottoImmagine> 
    {
        #region IEqualityComparer<ProdottoImmagine> Members

        bool IEqualityComparer<ProdottoImmagine>.Equals(ProdottoImmagine x, ProdottoImmagine y) 
        {
            // Check whether the compared objects reference the same data. 
            if (Object.ReferenceEquals(x, y))
                return true;

            // Check whether any of the compared objects is null. 
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return (x.ID == y.ID); 

        }

        public int GetHashCode(ProdottoImmagine obj)
        {
            return obj.GetHashCode(); 

        }

        #endregion
    }
}
