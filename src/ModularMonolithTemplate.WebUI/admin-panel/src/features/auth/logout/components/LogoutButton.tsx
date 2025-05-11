import { Button } from '@mui/material';
import { useAuth } from '@context/AuthContext';

const LogoutButton = () => {
  const { logoutUser } = useAuth();

  const handleLogout = () => {
    logoutUser();
  };

  return (
    <Button color="inherit" onClick={handleLogout}>
      Cerrar sesión
    </Button>
  );
};

export default LogoutButton;
