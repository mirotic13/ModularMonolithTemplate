import { useEffect } from 'react';
import { Box } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { useLoginForm } from '@auth/login/hooks/useLoginForm';
import { ROUTES } from '@routes/routePaths';
import LoginForm from '@auth/login/components/LoginForm';

const LoginPage = () => {
  const navigate = useNavigate();
  const { user } = useLoginForm(); // solo accedes al user aquí

  useEffect(() => {
    if (user) {
      navigate(ROUTES.DASHBOARD);
    }
  }, [user, navigate]);

  return (
    <Box sx={{ flex: 1, display: 'flex', justifyContent: 'center', alignItems: 'center', py: 6 }}>
      <LoginForm />
    </Box>
  );
};

export default LoginPage;
