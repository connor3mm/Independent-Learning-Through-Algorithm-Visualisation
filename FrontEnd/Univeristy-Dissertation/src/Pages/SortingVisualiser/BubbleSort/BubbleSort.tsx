import React, { useEffect, useState } from 'react';
import './BubbleSort.css';

interface BubbleSortAnimationProps {
  states: number[][];
}

const BubbleSortAnimation: React.FC<BubbleSortAnimationProps> = ({ states }) => {
  const [currentStep, setCurrentStep] = useState(0);

  useEffect(() => {
    let animation: NodeJS.Timeout;

    const playAnimation = () => {
      if (currentStep < states.length - 1) {
        animation = setTimeout(() => {
          setCurrentStep(prevStep => prevStep + 1);
        }, 1000); // Interval Duration, maybe find a calculation for longer lists 
      }
    };

    playAnimation();

    return () => {
      clearTimeout(animation);
    };
  }, [currentStep, states]);

  return (
    <div className="bubble-sort-container">
      <h2>Bubble Sort Visualization</h2>
      {states.length > 0 && (
        <div className="bubble-sort-state">
          {states[currentStep].map((value, index) => (
            <div key={index} className="sort-bar">
              {value}
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default BubbleSortAnimation;
