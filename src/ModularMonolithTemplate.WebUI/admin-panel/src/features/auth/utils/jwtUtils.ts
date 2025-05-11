import type { LoginResponse } from '@features/auth/types/loginTypes';

export const getUserFromToken = (): Pick<LoginResponse, 'userName' | 'roles' | 'twoFactorEnabled'> | null => {
  const token = localStorage.getItem('token');
  if (!token) return null;

  try {
    const payload = JSON.parse(atob(token.split('.')[1]));
    return {
      userName: payload?.unique_name || payload?.sub || '',
      roles: payload?.role
        ? Array.isArray(payload.role)
          ? payload.role
          : [payload.role]
        : [],
      twoFactorEnabled: payload["2fa"] !== "true",
    };
  } catch {
    return null;
  }
};