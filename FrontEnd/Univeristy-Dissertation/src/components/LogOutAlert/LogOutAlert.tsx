import * as React from "react";
import Button from "@mui/material/Button";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogTitle from "@mui/material/DialogTitle";
import { ThemeProvider, createTheme } from "@mui/material/styles";

const darkTheme = createTheme({
  palette: {
    mode: "dark",
  },
});

interface LogoutAlertsProps {
  open: boolean;
  onConfirm: () => void;
  onCancel: () => void;
}

const LogoutAlerts: React.FC<LogoutAlertsProps> = ({
  open,
  onConfirm,
  onCancel,
}) => {
  const [confirmed, setConfirmed] = React.useState(false);

  const handleConfirm = () => {
    setConfirmed(true);
    onConfirm(); // Call the original onConfirm function passed from props
  };

  const handleOkay = () => {
    // Reset the confirmation state and close the dialog
    setConfirmed(false);
    onCancel();
  };

  return (
    <ThemeProvider theme={darkTheme}>
      <React.Fragment>
        <Dialog
          open={open && !confirmed} // Only open if the alert is not confirmed
          onClose={onCancel}
          aria-labelledby="alert-dialog-title"
          aria-describedby="alert-dialog-description"
        >
          <DialogTitle id="alert-dialog-title">{"Confirm Log Out"}</DialogTitle>
          <DialogActions>
            <Button onClick={onCancel} autoFocus>
              Cancel
            </Button>
            <Button onClick={handleConfirm}>Log Out</Button>
          </DialogActions>
        </Dialog>

        {/* Second screen displayed after confirmation */}
        <Dialog
          open={confirmed}
          onClose={onCancel}
          aria-labelledby="alert-dialog-title"
          aria-describedby="alert-dialog-description"
        >
          <DialogTitle id="alert-dialog-title">
            {"You have been logged out"}
          </DialogTitle>
          <DialogActions>
            <Button onClick={handleOkay} autoFocus>
              Okay
            </Button>
          </DialogActions>
        </Dialog>
      </React.Fragment>
    </ThemeProvider>
  );
};

export default LogoutAlerts;
