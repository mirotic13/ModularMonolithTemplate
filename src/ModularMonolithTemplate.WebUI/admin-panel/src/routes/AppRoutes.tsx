import { Routes, Route, Navigate } from 'react-router-dom';
import { AUTH_ROUTES, ROUTES } from './routePaths';
import LoginPage from '@features/auth/pages/LoginPage';
import TwoFactorPage from '@features/auth/pages/TwoFactorPage';
import DashboardPage from '../pages/DashboardPage';
import PrivateRoute from './PrivateRoute';
import GuestRoute from './GuestRoute';

const AppRoutes = () => {
  return (
    <Routes>
      <Route
        path={AUTH_ROUTES.LOGIN}
        element={
          <GuestRoute>
            <LoginPage />
          </GuestRoute>
        }
      />
      <Route
        path={AUTH_ROUTES.TWO_FACTOR}
        element={
          <GuestRoute>
            <TwoFactorPage />
          </GuestRoute>
        }
      />

      <Route
        path={ROUTES.DASHBOARD}
        element={
          <PrivateRoute>
            <DashboardPage />
          </PrivateRoute>
        }
      />

      <Route path="*" element={<Navigate to={AUTH_ROUTES.LOGIN} replace />} />
    </Routes>
  );
};

export default AppRoutes;
