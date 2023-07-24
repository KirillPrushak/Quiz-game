using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using QuizGame;
using UnityEngine;

public class ViewQuiz : MonoBehaviour
{
    [SerializeField] private string question;
    [SerializeField] private string correct;
    [SerializeField] private string[] fakes;

    [SerializeField] private AnswerButton prefab;
    void Start()
    {
        IQuiz quiz = new ShuffledQuiz(
        new SimpleQuiz(question, correct, fakes)
        );
        foreach (var quizAnswer in quiz.Answers)
        {
            newButton(quizAnswer).clicked.AddListener(e =>
            {
                Debug.Log($"Answer {quizAnswer} is correct? {quiz.Answer(e)}");
                quiz.Answer(e);
            });
        }
        
        
    }

    AnswerButton newButton(string answer)
    {
        var button = Instantiate(prefab, transform);
        button.Construct(answer);
        return button;
    }
}
