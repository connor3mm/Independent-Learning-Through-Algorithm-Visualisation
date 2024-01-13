import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";

interface UserProfile {
  accessToken: string;
}

const Profile: React.FC = () => {
  const [userProfile, setUserProfile] = useState<UserProfile | null>(null);
  const navigate = useNavigate();

  useEffect(() => {
    const loggedInUser = localStorage.getItem("loggedInUser");

    if (loggedInUser) {
      const user = JSON.parse(loggedInUser);
      setUserProfile(user);
      console.log("User data:", user);
    }
  }, []);

  return (
    <div>
      <h2>User Profile</h2>
      {userProfile ? (
        <div>
          <p>Email: {userProfile.accessToken}</p>
        </div>
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
