import { ThemeProvider, CssBaseline } from '@mui/material';
import theme from '@theme/index';
import AppRoutes from '@routes/AppRoutes';
import LoadingScreen from '@shared/components/LoadingScreen';
import { useAuth } from '@context/AuthContext';
import AppLayout from '@shared/layouts/AppLayout';
import { SnackbarProvider } from '@context/SnackbarContext';

function App() {
  const { isInitializing } = useAuth();

  if (isInitializing) {
    return <LoadingScreen message="Cargando sesión..." />;
  }

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <SnackbarProvider>
        <AppLayout>
          <AppRoutes />
        </AppLayout>
      </SnackbarProvider>
    </ThemeProvider>
  );
}

export default App;
