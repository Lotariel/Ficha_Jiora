using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_Jiora.Control
{
    internal class Rolar_Dados
    {
        private Random dado = new Random();
        public int D100()
        {
            return dado.Next(1, 101);
        }
    }
}
