namespace Globomantics.Models;

public class Bid
{
  public int Id { get; set; }
  public int HouseId { get; set; }
  public House? House { get; set; }
  public string Bidder { get; set; } = string.Empty;
  public double Amount { get; set; }
}