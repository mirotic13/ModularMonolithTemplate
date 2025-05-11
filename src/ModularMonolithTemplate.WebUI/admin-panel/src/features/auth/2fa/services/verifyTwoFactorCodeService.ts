import axios from '@services/api/axios';
import type { Verify2FARequest } from '@auth/2fa/contracts/verify2FARequest';
import type { Verify2FAResponse } from '@auth/2fa/contracts/verify2FAResponse';
import type { Result } from '@shared/utils/apiResponses';
import { API_ROUTES } from '@services/api/apiRoutes';
import { parseApiError } from '@shared/utils/parseApiError';
import { safeApiCall } from '@shared/utils/safeApiCall';

export const verifyTwoFactorCode = async (data: Verify2FARequest): Promise<Verify2FAResponse> =>
  safeApiCall(async () => {
    const response = await axios.post<Result<Verify2FAResponse>>(API_ROUTES.AUTH.VERIFY_2FA, data);

    if (response.data.isSuccess) {
      return response.data.value!;
    }

    throw parseApiError({ response });
  });