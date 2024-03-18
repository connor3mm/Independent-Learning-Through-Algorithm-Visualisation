import Quiz from "../../components/Quiz/Quiz";

import "../TestingZone/TestingZone.css";
import { useState } from "react";

const TestingZone: React.FC = () => {
  const [quizActive, setQuizActive] = useState(false);
  const [quizIds, setQuizIds] = useState<number[]>([]);

  const handleStartQuiz = (ids: number[]) => {
    setQuizIds(ids);
    setQuizActive(true);
  };

  const handleResetQuiz = () => {
    setQuizActive(false);
    setQuizIds([]);
  };

  return (
    <>
      <div className="testingZoneInsideContainer">
        <h2 className="testingHeader">Testing Zone</h2>

        <div className="testingZoneDescriptionContainer">
          <div className="testingZoneDescription">
            {quizActive ? (
              <>
                <Quiz ids={quizIds} onQuizReset={handleResetQuiz} />
              </>
            ) : (
              <>
                <h2 className="infoTitle">Description</h2>
                <div className="testingDescription">
                  Welcome to the Interactive Learning Hub's Testing Zone—a
                  dynamic space designed to challenge and enhance your knowledge
                  through a diverse range of questions. This aims to provide a
                  stimulating learning environment where multiple choice
                  questions and "Fill the blanks" exercises await, made to
                  engage and assess your understanding across various subjects.
                </div>
                <div className="testingDescription">
                  For those seeking a personalised learning journey, log in to
                  your profile and your progress will be tracked. With a secure
                  profile, your statistics, including scores and completion
                  rates, will be saved. Witness your growth as you tackle
                  assessments, and enjoy the satisfaction of watching your
                  average score evolve over time. Current quiz sets are set at 5
                  questions each.
                </div>
                <div className="testingDescription">
                  WARNING! If you wish for your test score to be saved, register
                  and log into your account!
                </div>
                <div className="testingButtonContainer">
                  <button
                    className="playQuizButton"
                    onClick={() => handleStartQuiz([1])}
                  >
                    Complexity Quiz
                  </button>
                  <button
                    className="playQuizButton"
                    onClick={() => handleStartQuiz([2])}
                  >
                    Sorting Algorithm Quiz
                  </button>
                  <button
                    className="playQuizButton"
                    onClick={() => handleStartQuiz([3])}
                  >
                    Searching Algorithm Quiz
                  </button>
                  <button
                    className="playQuizButton"
                    onClick={() => handleStartQuiz([1, 2, 3])}
                  >
                    Combined Quiz
                  </button>
                </div>
              </>
            )}
          </div>
        </div>
      </div>
    </>
  );
};

export default TestingZone;
