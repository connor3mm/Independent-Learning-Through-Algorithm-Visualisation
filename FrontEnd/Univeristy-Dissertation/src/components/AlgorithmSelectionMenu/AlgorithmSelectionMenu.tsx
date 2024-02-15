import * as React from "react";
import FormControl from "@mui/material/FormControl";
import InputLabel from "@mui/material/InputLabel";
import MenuItem from "@mui/material/MenuItem";
import Select, { SelectChangeEvent } from "@mui/material/Select";

const SortingAlgorithm = {
  bubbleSort: "Bubble Sort",
  selectionSort: "Selection Sort",
  insertionSort: "Insertion Sort",
  mergeSort: "Merge Sort",
  quickSort: "Quick Sort",
  shellSort: "Shell Sort",
  heapSort: "Heap Sort",
};

const AlgorithmSelectionMenu = () => {
  const [selectedAlgorithm, setSelectedAlgorithm] = React.useState("");

  const handleAlgorithmChange = (event: SelectChangeEvent) => {
    setSelectedAlgorithm(event.target.value as string);
  };

  return (
    <div>
      <FormControl variant="filled" sx={{ m: 1, minWidth: 120 }}>
        <InputLabel id="algorithm-select-label">Sorting Algorithm</InputLabel>
        <Select
          labelId="algorithm-select-label"
          id="algorithm-select"
          value={selectedAlgorithm}
          onChange={handleAlgorithmChange}
        >
          <MenuItem value="" disabled>
            <em>None</em>
          </MenuItem>
          {Object.values(SortingAlgorithm).map((algorithm) => (
            <MenuItem key={algorithm} value={algorithm}>
              {algorithm}
            </MenuItem>
          ))}
        </Select>
      </FormControl>
    </div>
  );
};

export default AlgorithmSelectionMenu;
