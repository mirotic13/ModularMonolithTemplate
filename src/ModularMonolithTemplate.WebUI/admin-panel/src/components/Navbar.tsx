import { AppBar, Toolbar, Typography, Button, Box } from '@mui/material';
import { useAuth } from '@context/AuthContext';
import { Link as RouterLink } from 'react-router-dom';

const Navbar = () => {
  const { user, logoutUser } = useAuth();

  const handleLogout = () => {
    logoutUser();
  };

  const userName = user?.userName ?? 'Invitado';

  return (
    <AppBar position="static">
      <Toolbar sx={{ justifyContent: 'space-between' }}>
        <Typography variant="h6">Admin Panel</Typography>

        <Box display="flex" alignItems="center" gap={2}>
          {user ? (
            <>
              <Typography variant="body1">👤 {userName}</Typography>
              <Button color="inherit" onClick={handleLogout}>
                Cerrar sesión
              </Button>
            </>
          ) : (
            <>
              <Button color="inherit" component={RouterLink} to="/login">
                Iniciar sesión
              </Button>
              <Button color="inherit" component={RouterLink} to="/register">
                Registrarse
              </Button>
            </>
          )}
        </Box>
      </Toolbar>
    </AppBar>
  );
};

export default Navbar;
