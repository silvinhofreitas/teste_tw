using BestHotel.Domain;
using BestHotel.Services;
using System;
using Xunit;

namespace CSharpTestProject
{
  public class SampleUnitTest
  {
    public Hotel ParqueDasFlores;
    public Hotel JardimBotanico;
    public Hotel MarAtlantico;
    public PriceCalculator Calculator;

    public SampleUnitTest()
    {
      (ParqueDasFlores, JardimBotanico, MarAtlantico) = CreateHotels.Create();
      Calculator = new PriceCalculator(ParqueDasFlores,
                                       JardimBotanico,
                                       MarAtlantico);
    }

    [Fact]
    public void WhenRegularAndNotWeekend_ShouldReturnParqueDasFlores()
    {
      Client client = new Client(ClientType.Regular, new DateTime(2020, 1, 6));

      Hotel result = Calculator.FindCheaper(client);

      Assert.Equal(ParqueDasFlores, result);
    }

    [Fact]
    public void WhenFidelityAndNotWeekend_ShouldReturnParqueDasFlores()
    {
      Client client = new Client(ClientType.Fidelity, new DateTime(2020, 1, 6));

      Hotel result = Calculator.FindCheaper(client);

      Assert.Equal(ParqueDasFlores, result);
    }

    [Fact]
    public void WhenRegularAndWeekend_ShouldReturnJardimBotanico()
    {
      Client client = new Client(ClientType.Regular, new DateTime(2020, 1, 4));

      Hotel result = Calculator.FindCheaper(client);

      Assert.Equal(JardimBotanico, result);
    }

    [Fact]
    public void WhenFidelityAndWeekend_ShouldReturnMarAtlantico()
    {
      Client client = new Client(ClientType.Fidelity, new DateTime(2020, 1, 4));

      Hotel result = Calculator.FindCheaper(client);

      Assert.Equal(MarAtlantico, result);
    }
  }
}
