import { Line } from "react-chartjs-2";
import "./ProgressionChart.css";
import { useEffect, useState } from "react";
import { lastFiveGamesStatistics } from "../../services/api/ApiEndpoints";

interface LastFiveGames {
  id: number;
  score: number;
  quizLength: number;
  createdOn: Date;
}

const ProgressionChart = () => {
  const [lastFiveGamesData, setLastFiveGamesData] = useState<LastFiveGames[]>(
    []
  );

  useEffect(() => {
    const loggedInUser = localStorage.getItem("loggedInUser");

    if (loggedInUser) {
      async function fetchLastFiveGames() {
        try {
          await lastFiveGamesStatistics().then((data) => {
            setLastFiveGamesData(data);
          });
        } catch (error) {}
      }
      fetchLastFiveGames();
    }
  }, []);

  const scoresArray = lastFiveGamesData.map((quiz) => quiz.score);
  const data = {
    labels: lastFiveGamesData.map(
      (game) =>
        `Quiz ${new Date(game.createdOn).toLocaleDateString("en-GB", {
          month: "2-digit",
          day: "2-digit",
        })}`
    ),
    datasets: [
      {
        label: "Last Five Quizzes",
        data: scoresArray,
        fill: true,
        backgroundColor: "#543bd3",
        borderColor: "rgba(75,192,192,1)",
      },
    ],
  };
  const options = {
    plugins: {
      legend: {
        labels: {
          color: "white",
        },
      },
    },
    scales: {
      x: {
        ticks: {
          color: "white",
        },
      },
      y: {
        ticks: {
          color: "white",
          stepSize: 1,
        },
        grid: {
          color: "rgba(255, 255, 255, 0.1)",
        },
        min: 0,
        max: Math.ceil(Math.max(...scoresArray)) + 1,
      },
    },
  };
  return (
    <div className="progressionLineChart">
      <Line data={data} options={options} />
    </div>
  );
};

export default ProgressionChart;
