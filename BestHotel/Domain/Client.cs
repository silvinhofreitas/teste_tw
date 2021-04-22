using System;
using System.Collections.Generic;
using System.Text;

namespace BestHotel.Domain
{
  public class Client
  {
    public ClientType Type { get; set; }
    public List<DateTime> BookDates { get; set; }

    public Client(ClientType type, params DateTime[] bookDates)
    {
      Type = type;
      BookDates = new List<DateTime>();
      BookDates.AddRange(bookDates);
    }
  }

  public enum ClientType
  {
    Regular,
    Fidelity
  }
}
