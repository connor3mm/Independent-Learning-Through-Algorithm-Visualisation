import { useEffect, useState } from "react";
import { bubbleSort } from "../../api/ApiEndpoints";
import SortAnimation from "../../components/SortingAlgorithmVisualiser/AlgorithmAnimation";
import "./SortingVisualiser.css";

function SortingVisualiser() {
  const [isLoading, setLoading] = useState<boolean>(true);
  const [bubbleData, setBubbleData] = useState<number[][]>([]);
  const [speed, setSpeed] = useState<number>(1000);
  const [isPlaying, setIsPlaying] = useState<boolean>(false);
  const numbers = [5, 2, 9, 1, 5, 6];

  useEffect(() => {
    setLoading(false);
    handleBubbleSort(numbers);
  }, []);

  const handleBubbleSort = (input: any) => {
    setLoading(true);
    async function fetchBubbleData() {
      try {
        await bubbleSort(input).then((data) => {
          setBubbleData(data);
        });
      } catch (error) {}
    }

    fetchBubbleData();
    setLoading(false);
  };

  const handleSpeedChange = (newSpeed: number) => {
    setSpeed(newSpeed);
  };

  const handlePlayButtonClick = () => {
    setIsPlaying(true);
  };

  const reset = () => {
    setIsPlaying(false);
    handleBubbleSort(numbers);
  };

  return (
    <>
      {isLoading ? (
        <div className="loading">Loading...</div>
      ) : (
        <>
          <div className="sortAnimationContainer">
            <div className="visualisationContainer">
              <SortAnimation
                states={bubbleData}
                speed={speed}
                isPlaying={isPlaying}
              />
            </div>
            <div className="visualisationControlsContainer">
              <div className="controls">
                <h2>Controls</h2>

                <div>
                  <label>
                    Slow
                    <input
                      type="checkbox"
                      checked={speed === 1500}
                      onChange={() => handleSpeedChange(1500)}
                    />
                  </label>
                  <label>
                    Medium
                    <input
                      type="checkbox"
                      checked={speed === 1000}
                      onChange={() => handleSpeedChange(1000)}
                    />
                  </label>
                  <label>
                    Fast
                    <input
                      type="checkbox"
                      checked={speed === 500}
                      onChange={() => handleSpeedChange(500)}
                    />
                  </label>
                </div>
                <button onClick={handlePlayButtonClick}>Play</button>
                <button onClick={reset}>Reset</button>
                <div>
                  <select className="dropBox">
                    <option value="bubbleSort">Bubble Sort</option>
                    <option value="selectionSort">Selection Sort</option>
                    <option value="insertionSort">Insertion Sort</option>
                    <option value="quickSort">Quick Sort</option>
                    <option value="mergeSort">Merge Sort</option>
                  </select>
                </div>
              </div>

              <div className="customInputs">
                <h2>Custom Input values:</h2>
                <form>
                  <input type="text" name="inputs"></input>
                </form>
              </div>
            </div>
          </div>
        </>
      )}
    </>
  );
}

export default SortingVisualiser;
