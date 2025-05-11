import { Navigate } from 'react-router-dom';
import { useAuth } from '@context/AuthContext';
import LoadingScreen from '@components/LoadingScreen';
import { AUTH_ROUTES, ROUTES } from '@routes/routePaths';

interface GuestRouteProps {
  children: React.ReactNode;
}

export default function GuestRoute({ children }: GuestRouteProps) {
  const { isAuthenticated, isInitializing, user } = useAuth();

  if (isInitializing) {
    return <LoadingScreen message="Verificando sesión..." />;
  }

  if (isAuthenticated && !user?.twoFactorEnabled) {
    return <Navigate to={ROUTES.DASHBOARD} replace />;
  }

  if (isAuthenticated && user?.twoFactorEnabled) {
    return <Navigate to={AUTH_ROUTES.TWO_FACTOR} replace />;
  }

  return <>{children}</>;
}
