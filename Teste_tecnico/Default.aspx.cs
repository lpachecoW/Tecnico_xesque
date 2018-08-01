using System;
using System.Linq;
using System.Web.UI.WebControls;
using Teste_tecnico.Models;
using Teste_tecnico.Funcoes;


namespace Teste_tecnico
{
    public partial class Default : System.Web.UI.Page
    {
        refatoracaoEntitiesModel db = new refatoracaoEntitiesModel();
        Uteis funcoes = new Uteis();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                BindGrid();
            }
        }
        

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

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {   
            try
            {
                int codigo = Convert.ToInt32(txtCodigo.Text);
               
                if (!db.arquivo.Any(x => x.codigo == codigo))
                {
                    
                    if ((funcoes.verificaArquivo(Arquivo)))
                    {
                        arquivo arquivo = new arquivo();
                        {
                            arquivo.codigo = Convert.ToInt32(txtCodigo.Text);
                            arquivo.titulo = txtTitulo.Text;
                            arquivo.processo = txtProcesso.Text;
                            arquivo.categoria = txtCategoria.Text;
                            arquivo.arquivo1 = funcoes.SaveFile(Arquivo.PostedFile); 
                            db.arquivo.Add(arquivo);
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


