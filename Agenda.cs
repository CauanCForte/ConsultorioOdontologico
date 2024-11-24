using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontologico
{
    public class Agenda
    {
        private static List<Consulta> lista;
        private static bool ordenada;

        public Agenda()
        {
            lista = new List<Consulta>();
        }

        public static List<Consulta> Lista
        {
            get { return lista; }
        }

        public static bool Ordenada
        {
            get { return ordenada; }
            set { ordenada = value; }
        }

        public static void CancelarAgendamento(string cpf, string data, string horaI)
        {
            int i = Lista.FindIndex(c => c.Data == data && c.HoraInicial == horaI);

            if (data.ValidarDataFutura() && horaI.ValidarHoraFutura(data))
            {
                Lista.Remove(Lista[i]);
                int j = Cadastro.Lista.FindIndex(p => p.Cpf == cpf);
                Cadastro.Lista[j].AnularAgendamento();
                Mensagens.AgendamentoCancelado();
            }
            else
            {
                Mensagens.AgendamentoPassado();
            }
        }
    }
}
}
