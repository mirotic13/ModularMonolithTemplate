import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '@context/AuthContext';
import { AUTH_ROUTES, ROUTES } from '@routes/routePaths';
import { useSnackbar } from '@context/SnackbarContext';

export const useLoginForm = () => {
  const navigate = useNavigate();
  const { loginUser, user } = useAuth();
  const [form, setForm] = useState({ email: '', password: '' });
  const [error] = useState('');
  const { showMessageList } = useSnackbar();

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = async () => {
    try {
      const result = await loginUser({ ...form });

      if (result?.twoFactorEnabled) {
        navigate(AUTH_ROUTES.TWO_FACTOR, {
          state: { email: form.email, password: form.password },
        });
      } else if (result) {
        navigate(ROUTES.DASHBOARD);
      }
    } catch (err: any) {
      showMessageList(err);
    }
  };

  return {
    form,
    error,
    user,
    handleChange,
    handleSubmit,
  };
};