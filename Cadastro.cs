using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsultorioOdontologico
{
    public class Cadastro
    {
        private static List<Paciente> lista;
        private static bool ordenadoCPF;
        private static bool ordenadoNome;

        public Cadastro()
        {
            lista = new List<Paciente>();
        }

        public static List<Paciente> Lista
        {
            get { return lista; }
        }

        public static bool OrdenadoCPF 
        {
            get { return ordenadoCPF; }
            set { ordenadoCPF = value; }
        }

        public static bool OrdenadoNome
        {
            get { return ordenadoNome;}
            set { ordenadoNome = value;}
        }

        public static void ExcluirPaciente(string cpf)
        {
            int i = Lista.FindIndex(p => p.Cpf == cpf);
            Paciente p = Lista[i];
            if (p.AgendamentoFuturo == null)
            {
                Lista.Remove(p);
                foreach (Consulta c in Agenda.Lista)
                {
                    if (c.CpfPaciente == cpf)
                    {
                        Agenda.Lista.Remove(c);
                        Mensagens.PacienteExcluido();
                    }
                }
            }
            else
            {
                Mensagens.PacienteAgendado();
            }
        }
    }
}
