import { createContext, useContext, useState, useCallback } from 'react';
import { Snackbar, Alert, type AlertColor } from '@mui/material';

interface SnackbarContextType {
  showMessage: (message: string, severity?: AlertColor) => void;
  showMessageList: (messages: string[], severity?: AlertColor) => void;
}

const SnackbarContext = createContext<SnackbarContextType | undefined>(undefined);

export const SnackbarProvider = ({ children }: { children: React.ReactNode }) => {
  const [open, setOpen] = useState(false);
  const [message, setMessage] = useState('');
  const [severity, setSeverity] = useState<AlertColor>('info');

  const showMessage = useCallback((msg: string, sev: AlertColor = 'info') => {
    setMessage(msg);
    setSeverity(sev);
    setOpen(true);
  }, []);

  const showMessageList = useCallback((messages: string[], sev: AlertColor = 'error') => {
    if (!messages.length) return;
    if (messages.length === 1) {
      showMessage(messages[0], sev);
    } else {
      showMessage(
        messages.map((m) => `• ${m}`).join('\n'),
        sev
      );
    }
  }, [showMessage]);

  const handleClose = () => setOpen(false);

  return (
    <SnackbarContext.Provider value={{ showMessage, showMessageList }}>
      {children}
      <Snackbar open={open} autoHideDuration={3000} onClose={handleClose} anchorOrigin={{ vertical: 'top', horizontal: 'center' }} sx={{ mt: 6 }}>
        <Alert severity={severity} onClose={handleClose} sx={{ whiteSpace: 'pre-line' }}>
          {message}
        </Alert>
      </Snackbar>
    </SnackbarContext.Provider>
  );
};

function useSnackbar(): SnackbarContextType {
  const context = useContext(SnackbarContext);
  if (!context) throw new Error('useSnackbar must be used within a SnackbarProvider');
  return context;
}

export { useSnackbar };
