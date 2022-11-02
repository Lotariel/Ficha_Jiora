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
    internal class Magia_Control
    {
        
        private Magia_Data magia_Data = new Magia_Data();
        public MagiaAntiga_Model RetornaDescricaoMagiaAntiga(string Elemento, int Rank, string alvo, string Categoria)
        {
            return magia_Data.RetornaDescricaoMagiaAntiga(Elemento, Rank, alvo, Categoria);
        }
    }
}
