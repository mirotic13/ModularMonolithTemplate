import { toast } from 'react-toastify';
import { parseApiError } from '@utils/parseApiError';

export const useApiErrorHandler = () => {
  const handleError = (error: any) => {
    const messages = parseApiError(error);

    messages.forEach((msg, i) =>
      toast.error(msg, {
        delay: i * 300,
        autoClose: 4000,
      })
    );
  };

  return handleError;
};