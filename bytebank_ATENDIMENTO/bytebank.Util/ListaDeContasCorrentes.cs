using bytebank.Modelos.Conta;
using System;

namespace bytebank_ATENDIMENTO.bytebank.Util
{
    public class ListaDeContasCorrentes
    {
        private ContaCorrente[] _itens = null;
        private int _proximoPosicao = 0;

        // Caso nada seja passado para o argumento, o valor padrão sera de 5 como limite de uma array
        public ListaDeContasCorrentes(int tamanhoInicial = 5)
        {
            _itens = new ContaCorrente[tamanhoInicial];
        }

        public void Adicionar(ContaCorrente item)
        {
            Console.WriteLine($"Adicionando item na posição {_proximoPosicao}");
            VerificarCapacidade(_proximoPosicao + 1);
            _itens[_proximoPosicao] = item;
            _proximoPosicao++;
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            // Verifica se a capacidade é maior ou igual ao tamanho definido, se for o metodo continua a rodar
            if(_itens.Length >= tamanhoNecessario)
            {
                return;
            }
            // se não o metodo roda e aumenta a capacidade da array
            else
            {
                Console.WriteLine("Aumentando a capacidade da lista!");
                ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];

                for(int i = 0; i < _itens.Length; i++)
                {
                    novoArray[i] = _itens[i];
                }

                _itens = novoArray;
            }
        }

        public void Remover(ContaCorrente conta)
        {
            // tem função de pegar o valor anteiror pois no laço ele começa contando do 1
            int indiceItem = -1;
            // Esse for vai pegar o indice e vai atribuir no indiceItem
            for (int i = 0; i < _proximoPosicao; i++)
            {
                ContaCorrente contaAtual = _itens[i];
                if (contaAtual == conta)
                {
                    indiceItem = i;
                    break;
                }
            }
            // 0            1         2
            //[Conta1]  [Conta2]  [Conta4]  [Conta5] [null]
            // Esse laço 
            for(int i = indiceItem; i < _proximoPosicao - 1; i++)
            {
                _itens[i] = _itens[i + 1];
            }
            _proximoPosicao--;
            _itens[_proximoPosicao] = null;
        }

        public void ExibirLista()
        {
            for (int i = 0; i < _itens.Length; i++)
            {
                if(_itens[i] != null)
                {
                    var conta = _itens[i];
                    Console.WriteLine($"Indice[{i}] = " +
                        $"Conta: {conta.Conta} - " +
                        $"Nº da Agencia: {conta.Numero_agencia}");
                }
            }
        }

        public ContaCorrente RecuperarContaNoIndice(int indice)
        {
            if(indice < 0 || indice >= _proximoPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        public int Tamanho
        {
            get
            {
                return _proximoPosicao;
            }
        }

        // Indexador serve para manipular elementos de uma array dentro de uma classe, como se a classe fosse uma array
        public ContaCorrente this[int indice]
        {
            get
            {
                return RecuperarContaNoIndice(indice);
            }
        }

        public ContaCorrente MaiorSaldo()
        {
            // Significa que ainda não foi encontrado nenhuma conta
            ContaCorrente conta = null;
            
            // Armazena o maior valor do Saldo
            double maiorValor = 0;

            // Laço para percorrer e verificar qual conta é a que tem mais saldo
            for (int i = 0; i < _itens.Length; i++)
            {
                // Verfica se a conta não é null
                if(_itens[i] != null)
                {
                    // se o saldo for maior que a variavel que armazena o maior valor, registra o novo valor na varivel
                    if (maiorValor < _itens[i].Saldo)
                    {
                        // Saldo é armazenado na variavel e a conta é atualizada para referenciar essa conta
                        maiorValor = _itens[i].Saldo;
                        conta = _itens[i];
                    }
                }
            }

            return conta;
        }
    }
}
