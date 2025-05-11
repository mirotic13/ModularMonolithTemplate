import { createContext, useContext, useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import type { LoginRequest, LoginResponse } from '@features/auth/types/loginTypes';
import { login, logout } from '@features/auth/services/authService';
import { getUserFromToken } from '@features/auth/utils/jwtUtils';
import { localStorageService } from '@utils/localStorageService';
import { AUTH_ROUTES } from '@routes/routePaths';

interface AuthContextType {
  user: LoginResponse | null;
  isAuthenticated: boolean;
  isInitializing: boolean;
  loginUser: (credentials: LoginRequest) => Promise<LoginResponse | null>;
  logoutUser: () => void;
  setUser: (user: LoginResponse) => void;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({ children }: { children: React.ReactNode }) => {
  const [user, setUser] = useState<LoginResponse | null>(null);
  const [isInitializing, setIsInitializing] = useState(true);
  const navigate = useNavigate();

  useEffect(() => {
    const initializeAuth = () => {
      const token = localStorageService.getToken();
      const refreshToken = localStorageService.getRefreshToken();
      const tokenUser = getUserFromToken();

      if (token && tokenUser && tokenUser.twoFactorEnabled === false) {
        setUser({
          ...tokenUser,
          token,
          refreshToken: refreshToken ?? '',
          twoFactorEnabled: false,
        });
      }

      setIsInitializing(false);
    };

    initializeAuth();
  }, []);


  const loginUser = async (credentials: LoginRequest): Promise<LoginResponse> => {
    const data = await login(credentials);

    localStorageService.setToken(data.token);

    if (!data.twoFactorEnabled) {
      localStorageService.setRefreshToken(data.refreshToken ?? '');
      setUser(data);
    }

    return data;
  };


  const logoutUser = async () => {
    await logout();
    localStorageService.removeToken();
    localStorageService.removeRefreshToken();
    setUser(null);
    navigate(AUTH_ROUTES.LOGIN);
  };

  const isAuthenticated = !!user;

  return (
    <AuthContext.Provider value={{ user, isAuthenticated, loginUser, logoutUser, setUser, isInitializing }}>
      {children}
    </AuthContext.Provider>
  );
};

function useAuth(): AuthContextType {
  const context = useContext(AuthContext);
  if (!context) throw new Error('useAuth must be used within AuthProvider');
  return context;
}

export { useAuth };
