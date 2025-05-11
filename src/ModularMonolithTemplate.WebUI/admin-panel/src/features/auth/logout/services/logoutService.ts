import axios from '@services/api/axios';
import type { LogoutResponse } from '@auth/logout/contracts/logoutResponse';
import type { Result } from '@shared/utils/apiResponses';
import { API_ROUTES } from '@services/api/apiRoutes';
import { parseApiError } from '@shared/utils/parseApiError';
import { safeApiCall } from '@shared/utils/safeApiCall';

export const logout = async (): Promise<LogoutResponse> =>
  safeApiCall(async () => {
    const response = await axios.post<Result<LogoutResponse>>(API_ROUTES.AUTH.LOGOUT);

    if (response.data.isSuccess) {
      return response.data.value!;
    }

    throw parseApiError({ response });
  });