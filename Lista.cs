using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsultorioOdontologico
{
    public class Lista
    {
        private static List<Paciente> cadastro;
        private static List<Consulta> agenda;
        private static bool cadastroOrdenadoCPF;
        private static bool cadastroOrdenadoNome;
        private static bool agendaOrdenada;

        public Lista()
        {
            cadastro = new List<Paciente>();
            agenda = new List<Consulta>();
        }

        public static List<Paciente> Cadastro
        {
            get { return cadastro; }
        }

        public static List<Consulta> Agenda
        {
            get { return agenda; }
        }

        public static bool CadastroOrdenadoCPF 
        {
            get { return cadastroOrdenadoCPF; }
            set { cadastroOrdenadoCPF = value; }
        }

        public static bool CadastroOrdenadoNome
        {
            get { return cadastroOrdenadoNome;}
            set { cadastroOrdenadoNome = value;}
        }

        public static bool AgendaOrdenada 
        {
            get { return agendaOrdenada; }
            set { agendaOrdenada = value; }
        }

        public static void ExcluirPaciente(string cpf) 
        {
            int i = Cadastro.FindIndex(p => p.Cpf == cpf);
            Paciente p = Cadastro[i];
            if (p.AgendamentoFuturo == null)
            {
                Cadastro.Remove(p);
                foreach (Consulta c in Agenda)
                {
                    if (c.CpfPaciente == cpf)
                    {
                        Agenda.Remove(c);
                        Mensagens.PacienteExcluido();
                    }
                }
            }
            else 
            {
                Mensagens.PacienteAgendado();
            }
        }

        public static void CancelarAgendamento(string cpf, string data, string horaI)
        {
            int i = Agenda.FindIndex(c => c.Data == data && c.HoraInicial == horaI);

            if (data.ValidarDataFutura() && horaI.ValidarHoraFutura(data))
            {
                Agenda.Remove(Agenda[i]);
                int j = Cadastro.FindIndex(p => p.Cpf == cpf);
                Cadastro[j].AnularAgendamento();
                Mensagens.AgendamentoCancelado();
            }
            else
            {
                Mensagens.AgendamentoPassado();
            }
        }
    }
}
