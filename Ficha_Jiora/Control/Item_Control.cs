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
    internal class Item_Control
    {
        private Item_Data Item_Data = new Item_Data();

        public DataTable Carrega_Item(string IDPersonagem)
        {
            return Item_Data.Carrega_Item(IDPersonagem);
        }
    }
}
