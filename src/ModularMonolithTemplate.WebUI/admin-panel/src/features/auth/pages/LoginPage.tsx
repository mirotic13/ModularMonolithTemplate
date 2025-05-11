import { useEffect } from 'react';
import { TextField, Button, Typography, Box, Paper } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { useLoginForm } from '@features/auth/hooks/useLoginForm';
import { ROUTES } from '@routes/routePaths';

const LoginPage = () => {
  const navigate = useNavigate();
  const { form, error, user, handleChange, handleSubmit } = useLoginForm();

  useEffect(() => {
    if (user) {
      navigate(ROUTES.DASHBOARD);
    }
  }, [user, navigate]);

  return (
    <Box sx={{ flex: 1, display: 'flex', justifyContent: 'center', alignItems: 'center', py: 6 }}>
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
    </Box>
  );
};

export default LoginPage;
