import { parseApiError } from './parseApiError';

export const safeApiCall = async <T>(fn: () => Promise<T>): Promise<T> => {
  try {
    return await fn();
  } catch (error: any) {
    throw parseApiError(error);
  }
};
