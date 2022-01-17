using System;

namespace ByteBank.Modelos
{
    /// <summary>
    /// Define uma Conta Corrente do banco ByteBank.
    /// </summary>
    public class ContaCorrente
    {
        public static double TaxaOperacao { get; private set; }
        public Cliente Titular { get; set; }

        public int ContadorSaquesNaoPermitidos { get; private set; }

        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public static int TotalDeContasCriadas { get; private set; }
        public int Agencia { get; }
        public int Numero { get; }

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        /// <summary>
        /// Cria uma instancia de ContaCorrente com os argumentos utilizados.
        /// </summary>
        /// <param name="agencia"> Representa o valor da propriedade <see cref="Agencia"/> e deve possuir um valor maior que zero. </param>
        /// <param name="numero"> Representa o valor da propriedade <see cref="Numero"/> e deve possuir um valor maior que zero. </param>
        /// <exception cref="ArgumentException"></exception>
        public ContaCorrente(int agencia, int numero)
        {
            if (agencia <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }
             
            if (numero <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        /// <summary>
        /// Realiza o saque e atualiza o <paramref name="valor"/> da propriedade <see cref="Saldo"/>.
        /// </summary>
        /// <param name="valor"> Representa o valor do saque, deve ser maior que 0, e menor do que o <see cref="Saldo"/>. </param>
        /// <exception cref="ArgumentException"> Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/>. </exception>
        /// <exception cref="SaldoInsuficienteException"> Exceção lançada quando o argumento <paramref name="valor"/> é maior do que o a propriedade <see cref="Saldo"/>. </exception>
        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor invalido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;

                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
        }

        /// <summary>
        /// Realiza o deposito do <paramref name="valor"/> a propriedade <see cref="Saldo"/>.
        /// </summary>
        /// <param name="valor"> Representa o valor que sera depositado a propriedade <see cref="Saldo"/> </param>
        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor invalido para a transferencia.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException e)
            {
                ContadorTransferenciasNaoPermitidas++;

                throw new OperacaoFinanceiraException("Operacão não realizada", e);
            }
            contaDestino.Depositar(valor);
        }
    }
}
