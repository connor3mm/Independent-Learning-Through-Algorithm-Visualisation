import React, { useEffect, useState, useRef } from "react";
import Chart from "chart.js/auto";
import "./AlgorithmAnimation.css";

interface AlgorithmAnimationProps {
  algorithmSwaps: AlgorithmSwaps[];
  speed: number;
  isPlaying: boolean;
  title: string;
  initialState: number[];
}

const AlgorithmAnimation: React.FC<AlgorithmAnimationProps> = ({
  algorithmSwaps,
  speed,
  isPlaying,
  title,
  initialState,
}) => {
  const [currentStep, setCurrentStep] = useState(0);
  const chartRef = useRef<HTMLCanvasElement | null>(null);
  const chartInstance = useRef<Chart | null>(null);
  const [currentState, setCurrentState] = useState<number[]>(initialState);

  useEffect(() => {
    let animation: NodeJS.Timeout;

    const playAnimation = () => {
      if (currentStep < algorithmSwaps.length - 1) {
        animation = setTimeout(() => {
          setCurrentStep((prevStep) => prevStep + 1);
        }, speed + 100);
      }
    };

    if (isPlaying) {
      playAnimation();
    }

    return () => {
      clearTimeout(animation);
    };
  }, [currentStep, speed, isPlaying]);

  //CHART.JS bar char - Modified code to suit this project
  useEffect(() => {
    if (chartRef.current && currentState) {
      if (chartInstance.current) {
        // Update chart data
        chartInstance.current.data.labels = currentState.map(String);
        chartInstance.current.data.datasets[0].data = currentState;
        chartInstance.current.update();
      } else {
        // Create new chart instance
        const context = chartRef.current.getContext("2d");
        if (context) {
          chartInstance.current = new Chart(context, {
            type: "bar",
            data: {
              labels: initialState.map(String),
              datasets: [
                {
                  label: "",
                  data: currentState,
                  backgroundColor: "rgba(54, 162, 235, 0.5)",
                  borderColor: "rgba(54, 162, 235, 1)",
                  borderWidth: 1,
                },
              ],
            },
            options: {
              indexAxis: "x",

              scales: {
                y: {
                  display: false,
                },
                x: {
                  grid: {
                    color: "#1c163a",
                  },
                  ticks: {
                    color: "#FFFF",
                    font: {
                      size: 20,
                    },
                  },
                },
              },
              plugins: {
                legend: {
                  display: false,
                },
                tooltip: {
                  enabled: false,
                },
              },
            },
          });
        }
      }
    }
  }, [currentStep, initialState, algorithmSwaps]);

  useEffect(() => {
    if (chartRef.current && currentState && isPlaying) {
      let updatedValues = [...currentState];

      const { firstValue, secondValue, hasSwapped } =
        algorithmSwaps[currentStep];

      // Swap values
      if (hasSwapped) {
        const temp = updatedValues[firstValue];
        updatedValues[firstValue] = updatedValues[secondValue];
        updatedValues[secondValue] = temp;
      }

      setCurrentState(updatedValues);

      if (chartInstance.current) {
        chartInstance.current.data.labels = updatedValues.map(String);
        chartInstance.current.data.datasets[0].data = updatedValues;
        chartInstance.current.data.datasets[0].backgroundColor =
          updatedValues.map(
            (_value, index) =>
              index === firstValue || index === secondValue
                ? hasSwapped
                  ? "rgba(0, 255, 0, 0.5)" // Green color for bars swapped
                  : "rgba(255, 0, 0, 0.5)" // Red color for bars not swapped
                : "rgba(54, 162, 235, 0.5)" // Default color for other bars
          );
        chartInstance.current.update(); // Update the chart
      }
    }
  }, [currentStep]);

  return (
    <div className="sort-container">
      <h2>{title} Visualisation</h2>
      <canvas ref={chartRef} className="sort-chart"></canvas>
    </div>
  );
};

export default AlgorithmAnimation;
