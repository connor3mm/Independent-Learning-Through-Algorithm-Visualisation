import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import {
  getProfile,
  getUserStatistics,
  lastFiveGamesStatistics,
} from "../../services/api/ApiEndpoints";
import "./Profile.css";
import proficiencyLevel from "../../services/enums/ProficiencyLevel";
import ProficiencyQuiz from "../../components/ProficiencyQuiz/ProficiencyQuiz";
import Button from "@mui/material/Button";
import ButtonGroup from "@mui/material/ButtonGroup";
import ProgressionBar from "../../components/ProgressionBar/ProgressionBar";
import ProgressionChart from "../../components/ProgressionChart/ProgressionChart";

interface UserStatistics {
  totalScore: number;
  totalQuestions: number;
  gamesPlayed: number;
  averageScore: number;
  proficiencyScore: number;
}

const Profile: React.FC = () => {
  const navigate = useNavigate();
  const [userProfile, setUserProfile] = useState<UserProfile | null>(null);
  const [showProficiencyTest, setShowProficiencyTest] = useState(false);
  const [userStatistics, setUserStatistics] = useState<UserStatistics>({
    totalScore: 0,
    totalQuestions: 0,
    gamesPlayed: 0,
    averageScore: 0,
    proficiencyScore: 0,
  });

  useEffect(() => {
    const loggedInUser = localStorage.getItem("loggedInUser");

    if (loggedInUser) {
      async function fetchData() {
        try {
          await getProfile().then((data) => {
            setUserProfile(data);
          });
        } catch (error) {}
      }

      async function fetchUserStatistics() {
        try {
          await getUserStatistics().then((data) => {
            setUserStatistics(data);
          });
        } catch (error) {}
      }

      fetchData();
      fetchUserStatistics();
    }
  }, []);

  return (
    <div>
      <h2>Profile</h2>
      {showProficiencyTest ? (
        <div className="registrationBox">
          <ProficiencyQuiz email={userProfile?.email} />
        </div>
      ) : userProfile ? (
        <div className="profile-flex-container">
          <div className="profile-flex-items user-details">
            <h2>User Details</h2>
            <p>Email: {userProfile.email}</p>
            <p>First Name: {userProfile.firstName}</p>
            <p>Last Name: {userProfile.lastName}</p>
            <p>Account Created On: {userProfile.createdOn}</p>
            <p>
              Proficiency Level:{" "}
              {proficiencyLevel[userProfile.proficiencyLevelId]}
            </p>
            {userProfile.proficiencyLevelId === 1 && (
              <button onClick={() => setShowProficiencyTest(true)}>
                Take Proficiency Test
              </button>
            )}{" "}
            {userProfile.proficiencyLevelId !== 1 &&
              userProfile.proficiencyLevelId !== 5 && (
                <div style={{ display: "inline-block" }}>
                  Proficiency Level Progression:
                  <ProgressionBar value={userStatistics.proficiencyScore} />
                </div>
              )}
          </div>
          <div className="profile-flex-items">
            <h2>Testing Statistics</h2>
            <p>Games Played: {userStatistics.gamesPlayed}</p>
            <p>Total Questions: {userStatistics.totalQuestions}</p>
            <p>Total Score: {userStatistics.totalScore}</p>
            <p>Average Score Per Game: {userStatistics.averageScore}</p>
            <div className="progressionChart">
              <ProgressionChart />
            </div>
          </div>
        </div>
      ) : (
        <div className="notFoundBox">
          <p>Profile not found</p>
          <p>Please Register or Log In</p>
          <ButtonGroup
            variant="contained"
            aria-label="outlined primary button group"
          >
            <Button onClick={() => navigate("/register")}>Register</Button>
            <Button onClick={() => navigate("/login")}>Log In</Button>
          </ButtonGroup>
        </div>
      )}
    </div>
  );
};
export default Profile;
