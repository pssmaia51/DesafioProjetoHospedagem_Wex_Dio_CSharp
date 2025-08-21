# 🏨 Desafio Projeto Hospedagem

Este projeto foi desenvolvido em **C#** como parte de um desafio prático para consolidar os conceitos de **Programação Orientada a Objetos (POO)**.  

O objetivo é simular um **sistema de hospedagem de hotel**, incluindo **cadastro de hóspedes**, **suítes** e **reservas**.

---

## 📌 Estrutura do Projeto
DESAFIOPROJETOHOSPEDAGEM
│── Program.cs
│
├── Model
│   ├── Pessoa.cs
│   ├── Suite.cs
│   └── Reserva.cs

O projeto segue uma divisão em camadas simples, localizada dentro da pasta **Model**:
- **Program.cs** → Classe principal, responsável por executar e testar as funcionalidades.
- **Pessoa.cs** → Representa o hóspede.
- **Suite.cs** → Representa uma suíte do hotel.
- **Reserva.cs** → Responsável pelo gerenciamento das reservas.

---

## ⚙️ Funcionalidades

### 👤 Pessoa
- Armazena informações do hóspede:
  - **Nome**
  - **Sobrenome**
- Fornece uma propriedade para exibir o **nome completo**.

---

### 🛏️ Suite
- Representa uma suíte do hotel com os seguintes atributos:
  - **Tipo de suíte** (Ex.: Standard, Premium, Master).
  - **Capacidade** (quantidade máxima de hóspedes).
  - **Valor da diária**.

---

### 📅 Reserva
- Representa a reserva feita por um ou mais hóspedes.
- Funcionalidades principais:
  - **Cadastrar hóspedes** respeitando a capacidade da suíte.
  - **Calcular o valor total da hospedagem**:
    - Considera o número de dias da reserva.
    - Concede **10% de desconto** caso o período seja **igual ou superior a 10 dias**.
  - **Obter quantidade de hóspedes cadastrados**.

---

## 🖥️ Exemplo de Uso (Program.cs)

```csharp
using System;
using DESAFIOPROJETOHOSPEDAGEM.Model;

class Program
{
    static void Main()
    {
        // Criando hóspedes
        Pessoa p1 = new Pessoa(nome: "Paulo", sobrenome: "Maia");
        Pessoa p2 = new Pessoa(nome: "Maria", sobrenome: "Oliveira");

        // Criando suíte
        Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 150);

        // Criando reserva
        Reserva reserva = new Reserva(diasReservados: 12);
        reserva.CadastrarSuite(suite);
        reserva.CadastrarHospedes(new List<Pessoa> { p1, p2 });

        Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor Total: {reserva.CalcularValorDiaria()}");
    }
}
