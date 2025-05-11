import axios from '@api/axios';
import type { LoginRequest, LoginResponse } from '../types/loginTypes';
import type { LogoutResponse } from '../types/logoutTypes';
import type { RefreshTokenRequest, RefreshTokenResponse } from '../types/refreshTypes';
import type { Verify2FARequest, Verify2FAResponse } from '../types/verify2FATypes';
import type { Result } from '@utils/apiResponses';
import { API_ROUTES } from '@api/apiRoutes';
import { parseApiError } from '@utils/parseApiError';
import { safeApiCall } from '@utils/safeApiCall';

export const login = async (data: LoginRequest): Promise<LoginResponse> =>
  safeApiCall(async () => {
    const response = await axios.post<Result<LoginResponse>>(API_ROUTES.AUTH.LOGIN, data);

    if (!response.data.isSuccess) throw parseApiError({ response });

    return response.data.value!;
  });

export const logout = async (): Promise<LogoutResponse> =>
  safeApiCall(async () => {
    const response = await axios.post<Result<LogoutResponse>>(API_ROUTES.AUTH.LOGOUT);

    if (response.data.isSuccess) {
      return response.data.value!;
    }

    throw parseApiError({ response });
  });

export const refresh = async (data: RefreshTokenRequest): Promise<RefreshTokenResponse> =>
  safeApiCall(async () => {
    const response = await axios.post<Result<RefreshTokenResponse>>(API_ROUTES.AUTH.REFRESH, data);

    if (response.data.isSuccess) {
      return response.data.value!;
    }

    throw parseApiError({ response });
  });

export const verifyTwoFactorCode = async (data: Verify2FARequest): Promise<Verify2FAResponse> =>
  safeApiCall(async () => {
    const response = await axios.post<Result<Verify2FAResponse>>(API_ROUTES.AUTH.VERIFY_2FA, data);

    if (response.data.isSuccess) {
      return response.data.value!;
    }

    throw parseApiError({ response });
  });
