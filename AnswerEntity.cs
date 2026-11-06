using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfTest.Enitities;

[Table("Answer")]
public class AnswerEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string Text { get; set; } = string.Empty;

    public bool IsCorrect { get; set; }

    [Required]
    [ForeignKey(nameof(Question))]
    public int QuestionId { get; set; }

    public QuestionEntity Question { get; set; } = null!;

    public ICollection<QuestionEntity> Questions { get; set; } = null!;
}
