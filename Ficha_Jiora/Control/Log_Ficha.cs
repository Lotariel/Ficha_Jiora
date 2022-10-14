using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficha_Jiora.DAO;
using Ficha_Jiora.Model;

namespace Ficha_Jiora.Control
{
    internal class Log_Ficha: Conexao
    {
        private Log_Data log_Data = new Log_Data();
        
        public void Insert_Log(string nome,string action)
        {
            log_Data.InsertLog(nome, action);
        }

        public DataTable Carrega_Log(string nomepersonagem)
        {
            return log_Data.Carrega_Log(nomepersonagem);
        }


    }
}
