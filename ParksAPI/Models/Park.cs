using System.ComponentModel.DataAnnotations;

namespace ParkAPI.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Type { get; set; }
    public string Features { get; set; }
  }
}