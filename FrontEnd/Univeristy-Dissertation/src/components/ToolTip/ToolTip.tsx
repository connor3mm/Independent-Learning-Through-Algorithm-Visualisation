import React from "react";
import InfoIcon from "@mui/icons-material/Info";
import IconButton from "@mui/material/IconButton";
import Tooltip from "@mui/material/Tooltip";
import { Theme, useTheme } from "@mui/material/styles";

interface ToolTipProps {
  customMessage: string;
  iconSize?: "small" | "medium" | "large";
  titleSize?: string;
}

const ToolTip: React.FC<ToolTipProps> = ({
  customMessage,
  iconSize = "large",
  titleSize = "14px",
}) => {
  const theme: Theme = useTheme();

  //Material UI Tool Tip
  return (
    <div>
      <Tooltip
        title={customMessage}
        PopperProps={{
          sx: { "& .MuiTooltip-tooltip": { fontSize: titleSize } },
        }}
      >
        <IconButton
          style={{
            color:
              theme.palette.mode === "light"
                ? theme.palette.primary.main
                : theme.palette.secondary.main,
          }}
        >
          <InfoIcon fontSize={iconSize} />
        </IconButton>
      </Tooltip>
    </div>
  );
};

export default ToolTip;
