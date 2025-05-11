import { TextField, Button, Typography, Paper } from '@mui/material';
import { useLoginForm } from '@auth/login/hooks/useLoginForm';

const LoginForm = () => {
  const { form, error, handleChange, handleSubmit } = useLoginForm();

  return (
    <Paper elevation={3} sx={{ p: 4, width: '100%', maxWidth: { xs: 320, sm: 400, md: 500, lg: 600 } }}>
      <Typography variant="h5" align="center" gutterBottom>
        Iniciar Sesión
      </Typography>
      {error && (
        <Typography color="error" align="center" sx={{ mb: 2 }}>
          {error}
        </Typography>
      )}
      <TextField
        label="Email"
        name="email"
        value={form.email}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />
      <TextField
        label="Password"
        name="password"
        type="password"
        value={form.password}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />
      <Button variant="contained" color="primary" fullWidth sx={{ mt: 2 }} onClick={handleSubmit}>
        Continuar
      </Button>
    </Paper>
  );
};

export default LoginForm;
