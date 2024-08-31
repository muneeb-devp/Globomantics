using System.ComponentModel.DataAnnotations;

namespace Globomantics.Data.DTO;

// For list of attributes: 4sh.nl/annotations
public record HouseDetailDTO(
  int Id,
  [property: Required] string? Address,
  [property: Required] string? Country,
  [property: Required] double Price,
  string? Description,
  string? Photo
);