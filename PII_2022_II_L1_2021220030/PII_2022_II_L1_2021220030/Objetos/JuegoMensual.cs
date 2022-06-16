using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PII_2022_II_L1_2021220030
{
    internal class JuegoMensual
    {
        public string[] Personas = new string[100];// { get; set; }
        
        public JuegoMensual()
        {
            
        }

        public string getGanador(int index)
        {
            if (string.IsNullOrEmpty( Personas[index]))
            {
                return "No hay ganador";
            }
            return Personas[index];
        }
    }
}
