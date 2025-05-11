import { TextField, Button, Typography, Box } from '@mui/material';
import { useTwoFactorForm } from '@auth/2fa/hooks/useTwoFactorForm';

const TwoFactorForm = () => {
  const { code, setCode, handleSubmit } = useTwoFactorForm();

  return (
    <Box mt={10}>
        <Typography variant="h5" align="center" gutterBottom>
            Verificación en 2 pasos
        </Typography>
        <TextField
            label="Código 2FA"
            value={code}
            onChange={(e) => setCode(e.target.value)}
            fullWidth
            margin="normal"
        />
        <Button variant="contained" color="primary" fullWidth onClick={handleSubmit}>
            Verificar
        </Button>
    </Box>
  );
};

export default TwoFactorForm;