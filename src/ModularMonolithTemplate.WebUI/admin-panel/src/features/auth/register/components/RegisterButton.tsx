import { Button } from '@mui/material';
import { Link as RouterLink } from 'react-router-dom';
import { AUTH_ROUTES } from '@routes/routePaths';

const RegisterButton = () => (
    <Button color="inherit" component={RouterLink} to={AUTH_ROUTES.REGISTER}>
        Registrarse
    </Button>
);

export default RegisterButton;