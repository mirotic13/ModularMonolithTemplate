import { Container } from '@mui/material';
import TwoFactorForm from '@auth/2fa/components/TwoFactorForm';

const TwoFactorPage = () => {
  return (
    <Container maxWidth="xs">
      <TwoFactorForm />
    </Container>
  );
};

export default TwoFactorPage;
