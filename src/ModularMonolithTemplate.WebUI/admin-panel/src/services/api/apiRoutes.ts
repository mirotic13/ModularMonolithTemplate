export const API_ROUTES = {
  AUTH: {
    LOGIN: '/auth/login',
    LOGOUT: '/auth/logout',
    VERIFY_2FA: '/auth/verify2fa',
    REFRESH: '/auth/refresh',
    REGISTER: 'auth/register'
  },
  INVENTORY: {
    SOTCK: {
      GET_BY_PRODUCT_ID: (id: string) => `/inventory/product/${id}`,
      GET_ALL: '/inventory/stock'
    }
  }
};
