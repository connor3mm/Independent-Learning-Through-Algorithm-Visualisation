import React, { useState } from 'react';
import { registerUser } from '../../api/ApiEndpoints';

interface RegisterFormData {
  fullName: string;
  email: string;
  password: string;
  confirmPassword: string;
}

const Register: React.FC = () => {
  const [formData, setFormData] = useState<RegisterFormData>({
    fullName: '',
    email: '',
    password: '',
    confirmPassword: '',
  });
  
  const [registrationSuccess, setRegistrationSuccess] = useState(false);

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    if (formData.password !== formData.confirmPassword) {
      alert("Passwords don't match. Please re-enter.");
      return;
    }

    try {
      const data = await registerUser(formData.email, formData.password);
      if(data.status !== 400){
        console.log(data);
        setRegistrationSuccess(true);
  
      }
     
    } catch (error) {
      console.error(error);
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

  return (
    <div>
      {!registrationSuccess ? (
        <div>
          <h2>Register</h2>
          <form onSubmit={handleSubmit}>
          <div>
          <label htmlFor="fullName">Full Name:</label>
          <input
            type="text"
            id="fullName"
            value={formData.fullName}
            onChange={(e) => handleChange(e, 'fullName')}
          />
        </div>
        <div>
          <label htmlFor="email">Email:</label>
          <input
            type="email"
            id="email"
            value={formData.email}
            onChange={(e) => handleChange(e, 'email')}
          />
        </div>
        <div>
          <label htmlFor="password">Password:</label>
          <input
            type="password"
            id="password"
            value={formData.password}
            onChange={(e) => handleChange(e, 'password')}
          />
        </div>
        <div>
          <label htmlFor="confirmPassword">Confirm Password:</label>
          <input
            type="password"
            id="confirmPassword"
            value={formData.confirmPassword}
            onChange={(e) => handleChange(e, 'confirmPassword')}
          />
        </div>
            <button type="submit">Register</button>
          </form>
        </div>
      ) : (
        <div>
          <h2>Registration Successful!</h2>
        </div>
      )}
    </div>
  );
};

export default Register;
