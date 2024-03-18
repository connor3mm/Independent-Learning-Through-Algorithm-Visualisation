import React, { useState } from "react";
import { registerUser, saveProfile } from "../../services/api/ApiEndpoints";
import { useNavigate } from "react-router-dom";
import "./Registration.css";
import ProficiencyQuiz from "../../components/ProficiencyQuiz/ProficiencyQuiz";

interface RegisterFormData {
  password: string;
  confirmPassword: string;
}

interface UserProfile {
  email: string;
  firstName: string;
  lastName: string;
  proficiencyLevelId: number;
  createdOn: string;
  proficiencyScore: number;
}

const Register: React.FC = () => {
  const navigate = useNavigate();

  const [userProfile, setUserProfile] = useState<UserProfile>({
    email: "",
    firstName: "",
    lastName: "",
    proficiencyLevelId: 1,
    createdOn: new Date().toISOString().split("T")[0],
    proficiencyScore: 0,
  });
  const [formData, setFormData] = useState<RegisterFormData>({
    password: "",
    confirmPassword: "",
  });

  const [registrationSuccess, setRegistrationSuccess] = useState(false);

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    let registerSuccess = true;

    if (
      formData.password === "" ||
      formData.password !== formData.confirmPassword
    ) {
      alert("Passwords don't match. Please re-enter.");
      return;
    }

    try {
      await registerUser(userProfile.email, formData.password);
      registerSuccess = true;
      setRegistrationSuccess(true);
    } catch (error) {
      console.error(error);
    }

    if (registerSuccess) {
      try {
        await saveProfile(userProfile);
      } catch (error) {
        console.error(error);
      }
    }
  };

  const handleChange = (
    event: React.ChangeEvent<HTMLInputElement>,
    field: keyof RegisterFormData
  ) => {
    setFormData({
      ...formData,
      [field]: event.target.value,
    });
  };

  const handleChangeUser = (
    event: React.ChangeEvent<HTMLInputElement>,
    field: keyof UserProfile
  ) => {
    setUserProfile({
      ...userProfile,
      [field]: event.target.value,
    });
  };

  return (
    <div>
      <div className="registrationBox">
        {registrationSuccess ? (
          <div>
            <h2>Registration Successful!</h2>
            <div>
              <button onClick={() => navigate("/login")}> Log In</button>
            </div>
            <div>
              <ProficiencyQuiz email={userProfile.email} />
            </div>
          </div>
        ) : (
          <>
            <h2>Register</h2>
            <form onSubmit={handleSubmit}>
              <div>
                <label htmlFor="firstName">First Name:</label>
                <input
                  type="text"
                  id="firstName"
                  value={userProfile.firstName}
                  onChange={(e) => handleChangeUser(e, "firstName")}
                />
              </div>
              <div>
                <label htmlFor="fullName">Last Name:</label>
                <input
                  type="text"
                  id="lastName"
                  value={userProfile.lastName}
                  onChange={(e) => handleChangeUser(e, "lastName")}
                />
              </div>
              <div>
                <label htmlFor="email">Email:</label>
                <input
                  type="email"
                  id="email"
                  value={userProfile.email}
                  onChange={(e) => handleChangeUser(e, "email")}
                />
              </div>
              <div>
                <label htmlFor="password">Password:</label>
                <input
                  type="password"
                  id="password"
                  value={formData.password}
                  onChange={(e) => handleChange(e, "password")}
                />
              </div>
              <div>
                <label htmlFor="confirmPassword">Confirm Password:</label>
                <input
                  type="password"
                  id="confirmPassword"
                  value={formData.confirmPassword}
                  onChange={(e) => handleChange(e, "confirmPassword")}
                />
              </div>
              <button type="submit">Register</button>
            </form>
          </>
        )}
      </div>
    </div>
  );
};

export default Register;
