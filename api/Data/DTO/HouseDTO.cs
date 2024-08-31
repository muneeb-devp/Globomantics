namespace Globomantics.Data.DTO;

public record HouseDTO(
  int Id,
  string? Address,
  string? Country,
  double Price
);