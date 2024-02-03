import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { getProfile } from "../../services/api/ApiEndpoints";
import "./Profile.css";

const Profile: React.FC = () => {
  const [userProfile, setUserProfile] = useState<UserProfile | null>(null);
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

      fetchData();
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
              <p>Proficiency Level : {userProfile.proficiencyLevel}</p>
              <p>Created On : {userProfile.createdOn}</p>
            </div>
            <div className="profile-flex-items">
              {" "}
              <h2>Testing Statistics</h2>
              <p>Email: {userProfile.email}</p>
              <p>First Name: {userProfile.firstName}</p>
              <p>Last Name : {userProfile.lastName}</p>
              <p>Proficiency Level : {userProfile.proficiencyLevel}</p>
              <p>Created On : {userProfile.createdOn}</p>
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
