import Radio from "@mui/material/Radio";
import RadioGroup from "@mui/material/RadioGroup";
import FormControlLabel from "@mui/material/FormControlLabel";
import FormControl from "@mui/material/FormControl";
import FormLabel from "@mui/material/FormLabel";

interface SpeedOptionsProps {
  speed: number;
  handleSpeedChange: (newSpeed: number) => void;
}

const SpeedOptions: React.FC<SpeedOptionsProps> = ({
  speed,
  handleSpeedChange,
}) => (
  <div>
    <FormControl>
      <FormLabel
        id="demo-radio-buttons-group-label"
        component="legend"
        sx={{
          color: "white",
        }}
      >
        Speed
      </FormLabel>
      <RadioGroup
        aria-labelledby="demo-radio-buttons-group-label"
        defaultValue="female"
        name="radio-buttons-group"
      >
        <FormControlLabel
          value="slow"
          control={
            <Radio
              value={1500}
              checked={speed === 1500}
              onChange={() => handleSpeedChange(1500)}
              sx={{
                color: "white",
              }}
              size="small"
            />
          }
          label="Slow"
        />
        <FormControlLabel
          value="moderate"
          control={
            <Radio
              value={1000}
              checked={speed === 1000}
              onChange={() => handleSpeedChange(1000)}
              sx={{
                color: "white",
              }}
              size="small"
            />
          }
          label="Moderate"
        />
        <FormControlLabel
          value="fast"
          control={
            <Radio
              value={500}
              checked={speed === 500}
              onChange={() => handleSpeedChange(500)}
              sx={{
                color: "white",
              }}
              size="small"
            />
          }
          label="Fast"
        />
        <FormControlLabel
          value="rapid"
          control={
            <Radio
              value={100}
              checked={speed === 100}
              onChange={() => handleSpeedChange(100)}
              sx={{
                color: "white",
              }}
              size="small"
            />
          }
          label="Rapid"
        />
      </RadioGroup>
    </FormControl>
  </div>
);

export default SpeedOptions;
