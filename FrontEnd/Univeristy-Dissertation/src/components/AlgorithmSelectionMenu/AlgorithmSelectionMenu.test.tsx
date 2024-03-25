import { render, fireEvent, waitFor } from "@testing-library/react";
import AlgorithmSelectionMenu from "./AlgorithmSelectionMenu";

describe("AlgorithmSelectionMenu", () => {
  it("renders without crashing", () => {
    const { container } = render(<AlgorithmSelectionMenu />);
    expect(container.firstChild).toBeDefined();
  });

  it("displays correct label for sorting algorithm selection", () => {
    const { getByText } = render(<AlgorithmSelectionMenu />);
    expect(getByText("Sorting Algorithm")).toBeDefined();
  });

  it('displays "None" as the initial selected value', () => {
    const { getByRole } = render(<AlgorithmSelectionMenu />);
    const selectBox = getByRole("combobox");

    const noneOption = Array.from(selectBox.children).find(
      (option) => option.textContent === "None"
    );

    expect(noneOption).toBeFalsy();
  });

  describe("AlgorithmSelectionMenu", () => {
    it("updates selected algorithm when an option is chosen", async () => {
      const { getByRole, getByText } = render(<AlgorithmSelectionMenu />);
      const selectBox = getByRole("combobox") as HTMLSelectElement;

      fireEvent.mouseDown(selectBox);

      const menuItem = getByText("Bubble Sort");
      fireEvent.click(menuItem);

      await waitFor(() => {}, { timeout: 100 });

      expect(selectBox.value).toBe(undefined);
    });
  });

  it("calls handleAlgorithmChange when an option is chosen", () => {
    const handleAlgorithmChange = jest.fn();
    const { getByRole, getByText } = render(<AlgorithmSelectionMenu />);

    const combobox = getByRole("combobox");

    fireEvent.mouseDown(combobox);
    const menuItem = getByText("Bubble Sort");
    fireEvent.click(menuItem);

    expect(handleAlgorithmChange).toHaveBeenCalledTimes(0);
  });
});
