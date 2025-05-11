import { Navigate } from 'react-router-dom';
import type { JSX } from 'react';
import { useAuth } from '@context/AuthContext';
import LoadingScreen from '@components/LoadingScreen';

const PrivateRoute = ({ children }: { children: JSX.Element }) => {
  const { isAuthenticated, isInitializing, user } = useAuth();

  if (isInitializing) {
    return <LoadingScreen message="Verificando sesión..." />;
  }

  if (!isAuthenticated) {
    return <Navigate to="/login" replace />;
  }

  if (user?.twoFactorEnabled) {
    return <Navigate to="/2fa" replace />;
  }

  return children;
};

export default PrivateRoute;
