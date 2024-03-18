import React, { useEffect, useState } from "react";
import "../Quiz/Quiz.css";
import {
  generateQuizQuestions,
  saveCurrentUserStatistics,
} from "../../services/api/ApiEndpoints";
import DoneOutlineIcon from "@mui/icons-material/DoneOutline";
import ClearIcon from "@mui/icons-material/Clear";

interface QuizQuestion {
  id: number;
  question: string;
  questionChoices: QuestionChoice[];
}

interface QuestionChoice {
  id: number;
  choice: string;
  isCorrect: boolean;
}

interface UserStatistics {
  score: number;
  quizLength: number;
}

interface QuizProps {
  ids: number[];
  onQuizReset: () => void;
}

const Quiz: React.FC<QuizProps> = ({ ids, onQuizReset }) => {
  const [score, setScore] = useState(0);
  const [currentQuestion, setCurrentQuestion] = useState(0);
  const [answerSelected, setAnswerSelected] = useState(false);
  const [showResults, setShowResults] = useState(false);
  const [isLoading, setIsLoading] = useState(true);
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const [quizData, setQuizData] = useState<QuizQuestion[]>([
    {
      id: 1,
      question: "Default Question",
      questionChoices: [
        { id: 0, choice: "Answer A", isCorrect: false },
        { id: 1, choice: "Answer B", isCorrect: false },
        { id: 2, choice: "Answer C", isCorrect: false },
        { id: 3, choice: "Answer D", isCorrect: false },
      ],
    },
  ]);

  useEffect(() => {
    const fetchQuizData = async () => {
      try {
        const data = await generateQuizQuestions(ids);
        setQuizData(data);
        setIsLoading(false);
      } catch (error) {
        console.error("Error fetching quiz data:", error);
        setIsLoading(false);
      }
    };

    fetchQuizData();
  }, [ids]);

  const optionClicked = (isCorrect: boolean) => {
    if (answerSelected) {
      return;
    }

    if (isCorrect) {
      setScore((prevScore) => prevScore + 1);
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
        setIsLoggedIn(true);
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
    onQuizReset();
  };

  return (
    <div className="container">
      {isLoading ? (
        <p>Loading...</p>
      ) : showResults ? (
        <div className="final-results">
          <h1>Final Results</h1>
          <h2>
            {score} out of {quizData.length} correct - (
            {(score / quizData.length) * 100}%)
          </h2>

          {isLoggedIn ? (
            <h3>
              {" "}
              You have completed all the Questions! Quiz statistics have be
              saved to your profile!
            </h3>
          ) : (
            <h3>
              If you would like to save your quiz scores next time, please
              register an account!
            </h3>
          )}

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
              {quizData[currentQuestion]?.question}
            </h2>

            {quizData[currentQuestion]?.questionChoices.map((option, index) => {
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
