import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { getProfile, getUserStatistics } from "../../services/api/ApiEndpoints";
import "./Profile.css";
import proficiencyLevel from "../../services/enums/ProficiencyLevel";

interface UserStatistics {
  totalScore: number;
  totalQuestions: number;
  gamesPlayed: number;
  averageScore: number;
}

const Profile: React.FC = () => {
  const [userProfile, setUserProfile] = useState<UserProfile | null>(null);
  const [userStatistics, setUserStatistics] = useState<UserStatistics>({
    totalScore: 0,
    totalQuestions: 0,
    gamesPlayed: 0,
    averageScore: 0,
  });
  const navigate = useNavigate();

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
      {userProfile ? (
        <>
          <div className="profile-flex-container">
            <div className="profile-flex-items">
              <h2>User Details</h2>
              <p>Email: {userProfile.email}</p>
              <p>First Name: {userProfile.firstName}</p>
              <p>Last Name : {userProfile.lastName}</p>
              <p>
                Proficiency Level :{" "}
                {proficiencyLevel[userProfile.proficiencyLevelId]}
              </p>
              <p>Created On : {userProfile.createdOn}</p>
            </div>
            <div className="profile-flex-items">
              {" "}
              <h2>Testing Statistics</h2>
              <p>Games Played: {userStatistics.gamesPlayed}</p>
              <p>Total Score: {userStatistics.totalScore}</p>
              <p>Total Questions: {userStatistics.totalQuestions}</p>
              <p>Average Score: {userStatistics.averageScore}</p>
              <p>Proficency Level Progresssion: </p>
            </div>
          </div>
        </>
      ) : (
        <>
          <p>Profile not found</p>
          <p>Please Register or Log In</p>
          <div>
            <button onClick={() => navigate("/register")}> Register</button>
          </div>
          <div>
            <button onClick={() => navigate("/login")}> Log In</button>
          </div>
        </>
      )}
    </div>
  );
};

export default Profile;
