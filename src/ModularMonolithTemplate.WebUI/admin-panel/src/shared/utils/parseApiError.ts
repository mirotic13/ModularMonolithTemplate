import type { Result, PagedResult } from '@shared/utils/apiResponses';

export const parseApiError = (error: any): string[] => {
  if (!error.response) {
    return ['No se pudo conectar con el servidor'];
  }

  const data = error.response.data as Result<unknown> | PagedResult<unknown>;
  const rawMessage = data?.error?.message;

  if (data?.isFailure && rawMessage) {
    return rawMessage.split('|').map(msg => msg.trim());
  }

  if (typeof data === 'string') {
    return [data];
  }

  return ['Ocurrió un error inesperado'];
};
