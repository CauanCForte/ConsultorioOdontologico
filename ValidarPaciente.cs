﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ConsultorioOdontologico
{
    public static class ValidarPaciente
    {
        public static bool ValidarCpf(this string cpf)
        {
            if (cpf.Length != 11)
            {
                Mensagens.CPFFormato();
                return false;
            }
            // Verifica se todos os dígitos são iguais
            if (new string(cpf[0], cpf.Length) == cpf)
            {
                Mensagens.CPFFormato();
                return false;
            }
            
            // Calcula o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += (cpf[i] - '0') * (10 - i);
            }

            int primeiroDigitoVerificador = soma % 11;
            if (primeiroDigitoVerificador < 2)
            {
                primeiroDigitoVerificador = 0;
            }
            else
            {
                primeiroDigitoVerificador = 11 - primeiroDigitoVerificador;
            }
            // Verifica o primeiro dígito
            if (cpf[9] - '0' != primeiroDigitoVerificador)
            {
                Mensagens.CPFFormato();
                return false;
            }
            // Calcula o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += (cpf[i] - '0') * (11 - i);
            }

            int segundoDigitoVerificador = soma % 11;
            if (segundoDigitoVerificador < 2)
            {
                segundoDigitoVerificador = 0;
            }
            else
            {
                segundoDigitoVerificador = 11 - segundoDigitoVerificador;
            }
            // Verifica o segundo dígito
            if (cpf[10] - '0' != segundoDigitoVerificador)
            {
                Mensagens.CPFFormato();
                return false;
            }
            // Verifica se o cpf já não existe no sistema

            return true;
        }

        public static bool ValidarNome(this string nome) 
        {
            if (nome.Length < 5)
            {
                Mensagens.NomeFormato();
                return false;
            }
            return true;
        }

        public static bool ValidarDataP(this string data) 
        {

            if(!(DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))) 
            {
                Mensagens.DataFormato();
                return false; 
            }

            DateTime dataDT = DateTime.Parse(data);
            TimeSpan trezeAnos = TimeSpan.FromDays(13 * 365);

            if((DateTime.Now - dataDT) < trezeAnos) 
            {
                Mensagens.Idade();
                return false;
            }
            return true;
        }

        public static bool ValidarAgendamentoFuturo(this string cpf)
        {
            int i = Lista.Cadastro.FindIndex(p => p.Cpf == cpf);
            if (Lista.Cadastro[i].AgendamentoFuturo != null)
            {
                Mensagens.AgendamentoExcesso();
                return false;
            }

            return true;
        }

        public static void NaListaP(Paciente p) 
        {
            if (Lista.Cadastro.Contains(p)) 
            {
                Mensagens.CPFRepetido();
                p.Cpf = Console.ReadLine();
            }
        }
    }
}
