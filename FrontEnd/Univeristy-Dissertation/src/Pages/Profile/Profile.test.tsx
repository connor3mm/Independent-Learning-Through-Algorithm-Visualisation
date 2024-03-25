import { render, waitFor } from "@testing-library/react";
import Profile from "./Profile";
import { getProfile, getUserStatistics } from "../../services/api/ApiEndpoints";

// Mocking dependencies
jest.mock("react-router-dom", () => ({
  ...jest.requireActual("react-router-dom"),
  useNavigate: () => jest.fn(),
}));
jest.mock("../../services/api/ApiEndpoints", () => ({
  getProfile: jest.fn(),
  getUserStatistics: jest.fn(),
}));

describe("Profile Component", () => {
  it("displays profile information when profile is fetched", async () => {
    const mockedProfile = {
      email: "test@example.com",
      firstName: "John",
      lastName: "Doe",
      createdOn: "2024-03-22",
      proficiencyLevelId: 1,
    };
    const mockedUserStatistics = {
      totalScore: 100,
      totalQuestions: 20,
      gamesPlayed: 5,
      averageScore: 20,
      proficiencyScore: 80,
    };

    (getProfile as jest.Mock).mockResolvedValue(mockedProfile);
    (getUserStatistics as jest.Mock).mockResolvedValue(mockedUserStatistics);

    const { getByText } = render(<Profile />);

    waitFor(
      () => {
        expect(getByText("Profile")).toBeTruthy();
        expect(getByText(`Email: ${mockedProfile.email}`)).toBeTruthy();
        expect(
          getByText(`First Name: ${mockedProfile.firstName}`)
        ).toBeTruthy();
        expect(getByText(`Last Name: ${mockedProfile.lastName}`)).toBeTruthy();
        expect(
          getByText(`Account Created On: ${mockedProfile.createdOn}`)
        ).toBeTruthy();
        expect(
          getByText(`Games Played: ${mockedUserStatistics.gamesPlayed}`)
        ).toBeTruthy();
        expect(
          getByText(`Total Questions: ${mockedUserStatistics.totalQuestions}`)
        ).toBeTruthy();
        expect(
          getByText(`Total Score: ${mockedUserStatistics.totalScore}`)
        ).toBeTruthy();
        expect(
          getByText(
            `Average Score Per Game: ${mockedUserStatistics.averageScore}`
          )
        ).toBeTruthy();
      },
      { timeout: 200 }
    );
  });

  it('displays "Profile not found" when profile is not fetched', async () => {
    (getProfile as jest.Mock).mockResolvedValue(null);

    const { getByText } = render(<Profile />);

    await waitFor(() => {
      expect(getByText("Profile not found")).toBeTruthy();
      expect(getByText("Please Register or Log In")).toBeTruthy();
    });
  });

  it('displays "Profile not found" when profile is not fetched', async () => {
    const { getByText } = render(<Profile />);

    await waitFor(() => {
      expect(getByText("Profile not found")).toBeTruthy();
      expect(getByText("Please Register or Log In")).toBeTruthy();
    });
  });
});
