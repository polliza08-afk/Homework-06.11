using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WpfTest.Enitities;

namespace WpfTest.Entities;

[Table("tblTestResultAnswers")]
public class TestResultAnswerEntity
{
    [Key]
    public int Id { get; set; }

    [Required, ForeignKey(nameof(TestResult))]
    public int TestResultId { get; set; }
    public TestResultEntity TestResult { get; set; } = null!;

    [ForeignKey(nameof(SelectedAnswer))]
    public int SelectedAnswerId { get; set; }
    public AnswerEntity SelectedAnswer { get; set; } = null!;

    public bool IsCorrect { get; set; }
}
