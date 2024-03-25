import { render, fireEvent } from "@testing-library/react";
import AlgorithmInputBox from "./AlgorithmInputBox";

describe("AlgorithmInputBox Component", () => {
  it("updates input value correctly", () => {
    const setCustomInputArrayMock = jest.fn();
    const setIsPlayingMock = jest.fn();

    const { container } = render(
      <AlgorithmInputBox
        setCustomInputArray={setCustomInputArrayMock}
        setIsPlaying={setIsPlayingMock}
      />
    );

    const input = container.querySelector(
      'input[name="inputs"]'
    ) as HTMLInputElement;

    fireEvent.change(input, { target: { value: "1, 2, 3" } });

    expect(input.value).toBe("1, 2, 3");
  });

  it("submits input correctly", () => {
    const setCustomInputArrayMock = jest.fn();
    const setIsPlayingMock = jest.fn();

    const { container } = render(
      <AlgorithmInputBox
        setCustomInputArray={setCustomInputArrayMock}
        setIsPlaying={setIsPlayingMock}
      />
    );

    const input = container.querySelector(
      'input[name="inputs"]'
    ) as HTMLInputElement;
    const submitButton = container.querySelector('button[type="submit"]');

    fireEvent.change(input, { target: { value: "1, 2, 3" } });
    fireEvent.click(submitButton!);

    expect(setCustomInputArrayMock).toHaveBeenCalledWith([1, 2, 3]);
    expect(setIsPlayingMock).toHaveBeenCalledWith(false);
  });

  it("displays error message for invalid input", () => {
    const setCustomInputArrayMock = jest.fn();
    const setIsPlayingMock = jest.fn();

    const { container } = render(
      <AlgorithmInputBox
        setCustomInputArray={setCustomInputArrayMock}
        setIsPlaying={setIsPlayingMock}
      />
    );

    const input = container.querySelector(
      'input[name="inputs"]'
    ) as HTMLInputElement;
    const submitButton = container.querySelector('button[type="submit"]');

    fireEvent.change(input, { target: { value: "abc" } });
    fireEvent.click(submitButton!);

    expect(setCustomInputArrayMock).not.toHaveBeenCalled();
    expect(setIsPlayingMock).toHaveBeenCalledWith(false);

    const errorMessage = container.querySelector("p") as HTMLParagraphElement;
    expect(errorMessage.textContent).toBe(
      "Please enter one or more positive numbers."
    );
  });
});
