import { useEffect, useState } from "react";
import { bubbleSort } from "../../api/ApiEndpoints";
import SortAnimation from "../../components/SortingAlgorithmVisualiser/AlgorithmAnimation";
import "./SortingVisualiser.css"


function SortingVisualiser() {
  const [isLoading, setLoading] = useState<boolean>(true);
  const [bubbleData, setBubbleData] = useState<number[][]>([]);

  useEffect(() => {
    setLoading(false)
    handleBubbleSort()
  }, []);


const handleBubbleSort = () => {
    async function fetchBubbleData() {
      const numbers = [5, 2, 9, 1, 5, 6];
    setLoading(true);
    try {
      await bubbleSort(numbers).then((data) => {
        setBubbleData(data);
      });
    } catch (error) {}
  }

  fetchBubbleData();
  setLoading(false);
  };


  return (
    <>
      {isLoading ? (
        <div className="loading">Loading...</div>
      ) : (
        <>
          <div className="sortAnimationContainer">
            <div className="algorithmBox"> 
          <SortAnimation states={bubbleData} />
          </div>
          <div className="algorithmBox"> 
          </div>
          </div>
        </>
      )}
    </>
  );
}

export default SortingVisualiser;