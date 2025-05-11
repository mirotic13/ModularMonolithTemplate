import Navbar from '@shared/components/Navbar';
import { Box } from '@mui/material';
import type { ReactNode } from 'react';

const AppLayout = ({ children }: { children: ReactNode }) => (
  <Box sx={{ minHeight: '100vh', display: 'flex', flexDirection: 'column' }}>
    <Navbar />

    <Box
      component="main"
      sx={{
        flex: 1,
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        px: 2,
      }}
    >
      {children}
    </Box>
  </Box>
);

export default AppLayout;
