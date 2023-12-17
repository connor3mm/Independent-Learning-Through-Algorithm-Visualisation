import { useState } from 'react';
import { userLogin } from '../../api/ApiEndpoints';

const Login = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');


  const handleSubmit = (event: { preventDefault: () => void; }) => {
    event.preventDefault();

    apiCall()

    setUsername('');
    setPassword('');
  };

  const apiCall = () => {
    async function login() {
    try {
      await userLogin(username, password).then((data) => {
        console.log(data)
      });
    } catch (error) {}
  }
  login()
  };


  return (
    <div>
      <h2>Login</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="username">Username:</label>
          <input
            type="text"
            id="username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </div>
        <div>
          <label htmlFor="password">Password:</label>
          <input
            type="password"
            id="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <button type="submit">Login</button>
      </form>
    </div>
  );
};

export default Login;
