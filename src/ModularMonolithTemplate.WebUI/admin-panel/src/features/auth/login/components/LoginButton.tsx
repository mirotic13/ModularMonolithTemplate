import { Button } from '@mui/material';
import { Link as RouterLink } from 'react-router-dom';
import { AUTH_ROUTES } from '@routes/routePaths';

const LoginButton = () => (
    <Button color="inherit" component={RouterLink} to={AUTH_ROUTES.LOGIN}>
        Iniciar sesión
    </Button>
);

export default LoginButton;
