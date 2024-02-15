import { useEffect, useState } from "react";
import "./LearningZone.css";
import SortingAlgorithm from "../../services/enums/SortingAlgorithms";

const LearningZone: React.FC = () => {
  const [infoFlag, setInfoFlag] = useState(false);
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

  const [infoDescription, setInfoDescription] = useState<{
    description: string;
    complexityDescription: string;
  }>({
    description: "Default Info Description",
    complexityDescription: "Default Complexity Description",
  });

  const renderTextLines = (text: string) => {
    return text.split("\n").map((line, index) => <p key={index}>{line}</p>);
  };

  useEffect(() => {
    fetch(`src/components/AlgorithmDescriptions/Default Descriptions.txt`)
      .then((response) => response.text())
      .then((data) => {
        const parsedData = JSON.parse(data);
        setInfoDescription(parsedData);

        setInfoFlag(false);
      })
      .catch((err) => console.error(err));
  }, []);

  const algorithmClickHandler = (algorithm: string) => {
    const filePath = `src/components/AlgorithmDescriptions/${algorithm}.txt`;

    fetch(filePath)
      .then((response) => response.text())
      .then((data) => {
        const parsedData = JSON.parse(data);
        setComplexityInfo(parsedData);
        setInfoFlag(true);
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
          onClick={() => algorithmClickHandler(SortingAlgorithm.heapSort)}
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
                {infoFlag ? (
                  <div className="description">
                    {renderTextLines(complexityInfo?.description)}
                  </div>
                ) : (
                  <div className="description">
                    {renderTextLines(infoDescription?.description)}
                  </div>
                )}
              </div>
              <div className="separator"></div>
              <div className="learningZoneComplexity">
                <h2 className="infoTitle">Complexity</h2>
                <div className="description">
                  {infoFlag ? (
                    <>
                      <table className="complexityTable">
                        <tr>
                          <td>Average Complexity:</td>
                          <td>{complexityInfo?.averageComplexity}</td>
                        </tr>
                        <tr>
                          <td>Best Case:</td>
                          <td>{complexityInfo?.bestCase}</td>
                        </tr>
                        <tr>
                          <td>Worst Case:</td>
                          <td>{complexityInfo?.worstCase}</td>
                        </tr>
                        <tr>
                          <td>Space Complexity:</td>
                          <td>{complexityInfo?.spaceComplexity}</td>
                        </tr>
                      </table>
                    </>
                  ) : (
                    <div>
                      {renderTextLines(infoDescription?.complexityDescription)}
                    </div>
                  )}
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
