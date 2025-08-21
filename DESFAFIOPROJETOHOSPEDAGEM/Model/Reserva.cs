using System;
using System.Collections.Generic;

namespace DESFAFIOPROJETOHOSPEDAGEM.Model
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite == null)
                throw new Exception("Suite não cadastrada.");

            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Capacidade insuficiente para o número de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeDeHospedes()
        {
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDaDiaria()
        {
            if (Suite == null)
                throw new Exception("Suite não cadastrada.");

            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados > 10)
            {
                valor *= 0.9m; // Desconto de 10%
            }

            return valor;
        }
    }
}
