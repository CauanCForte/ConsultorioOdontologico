using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontologico
{
    public class Menu
    {
        public static void MenuPrincipal()
        {
            Mensagens.ExibirMenuPrincipal();

            int selectorMP = int.Parse(Console.ReadLine());
            switch (selectorMP)
            {
                case 1:
                {
                    MenuCadastro();
                    break;
                }
                case 2:
                {
                    MenuAgenda();
                    break;
                }
                case 3:
                {
                    return;
                }
            }
        }

        public static void MenuCadastro()
        {
            Mensagens.ExibirMenuCadastro();

            int selectorMC = int.Parse(Console.ReadLine());
            switch (selectorMC)
            {
                case 1:
                {
                    CadastrarPaciente();
                    MenuPrincipal();
                    break;
                }

                case 2:
                {
                    Console.Write("CPF: ");
                    Lista.ExcluirPaciente(Console.ReadLine());
                    MenuPrincipal();
                    break;
                }

                case 3:
                {
                    ListarPacientesCPF();
                    MenuPrincipal();
                    break;
                }

                case 4:
                {
                    ListarPacientesNome();
                    MenuPrincipal();
                    break;
                }

                case 5:
                {
                    MenuPrincipal();
                    break;
                }
            }
        }

        public static void MenuAgenda()
        {
            Mensagens.ExibirMenuAgenda();
            int selectorMA = int.Parse(Console.ReadLine());
            switch (selectorMA)
            {
                case 1:
                {
                    AgendarConsulta();
                    MenuPrincipal();
                    break;
                }
                case 2:
                {
                    int k = 0;
                    while (k == 0)
                    {
                        Console.Write("CPF: ");
                        string cpf = Console.ReadLine();
                        if (cpf.ValidarCpfRepetido())
                        {
                            Console.Write("Data: ");
                            string data = Console.ReadLine();
                            Console.Write("Hora Incial: ");
                            string hora = Console.ReadLine();
                            if (data.ValidarAgendamentoRepetido(hora))
                            {
                                Lista.CancelarAgendamento(cpf, data, hora);
                                k = 1;
                            }
                        }
                    }
                    MenuPrincipal();
                    break;
                }
                case 3:
                {
                    ListarConsultas();
                    MenuPrincipal();
                    break;
                }
                case 4:
                {
                    MenuPrincipal();
                    break;
                }
            }
        }

        public static void CadastrarPaciente() 
        {
            Paciente p = new Paciente();
            Console.Write("CPF: ");
            p.Cpf = Console.ReadLine();
            Console.Write("Nome: ");
            p.Nome = Console.ReadLine();
            Console.Write("Data de Nascimento: ");
            p.DataNascimento = Console.ReadLine();
            p.PacienteCadastrado();
            Lista.Cadastro.Add(p);
            Lista.CadastroOrdenadoCPF = false;
            Lista.CadastroOrdenadoNome = false;
        }

        public static void AgendarConsulta() 
        {
            Consulta c = new Consulta();
            Console.Write("CPF: ");
            c.CpfPaciente = Console.ReadLine();
            Console.Write("Data da consulta: ");
            c.Data = Console.ReadLine();
            Console.Write("Hora inicial: ");
            c.HoraInicial = Console.ReadLine();
            Console.Write("Hora final: ");
            c.HoraFinal = Console.ReadLine();
            c.AgendamentoRealizado();
            Lista.Agenda.Add(c);
            Lista.AgendaOrdenada = false;
        }

        public static void ListarPacientesCPF()
        {
            if (Lista.CadastroOrdenadoCPF == false)
            {
                Lista.Cadastro.Sort((p1, p2) => p1.Cpf.CompareTo(p2.Cpf));
                Lista.CadastroOrdenadoCPF = true;
            }

            string maiorNome = Lista.Cadastro[0].Nome;
            for (int i = 0; i < Lista.Cadastro.Count; i++)
            {
                if (Lista.Cadastro[i].Nome.Length > maiorNome.Length)
                {
                    maiorNome = Lista.Cadastro[i].Nome;
                }
            }

            string espacoNome = new string(' ', maiorNome.Length - 4);
            string tracoNome = new string('-', maiorNome.Length);
            Console.WriteLine("------------" + tracoNome + "-----------------");
            Console.WriteLine("CPF         Nome" + espacoNome + " Dt. Nasc. Idade");
            Console.WriteLine("------------" + tracoNome + "-----------------");
            foreach (Paciente p in Lista.Cadastro)
            {
                Console.WriteLine(p.Cpf + " " + p.Nome + " " + p.DataNascimento + "   " + p.Idade);
                if (p.AgendamentoFuturo != null)
                {
                    Console.WriteLine("            Agendado para: " + p.AgendamentoFuturo.Data);
                    Console.WriteLine("            " + p.AgendamentoFuturo.HoraInicial + "às" + p.AgendamentoFuturo.HoraFinal);
                }
            }
            Console.WriteLine("------------" + tracoNome + "-----------------");
        }

        public static void ListarPacientesNome()
        {
            if (Lista.CadastroOrdenadoNome == false)
            {
                Lista.Cadastro.Sort();
                Lista.CadastroOrdenadoNome = true;
            }

            string maiorNome = Lista.Cadastro[0].Nome;
            for (int i = 0; i < Lista.Cadastro.Count; i++)
            {
                if (Lista.Cadastro[i].Nome.Length > maiorNome.Length)
                {
                    maiorNome = Lista.Cadastro[i].Nome;
                }
            }

            string espacoNome = new string(' ', maiorNome.Length - 4);
            string tracoNome = new string('-', maiorNome.Length);
            Console.WriteLine("------------" + tracoNome + "-----------------");
            Console.WriteLine("CPF         Nome" + espacoNome + " Dt. Nasc. Idade");
            Console.WriteLine("------------" + tracoNome + "-----------------");
            foreach (Paciente p in Lista.Cadastro)
            {
                Console.WriteLine(p.Cpf + " " + p.Nome + " " + p.DataNascimento + "   " + p.Idade);
                if (p.AgendamentoFuturo != null)
                {
                    Console.WriteLine("            Agendado para: " + p.AgendamentoFuturo.Data);
                    Console.WriteLine("            " + p.AgendamentoFuturo.HoraInicial + " " + "às" + " " + p.AgendamentoFuturo.HoraFinal);
                }
            }
            Console.WriteLine("------------" + tracoNome + "-----------------");
        }


        public static void ListarConsultas()
        {
            if (Lista.AgendaOrdenada == false)
            {
                Lista.Agenda.Sort();
                Lista.AgendaOrdenada = true;
            }

            string maiorNome = Lista.Agenda[0].PacienteMarcado.Nome;
            for (int i = 0; i < Lista.Agenda.Count; i++)
            {
                if (Lista.Agenda[i].PacienteMarcado.Nome.Length > maiorNome.Length)
                {
                    maiorNome = Lista.Agenda[i].PacienteMarcado.Nome;
                }
            }

            string espacoNome = new string(' ', maiorNome.Length - 4);
            string tracoNome = new string('-', maiorNome.Length);
            Console.WriteLine("-----------------------------" + tracoNome + "-----------");
            Console.WriteLine("   Data    H.Ini H.Fim Tempo Nome" + espacoNome + " Dt.Nasc. ");
            Console.WriteLine("-----------------------------" + tracoNome + "-----------");
            string dataReferencia = "01/01/0001";
            foreach (Consulta c in Lista.Agenda)
            {
                if (c.Data == dataReferencia)
                {
                    Console.WriteLine("          " + " " + c.HoraInicial + " " + c.HoraFinal + " " + c.Tempo + " "
                        + c.PacienteMarcado.Nome + " " + c.PacienteMarcado.DataNascimento);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(c.Data + " " + c.HoraInicial + " " + c.HoraFinal + " " + c.Tempo + " "
                        + c.PacienteMarcado.Nome + " " + c.PacienteMarcado.DataNascimento);
                    Console.WriteLine();
                    dataReferencia = c.Data;
                }
            }
            Console.WriteLine("-----------------------------" + tracoNome + "-----------");
        }
    }
}
