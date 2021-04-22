using BestHotel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestHotel.Services
{
  public static class CreateHotels
  {
    public static (Hotel parqueDasFlores, Hotel jardimBotanico, Hotel marAtlantico) Create()
    {
      Hotel ParqueDasFlores = new Hotel("Parque das Flores", 3,
                                        90, 110,
                                        80, 80);

      Hotel JardimBotanico = new Hotel("Jardim Botânico", 4,
                                       60, 160,
                                       50, 110);

      Hotel MarAtlantico = new Hotel("Mar Atlântico", 5,
                                     150, 220,
                                     40, 100);

      return (ParqueDasFlores, JardimBotanico, MarAtlantico);
    }
  }
}
