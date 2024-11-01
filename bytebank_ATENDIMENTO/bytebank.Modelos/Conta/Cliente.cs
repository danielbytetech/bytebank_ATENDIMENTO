﻿using System;

namespace bytebank.Modelos.Conta
{
    public class Cliente
    {

        public string Cpf { get; set; }

        private string _nome;
        public string Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                if (value.Length < 3)
                {
                    Console.WriteLine("Nome do titular precisa ter pelo menos 3 caracteres.");
                }

                // Passar o valor para a propriedade privada, para ser exibido no get 
                _nome = value;
            }

        }
        //public string Nome { get; set; }
        public string Profissao { get; set; }

        public static int TotalClientesCadastrados { get; set; }

        public Cliente()
        {
            TotalClientesCadastrados = TotalClientesCadastrados + 1;
        }
    }
}