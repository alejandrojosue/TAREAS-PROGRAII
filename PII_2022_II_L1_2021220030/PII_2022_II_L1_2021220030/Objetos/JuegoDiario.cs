using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PII_2022_II_L1_2021220030.Objetos
{
    internal class JuegoDiario
    {
        public string Persona { get; }
        public int[] Numeros { get; }
        public Decimal Dinero { get; private set; }

        public int Cont = 0;

        public JuegoDiario(string persona, int[] numeros) {
            this.Persona = persona;
            Numeros = numeros;
        }

        private void setDinero()
        {
            if (Cont == 3)
            {
                Dinero = 5000M;
            }
            else if (Cont == 4)
            {
                Dinero = 10000M;
            }
            else if (Cont == 5)
            {
                Dinero = 100000M;
            }
        }

        public string getGanador() {
            setDinero();
            if (Dinero == 0)
            {
                return null;
            }
            return $"Nombre: {this.Persona}, Cantidad: L.{this.Dinero}";
        }

    }
}
