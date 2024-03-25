import { render, fireEvent } from "@testing-library/react";
import LogoutAlerts from "./LogOutAlert";

//Mock function
const mockOnConfirm = jest.fn();
const mockOnCancel = jest.fn();

describe("LogoutAlerts", () => {
  it("displays correct dialog title", () => {
    const { getByText } = render(
      <LogoutAlerts
        open={true}
        onConfirm={mockOnConfirm}
        onCancel={mockOnCancel}
      />
    );
    expect(getByText("Confirm Log Out")).toBeTruthy();
  });

  it('calls onConfirm when "Log Out" button is clicked', () => {
    const { getByText } = render(
      <LogoutAlerts
        open={true}
        onConfirm={mockOnConfirm}
        onCancel={mockOnCancel}
      />
    );
    fireEvent.click(getByText("Log Out"));
    expect(mockOnConfirm).toHaveBeenCalledTimes(1);
  });

  it('calls onCancel when "Cancel" button is clicked', () => {
    const { getByText } = render(
      <LogoutAlerts
        open={true}
        onConfirm={mockOnConfirm}
        onCancel={mockOnCancel}
      />
    );
    fireEvent.click(getByText("Cancel"));
    expect(mockOnCancel).toHaveBeenCalledTimes(1);
  });

  it('calls onCancel when "Okay" button is clicked in the second dialog box', () => {
    const { getByText } = render(
      <LogoutAlerts
        open={true}
        onConfirm={mockOnConfirm}
        onCancel={mockOnCancel}
      />
    );

    fireEvent.click(getByText("Log Out"));
    fireEvent.click(getByText("Okay"));

    expect(mockOnCancel).toHaveBeenCalledTimes(2);
  });
});
