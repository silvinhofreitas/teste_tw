using System;
using System.Collections.Generic;
using System.Text;

namespace BestHotel.Domain
{
  public class Hotel
  {
    public string Description { get; set; }
    public int Rating { get; set; }
    public HotelValues RegularCostumerValues { get; set; }
    public HotelValues FidelityCostumerValues { get; set; }

    public Hotel(string description,
                 int rating,
                 double weekendRegularCostumerValue,
                 double weekRegularCostumerValue,
                 double weekendFidelityCostumerValue,
                 double weekFidelityCostumerValue)
    {
      Description = description;
      Rating = rating;
      RegularCostumerValues = new HotelValues(weekendRegularCostumerValue,
                                              weekRegularCostumerValue);
      FidelityCostumerValues = new HotelValues(weekendFidelityCostumerValue,
                                               weekFidelityCostumerValue);
    }
  }

  public class HotelValues
  {
    public double Weekend { get; set; }
    public double Week { get; set; }

    public HotelValues(double weekend,
                       double week)
    {
      Weekend = weekend;
      Week = week;
    }
  }

}
