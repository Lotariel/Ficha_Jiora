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

        public int D10()
        {
            return dado.Next(1, 11);
        }

        public int D12()
        {
            return dado.Next(1, 13);
        }

        public int D8()
        {
            return dado.Next(1, 9);
        }

        public int D6()
        {
            return dado.Next(1, 7);
        }
    }
}
