﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsultorioOdontologico
{
    public class Paciente : IComparable
    {
        private string cpf;
        private string nome;
        private DateTime dataNascimento;
        private int idade;
        private Consulta agendamentoFuturo;

        public string Cpf 
        { 
            get { return cpf; }
            set
            {
                if (value.ValidarCpf())
                {
                    cpf = value;
                    ValidarPaciente.NaListaP(this);
                }
                else
                {
                    Cpf = Console.ReadLine();
                }
            }
        }

        public string Nome
        {
            get { return nome; }
            set
            {
                if (value.ValidarNome())
                {
                    nome = value;
                }
                else 
                {
                    Nome = Console.ReadLine();
                }
            }
        }

        public string DataNascimento
        {
            get { return dataNascimento.ToString("d"); }
            set
            {
                if (value.ValidarDataP())
                {
                    DateTime dataDT = DateTime.Parse(value);
                    dataNascimento = dataDT;
                    TimeSpan i = DateTime.Now - dataNascimento;
                    idade = ((int)i.TotalDays) / 365;
                }
                else
                {
                    DataNascimento = Console.ReadLine();
                }
            }
        }

        public int Idade
        {
            get { return idade; }
        }


        public Consulta AgendamentoFuturo
        {
            get { return agendamentoFuturo; }
            set 
            {
                if (agendamentoFuturo == null)
                {
                    agendamentoFuturo = value;
                }
            }
        }

        public void AnularAgendamento ()
        {
            agendamentoFuturo = null;
        }

        public override bool Equals(object obj) 
        {
            if (obj is Paciente p)
            {
                return p.Cpf == Cpf;
            }
            return false;
        }

        public int CompareTo(object obj)
        {
            Paciente p = (Paciente)obj;
            return Nome.CompareTo(p.Nome);
        }
    }
}