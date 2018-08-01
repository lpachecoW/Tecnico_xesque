using System;
using System.Linq;
using System.Web.UI.WebControls;
using Teste_tecnico.Models;
using Teste_tecnico.Funcoes;


namespace Teste_tecnico
{
    public partial class Default : System.Web.UI.Page
    {
        refatoradoEntitiesModel db = new refatoradoEntitiesModel();
        Uteis funcoes = new Uteis();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                BindGrid();
            }
        }
        

        private void BindGrid()
        {
            var query = from doc in db.tb_documentos.ToList()
                        orderby doc.titulo ascending
                        select doc;

            if (query.Count() > 0)
            {
                grdDocumentos.DataSource = query;
                grdDocumentos.DataBind();
            }
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {   
            try
            {
                int codigo = Convert.ToInt32(txtCodigo.Text);
               
                if (!db.tb_documentos.Any(x => x.codigo == codigo))
                {
                    
                    if ((funcoes.verificaArquivo(Arquivo)))
                    {
                        tb_documentos arquivo = new tb_documentos();
                        {
                            arquivo.codigo = Convert.ToInt32(txtCodigo.Text);
                            arquivo.titulo = txtTitulo.Text;
                            arquivo.processo = txtProcesso.Text;
                            arquivo.categoria = txtCategoria.Text;
                            arquivo.arquivo = funcoes.SaveFile(Arquivo.PostedFile); 
                            db.tb_documentos.Add(arquivo);
                            db.SaveChanges();
                            BindGrid();
                            LimpaCampos();
                            lblSucesso.Text = "Arquivo enviado com sucesso";
                        }
                        
                    }
                    else
                    {
                        lblError.Text = "Arquivo não selecionado ou fora do formato .PDF, .XLS ou .DOC.";
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

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }
        

        void LimpaCampos()
        {
            txtCodigo.Text = string.Empty;
            txtTitulo.Text = string.Empty;
            txtProcesso.Text = string.Empty;
            txtCategoria.Text = string.Empty;
        }
        

    }
    
    }


