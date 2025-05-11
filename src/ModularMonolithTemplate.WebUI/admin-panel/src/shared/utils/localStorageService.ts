const TOKEN_KEY = 'token';
const REFRESH_TOKEN_KEY = 'refreshToken';

export const localStorageService = {
  getToken: (): string | null => localStorage.getItem(TOKEN_KEY),
  setToken: (token: string): void => localStorage.setItem(TOKEN_KEY, token),
  removeToken: (): void => localStorage.removeItem(TOKEN_KEY),

  getRefreshToken: (): string | null => localStorage.getItem(REFRESH_TOKEN_KEY),
  setRefreshToken: (refreshToken: string): void =>
    localStorage.setItem(REFRESH_TOKEN_KEY, refreshToken),
  removeRefreshToken: (): void => localStorage.removeItem(REFRESH_TOKEN_KEY),
};