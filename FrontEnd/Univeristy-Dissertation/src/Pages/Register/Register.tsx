import React, { useState } from "react";
import { registerUser, saveProfile } from "../../services/api/ApiEndpoints";
import { useNavigate } from "react-router-dom";
import "./Registration.css";
import ProficiencyQuiz from "../../components/ProficiencyQuiz/ProficiencyQuiz";
import { Button } from "@mui/material";
import ClearIcon from "@mui/icons-material/Clear";

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

  const [registering, setRegistering] = useState(false);
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
  const [passwordMismatchError, setPasswordMismatchError] = useState(false);

  // State variables for input field errors
  const [firstNameError, setFirstNameError] = useState(false);
  const [lastNameError, setLastNameError] = useState(false);
  const [emailError, setEmailError] = useState(false);
  const [passwordError, setPasswordError] = useState(false);
  const [emailDuplication, setEmailDuplication] = useState(false);
  const [confirmPasswordError, setConfirmPasswordError] = useState(false);
  const [passwordValidationErrors, setPasswordValidationErrors] = useState<
    string[]
  >([]);

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    let registerSuccess = true;

    // Check for empty fields
    if (!userProfile.firstName) {
      setFirstNameError(true);
      registerSuccess = false;
    } else {
      setFirstNameError(false);
    }
    if (!userProfile.lastName) {
      setLastNameError(true);
      registerSuccess = false;
    } else {
      setLastNameError(false);
    }
    if (!userProfile.email) {
      setEmailError(true);
      registerSuccess = false;
    } else {
      setEmailError(false);
    }
    if (!formData.password) {
      setPasswordError(true);
      registerSuccess = false;
    } else {
      setPasswordError(false);
    }
    if (!formData.confirmPassword) {
      setConfirmPasswordError(true);
      registerSuccess = false;
    } else {
      setConfirmPasswordError(false);
    }

    if (formData.password !== formData.confirmPassword) {
      setPasswordMismatchError(true);
      registerSuccess = false;
    }

    const passwordRegex =
      /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$/;
    if (!passwordRegex.test(formData.password)) {
      setPasswordValidationErrors([
        "Password must be at least 6 characters long and contain at least one lowercase letter, one uppercase letter, one digit, and one special character.",
      ]);
      registerSuccess = false;
    } else {
      setPasswordValidationErrors([]);
    }

    if (!registerSuccess) {
      return;
    }

    var registration = false;

    setRegistering(true);
    try {
      await registerUser(userProfile.email, formData.password);
      registration = true;
    } catch (error: unknown) {
      setEmailDuplication(true);
      registration = false;
    } finally {
      setRegistering(false);
    }

    if (registration) {
      try {
        await saveProfile(userProfile);
        setRegistrationSuccess(true);
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
    setPasswordMismatchError(false);
    setPasswordError(false);
    setConfirmPasswordError(false);
  };

  const handleChangeUser = (
    event: React.ChangeEvent<HTMLInputElement>,
    field: keyof UserProfile
  ) => {
    setUserProfile({
      ...userProfile,
      [field]: event.target.value,
    });
    if (field === "firstName") {
      setFirstNameError(false);
    }
    if (field === "lastName") {
      setLastNameError(false);
    }
    if (field === "email") {
      setEmailError(false);
    }
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
                {firstNameError && (
                  <p className="error-message">First name is required.</p>
                )}
              </div>
              <div>
                <label htmlFor="fullName">Last Name:</label>
                <input
                  type="text"
                  id="lastName"
                  value={userProfile.lastName}
                  onChange={(e) => handleChangeUser(e, "lastName")}
                />
                {lastNameError && (
                  <p className="error-message">Last name is required.</p>
                )}
              </div>
              <div>
                <label htmlFor="email">Email:</label>
                <input
                  type="email"
                  id="email"
                  value={userProfile.email}
                  onChange={(e) => handleChangeUser(e, "email")}
                />
                {emailError && (
                  <p className="error-message">Email is required.</p>
                )}
                {emailDuplication && (
                  <p className="error-message">
                    Email is already set to a user.
                  </p>
                )}
              </div>
              <div>
                <label htmlFor="password">Password:</label>
                <input
                  type="password"
                  id="password"
                  value={formData.password}
                  onChange={(e) => handleChange(e, "password")}
                />
                {passwordError && (
                  <p className="error-message">Password is required.</p>
                )}
              </div>
              <div>
                <label htmlFor="confirmPassword">Confirm Password:</label>
                <input
                  type="password"
                  id="confirmPassword"
                  value={formData.confirmPassword}
                  onChange={(e) => handleChange(e, "confirmPassword")}
                />
                {confirmPasswordError && (
                  <p className="error-message">
                    <ClearIcon className="clear-icon" /> Confirm password is
                    required.
                  </p>
                )}
                {passwordMismatchError &&
                  passwordValidationErrors.length === 0 && (
                    <p className="error-message">
                      <ClearIcon className="clear-icon" /> Passwords don't
                      match. Please re-enter.
                    </p>
                  )}

                {passwordValidationErrors.length > 0 &&
                  passwordValidationErrors.map((error, index) => (
                    <p key={index} className="error-message">
                      <ClearIcon className="clear-icon" /> {error}
                    </p>
                  ))}
              </div>

              <Button
                variant="contained"
                aria-label="outlined primary button group"
                className="button-container"
                type="submit"
                disabled={registering}
              >
                {registering ? "Registering account..." : "Register"}
              </Button>
            </form>
          </>
        )}
      </div>
    </div>
  );
};

export default Register;
