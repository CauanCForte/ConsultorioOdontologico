using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontologico
{
    public static class Mensagens
    {
        public static void CPFFormato()
        {
            Console.WriteLine("Erro: O CPF deve estar de acordo com a validação oficial!");
            Console.Write("CPF: ");
        }

        public static void CPFRepetido()
        {
            Console.WriteLine("Erro: CPF já cadastrado!");
            Console.Write("CPF: ");
        }

        public static void NomeFormato()
        { 
            Console.WriteLine("Erro: O Nome deve ter ao menos 5 caracteres!");
            Console.Write("Nome: ");
        }
        
        public static void Idade()
        { 
            Console.WriteLine("Erro: O paciente deve ter pelo menos 13 anos!");
            Console.Write("Data: ");
        }

        public static void PacienteNaoCadastrado()
        {
            Console.WriteLine("Erro: Paciente não cadastrado!");
            Console.Write("CPF: ");
        }

        public static void DataFormato()
        {
            Console.WriteLine("Erro: A data deve ser inserida no formato DDMMAAAA!");
            Console.Write("Data: ");
        }

        public static void AgendamentoInexistente()
        {
            Console.WriteLine("Erro: Agendamento não encontrado!");
            Console.Write("CPF: ");
        }

        public static void AgendamentoFuturo() 
        {
            Console.WriteLine("Erro: O agendamento não pode ser feito para um momento que já passou!");
            Console.Write("Data: ");
        }

        public static void AgendamentoExcesso()
        {
            Console.WriteLine("Erro: O paciente já tem uma consulta agendada!");
            Console.Write("CPF: ");
        }

        public static void HoraFormato()
        { 
            Console.WriteLine("Erro: Hora inicial e final devem ser fornecidos no formato HHMM (padrão brasileiro)!");
            Console.Write("Hora: ");
        }

        public static void HoraDisponivel()
        {
            Console.WriteLine("Erro: Um agendamento deve ser feito no entre 08:00h e 19:00h!");
            Console.Write("Hora: ");
        }

        public static void Hora15()
        {
            Console.WriteLine("Erro: As consultas ocorrem em múltiplos de 15 minutos. Marque um horário com o final 00, 15, 30 ou 45!");
            Console.Write("Hora: ");
        }

        public static void HoraFinal() 
        { 
            Console.WriteLine("Erro: Hora final deve ser depois da inicial!");
            Console.Write("Hora Final: ");
        }

        public static void HoraSobreposta() 
        { 
            Console.WriteLine("Erro: Já existe uma consulta agendada nesse horário!");
            Console.Write("Hora: ");
        }

        public static void PacienteAgendado() 
        { 
            Console.WriteLine("Erro: Este paciente tem uma consulta agendada! Cancele o agendamento antes de excluir o paciente!");
            Console.Write("CPF: ");
        }

        public static void AgendamentoPassado()
        { 
            Console.WriteLine("Erro: Não possível cancelar o agendamento de uma consulta que já aconteceu ou está acontecendo!");
            Console.Write("Hora: ");
        }

        public static void PacienteCadastrado()
        {
            Console.WriteLine("Paciente cadastrado com sucesso!");
        }

        public static void PacienteExcluido() 
        {
            Console.WriteLine("Paciente excluído com sucesso!");
        }

        public static void AgendamentoRealizado()
        {
            Console.WriteLine("Agendamento realizado com sucesso!");
        }

        public static void AgendamentoCancelado() 
        {
            Console.WriteLine("Agendamento cancelado com sucesso!");
        }
        public static void ExibirMenuPrincipal() 
        {
            Console.WriteLine("Menu Principal");
            Console.WriteLine("1-Cadastro Paciente");
            Console.WriteLine("2-Agenda");
            Console.WriteLine("3-Fim");
        }

        public static void ExibirMenuCadastro() 
        {
            Console.WriteLine("Menu do Cadastro de Pacientes");
            Console.WriteLine("1-Cadastrar novo paciente");
            Console.WriteLine("2-Excluir paciente");
            Console.WriteLine("3-Listar pacientes (ordenado por CPF)");
            Console.WriteLine("4-Listar pacientes (ordenado por nome)");
            Console.WriteLine("5-Voltar p/ menu principal");
        }

        public static void CadastroVazio() 
        {
            Console.WriteLine("O Cadastro está vazio!");
        }

        public static void ExibirMenuAgenda() 
        {
            Console.WriteLine("Agenda");
            Console.WriteLine("1-Agendar consulta");
            Console.WriteLine("2-Cancelar agendamento");
            Console.WriteLine("3-Listar agenda");
            Console.WriteLine("4-Voltar p/ menu principal");
        }

        public static void NaoExibirMenuAgenda() 
        {
            Console.WriteLine("O Cadastro não possui pacientes, não é possível usar a Agenda!");
        }

        public static void AgendaVazia() 
        {
            Console.WriteLine("A Agenda está vazia!");
        }
    }
}
