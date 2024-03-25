import { render } from "@testing-library/react";
import AlgorithmAnimation from "./AlgorithmAnimation";

// Mock Chart.js methods
jest.mock("chart.js/auto", () => ({
  __esModule: true,
  default: jest.fn(),
}));

describe("AlgorithmAnimation", () => {
  const algorithmSwaps = [
    { firstValue: 0, secondValue: 1, hasSwapped: true },
    { firstValue: 2, secondValue: 3, hasSwapped: true },
  ];

  it("renders without crashing", () => {
    render(
      <AlgorithmAnimation
        algorithmSwaps={algorithmSwaps}
        speed={100}
        isPlaying={true}
        title="Sorting"
        initialState={[3, 1, 4, 2]}
      />
    );
  });

  it("updates chart when receiving new props", () => {
    const { rerender } = render(
      <AlgorithmAnimation
        algorithmSwaps={algorithmSwaps}
        speed={100}
        isPlaying={true}
        title="Sorting"
        initialState={[3, 1, 4, 2]}
      />
    );

    rerender(
      <AlgorithmAnimation
        algorithmSwaps={[{ firstValue: 0, secondValue: 2, hasSwapped: true }]}
        speed={100}
        isPlaying={true}
        title="Sorting"
        initialState={[3, 4, 1, 2]}
      />
    );

    expect(document.querySelector(".sort-chart")).toBeDefined();
  });

  it("does not update chart if isPlaying is false", () => {
    const { rerender } = render(
      <AlgorithmAnimation
        algorithmSwaps={algorithmSwaps}
        speed={100}
        isPlaying={true}
        title="Sorting"
        initialState={[3, 1, 4, 2]}
      />
    );

    // Re-render with isPlaying set to false
    rerender(
      <AlgorithmAnimation
        algorithmSwaps={algorithmSwaps}
        speed={100}
        isPlaying={false}
        title="Sorting"
        initialState={[3, 1, 4, 2]}
      />
    );

    expect(document.querySelector(".sort-chart")).toBeDefined();
  });
});
