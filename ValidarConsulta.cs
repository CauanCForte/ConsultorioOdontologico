using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsultorioOdontologico
{
    public static class ValidarConsulta
    {
        public static bool ValidarDataC (this string data)
        {
            if (!(DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _)))
            {
                Mensagens.DataFormato();
                return false;
            }

            if (!data.ValidarDataFutura())
            {
                Mensagens.AgendamentoFuturo();
                return false;
            }
             
            return true;
        }

        public static bool ValidarDataFutura(this string data)
        {
            DateTime dataDT = DateTime.Parse(data);
            DateTime hoje = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

            if (hoje > dataDT)
            {
                return false;
            }
            return true;
        }

        public static bool ValidarHora(this string hora, string data) 
        {
            if (!DateTime.TryParseExact(hora, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                Mensagens.HoraFormato();
                return false;
            }

            string min = hora.Substring(3, 2);
            int intMin = int.Parse(min);

            if (intMin % 15 != 0)
            {
                Mensagens.Hora15();
                return false;
            }

            if (!hora.ValidarHoraFutura(data)) 
            {
                Mensagens.AgendamentoFuturo();
                return false;
            }

            return true;
        }

        public static bool ValidarHoraFutura(this string hora, string data) 
        {
            int min = int.Parse(hora.Substring(3, 2));

            DateTime dataDT = DateTime.Parse(data);
            DateTime hoje = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

            if (hoje == dataDT)
            {
                int h = int.Parse(hora.Substring(0, 2));

                DateTime dataHora = new DateTime(dataDT.Year, dataDT.Month, dataDT.Day, h, min, 0);
                if (dataHora <= DateTime.Now)
                {
                    return false;
                }
            }
            return true;

        }

        public static bool ValidarHoraInicial(this string hora, string data)
        {
            if (!ValidarHora(hora, data))
            {
                return false;
            }

            string aux = hora.Remove(2, 1);
            int intHoraCompleta = int.Parse(aux);

            if (intHoraCompleta < 0900 || intHoraCompleta > 1845) 
            {
                Mensagens.HoraDisponivel();                
                return false;
            }

            return true;
        }

        public static bool ValidarHoraFinal(this string horaF, string horaI, string data)
        {
            if (!ValidarHora(horaF, data))
            {
                return false;
            }

            string auxF = horaF.Remove(2, 1);
            string auxI = horaI.Remove(2, 1);

            if (int.Parse(auxF) <= int.Parse(auxI)) 
            {
                Mensagens.HoraFinal();
                return false;
            }

            if (int.Parse(auxF) < 0945 || int.Parse(auxF) > 1900)
            {
                Mensagens.HoraDisponivel();
                return false;
            }

            return true;
        }

        public static bool ValidarSobreposicao(this Consulta c) 
        {
            DateTime horaI = DateTime.Parse(c.HoraInicial);
            DateTime horaF = DateTime.Parse(c.HoraFinal);

            foreach (Consulta x in Lista.Agenda) 
            {
                DateTime horaIX = DateTime.Parse(x.HoraInicial);
                DateTime horaFX = DateTime.Parse(x.HoraFinal);

                if (horaIX < horaF && horaFX > horaI) 
                {
                    Mensagens.HoraSobreposta();
                    return false;
                }
            }
            return true;
        }

        public static bool ValidarPacienteExiste(this string cpf)
        {
            foreach (Paciente p in Lista.Cadastro)
            {
                if (p.Cpf == cpf)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ValidarAgendamentoExiste(this string data, string hora) 
        {
            foreach (Consulta c in Lista.Agenda) 
            {
                if (c.Data == data && c.HoraInicial == hora) 
                {
                    return true;
                }
            }
            return false;
        }
    }
}
