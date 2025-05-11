import axios from '@services/api/axios';
import type { RefreshTokenRequest } from '@auth/refresh/contracts/refreshTokenRequest';
import type { RefreshTokenResponse } from '@auth/refresh/contracts/refreshTokenResponse';
import type { Result } from '@shared/utils/apiResponses';
import { API_ROUTES } from '@services/api/apiRoutes';
import { parseApiError } from '@shared/utils/parseApiError';
import { safeApiCall } from '@shared/utils/safeApiCall';

export const refresh = async (data: RefreshTokenRequest): Promise<RefreshTokenResponse> =>
  safeApiCall(async () => {
    const response = await axios.post<Result<RefreshTokenResponse>>(API_ROUTES.AUTH.REFRESH, data);

    if (response.data.isSuccess) {
      return response.data.value!;
    }

    throw parseApiError({ response });
  });