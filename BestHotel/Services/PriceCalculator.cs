using BestHotel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BestHotel.Services
{
  public class PriceCalculator
  {
    public List<Hotel> HotelList { get; set; }

    public PriceCalculator(params Hotel[] hotels)
    {
      HotelList = new List<Hotel>();
      HotelList.AddRange(hotels);
    }

    public Hotel FindCheaper(Client client)
    {
      int totalDays = client.BookDates.Count;
      int weekendDays = client.BookDates.Where(x => IsWeekend(x.DayOfWeek)).Count();
      Hotel result = HotelList[0];
      double cheaperValue = -1;

      foreach(var hotel in HotelList)
      {
        double weekendValue = 0;
        double weekdayValue = 0;
        double totalValue = 0;

        if (client.Type == ClientType.Regular)
        {
          weekendValue = weekendDays * hotel.RegularCostumerValues.Weekend;
          weekdayValue = (totalDays - weekendDays) * hotel.RegularCostumerValues.Week;
        }
        else
        {
          weekendValue = weekendDays * hotel.FidelityCostumerValues.Weekend;
          weekdayValue = (totalDays - weekendDays) * hotel.FidelityCostumerValues.Week;
        }

        totalValue = weekendValue + weekdayValue;

        if (cheaperValue < 0 ||
            totalValue < cheaperValue ||
            (cheaperValue == totalValue &&
             hotel.Rating > result.Rating))
        {
          cheaperValue = totalValue;
          result = hotel;
        }
      }

      return result;
    }

    private bool IsWeekend(DayOfWeek day)
    {
      List<DayOfWeek> weekendDays = new List<DayOfWeek>()
      {
        DayOfWeek.Saturday,
        DayOfWeek.Sunday
      };

      return weekendDays.Contains(day);
    }
  }
}
