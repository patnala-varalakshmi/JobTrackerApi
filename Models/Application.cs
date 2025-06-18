namespace JobTrackerApi.Models
{
  public class Application
  {
    public int Id { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
      
    public DateTime CreatedAt { get; set; } = DateTime.Now;
  }
}
