using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfTest.Enitities;

[Table("TestResults")]
public class TestResultEntity
{
    [Key]
    public int Id { get; set; }

    [Required, ForeignKey(nameof(Test))]
    public int TestId { get; set; }
    public TestEntity Test { get; set; } = null!;

    [Required, StringLength(100)]
    public string LastName { get; set; } = null!;

    [Required, StringLength(100)]
    public string FirstName { get; set; } = null!;

    [StringLength(100)]
    public string? MiddleName { get; set; }

    public int CorrectAnswersCount { get; set; }
    public int WrongAnswersCount { get; set; }

    
    [Required]
    public DateTime StartedAt { get; set; }
    
    [Required]
    public DateTime FinisheddAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

}