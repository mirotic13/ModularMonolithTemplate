import axios from '@services/api/axios';
import type { RegisterRequest } from '@auth/register/contracts/registerRequest'
import type { RegisterResponse } from '@auth/register/contracts/registerResponse';
import type { Result } from '@shared/utils/apiResponses';
import { API_ROUTES } from '@services/api/apiRoutes';
import { parseApiError } from '@shared/utils/parseApiError';
import { safeApiCall } from '@shared/utils/safeApiCall';

export const register = async (data: RegisterRequest): Promise<RegisterResponse> =>
  safeApiCall(async () => {
    const response = await axios.post<Result<RegisterResponse>>(API_ROUTES.AUTH.REGISTER, data);

    if (!response.data.isSuccess) throw parseApiError({ response });

    return response.data.value!;
  });