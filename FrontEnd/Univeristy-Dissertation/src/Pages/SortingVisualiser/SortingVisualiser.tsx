import { useEffect, useState } from "react";
import viteLogo from "/vite.svg";
import { apiTester, apiTesterAddOne, bubbleSort } from "../../api/ApiEndpoints";
import WeatherForecast from "../../models/WeatherForecast";
import { useNavigate } from "react-router-dom";


function SortingVisualiser() {
  const [count, setCount] = useState(0);
  const [isLoading, setLoading] = useState<boolean>(true);
  const [weatherForecast, setWeatherForecast] = useState<WeatherForecast[]>([]);
  const [bubbleData, setBubbleData] = useState<number[]>([]);
  const origin = window.location.origin;
  const navigate = useNavigate();

  useEffect(() => {
    async function fetchData() {
      setLoading(true);
      try {
        await apiTester().then((data) => {
          setWeatherForecast(data);
          console.log(data);
        });
      } catch (error) {}
    }

    fetchData();
    setLoading(false);

    async function fetchBubbleData() {
        const numbers = [5, 2, 9, 1, 5, 6];
      setLoading(true);
      try {
        await bubbleSort(numbers).then((data) => {
          setBubbleData(data);
          console.log(data);
        });
      } catch (error) {}
    }

    fetchBubbleData();
    setLoading(false);
  }, []);

  async function addOne(count: number) {
    try {
      setCount(await apiTesterAddOne(count));
    } catch (error) {
      setLoading(false);
    }
  }

  const navigate2 = () => {
    // Navigate to another page
    navigate('/sortingVisualiser'); // Replace '/another-page' with the path of the page you want to navigate to
  };

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
          <button onClick={navigate2}>Go to Another Page</button>
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
  );
}

export default SortingVisualiser;