using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PII_2022_II_L1_2021220030.Objetos
{
    internal class JuegoSemanal
    {
        public string Persona { get; }
        public int NumeroColumn1 { get; set; }
        public int NumeroColumn2 { get; set; }
        public int Dinero { get; private set; }

        public int Cont = 0;

        public JuegoSemanal(string persona, int numeroColumn1, int numeroColumn2)
        {
            this.Persona = persona;
            this.NumeroColumn1 = numeroColumn1;
            this.NumeroColumn2 = numeroColumn2;
        }

        private void setDinero(int numero1, int numero2)
        {
            if (this.NumeroColumn1 == numero1)
            {
                Dinero = 10000;
            }else if(this.NumeroColumn2 == numero2)
            {
                Dinero = 1000;
            }

            if(this.NumeroColumn1 == numero1 && this.NumeroColumn2 == numero2)
            {
                Dinero = 100000;
            }
        }

        public string getGanador(int numero1, int numero2)
        {            
            setDinero(numero1, numero2);
            if (Dinero == 0)
            {
                return null;
            }
            return $"Nombre: {this.Persona}, Cantidad: L.{this.Dinero}";
        }

    }
}
