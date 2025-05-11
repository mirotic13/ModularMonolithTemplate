import axios from 'axios';
import { localStorageService } from 'src/shared/utils/localStorageService';
import { AUTH_ROUTES } from 'src/app/routes/routePaths';
import { API_ROUTES } from '@services/api/apiRoutes';
import { refresh } from '@auth/refresh/services/refreshService';

const api = axios.create({
  baseURL: import.meta.env.VITE_API_URL || 'https://localhost:7118/api',
  headers: {
    'Content-Type': 'application/json',
  },
});

api.interceptors.request.use((config) => {
  const token = localStorageService.getToken();
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

let isRefreshing = false;
let refreshQueue: Array<() => void> = [];

api.interceptors.response.use(
  (response) => response,
  async (error) => {
    const originalRequest = error.config;
    const status = error.response?.status;

    if (status === 401 && !originalRequest._retry && !originalRequest.url.includes(API_ROUTES.AUTH.LOGIN)) {
      originalRequest._retry = true;

      if (isRefreshing) {
        return new Promise((resolve) => {
          refreshQueue.push(() => resolve(api(originalRequest)));
        });
      }

      isRefreshing = true;

      try {
        const refreshToken = localStorageService.getRefreshToken();

      if (!refreshToken) {
        if (window.location.pathname !== AUTH_ROUTES.LOGIN) {
          localStorageService.removeToken();
          localStorageService.removeRefreshToken();
          window.location.href = AUTH_ROUTES.LOGIN;
        }

        return Promise.reject(new Error('Refresh token missing'));
      }

        const res = await refresh({ refreshToken });

        const newToken = res.accessToken;
        const newRefresh = res.refreshToken;

        localStorageService.setToken(newToken);
        localStorageService.setRefreshToken(newRefresh);

        // Retry all queued requests
        refreshQueue.forEach((cb) => cb());
        refreshQueue = [];
        isRefreshing = false;

        // Retry the original failed request
        originalRequest.headers.Authorization = `Bearer ${newToken}`;
        return api(originalRequest);
      } catch (err) {
        localStorageService.removeToken();
        localStorageService.removeRefreshToken();
        window.location.href = AUTH_ROUTES.LOGIN;
        return Promise.reject(err);
      }
    }

    return Promise.reject(error);
  },
);

export default api;
