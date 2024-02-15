import React, { useEffect, useState } from "react";
import "../Quiz/Quiz.css";
import {
  generateQuizQuestions,
  saveCurrentUserStatistics,
} from "../../services/api/ApiEndpoints";
import DoneOutlineIcon from "@mui/icons-material/DoneOutline";
import ClearIcon from "@mui/icons-material/Clear";

interface QuizQuestion {
  question: string;
  options: QuizOption[];
}

interface QuizOption {
  id: number;
  choice: string;
  isCorrect: boolean;
}

interface UserStatistics {
  score: number;
  quizLength: number;
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

  const questions: QuizQuestion[] = [
    {
      question: "What is the capital of America?",
      options: [
        { id: 0, choice: "New York City", isCorrect: false },
        { id: 1, choice: "Boston", isCorrect: false },
        { id: 2, choice: "Santa Fe", isCorrect: false },
        { id: 3, choice: "Washington DC", isCorrect: true },
      ],
    },
    {
      question: "What year was the Constitution of America written?",
      options: [
        { id: 0, choice: "1787", isCorrect: true },
        { id: 1, choice: "1776", isCorrect: false },
        { id: 2, choice: "1774", isCorrect: false },
        { id: 3, choice: "1826", isCorrect: false },
      ],
    },
    {
      question: "Who was the second president of the US?",
      options: [
        { id: 0, choice: "John Adams", isCorrect: true },
        { id: 1, choice: "Paul Revere", isCorrect: false },
        { id: 2, choice: "Thomas Jefferson", isCorrect: false },
        { id: 3, choice: "Benjamin Franklin", isCorrect: false },
      ],
    },
    {
      question: "What is the largest state in the US?",
      options: [
        { id: 0, choice: "California", isCorrect: false },
        { id: 1, choice: "Alaska", isCorrect: true },
        { id: 2, choice: "Texas", isCorrect: false },
        { id: 3, choice: "Montana", isCorrect: false },
      ],
    },
    {
      question: "Which of the following countries DO NOT border the US?",
      options: [
        { id: 0, choice: "Canada", isCorrect: false },
        { id: 1, choice: "Russia", isCorrect: true },
        { id: 2, choice: "Cuba", isCorrect: false },
        { id: 3, choice: "Mexico", isCorrect: false },
      ],
    },
  ];

  const optionClicked = (isCorrect: boolean) => {
    if (answerSelected) {
      return;
    }

    if (isCorrect) {
      setScore((prevScore) => prevScore + 1);
      console.log("hi");
    }

    setAnswerSelected(true);
  };

  const handleNextClick = () => {
    if (currentQuestion + 1 < quizData.length) {
      setAnswerSelected(false);
      setCurrentQuestion((prevQuestion) => prevQuestion + 1);
    } else {
      setShowResults(true);
      saveUserStatistics();
    }
  };

  const saveUserStatistics = async () => {
    const loggedInUser = localStorage.getItem("loggedInUser");

    if (loggedInUser) {
      let userStatistics: UserStatistics = {
        score: score,
        quizLength: quizData.length,
      };

      try {
        await saveCurrentUserStatistics(userStatistics);
      } catch (error) {
        console.error("Error saving user statisitcs:", error);
      }
    }
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
              const sign =
                answerSelected && isCorrect ? (
                  <DoneOutlineIcon />
                ) : answerSelected ? (
                  <ClearIcon />
                ) : (
                  ""
                );

              return (
                <div
                  className={optionClassName}
                  key={option.id}
                  onClick={() => optionClicked(isCorrect)}
                >
                  <p className="choice-prefix">
                    {String.fromCharCode(65 + index)}
                  </p>
                  <p className="choice-text">
                    {sign}
                    <span className="option-choice">{option.choice}</span>
                  </p>
                </div>
              );
            })}
          </div>
          {answerSelected && <button onClick={handleNextClick}>Next</button>}
        </>
      )}
    </div>
  );
};

export default Quiz;
