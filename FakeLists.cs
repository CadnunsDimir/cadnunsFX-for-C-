using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxilarLib
{
    public class FakeLists
    {
        string nome;
        bool isIndicador;
        bool isSom;

        public FakeLists(string nome, bool som, bool indi)
        {
            this.nome = nome;
            this.isIndicador = indi;
            this.isSom = som;
        }

        public bool PodeTrabalharSom(){
            return isSom;
        }

        public bool PodeTrabalharIndicador()
        {
            return isIndicador;
        }

        public string NomePessoa()
        {
            return nome;
        }

        public class diaReunião
        {
            string[] somHoje;
            string[] indHoje;

            public diaReunião(String[] som, String[] indicador)
            {
                this.somHoje = som;
                this.indHoje = indicador;
            }

            public string[] imprimeSom()
            {
                return somHoje;
            }

            public string[] imprimeIndicador()
            {
                return indHoje;
            }
        }
    }
}
