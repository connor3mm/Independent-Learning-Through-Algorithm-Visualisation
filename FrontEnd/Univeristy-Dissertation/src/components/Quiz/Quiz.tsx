import React, { useEffect, useState } from "react";
import "../Quiz/Quiz.css";
import { generateQuizQuestions } from "../../services/api/ApiEndpoints";

interface QuizQuestion {
  question: string;
  options: QuizOption[];
}

interface QuizOption {
  id: number;
  choice: string;
  isCorrect: boolean;
}

const Quiz: React.FC = () => {
  const [score, setScore] = useState(0);
  const [currentQuestion, setCurrentQuestion] = useState(0);
  const [answerSelected, setAnswerSelected] = useState(false);
  const [showResults, setShowResults] = useState(false);

  const [quizData, setQuizData] = useState<QuizQuestion[]>([
    {
      question: "Default Question",
      options: [
        { id: 0, choice: "Answer A", isCorrect: false },
        { id: 1, choice: "Answer B", isCorrect: false },
        { id: 2, choice: "Answer C", isCorrect: false },
        { id: 3, choice: "Answer D", isCorrect: true },
      ],
    },
  ]);

  useEffect(() => {
    const fetchQuizData = async () => {
      try {
        await generateQuizQuestions().then((data) => {
          setQuizData(data);
        });
      } catch (error) {
        console.error("Error fetching quiz data:", error);
      }
    };

    fetchQuizData();
    setQuizData(questions);
  }, []);

  const optionClicked = (isCorrect: boolean) => {
    if (answerSelected) {
      return;
    }

    if (isCorrect) {
      setScore(score + 1);
    }

    setAnswerSelected(true);

    setTimeout(() => {
      if (currentQuestion + 1 < quizData.length) {
        setAnswerSelected(false);
        setCurrentQuestion(currentQuestion + 1);
      } else {
        setShowResults(true);
      }
    }, 1500);
  };

  const restartGame = () => {
    setScore(0);
    setCurrentQuestion(0);
    setShowResults(false);
    setAnswerSelected(false);
  };

  return (
    <div className="container">
      {showResults ? (
        <div className="final-results">
          <h1>Final Results</h1>
          <h2>
            {score} out of {quizData.length} correct - (
            {(score / quizData.length) * 100}%)
          </h2>
          <h3>
            If you are logged into an account, quiz statistics will be saved to
            your profile.
          </h3>
          <button onClick={() => restartGame()}>New game</button>
        </div>
      ) : (
        <>
          <h2>Score: {score}</h2>
          <div id="game" className="justify-center flex-column">
            <h3 id="question">
              {" "}
              Question: {currentQuestion + 1} out of {quizData.length}
            </h3>
            <h2 className="question-text">
              {quizData[currentQuestion].question}
            </h2>

            {quizData[currentQuestion].options.map((option, index) => {
              const isCorrect = option.isCorrect;
              const optionClassName = `choice-container${
                answerSelected && isCorrect
                  ? " correct"
                  : answerSelected
                  ? " incorrect"
                  : ""
              }`;

              return (
                <div
                  className={optionClassName}
                  key={option.id}
                  onClick={() => optionClicked(isCorrect)}
                >
                  <p className="choice-prefix">
                    {String.fromCharCode(65 + index)}
                  </p>
                  <p className="choice-text">{option.choice}</p>
                </div>
              );
            })}
          </div>
        </>
      )}
    </div>
  );
};

export default Quiz;
