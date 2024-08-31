using Globomantics.Models;
using Microsoft.EntityFrameworkCore;

namespace Globomantics.Data;

public static class SeedData
{
  public static void Seed(ModelBuilder builder)
  {
    builder.Entity<House>().HasData(
      new List<House>
      {
        new House { Id = 1, Address = "123 Elm St", Country = "USA", Description = "A cozy family home.", Price = 250000 },
        new House { Id = 2, Address = "456 Oak St", Country = "USA", Description = "Spacious with a large backyard.", Price = 350000 },
        new House { Id = 3, Address = "789 Pine St", Country = "USA", Description = "Modern design, close to downtown.", Price = 500000 },
        new House { Id = 4, Address = "101 Maple St", Country = "Canada", Description = "Quaint and charming cottage.", Price = 200000 },
        new House { Id = 5, Address = "202 Birch St", Country = "Canada", Description = "Recently renovated with high-end finishes.", Price = 450000 },
        new House { Id = 6, Address = "303 Cedar St", Country = "UK", Description = "Historic home with original features.", Price = 600000 },
        new House { Id = 7, Address = "404 Willow St", Country = "UK", Description = "Contemporary design, energy efficient.", Price = 400000 },
        new House { Id = 8, Address = "505 Ash St", Country = "Australia", Description = "Beachside property with stunning views.", Price = 750000 },
        new House { Id = 9, Address = "606 Cherry St", Country = "Australia", Description = "Ideal for families, near schools and parks.", Price = 300000 },
        new House { Id = 10, Address = "707 Fir St", Country = "Germany", Description = "Traditional German house, well-maintained.", Price = 350000 },
        new House { Id = 11, Address = "808 Spruce St", Country = "Germany", Description = "Modern apartment in a vibrant area.", Price = 500000 },
        new House { Id = 12, Address = "909 Poplar St", Country = "France", Description = "Elegant home with classic French architecture.", Price = 650000 },
        new House { Id = 13, Address = "1010 Linden St", Country = "France", Description = "Charming property with a beautiful garden.", Price = 300000 },
        new House { Id = 14, Address = "1111 Sequoia St", Country = "Italy", Description = "Rustic villa in the countryside.", Price = 550000 },
        new House { Id = 15, Address = "1212 Redwood St", Country = "Italy", Description = "Modern apartment with city views.", Price = 400000 },
        new House { Id = 16, Address = "1313 Oakwood St", Country = "Spain", Description = "Luxury home with a private pool.", Price = 700000 },
        new House { Id = 17, Address = "1414 Pinewood St", Country = "Spain", Description = "Cozy apartment in a historic building.", Price = 250000 },
        new House { Id = 18, Address = "1515 Maplewood St", Country = "Japan", Description = "Traditional house with a serene garden.", Price = 450000 },
        new House { Id = 19, Address = "1616 Cherrywood St", Country = "Japan", Description = "Modern loft in a bustling area.", Price = 300000 },
        new House { Id = 20, Address = "1717 Willowwood St", Country = "South Korea", Description = "Stylish home with advanced features.", Price = 500000 }
      }
    );

    builder.Entity<Bid>().HasData(new List<Bid>
        {
            new Bid { Id = 1, HouseId = 1, Bidder = "Sonia Reading", Amount = 200000 },
            new Bid { Id = 2, HouseId = 1, Bidder = "Dick Johnson", Amount = 202400 },
            new Bid { Id = 3, HouseId = 2, Bidder = "Mohammed Vahls", Amount = 302400 },
            new Bid { Id = 4, HouseId = 2, Bidder = "Jane Williams", Amount = 310500 },
            new Bid { Id = 5, HouseId = 2, Bidder = "John Kepler", Amount = 315400 },
            new Bid { Id = 6, HouseId = 3, Bidder = "Bill Mentor", Amount = 201000 },
            new Bid { Id = 7, HouseId = 4, Bidder = "Melissa Kirk", Amount = 410000 },
            new Bid { Id = 8, HouseId = 4, Bidder = "Scott Max", Amount = 450000 },
            new Bid { Id = 9, HouseId = 4, Bidder = "Christine James", Amount = 470000 },
            new Bid { Id = 10, HouseId = 5, Bidder = "Omesh Carim", Amount = 450000 },
            new Bid { Id = 11, HouseId = 5, Bidder = "Charlotte Max", Amount = 150000 },
            new Bid { Id = 12, HouseId = 5, Bidder = "Marcus Scott", Amount = 170000 }
        });
  }
}