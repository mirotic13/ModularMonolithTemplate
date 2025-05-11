import { CircularProgress, Box, Typography } from '@mui/material';

const LoadingScreen = ({ message = 'Cargando...' }: { message?: string }) => {
  return (
    <Box
      height="100vh"
      display="flex"
      flexDirection="column"
      justifyContent="center"
      alignItems="center"
      gap={2}
    >
      <CircularProgress color="primary" />
      <Typography variant="h6" color="textSecondary">
        {message}
      </Typography>
    </Box>
  );
};

export default LoadingScreen;
