import React, { useState, useEffect } from "react";
import { userLogin } from "../../services/api/ApiEndpoints";
import { useNavigate } from "react-router-dom";
import ClearIcon from "@mui/icons-material/Clear";
import "./Login.css";
import Button from "@mui/material/Button";

interface LoginProps {
  handleLogin: () => void;
}

const Login: React.FC<LoginProps> = ({ handleLogin }) => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState<string | null>(null);
  const [loggingIn, setLoggingIn] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    const loggedInUser = localStorage.getItem("loggedInUser");
    if (loggedInUser) {
      handleLogin();
      navigate("/");
    }
  }, [navigate]);

  const validateEmail = (input: string): boolean => {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(input);
  };

  const handleSubmit = async (event: { preventDefault: () => void }) => {
    event.preventDefault();

    setError(null);

    if (!validateEmail(email)) {
      setError("Please enter a valid email address.");
      return;
    }
    setLoggingIn(true);
    try {
      const data = await userLogin(email, password);
      const accessToken = data.accessToken;
      localStorage.setItem("loggedInUser", accessToken);
      handleLogin();
      navigate("/");
    } catch (error) {
      setError("User email or password was incorrect. Please try again.");
    } finally {
      setLoggingIn(false);
    }
  };

  return (
    <div className="loginBox">
      <h2>Login</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="email">Email: </label>
          <input
            type="text"
            id="email"
            value={email}
            onChange={(e) => {
              setEmail(e.target.value);
              setError(null);
            }}
          />
        </div>
        <div>
          <label htmlFor="password">Password: </label>
          <input
            type="password"
            id="password"
            value={password}
            onChange={(e) => {
              setPassword(e.target.value);
              setError(null);
            }}
          />
        </div>
        {error && (
          <div className="error-container">
            <ClearIcon className="clear-icon" /> {error}
          </div>
        )}

        <Button
          variant="contained"
          aria-label="outlined primary button group"
          className="button-container"
          type="submit"
          disabled={loggingIn}
        >
          {loggingIn ? "Logging in..." : "Login"}
        </Button>
      </form>
    </div>
  );
};

export default Login;
