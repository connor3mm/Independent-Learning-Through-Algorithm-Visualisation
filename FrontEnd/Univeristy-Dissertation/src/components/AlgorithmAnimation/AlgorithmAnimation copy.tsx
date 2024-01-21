import React, { useEffect, useState, useRef } from "react";
import Chart from "chart.js/auto";
import "./AlgorithmAnimation.css";

interface AlgorithmAnimationProps {
  swaps: [number, number][];
  initialArray: number[];
  speed: number;
  isPlaying: boolean;
  title: any;
}

const AlgorithmAnimation: React.FC<AlgorithmAnimationProps> = ({
  swaps,
  initialArray,
  speed,
  isPlaying,
  title,
}) => {
  const [currentStep, setCurrentStep] = useState(0);
  const chartRef = useRef<HTMLCanvasElement | null>(null);
  const chartInstance = useRef<Chart | null>(null);

  useEffect(() => {
    let animation: NodeJS.Timeout;

    const playAnimation = () => {
      if (isPlaying && currentStep < swaps.length) {
        animation = setTimeout(() => {
          setCurrentStep((prevStep) => prevStep + 1);
        }, speed);
      }
    };

    playAnimation();

    return () => {
      clearTimeout(animation);
    };
  }, [currentStep, swaps, speed, isPlaying]);

  useEffect(() => {
    if (chartRef.current) {
      const currentArray = initialArray.slice(); // Copy the initial array
      const [index1, index2] = swaps[currentStep] || [-1, -1]; // Default values if no swaps

      // Perform the swap if indices are valid
      if (index1 !== -1 && index2 !== -1) {
        const temp = currentArray[index1];
        currentArray[index1] = currentArray[index2];
        currentArray[index2] = temp;
      }

      if (chartInstance.current) {
        chartInstance.current.data.labels = currentArray.map(String);
        chartInstance.current.data.datasets[0].data = currentArray;
        chartInstance.current.update();
      } else {
        const context = chartRef.current.getContext("2d");
        if (context) {
          chartInstance.current = new Chart(context, {
            type: "bar",
            data: {
              labels: currentArray.map(String),
              datasets: [
                {
                  label: "",
                  data: currentArray,
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
  }, [currentStep, swaps, initialArray]);

  return (
    <div className="sort-container">
      <h2>{title} Visualization</h2>
      <canvas ref={chartRef} className="sort-chart"></canvas>
    </div>
  );
};

export default AlgorithmAnimation;
