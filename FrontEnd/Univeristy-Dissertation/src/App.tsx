import { useEffect, useState } from "react";
import viteLogo from "/vite.svg";
import "./App.css";
import { apiTester, apiTesterAddOne, bubbleSort } from "./api/ApiEndpoints";
import WeatherForecast from "./models/WeatherForecast";

function App() {
  const [count, setCount] = useState(0);
  const [isLoading, setLoading] = useState<boolean>(true);
  const [weatherForecast, setWeatherForecast] = useState<WeatherForecast[]>([]);
  const [bubbleData, setBubbleData] = useState<number[]>([]);
  const origin = window.location.origin;
  
  
  useEffect(() => {
 
    async function fetchData() {
      try {
        await apiTester()
        .then((data) => {
          setWeatherForecast(data); 
          setLoading(false);
          console.log(data);
        });
      } catch (error) {
         setLoading(false);
      }
    }
    fetchData();
  
  
  
  async function fetchBubbleData() {
    try {
      await bubbleSort()
      .then((data) => {
        setBubbleData(data); 
        setLoading(false);
        console.log(data);
      });
    } catch (error) {
       setLoading(false);
    }
  }
  fetchBubbleData();
}, []);

  async function addOne(count: number) {
    try {
      setCount(await apiTesterAddOne(count));
    } catch (error) {
      setLoading(false);
    }
  }

  return (
    <>
      {isLoading ? (
        <div className="loading">Loading...</div>
      ) : (
        <>
          <div>
          <p>Origin: {origin}</p>
            <a href="https://vitejs.dev" target="_blank">
              <img src={viteLogo} className="logo" alt="Vite logo" />
            </a>
            <a href="https://react.dev" target="_blank"></a>
          </div>
          <h1>Vite + React</h1>
          <div className="card">
            <button onClick={() => addOne(count)}>count is {count}</button>
          </div>
          
          <ul>
         {weatherForecast.map((item, index) => (
             <li key={index}>
             <strong>Date:</strong> {item.date}
              <br />
              <strong>summary:</strong> {item.summary}
              <br />
              <strong>temperatureC:</strong> {item.temperatureC}
              <br />
              <strong>temperatureF:</strong> {item.temperatureF}
              <br />
              <br /> 
              <br />
            </li>
        ))}
      </ul>
        </>
      )}
    </>
  )
}

export default App;
