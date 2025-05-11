import axios from '@services/api/axios';
import type { LoginRequest } from '@auth/login/contracts/loginRequest'
import type { LoginResponse } from '@auth/login/contracts/loginResponse';
import type { Result } from '@shared/utils/apiResponses';
import { API_ROUTES } from '@services/api/apiRoutes';
import { parseApiError } from '@shared/utils/parseApiError';
import { safeApiCall } from '@shared/utils/safeApiCall';

export const login = async (data: LoginRequest): Promise<LoginResponse> =>
  safeApiCall(async () => {
    const response = await axios.post<Result<LoginResponse>>(API_ROUTES.AUTH.LOGIN, data);

    if (!response.data.isSuccess) throw parseApiError({ response });

    return response.data.value!;
  });