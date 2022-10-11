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
    internal class Pericia_Control
    {
        private Pericia_Data pericia_Data = new Pericia_Data();

        public DataTable Carrega_Pericia(string IDPersonagem)
        {
            return pericia_Data.Carrega_Pericia(IDPersonagem);
        }
    }
}
