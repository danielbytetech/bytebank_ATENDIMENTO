using System;

namespace bytebank.Modelos.Conta
{
    
    /* IComparable foi utilizado para Implementar um metodo que possibilita comparar e retornar inteiros
	 * foi necessario para usar no metodo Sort no metodo Ordenar que esta no Program.cs
	 */
    public class ContaCorrente : IComparable<ContaCorrente>
    {
        private int _numero_agencia;

        private string _conta;

        private double saldo;

        public Cliente Titular { get; set; }

        public string Nome_Agencia { get; set; }

        public int Numero_agencia
        {
            get
            {
                return _numero_agencia;
            }
            set
            {
                if (value > 0)
                {
                    _numero_agencia = value;
                }
            }
        }

        public string Conta
        {
            get
            {
                return _conta;
            }
            set
            {
                if (value != null)
                {
                    _conta = value;
                }
            }
        }

        public double Saldo
        {
            get
            {
                return saldo;
            }
            set
            {
                if (!(value < 0.0))
                {
                    saldo = value;
                }
            }
        }

        public static int TotalDeContasCriadas { get; set; }

        public bool Sacar(double valor)
        {
            if (saldo < valor)
            {
                return false;
            }
            if (valor < 0.0)
            {
                return false;
            }
            saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            if (!(valor < 0.0))
            {
                saldo += valor;
            }
        }

        public bool Transferir(double valor, ContaCorrente destino)
        {
            if (saldo < valor)
            {
                return false;
            }
            if (valor < 0.0)
            {
                return false;
            }
            saldo -= valor;
            destino.saldo += valor;
            return true;
        }

        public ContaCorrente(int numero_agencia, string conta)
        {
            Numero_agencia = numero_agencia;
            Conta = conta;
            Titular = new Cliente();
            TotalDeContasCriadas += 1;
        }

        public ContaCorrente(int numero_agencia)
        {
            Numero_agencia = numero_agencia;
            Conta = Guid.NewGuid().ToString().Substring(0, 8); // O GUID é um identificador gerado por algoritmos, que tem itenção de ser unico no mundo e gera um sequencia alfanúmeica aleatória
            Titular = new Cliente();
            TotalDeContasCriadas += 1;
        }

        public override string ToString()
        {

            return $" === DADOS DA CONTA === \n" +
                   $"Número da Conta : {this.Conta} \n" +
                   $"Número da Agência : {this.Numero_agencia} \n" +
                   $"Titular da Conta: {this.Titular.Nome} \n" +
                   $"CPF do Titular  : {this.Titular.Cpf} \n" +
                   $"Profissão do Titular: { this.Titular.Profissao} \n" +
                   $">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> \n\n";
        }

        /*CompareTo foi o metodo implementado pelo IComparable e recebe como argumento outro Objeto da classe e retorna int
        Ordena da seguinte forma:

        - Se o CompareTo() retornar um valor menor que zero, significa que o primeiro objeto deve ficar antes do segundo na fila.

        - Se o CompareTo() retornar um valor maior que zero, significa que o primeiro objeto deve ficar depois do segundo na fila.

        - Se o CompareTo() retornar zero, significa que os objetos estão na mesma posição na fila.
        */
        public int CompareTo(ContaCorrente? outro)
        {
            if (outro == null)
            {
                return 1;
            }
            else
            {
                return this.Numero_agencia.CompareTo(outro.Numero_agencia);
            }
        }
    }

}