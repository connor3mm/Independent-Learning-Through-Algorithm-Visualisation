import { useEffect, useState } from "react";
import { sortingAlgorithm } from "../../services/api/ApiEndpoints";
import SortAnimation from "../../components/AlgorithmAnimation/AlgorithmAnimation";
import "./SortingVisualiser.css";
import SortingAlgorithm from "../../services/enums/SortingAlgorithms";
import AlgorithmInputBox from "../../components/AlgorithmInputBox/AlgorithmInputBox";
import SpeedOptions from "../../components/SpeedOptions/SpeedOptions";
import Button from "@mui/material/Button";
import ButtonGroup from "@mui/material/ButtonGroup";

function SortingVisualiser() {
  const [isLoading, setLoading] = useState<boolean>(true);
  const [speed, setSpeed] = useState<number>(1000);
  const [isPlaying, setIsPlaying] = useState<boolean>(false);

  const [customInputArray, setCustomInputArray] = useState<number[]>([
    5, 2, 9, 1, 5, 6,
  ]);
  const [sortingData, setSortingData] = useState<number[][]>([]);
  const [secondSortingData, setSecondSortingData] = useState<number[][]>([]);

  const [selectedAlgorithm, setSelectedAlgorithm] =
    useState<string>("bubbleSort");
  const [secondSelectedAlgorithm, setSecondSelectedAlgorithm] =
    useState<string>("bubbleSort");
  const [showSecondVisualiser, setShowSecondVisualiser] =
    useState<boolean>(false);

  useEffect(() => {
    setLoading(false);
    handleSortingAlgorithmChange(selectedAlgorithm);
    handleSecondSortingAlgorithmChange(secondSelectedAlgorithm);
  }, [selectedAlgorithm, secondSelectedAlgorithm, customInputArray]);

  const handleSortingAlgorithmChange = (algorithm: string) => {
    setLoading(true);
    async function fetchData() {
      try {
        await sortingAlgorithm(algorithm, customInputArray).then((data) => {
          setSortingData(data);
        });
      } catch (error) {
      } finally {
        setLoading(false);
      }
    }

    fetchData();
  };

  const handleSecondSortingAlgorithmChange = (algorithm: string) => {
    setLoading(true);
    async function fetchData() {
      try {
        await sortingAlgorithm(algorithm, customInputArray).then((data) => {
          setSecondSortingData(data);
        });
      } catch (error) {
      } finally {
        setLoading(false);
      }
    }
    fetchData();
  };

  const handleSpeedChange = (newSpeed: number) => {
    setSpeed(newSpeed);
  };

  const handlePlayButtonClick = () => {
    reset();
    setIsPlaying(true);
  };

  const reset = () => {
    setIsPlaying(false);
    handleSortingAlgorithmChange(selectedAlgorithm);
    handleSecondSortingAlgorithmChange(secondSelectedAlgorithm);
  };

  const handleAlgorithmChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    setSelectedAlgorithm(e.target.value);
    setIsPlaying(false);
  };

  const handleSecondAlgorithmChange = (
    e: React.ChangeEvent<HTMLSelectElement>
  ) => {
    setSecondSelectedAlgorithm(e.target.value);
    setIsPlaying(false);
  };

  const toggleSecondVisualiser = () => {
    reset();
    setShowSecondVisualiser(!showSecondVisualiser);
  };

  const renderVisualisationContainer = (
    algorithm: any,
    key: any,
    sortedData: any
  ) => (
    <div className="visualisationContainer" key={key}>
      <SortAnimation
        states={sortedData}
        speed={speed}
        isPlaying={isPlaying}
        title={SortingAlgorithm[algorithm as keyof typeof SortingAlgorithm]}
      />
    </div>
  );

  const renderDropdown = (value: any, onChange: any) => (
    <select className="dropBox" value={value} onChange={onChange}>
      <option value="bubbleSort">{SortingAlgorithm.bubbleSort}</option>
      <option value="selectionSort">{SortingAlgorithm.selectionSort}</option>
      <option value="insertionSort">{SortingAlgorithm.insertionSort}</option>
      <option value="mergeSort">{SortingAlgorithm.mergeSort}</option>
      <option value="quickSort">{SortingAlgorithm.quickSort}</option>
      <option value="shellSort">{SortingAlgorithm.shellSort}</option>
      <option value="bubbleSort" disabled hidden></option>
    </select>
  );

  return (
    <>
      {isLoading ? (
        <div className="loading">Loading...</div>
      ) : (
        <>
          <div className="sortAnimationContainer">
            {/* First Visualiser */}
            {renderVisualisationContainer(selectedAlgorithm, 1, sortingData)}
            {/* First Visualiser */}
            {showSecondVisualiser &&
              renderVisualisationContainer(
                secondSelectedAlgorithm,
                2,
                secondSortingData
              )}

            {/* Algorithm Controls  */}
            <div className="visualisationControlsContainer">
              <div className="controls">
                <h2>Controls</h2>

                <div>
                  <div>Algorithm One</div>
                  {renderDropdown(selectedAlgorithm, handleAlgorithmChange)}
                </div>

                {showSecondVisualiser && (
                  <div>
                    <div>Algorithm Two</div>
                    {renderDropdown(
                      secondSelectedAlgorithm,
                      handleSecondAlgorithmChange
                    )}
                  </div>
                )}

                <SpeedOptions
                  speed={speed}
                  handleSpeedChange={handleSpeedChange}
                />
                <ButtonGroup
                  variant="contained"
                  aria-label="outlined primary button group"
                >
                  <Button onClick={handlePlayButtonClick}>Play</Button>
                  <Button onClick={reset}>Reset</Button>
                </ButtonGroup>
                <Button variant="outlined" onClick={toggleSecondVisualiser}>
                  {showSecondVisualiser ? "Hide Compare" : "Compare Algorithms"}
                </Button>
              </div>
              <AlgorithmInputBox
                setCustomInputArray={setCustomInputArray}
                setIsPlaying={setIsPlaying}
              />
            </div>
          </div>
        </>
      )}
    </>
  );
}

export default SortingVisualiser;
