import React, { useEffect, useState, useRef } from "react";
import Chart from "chart.js/auto";
import "./BubbleSort.css";

interface BubbleSortAnimationProps {
  states: number[][];
}

const BubbleSortAnimation: React.FC<BubbleSortAnimationProps> = ({
  states,
}) => {
  const [currentStep, setCurrentStep] = useState(0);
  const chartRef = useRef<HTMLCanvasElement | null>(null);
  const chartInstance = useRef<Chart | null>(null);

  useEffect(() => {
    let animation: NodeJS.Timeout;

    const playAnimation = () => {
      if (currentStep < states.length - 1) {
        animation = setTimeout(() => {
          setCurrentStep((prevStep) => prevStep + 1);
        }, 1000); // Interval Duration, maybe find a calculation for longer lists
      }
    };

    playAnimation();

    return () => {
      clearTimeout(animation);
    };
  }, [currentStep, states]);

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
                  label: "Bubble Sort Visualization",
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
    <div className="bubble-sort-container">
      <h2>Bubble Sort Visualization</h2>
      <canvas ref={chartRef} className="bubble-sort-chart"></canvas>
    </div>
  );
};

export default BubbleSortAnimation;
