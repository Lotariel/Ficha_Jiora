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
    internal class Elemento_Control
    {
        private Elemento_Data elemento_Data = new Elemento_Data();
        public void ResetaElementoMod_all()
        {
            elemento_Data.ResetaElementoMod_all();
        }

        public void ResetaElementoMod(string ID)
        {
            elemento_Data.ResetaElementoMod(ID);
        }

        public void AumentaElementoMod(string ID, string Coluna, int valor)
        {
            elemento_Data.AumentaElementoMod(ID, Coluna, valor);
        }
    }
}
