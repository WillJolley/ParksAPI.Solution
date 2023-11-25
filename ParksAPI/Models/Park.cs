using System.ComponentModel.DataAnnotations;

namespace ParksAPI.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Features { get; set; }
  }
}