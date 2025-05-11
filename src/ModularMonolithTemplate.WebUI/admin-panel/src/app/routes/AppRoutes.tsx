import { Routes, Route, Navigate } from 'react-router-dom';
import { AUTH_ROUTES, ROUTES } from '@routes/routePaths';
import LoginPage from '@auth/login/pages/LoginPage';
import TwoFactorPage from '@auth/2fa/pages/TwoFactorPage';
import DashboardPage from '@dashboard/pages/DashboardPage';
import PrivateRoute from '@routes/PrivateRoute';
import GuestRoute from '@routes/GuestRoute';

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
