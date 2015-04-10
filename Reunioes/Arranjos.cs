using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reunioes
{
    public class Arranjos
    {
        public class Irmao
        {
            string nome;
            public string Nome
            {
                get { return nome; }
                set { nome = value; }
            }

            bool somP;//palc o
            public bool SomP
            {
                get { return somP; }
                set { somP = value; }
            }

            bool somM;//assistencia
            public bool SomM
            {
                get { return somM; }
                set { somM = value; }
            }

            bool somC;//equipamento(casinha)
            public bool SomC
            {
                get { return somC; }
                set { somC = value; }
            }

            bool indicador;
            public bool Indicador
            {
                get { return indicador; }
                set { indicador = value; }
            }

            public Irmao(string nome, bool palco, bool mic, bool casinha, bool indicador)
            {
                this.nome = nome;
                this.somP = palco;
                this.somM = mic;
                this.somC = casinha;
                this.indicador = indicador;
            }
        }
        public class Reunioes
        {
            DateTime dia;

            public DateTime Dia
            {
                get { return dia; }
                set { dia = value; }
            }
            string descricao;//pode ser o nome também

            public string Descricao
            {
                get { return descricao; }
                set { descricao = value; }
            }
            Irmao palco;

            public Irmao Palco
            {
                get { return palco; }
                set { palco = value; }
            }
            Irmao volante;

            public Irmao Volante
            {
                get { return volante; }
                set { volante = value; }
            }
            Irmao equipamento;

            public Irmao Equipamento
            {
                get { return equipamento; }
                set { equipamento = value; }
            }
            Irmao[] indicadores = new Irmao[3];
            
            public Irmao[] Indicadores
            {
                get { return indicadores; }
                set { indicadores = value; }
            }

            public Reunioes(Irmao palco,
            Irmao volante,
            Irmao equipamento,
            Irmao[] indicadores)
            {
                this.dia = DateTime.Today;
                this.descricao = null;
                this.palco = palco;
                this.volante =volante;
                this.equipamento = equipamento;
                this.indicadores = indicadores;
            }

            public Reunioes()
            {
                //devemor ir preenchendo os parametros que faltam
                
            }

            public bool estaNoSom(string nome)
            {
                if (palco == null && volante == null && equipamento == null)
                    return false;
                else if (palco.Nome == nome || volante.Nome == nome || equipamento.Nome == nome)
                    return true;
                else
                    return false;                
            }

            public bool estaDeIndicador(string nome)
            {
                if (indicadores[0] == null && indicadores[1] == null && indicadores[1] == null)
                    return false;
                if (indicadores[0].Nome == nome || indicadores[1].Nome == nome || indicadores[1].Nome == nome)
                    return true;
                else
                    return false;
            }
            public bool temQualquerDesignacao(string nome)
            {
                if(estaDeIndicador(nome)||estaNoSom(nome))
                    return true;
                else
                    return false;
            }
        }

        public static List<Reunioes> ListaReunioes()
        {
            List<Irmao> listaIrmaos = new List<Irmao>();
            List<Reunioes> mesReunões = new List<Reunioes>();
            listaIrmaos.Add(new Irmao("Tiago", true, true, true,true));
            listaIrmaos.Add(new Irmao("Airton", true, true, true,true));
            listaIrmaos.Add(new Irmao("Andre",true,true,true,true));
            listaIrmaos.Add(new Irmao("Washington", true, true, true, true));
            listaIrmaos.Add(new Irmao("Jose Paulo",true,true,false,true));

            if (mesReunões.Count().Equals(0))
            {
                //Irmao palco = null;
                //Irmao volante = null;
                //Irmao equipamento = null;
                //Irmao[] indicadores = null;
                int indice = 0;

                Reunioes novaReuniao = new Reunioes();

                //for (int x=0; x < 6; x++)
                //{
                    while (novaReuniao.Palco == null)
                    {
                        if (indice == listaIrmaos.Count)
                            indice = 0;
                        if (listaIrmaos[indice].SomP)
                        {
                            novaReuniao.Palco = listaIrmaos[indice];
                        }
                        else
                        {
                            indice++;
                        }
                    }
                    indice = 0;
                    while (novaReuniao.Volante == null)
                    {
                        if (indice == listaIrmaos.Count)
                            indice = 0;
                        if (listaIrmaos[indice].SomM && !novaReuniao.temQualquerDesignacao(listaIrmaos[indice].Nome))
                        {
                            novaReuniao.Volante = listaIrmaos[indice];
                        }
                        else
                        {
                            indice++;
                        }
                    }

                    indice = 0;
                    while (novaReuniao.Equipamento == null)
                    {
                        if (indice == listaIrmaos.Count)
                            indice = 0;
                        if (listaIrmaos[indice].SomC && !novaReuniao.temQualquerDesignacao(listaIrmaos[indice].Nome))
                        {
                            novaReuniao.Equipamento = listaIrmaos[indice];
                        }
                        else
                        {
                            indice++;
                        }
                    }
                    indice = 0;

                    for (int contador = 0; contador < novaReuniao.Indicadores.Length; contador++)
                    {
                        while (novaReuniao.Indicadores[contador] == null)
                        {
                            if (indice == listaIrmaos.Count)
                                indice = 0;
                            if (listaIrmaos[indice].Indicador && !novaReuniao.temQualquerDesignacao(listaIrmaos[indice].Nome))
                            {
                                novaReuniao.Indicadores[contador] = listaIrmaos[indice];
                            }
                            else
                            {
                                indice++;
                            }
                        }

                    }

                    
                //}



                

                //Reunioes nova = new Reunioes(palco, volante, equipamento, indicadores);
            }

            return mesReunões;
        }
    }
}
