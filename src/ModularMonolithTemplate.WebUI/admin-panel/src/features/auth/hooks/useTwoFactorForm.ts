import { useState, useEffect } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import { useAuth } from '@context/AuthContext';
import { verifyTwoFactorCode } from '@features/auth/services/authService';
import { AUTH_ROUTES, ROUTES } from '@routes/routePaths';
import { useSnackbar } from '@context/SnackbarContext';

export const useTwoFactorForm = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const { setUser } = useAuth();
  const { showMessageList } = useSnackbar();

  const [code, setCode] = useState('');
  const [error] = useState('');
  const { email, password } = location.state || {};

  useEffect(() => {
    if (!email || !password) {
      navigate(AUTH_ROUTES.LOGIN);
    }
  }, [navigate, email, password]);

  const handleSubmit = async () => {
    try {
      const result = await verifyTwoFactorCode({ email, code });

      localStorage.setItem('token', result.token);
      localStorage.setItem('refreshToken', result.refreshToken);

      setUser({
        token: result.token,
        refreshToken: result.refreshToken,
        twoFactorEnabled: true,
        userName: '',
        roles: [],
      });

      navigate(ROUTES.DASHBOARD);
    } catch (err: any) {
      showMessageList(err);
    }
  };

  return {
    code,
    error,
    setCode,
    handleSubmit,
  };
};
