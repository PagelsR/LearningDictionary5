using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDictionary5.Web.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Dictionary
    {
        public int Id { get; set; }
        public string PrimaryLanguage { get; set; }
        public string SecondaryLanguage { get; set; }
        public List<Word> Words { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

    public class Word
    {
        public int Id { get; set; }
        public string PrimaryWord { get; set; }
        public string SecondaryWord { get; set; }
        public int DictionaryId { get; set; }
        public Dictionary Dictionary { get; set; }
    }

    public class PracticeTest
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<Question> Questions { get; set; }
        public TestResult Results { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int DictionaryId { get; set; }
        public Dictionary Dictionary { get; set; }
    }

    public class TestResult
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int Score { get; set; }
        public int PracticeTestId { get; set; }
        public PracticeTest PracticeTest { get; set; }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Questions { get; set; }
        public List<Answer> Answers { get; set; }
        public int PracticeTestId { get; set; }
        public PracticeTest PracticeTest { get; set; }
    }

    public class Answer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }


}
