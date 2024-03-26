import LinearProgress, {
  LinearProgressProps,
} from "@mui/material/LinearProgress";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";

// Progression bar from material UI Componrny
export default function LinearProgressWithLabel(
  props: LinearProgressProps & { value: number }
) {
  // Limiting the value to a maximum of 50
  const cappedValue = Math.min(props.value, 50);
  const progressPercentage = (cappedValue / 50) * 100;

  // Rendering LinearProgressWithLabel component
  return (
    <Box sx={{ display: "flex", alignItems: "center", paddingTop: "1em" }}>
      <Box sx={{ width: "100%", mr: 1 }}>
        <LinearProgress
          variant="determinate"
          value={progressPercentage}
          sx={{ height: 10, paddingBottom: "1em" }}
        />
      </Box>
      <Box sx={{ minWidth: 100, fontSize: "1em" }}>
        <Typography variant="body2" sx={{ fontSize: "1em" }}>{`${Math.round(
          cappedValue
        )} / 50`}</Typography>
      </Box>
    </Box>
  );
}
