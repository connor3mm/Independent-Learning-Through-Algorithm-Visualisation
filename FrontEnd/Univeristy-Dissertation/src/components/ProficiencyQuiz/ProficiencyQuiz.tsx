import React, { useState } from "react";
import "./ProficiencyQuiz.css";
import ClearIcon from "@mui/icons-material/Clear";
import { updateProficencyLevel } from "../../services/api/ApiEndpoints";
import proficiencyLevel from "../../services/enums/ProficiencyLevel";

interface userDetails {
  email?: string;
}

const ProficiencyQuiz: React.FC<userDetails> = ({ email }) => {
  const [showError, setShowError] = useState(false);
  const [quizComplete, setQuizComplete] = useState(false);
  const [selfEvaluationScore, setSelfEvaluationScore] = useState<number>(0);
  const [currentQuestionIndex, setCurrentQuestionIndex] = useState(0);
  const [proficiencyChoice, setProficiencyChoice] = useState(-1);
  const [userLevel, setUserLevel] = useState("");

  const questions = [
    {
      questionText: "Do you have any previous knowledge of sorting algorithms?",
      questionChoices: ["No knowledge", "Little knowledge", "Great Knowledge"],
    },
    {
      questionText:
        "Do you have any previous knowledge of searching algorithms?",
      questionChoices: ["No knowledge", "Little knowledge", "Expert"],
    },
    {
      questionText:
        "Whats you knowledge levels of time and space complecity of sorting algorithms?",
      questionChoices: ["No knowledge", "Little knowledge", "Expert"],
    },
    {
      questionText:
        "Whats you knowledge levels of time and space complecity of searching algorithms?",
      questionChoices: ["No knowledge", "Little knowledge", "Expert"],
    },
    {
      questionText:
        "How confident are you in comparing various algorithms attributes?",
      questionChoices: ["Not Confident", "Fairly Confident", "Very Confident"],
    },
  ];

  const handleNextClick = (rating: number) => {
    if (rating === -1) {
      setShowError(true);
      return;
    }
    rating += 1;
    setShowError(false);
    setSelfEvaluationScore((prevEvaluation) => prevEvaluation + rating);

    setProficiencyChoice(-1);
    if (currentQuestionIndex < questions.length - 1) {
      setCurrentQuestionIndex(currentQuestionIndex + 1);
    } else {
      setQuizComplete(true);
      if (selfEvaluationScore + rating <= 6) {
        updateProficencyLevel(email, proficiencyLevel.Beginner);
        setUserLevel(
          "Beginner level. We recommend that you start within the learning zone, to gain knowledge on how certain algorithms work, before moving to more advanced areas and assessing your newly gained knowledge!"
        );
      } else if (selfEvaluationScore + rating <= 11) {
        updateProficencyLevel(email, proficiencyLevel.Intermediate);
        setUserLevel(
          "Intermediate level. We recommend that you start on the visualiser, as you already have an understanding of the topics. After this you can test your knowledge in the testing zone!"
        );
      } else if (selfEvaluationScore + rating <= 15) {
        updateProficencyLevel(email, proficiencyLevel.Advanced);
        setUserLevel(
          "Advanced level. We recommend that you start in the testing zone to assess your knowledge of the topics and improve your profiles score! You can also visit the visualiser and learning zone to refine your understanding. "
        );
      }
    }
  };

  return (
    <>
      {quizComplete ? (
        <div className="successMessage">
          Your proficiency level has been saved! You will start at the{" "}
          {userLevel}
        </div>
      ) : (
        <>
          {currentQuestionIndex < questions.length && (
            <div id="game" className="justify-center flex-column">
              <h3 id="question">
                Question: {currentQuestionIndex + 1} out of 5
              </h3>
              <h2 className="question-text">
                {questions[currentQuestionIndex]?.questionText}
              </h2>
              {questions[currentQuestionIndex]?.questionChoices.map(
                (option, index) => (
                  <div
                    className={`proficiency-choice-container ${
                      proficiencyChoice === index ? "selected" : ""
                    }`}
                    key={option}
                    onClick={() => setProficiencyChoice(index)}
                  >
                    <p className="choice-prefix">
                      {String.fromCharCode(65 + index)}
                    </p>
                    <p className="choice-text">
                      <span className="option-choice">{option}</span>
                    </p>
                  </div>
                )
              )}

              {showError && (
                <div className="errorMessage">
                  <ClearIcon /> Error: Please choose an option!
                </div>
              )}

              <button onClick={() => handleNextClick(proficiencyChoice)}>
                Next
              </button>
            </div>
          )}
        </>
      )}
    </>
  );
};

export default ProficiencyQuiz;
