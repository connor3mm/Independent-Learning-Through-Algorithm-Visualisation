interface CheckboxProps {
  label: string;
  value: number;
  checked: boolean;
  onChange: (value: number) => void;
}

const Checkbox: React.FC<CheckboxProps> = ({
  label,
  value,
  checked,
  onChange,
}) => (
  <label>
    {label}
    <input type="checkbox" checked={checked} onChange={() => onChange(value)} />
  </label>
);

interface SpeedOptionsProps {
  speed: number;
  handleSpeedChange: (newSpeed: number) => void;
}

const SpeedOptions: React.FC<SpeedOptionsProps> = ({
  speed,
  handleSpeedChange,
}) => (
  <div>
    <Checkbox
      label="Slow"
      value={1500}
      checked={speed === 1500}
      onChange={handleSpeedChange}
    />
    <Checkbox
      label="Medium"
      value={1000}
      checked={speed === 1000}
      onChange={handleSpeedChange}
    />
    <Checkbox
      label="Fast"
      value={500}
      checked={speed === 500}
      onChange={handleSpeedChange}
    />
    <Checkbox
      label="Very Fast"
      value={100}
      checked={speed === 100}
      onChange={handleSpeedChange}
    />
  </div>
);

export default SpeedOptions;
