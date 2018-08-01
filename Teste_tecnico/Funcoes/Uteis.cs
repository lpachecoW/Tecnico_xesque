using System;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;


namespace Teste_tecnico.Funcoes
{
    public class Uteis
    {
        public Boolean verificaArquivo(FileUpload arquivo)
        {
            string extension;
            Boolean isPermited = false;
            string fileName = arquivo.FileName;

            if (arquivo.HasFile)
            {
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
            }
            return isPermited;
        }

        public string SaveFile(HttpPostedFile file)
        {
            try
            {
                string filename = file.FileName;
                string path = "c:\\temp\\uploads\\";
                file.SaveAs(path + file.FileName);
                
                return filename;
            }
            catch (Exception ex)
            {
                return "Erro :" + ex.Message;
            }

        }

    }
}