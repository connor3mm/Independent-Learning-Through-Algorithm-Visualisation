import { render, fireEvent } from "@testing-library/react";
import Home from "./Home";

// Mocking useNavigate hook
jest.mock("react-router-dom", () => ({
  ...jest.requireActual("react-router-dom"),
  useNavigate: jest.fn(),
}));

describe("Home Component", () => {
  it("navigates to correct route when buttons are clicked", async () => {
    const mockedNavigate = jest.fn();
    (require("react-router-dom") as any).useNavigate.mockReturnValue(
      mockedNavigate
    );

    const { getByText } = render(<Home />);
    await new Promise((resolve) => setTimeout(resolve, 0));

    fireEvent.click(getByText("Sorting Visualiser"));
    expect(mockedNavigate).toHaveBeenCalledWith("/sortingVisualiser");

    fireEvent.click(getByText("My Profile"));
    expect(mockedNavigate).toHaveBeenCalledWith("/profile");

    fireEvent.click(getByText("Learning Zone"));
    expect(mockedNavigate).toHaveBeenCalledWith("/learningZone");

    fireEvent.click(getByText("Testing Zone"));
    expect(mockedNavigate).toHaveBeenCalledWith("/testingZone");
  });

  it("displays the correct alt text for the mascot image", () => {
    const { getByAltText } = render(<Home />);
    const mascotImage = getByAltText(
      "Sloth holding laptop - The Application Mascot"
    );
    expect(mascotImage).toBeDefined();
  });
});
