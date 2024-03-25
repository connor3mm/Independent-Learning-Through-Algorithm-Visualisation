import { render, waitFor } from "@testing-library/react";
import ProgressionChart from "./ProgressionChart";

describe("ProgressionChart", () => {
  it("displays proper labels when user is not logged in", async () => {
    // Mocking the absence of logged in user
    localStorage.removeItem("loggedInUser");

    const { queryByText } = render(<ProgressionChart />);
    await waitFor(
      () => {
        expect(queryByText("Game")).toBeNull();
      },
      { timeout: 200 }
    );
  });
});
