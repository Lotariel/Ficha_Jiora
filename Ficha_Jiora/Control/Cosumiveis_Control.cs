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
    internal class Cosumiveis_Control
    {
        private Consumiveis_Model consumiveis_Model = new Consumiveis_Model();
        private Consumiveis_Data consumiveis_Data = new Consumiveis_Data();


        public Consumiveis_Model Carrega_Consumivel(string IDConsumivel, string idpersonagem)
        {
            return consumiveis_Data.Carrega_Consumivel(IDConsumivel, idpersonagem);
        }

        public DataTable Carrega_Combo_Consumiveis(string idpersonagem)
        {
            return consumiveis_Data.Carrega_Combo_Consumiveis(idpersonagem);
        }

        public void Reduz_Quantidade_Consumivel(string idconsumivel, string idpersonagem)
        {
            consumiveis_Data.Reduz_Quantidade_Consumivel(idconsumivel, idpersonagem);
        }
    }
}
