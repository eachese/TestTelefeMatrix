using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfTelefeMatrix
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class TelefeService : ITelefeService
    {
        string[] secuencias = { "AGVNFT", "XJILSB", "CHAOHD", "ERCVTQ", "ASOYAO", "ERMYUA", "TELEFE" };

        public void ChangeSecuencias(string[] secuencia)
        {
            secuencias = secuencia;
        }

        public List<List<int>> GetPosiciones(string word)
        {
            var findWords = new TelefeMatrix.FindWord(secuencias);
            var sqlCon = new SQLConection.Conection(ConfigurationManager.AppSettings["Host"],
                ConfigurationManager.AppSettings["User"],
                ConfigurationManager.AppSettings["Pass"],
                ConfigurationManager.AppSettings["DataBase"]);
            var result = findWords.Find(word);
            var json = JsonConvert.SerializeObject(result);
            sqlCon.InsertNewSearch(word, json);
            return  result;
        }
        public List<string> GetSearchs()
        {
            var sqlCon = new SQLConection.Conection(ConfigurationManager.AppSettings["Host"],
               ConfigurationManager.AppSettings["User"],
               ConfigurationManager.AppSettings["Pass"],
               ConfigurationManager.AppSettings["DataBase"]);
            return sqlCon.GetResult();
        }
    }
}
