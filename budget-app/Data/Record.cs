using System.ComponentModel.DataAnnotations;

namespace budget_app.Data;

public class Record

{
    [Key] public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Description { get; set; }
    public RecordCategory Category { get; set; }
    public int Cost { get; set; }
    public DateTime Date { get; set; }
}
