import { render, fireEvent } from "@testing-library/react";
import ProficiencyQuiz from "./ProficiencyQuiz";

// Mocking API endpoint function
jest.mock("../../services/api/ApiEndpoints", () => ({
  updateProficencyLevel: jest.fn(),
}));

describe("ProficiencyQuiz Component", () => {
  it("renders without crashing", () => {
    const { getByText } = render(<ProficiencyQuiz />);
    const headerElement = getByText(/Question: 1 out of 5/i);
    expect(headerElement).toBeTruthy();
  });

  it("allows the user to answer questions and complete the quiz", () => {
    const { getByText, getByTestId } = render(<ProficiencyQuiz />);
    const nextButton = getByText(/Next/i);

    // Answering questions
    fireEvent.click(getByText(/Little knowledge/i)); // Answering the first question
    fireEvent.click(nextButton); // Moving to the next question

    fireEvent.click(getByText(/Expert/i)); // Answering the second question
    fireEvent.click(nextButton); // Moving to the next question

    fireEvent.click(getByText(/Expert/i)); // Answering the third question
    fireEvent.click(nextButton); // Moving to the next question

    fireEvent.click(getByText(/Expert/i)); // Answering the fourth question
    fireEvent.click(nextButton); // Moving to the next question

    fireEvent.click(getByText(/Very Confident/i)); // Answering the fifth question
    fireEvent.click(nextButton); // Completing the quiz

    // Assertion for completion message
    expect(getByTestId("success-message")).toBeTruthy();
  });

  it("shows error message if user tries to proceed without selecting an option", () => {
    const { getByText, getByTestId } = render(<ProficiencyQuiz />);
    const nextButton = getByText(/Next/i);

    // Trying to proceed without selecting an option
    fireEvent.click(nextButton);

    // Assertion for error message
    expect(getByTestId("error-message")).toBeTruthy();
  });
});
