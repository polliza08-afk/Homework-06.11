using System.Windows;
using WpfTest.Enitities;

namespace WpfTest;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        //Ініціалізація контексту бази даних
        MyDataContent fileData = new MyDataContent();
        fileData.Database.EnsureCreated();

        //Перевірка наявності тестів в БД
        if (fileData.Tests.Any() == false)
        {
            //Створення основного об'єкта тесту
            TestEntity test = new TestEntity
            {
                Title = "Основи C#",
                Description = "Тест: змінні, умови, цикли.",
                TimeLimitMinutes = 15,

                //Додавання пов'язаних питань та варіантів відповідей
                Questions = new List<QuestionEntity>
                {
                    new QuestionEntity
                    {
                        Text = "Яке ключове слово для цілочисельної змінної?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "int", IsCorrect = true },
                            new AnswerEntity { Text = "string", IsCorrect = false },
                            new AnswerEntity { Text = "bool", IsCorrect = false },
                            new AnswerEntity { Text = "double", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Який оператор перевіряє рівність?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "=", IsCorrect = false },
                            new AnswerEntity { Text = "==", IsCorrect = true },
                            new AnswerEntity { Text = "!=", IsCorrect = false },
                            new AnswerEntity { Text = "===", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Text = "Який цикл виконується хоча б один раз?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "for", IsCorrect = false },
                            new AnswerEntity { Text = "while", IsCorrect = false },
                            new AnswerEntity { Text = "do-while", IsCorrect = true },
                            new AnswerEntity { Text = "foreach", IsCorrect = false }
                        }
                    }
                }
            };

            //Збереження тесту разом із каскадними залежностями в БД
            fileData.Tests.Add(test);
            fileData.SaveChanges();
        }

        //Підрахунок сутності для виведення інформації
        int countTest = fileData.Tests.Count();
        int countQuestions = fileData.Questions.Count();
        int countAnswers = fileData.Answers.Count();

        //Відображення результатів ініціалізації
        MessageBox.Show($"Тестів: {countTest}\nПитань: {countQuestions}\nВідповідей: {countAnswers}");

        //Запуск головного вікна програми
        MainWindow window = new MainWindow();
        window.Show();
    }
}
