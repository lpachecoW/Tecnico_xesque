using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Teste_tecnico.Models;

namespace Teste_tecnico
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                BindGrid();
            }
        }

        teste_tecnicoEntitiesModel db = new teste_tecnicoEntitiesModel();

        private void BindGrid()
        {
            var query = from doc in db.arquivo.ToList()
                        orderby doc.titulo ascending
                        select doc;

            if (query.Count() > 0)
            {
                grdDocumentos.DataSource = query;
                grdDocumentos.DataBind();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {   
            try
            {
                //Codigo transformado em variavel a parte pois o EF não estava convertendo os valoes. **microsoft forum
                int codigo = Convert.ToInt32(txtCodigo.Text);

                if (!db.arquivo.Any(x => x.codigo == codigo))
                {
                    if (Arquivo.HasFile)
                    {
                        string extension;
                        string fileName = Arquivo.FileName;
                        string savePath = "c:\\temp\\uploads\\";
                        Boolean isPermited = false;

                        extension = Path.GetExtension(fileName);
                        switch (extension)
                        {
                            case ".pdf":
                                isPermited = true;
                                break;
                            case ".doc":
                                isPermited = true;
                                break;
                            case ".xls":
                                isPermited = true;
                                break;
                        }

                        if (isPermited)
                        {
                            SaveFile(Arquivo.PostedFile);

                            arquivo arquivo = new arquivo();
                            arquivo.codigo = Convert.ToInt32(txtCodigo.Text);
                            arquivo.titulo = txtTitulo.Text;
                            arquivo.processo = txtProcesso.Text;
                            arquivo.categoria = txtCategoria.Text;
                            arquivo.arquivo1 = savePath + Arquivo.FileName;
                            db.arquivo.Add(arquivo);
                            db.SaveChanges();
                            BindGrid();

                            txtCodigo.Text = string.Empty;
                            txtTitulo.Text = string.Empty;
                            txtProcesso.Text = string.Empty;
                            txtCategoria.Text = string.Empty;
                        }
                        else
                        {
                            lblError.Text = "Apenas arquivos do tipo PDF, DOC e XLS";
                        }
                    }
                    else
                    {
                        lblError.Text = "Selecione um arquivo.";
                    }
                }
                else
                {
                    lblError.Text = "Codigo ja existente.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Erro :" + ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = string.Empty;
            txtTitulo.Text = string.Empty;
            txtProcesso.Text = string.Empty;
            txtCategoria.Text = string.Empty;
        }
        
        void SaveFile(HttpPostedFile file)
        {
            string fileName = Arquivo.FileName;
            string savePath = "c:\\temp\\uploads\\";
                savePath += fileName;
                Arquivo.SaveAs(savePath);
                lblSucesso.Text = "Arquivo enviado com sucesso";
         }
            
        }



    }


