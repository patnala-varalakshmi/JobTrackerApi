namespace JobTrackerApi.Models
{
  public class Application
  {
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string Status { get; set; }
    public string Position { get; set; }
      
    public DateTime CreatedAt { get; set; } = DateTime.Now;
  }
}
