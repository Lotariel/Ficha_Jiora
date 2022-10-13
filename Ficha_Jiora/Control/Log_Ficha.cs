using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficha_Jiora.DAO;

namespace Ficha_Jiora.Control
{
    internal class Log_Ficha: Conexao
    {
        public void Insert_Log(string nome,string action)
        {
            InsertLog(nome, action);
        }
    }
}
