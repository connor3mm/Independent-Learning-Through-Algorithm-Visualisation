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
  return (
    <ThemeProvider theme={darkTheme}>
      <React.Fragment>
        <Dialog
          open={open}
          onClose={onCancel}
          aria-labelledby="alert-dialog-title"
          aria-describedby="alert-dialog-description"
        >
          <DialogTitle id="alert-dialog-title">{"Confirm Log Out"}</DialogTitle>
          <DialogActions>
            <Button onClick={onCancel} autoFocus>
              Cancel
            </Button>
            <Button onClick={onConfirm}>Log Out</Button>
          </DialogActions>
        </Dialog>
      </React.Fragment>
    </ThemeProvider>
  );
};

export default LogoutAlerts;
