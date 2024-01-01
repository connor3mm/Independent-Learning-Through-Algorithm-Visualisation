import React, { useState, useEffect } from 'react';

interface UserProfile {
  accessToken: string;
}

const Profile: React.FC = () => {
  const [userProfile, setUserProfile] = useState<UserProfile | null>(null);
  
  
  useEffect(() => {
    const loggedInUser = localStorage.getItem('loggedInUser');

  if (loggedInUser) {
    const user = JSON.parse(loggedInUser);
    setUserProfile(user)
    console.log('User data:', user);
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
        <><p>Profile not found</p><p>Please Register or Log In</p></>
      )}
    </div>
  );
};

export default Profile;
