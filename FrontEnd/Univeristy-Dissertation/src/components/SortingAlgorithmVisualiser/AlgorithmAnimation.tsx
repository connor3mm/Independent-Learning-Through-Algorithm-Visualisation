import React, { useEffect, useState, useRef } from "react";
import Chart from "chart.js/auto";
import "./AlgorithmAnimation.css";

interface AlgorithmAnimationProps {
  states: number[][];
  speed: number;
  isPlaying: boolean;
}

const AlgorithmAnimation: React.FC<AlgorithmAnimationProps> = ({
  states,
  speed,
  isPlaying,
}) => {
  const [currentStep, setCurrentStep] = useState(0);
  const chartRef = useRef<HTMLCanvasElement | null>(null);
  const chartInstance = useRef<Chart | null>(null);

  useEffect(() => {
    let animation: NodeJS.Timeout;

    const playAnimation = () => {
      if (isPlaying && currentStep < states.length - 1) {
        animation = setTimeout(() => {
          setCurrentStep((prevStep) => prevStep + 1);
        }, speed);
      }
    };

    playAnimation();

    return () => {
      clearTimeout(animation);
    };
  }, [currentStep, states, speed, isPlaying]);

  useEffect(() => {
    if (chartRef.current && states[currentStep]) {
      if (chartInstance.current) {
        chartInstance.current.data.labels = states[currentStep].map(String);
        chartInstance.current.data.datasets[0].data = states[currentStep];
        chartInstance.current.update();
      } else {
        const ctx = chartRef.current.getContext("2d");
        if (ctx) {
          chartInstance.current = new Chart(ctx, {
            type: "bar",
            data: {
              labels: states[currentStep].map(String),
              datasets: [
                {
                  label: "",
                  data: states[0],
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
  }, [currentStep, states]);

  return (
    <div className="sort-container">
      <h2>Bubble Sort Visualisation</h2>
      <canvas ref={chartRef} className="sort-chart"></canvas>
    </div>
  );
};

export default AlgorithmAnimation;
