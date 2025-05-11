import { AppBar, Toolbar, Typography, Button, Box } from '@mui/material';
import { useAuth } from '@context/AuthContext';
import { Link as RouterLink } from 'react-router-dom';
import LoginButton from '@auth/login/components/LoginButton';
import LogoutButton from '@auth/logout/components/LogoutButton';
import RegisterButton from '@auth/register/components/RegisterButton';

const Navbar = () => {
  const { user } = useAuth();

  const userName = user?.userName ?? 'Invitado';

  return (
    <AppBar position="static">
      <Toolbar sx={{ justifyContent: 'space-between' }}>
        <Typography variant="h6">Admin Panel</Typography>

        <Box display="flex" alignItems="center" gap={2}>
          {user ? (
            <>
              <Typography variant="body1">👤 {userName}</Typography>
              <LogoutButton />
            </>
          ) : (
            <>
              <LoginButton />
              <RegisterButton />
            </>
          )}
        </Box>
      </Toolbar>
    </AppBar>
  );
};

export default Navbar;
