import { useState } from "react";
import "./LearningZone.css";
import SortingAlgorithm from "../../services/enums/SortingAlgorithms";

const LearningZone: React.FC = () => {
  const [complexityInfo, setComplexityInfo] = useState<{
    description: string;
    averageComplexity: string;
    bestCase: string;
    worstCase: string;
    spaceComplexity: string;
  }>({
    description: "Default Description",
    averageComplexity: "Default Average Complexity",
    bestCase: "Default Best Case",
    worstCase: "Default Worst Case",
    spaceComplexity: "Default Space Complexity",
  });

  const algorithmClickHandler = (algorithm: string) => {
    const filePath = `src/components/AlgorithmComplexities/${algorithm}.txt`;

    fetch(filePath)
      .then((response) => response.text())
      .then((data) => {
        const parsedData = JSON.parse(data);
        console.log(parsedData);
        setComplexityInfo(parsedData);
      })
      .catch((err) => console.error(err));
  };

  return (
    <div className="learningContainer">
      <div className="vertical-menu">
        <h3 className="learningZoneHeader">Sorting Algorithms</h3>
        <a
          href="#"
          className="info"
          onClick={() => algorithmClickHandler(SortingAlgorithm.bubbleSort)}
        >
          Bubble Sort
        </a>
        <a
          href="#"
          className="info"
          onClick={() => algorithmClickHandler(SortingAlgorithm.selectionSort)}
        >
          Selection Sort
        </a>
        <a
          href="#"
          className="info"
          onClick={() => algorithmClickHandler(SortingAlgorithm.insertionSort)}
        >
          Insertion Sort
        </a>
        <a
          href="#"
          className="info"
          onClick={() => algorithmClickHandler(SortingAlgorithm.mergeSort)}
        >
          Merge Sort
        </a>
        <a
          href="#"
          className="info"
          onClick={() => algorithmClickHandler(SortingAlgorithm.quickSort)}
        >
          Quick Sort
        </a>
        <a
          href="#"
          className="info"
          onClick={() => algorithmClickHandler(SortingAlgorithm.shellSort)}
        >
          Shell Sort
        </a>
        <a
          href="#"
          className="info"
          onClick={() => algorithmClickHandler(SortingAlgorithm.heapsort)}
        >
          Heap Sort
        </a>
        <h3>Searching Algortithms</h3>
        <a
          href="#"
          className="info"
          onClick={() => algorithmClickHandler("Bubble Sort")}
        >
          Linear Search
        </a>
        <a
          href="#"
          className="info"
          onClick={() => algorithmClickHandler("Bubble Sort")}
        >
          Binary Search
        </a>
      </div>
      <div className="learningZone">
        <div className="learningZoneContainer">
          <div className="learningZoneInsideContainer">
            <h2 className="learningHeader">Learning Zone</h2>

            <div className="learningZoneDescriptionContainer">
              <div className="learningZoneDescription">
                <h2 className="infoTitle">Description</h2>
                <div>{complexityInfo?.description}</div>
              </div>
              <div className="learningZoneComplexity">
                <h2 className="infoTitle">Complexity</h2>
                <div>
                  <p>Average Complexity: {complexityInfo?.averageComplexity}</p>
                  <p>Best Case: {complexityInfo?.bestCase}</p>
                  <p>Worst Case: {complexityInfo?.worstCase}</p>
                  <p>Space Complexity: {complexityInfo?.spaceComplexity}</p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default LearningZone;
