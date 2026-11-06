using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfTest.Enitities;

public class QuestionEntity
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(1000)]
    public string Text { get; set; } = null!;

    [Required, ForeignKey(nameof(Test))]
    public int TestId { get; set; }

    public TestEntity Test { get; set; } = null!;

    public ICollection<AnswerEntity> Answers { get; set; } = null!;
}
