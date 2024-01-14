import React, { useState } from "react";

function AlgorithmInputBox({
  setCustomInputArray,
}: {
  setCustomInputArray: React.Dispatch<React.SetStateAction<number[]>>;
}) {
  const [customInput, setCustomInput] = useState<string>("");
  const [errorMessage, setErrorMessage] = useState<string>("");

  const handleCustomInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setCustomInput(e.target.value);
  };

  const handleCustomInputSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const inputArray = customInput
      .split(/[,\s]+/)
      .filter((num) => !isNaN(Number(num)) && Number(num) >= 0)
      .map((num) => Number(num));

    if (inputArray.length < 2) {
      setErrorMessage("Please enter one or more postive numbers.");
    } else {
      setErrorMessage("");
      setCustomInputArray(inputArray);
    }
  };

  return (
    <div className="customInputs">
      <h2>Custom Input values:</h2>
      <label>
        Please separate numbers by a comma or space. Any other inputs will be
        ignored.
      </label>
      <form onSubmit={handleCustomInputSubmit}>
        <input
          type="text"
          name="inputs"
          value={customInput}
          onChange={handleCustomInputChange}
        />
        <button type="submit">Submit</button>
      </form>
      {errorMessage && <p style={{ color: "red" }}>{errorMessage}</p>}
    </div>
  );
}

export default AlgorithmInputBox;
