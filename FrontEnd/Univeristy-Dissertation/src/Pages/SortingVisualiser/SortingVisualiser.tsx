import { useEffect, useState } from "react";
import viteLogo from "/vite.svg";
import { bubbleSort } from "../../api/ApiEndpoints";
import { useNavigate } from "react-router-dom";
import BubbleSortAnimation from "./BubbleSort/BubbleSort";


function SortingVisualiser() {
  const [isLoading, setLoading] = useState<boolean>(true);
  const [bubbleData, setBubbleData] = useState<number[][]>([]);
  const origin = window.location.origin;
  const navigate = useNavigate();

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
          <div>
            <p>Origin: {origin}</p>
          </div>
          <div className="card">
          <BubbleSortAnimation states={bubbleData} />
         
          </div>
        </>
      )}
    </>
  );
}

export default SortingVisualiser;