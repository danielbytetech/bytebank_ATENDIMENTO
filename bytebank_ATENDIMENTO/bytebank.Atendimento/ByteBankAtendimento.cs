using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bytebank_ATENDIMENTO.bytebank.Atendimento
{
// Implementada antes da classe, serve para desabilitar/habilitar o aviso sobre variveis que podem vir null 
// tem como fazer tambem clicando duas vezes na solução e modificando o nullable
#nullable disable
    class ByteBankAtendimento
    {
        private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>() {
           new ContaCorrente(95, "123456-Y") { Saldo = 100, Titular = new Cliente{ Cpf = "111111", Nome = "Henrique"} },
           new ContaCorrente(96, "951258-Z") { Saldo = 200, Titular = new Cliente{ Cpf = "222222", Nome = "Pedro"} },
           new ContaCorrente(94, "987321-X") { Saldo = 60, Titular = new Cliente{ Cpf = "333333", Nome = "Marisa" } },
        };
       
        public void AtendimentoAoCliente()
        {
            /*Cadastrar Contas
            Listas Contas
            Remover Contas
            Ordenar Contas
            Pesquisar Contas
            Sair do sistema*/
            try
            {
                char opcao = '0';
                while (opcao != '6')
                {
                    Console.Clear();
                    Console.WriteLine("===============================");
                    Console.WriteLine("===       Atendimento       ===");
                    Console.WriteLine("===1 - Cadastrar Conta      ===");
                    Console.WriteLine("===2 - Listar Contas        ===");
                    Console.WriteLine("===3 - Remover Conta        ===");
                    Console.WriteLine("===4 - Ordenar Contas       ===");
                    Console.WriteLine("===5 - Pesquisar Conta      ===");
                    Console.WriteLine("===6 - Sair do Sistema      ===");
                    Console.WriteLine("===============================");
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Digite a opção desejada: ");

                    try
                    {
                        opcao = Console.ReadLine()[0];
                    }
                    catch (Exception ex)
                    {

                        throw new ByteBankException(ex.Message);
                    }

                    switch (opcao)
                    {
                        case '1':
                            CadastrarConta();
                            break;
                        case '2':
                            ListarContas();
                            break;
                        case '3':
                            RemoverContas();
                            break;
                        case '4':
                            OrdenarContas();
                            break;
                        case '5':
                            PesquisarConta();
                            break;
                        case '6':
                            EncerrarAplicacao();
                            break;
                        default:
                            Console.WriteLine("Opcao não implementada.");
                            break;
                    }
                }
            }
            catch (ByteBankException ex)
            {

                Console.WriteLine($"{ex.Message}");
            }

        }

        #region Encerrando a Aplicação
        private void EncerrarAplicacao()
        {
            Console.WriteLine("... Encerrando a aplicação ...");
            Console.ReadKey();
        }
        #endregion

        #region Pesquisar Conta
        /*
         * 1- Para pesquisar a conta é necessario informa por qual tipo de dados quer consultar
         * 2- Obtenho a resposta e estruturo com a codição switch case
         * 3- Informe os dados do Número da Conta ou CPF e chamo o metodo que consulta
         * 4- Se ele conseguir retornar os dados, imprimi por meio do metodo ToString que foi sobescrito no Objeto Conta Corrente os dados da Conta
         * caso não, imprimi o não encontrado.
         */
        private void PesquisarConta()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("===     PESQUISAR CONTAS     ===");
            Console.WriteLine("================================");
            Console.WriteLine("\n\n");

            Console.Write("Deseja pesquisar por (1) NÚMERO DA CONTA ou (2) CPF DO TITULAR ou (3) Nº AGÊNCIA? ");
            int resposta = int.Parse(Console.ReadLine()!);

            switch (resposta)
            {
                case 1:
                    {
                        Console.Write("Informe o número da Conta: ");
                        string _numeroConta = Console.ReadLine()!;
                        Console.WriteLine();
                        ContaCorrente consultarConta = ConsultarPorNumeroConta(_numeroConta);
                        if (consultarConta != null)
                        {
                            Console.WriteLine(consultarConta.ToString());
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Numero da Conta não encontrado.");
                            Console.ReadKey();
                            break;
                        }

                    }
                case 2:
                    {
                        Console.Write("Informe o CPF do Titular: ");
                        string _cpf = Console.ReadLine()!;
                        Console.WriteLine();
                        ContaCorrente consultarCpf = ConsultarPorCpf(_cpf);
                        if (consultarCpf != null)
                        {
                            Console.WriteLine(consultarCpf.ToString());
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("CPF não encontrado.");
                            Console.ReadKey();
                            break;
                        }
                    }
                case 3:
                    {
                        Console.Write("Informe o Nº da Agência: ");
                        int _numeroAgencia = int.Parse(Console.ReadLine()!);
                        Console.WriteLine();
                        var contasPorAgencia = ConsultarAgencia(_numeroAgencia);
                        ExibirListaDeContas(contasPorAgencia);
                        Console.ReadKey();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Opção não implementada.");
                        Console.ReadKey();
                        break;
                    }
            }
        }

        private void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
        {
            if (contasPorAgencia == null)
            {
                Console.WriteLine("... A consulta não retornou dados ...");
            }
            else
            {
                foreach (var item in contasPorAgencia)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private List<ContaCorrente> ConsultarAgencia(int numeroAgencia)
        {
            // feito a consulta como é feito no SQL, parecido com o foreach 
            // from define a origem dos dados, o where para aplicação dos filtros e do select para a seleção dos dados
            var consulta = (
                from conta in _listaDeContas
                where conta.Numero_agencia == numeroAgencia
                select conta).ToList();

            return consulta;
        }

        private ContaCorrente ConsultarPorCpf(string cpf)
        {
            //ContaCorrente conta = null;
            //for(int i = 0; i < _listaDeContas.Count; i++)
            //{
            //    if (_listaDeContas[i].Titular.Cpf.Equals(cpf))
            //    {
            //        conta = _listaDeContas[i]; 
            //    }
            //}

            //return conta;
            return _listaDeContas.Where(c => c.Titular.Cpf == cpf).FirstOrDefault();
        }

        private ContaCorrente ConsultarPorNumeroConta(string numeroConta)
        {
            //ContaCorrente conta = null;
            //for (int i = 0; i < _listaDeContas.Count; i++)
            //{
            //    if (_listaDeContas[i].Conta.Equals(numeroConta))
            //    {
            //        conta = _listaDeContas[i];
            //    }
            //}

            //return conta;
            return _listaDeContas.Where(c => c.Conta == numeroConta).FirstOrDefault();
        }
        #endregion

        #region Ordenar Conta 
        private void OrdenarContas()
        {
            // Ordeno as listas com metodo Sort e logo informo ao usuario que foi executado com sucesso     
            _listaDeContas.Sort();
            Console.WriteLine("... Lista Ordenada ...");
            Console.ReadKey();
        }
        #endregion

        #region Remover Conta
        private void RemoverContas()
        {
            /* 1- Obtenho a informação do numero da conta
             * 2- instancio uma conta que receba null para usar caso eu encontre uma classe igual ao q foi digitado 
             * 3- Listo cada uma e verfico se existe 
             * 4- se existe eu remove da lista, se não, imprimo q nada foi encontrado
             */
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===      REMOVER CONTAS     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.Write("Informe o numero da conta: ");
            string numeroConta = Console.ReadLine()!;

            ContaCorrente conta = null;

            foreach (var item in _listaDeContas)
            {
                if (item.Conta.Equals(numeroConta))
                {
                    conta = item;
                }
            }

            if (conta != null)
            {
                _listaDeContas.Remove(conta);
                Console.WriteLine("... Conta removida da lista ...");
            }
            else
            {
                Console.WriteLine("... Conta para remoção não encontrada ...");
            }
            Console.ReadKey();
        }
        #endregion

        #region Listar Contas
        private void ListarContas()
        {
            /* 
             * 1- Faço uma verificão para ver se existe algum elemento na lista e caso n exista, imprimi na tela q n existe
             * 2- Listo cada elemento para exibir no Console
             */
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===     LISTA DE CONTAS     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            if (_listaDeContas.Count <= 0)
            {
                Console.WriteLine("... Não há contas cadastradas! ...");
                Console.ReadKey();
                return;
            }
            foreach (ContaCorrente item in _listaDeContas)
            {
                //Console.WriteLine("===  Dados da Conta  ===");
                //Console.WriteLine("Número da Conta: " + item.Conta);
                //Console.WriteLine("Saldo da Conta: " + item.Saldo);
                //Console.WriteLine("Titular da Conta: " + item.Titular.Nome);
                //Console.WriteLine("CPF do Titular: " + item.Titular.Cpf);
                //Console.WriteLine("Profissão do Titular: " + item.Titular.Profissao);
                //Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine(item.ToString());
                Console.ReadKey();
            }
        }
        #endregion

        #region Cadastrar Conta
        private void CadastrarConta()
        {
            /*
             * 1- Obtenho os dados do cliente por meio das variaveis e instancio o Objeto para continuar registrando outros informações do cliente
             * 2- Adicionando todas essas informações, adiciona a lista, imprimo que foi concluido o cadastro e retorno ao menu
             */
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===   CADASTRO DE CONTAS    ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.WriteLine("=== Informe dados da conta ===");

            Console.Write("Número da Agência: ");
            int numeroAgencia = int.Parse(Console.ReadLine()!);

            ContaCorrente conta = new ContaCorrente(numeroAgencia);

            Console.WriteLine($"Número da conta [NOVA] : {conta.Conta}");

            Console.Write("Informe o Saldo inicial: ");
            conta.Saldo = double.Parse(Console.ReadLine()!);

            Console.Write("Informe o Nome do Titular: ");
            conta.Titular.Nome = Console.ReadLine()!;

            Console.Write("Informe o CPF do Titular: ");
            conta.Titular.Cpf = Console.ReadLine()!;

            Console.Write("Informe Profissão do Titular: ");
            conta.Titular.Profissao = Console.ReadLine()!;

            _listaDeContas.Add(conta);
            Console.WriteLine("... Conta cadastrada com sucesso! ...");
            Console.ReadKey();
        }
        #endregion
    }
}
