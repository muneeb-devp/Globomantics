using System.ComponentModel.DataAnnotations;

namespace Globomantics.Data.DTO;

public record BidDTO(
  int Id,
  int HouseId,
  [property: Required] string Bidder,
  double Amount
);