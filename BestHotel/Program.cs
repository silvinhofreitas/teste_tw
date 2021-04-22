using BestHotel.Domain;
using BestHotel.Services;
using System;

namespace BestHotel
{
  class Program
  {
    static void Main(string[] args)
    {
      (var ParqueDasFlores, var JardimBotanico, var MarAtlantico) = CreateHotels.Create();
      PriceCalculator calculator = new PriceCalculator(ParqueDasFlores,
                                                       JardimBotanico,
                                                       MarAtlantico);

      Client cliente1 = new Client(ClientType.Regular,
                                   new DateTime(2020, 3, 16),
                                   new DateTime(2020, 3, 17),
                                   new DateTime(2020, 3, 18));

      Client cliente2 = new Client(ClientType.Regular,
                                   new DateTime(2020, 3, 20),
                                   new DateTime(2020, 3, 21),
                                   new DateTime(2020, 3, 22));

      Client cliente3 = new Client(ClientType.Fidelity,
                                   new DateTime(2020, 3, 26),
                                   new DateTime(2020, 3, 27),
                                   new DateTime(2020, 3, 28));

      Console.WriteLine($@"Opção mais barata para o cliente 1: ""{calculator.FindCheaper(cliente1).Description}""");
      Console.WriteLine($@"Opção mais barata para o cliente 2: ""{calculator.FindCheaper(cliente2).Description}""");
      Console.WriteLine($@"Opção mais barata para o cliente 3: ""{calculator.FindCheaper(cliente3).Description}""");
      Console.ReadKey();
    }
  }
}
