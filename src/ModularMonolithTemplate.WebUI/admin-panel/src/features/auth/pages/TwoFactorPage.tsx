import { TextField, Button, Container, Typography, Box } from '@mui/material';
import { useTwoFactorForm } from '@features/auth/hooks/useTwoFactorForm';

const TwoFactorPage = () => {
  const { code, setCode, handleSubmit } = useTwoFactorForm();

  return (
    <Container maxWidth="xs">
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
    </Container>
  );
};

export default TwoFactorPage;
