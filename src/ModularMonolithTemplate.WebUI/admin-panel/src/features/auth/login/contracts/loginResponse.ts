export interface LoginResponse {
  token: string;
  twoFactorEnabled: boolean;
  userName: string;
  roles: string[];
  refreshToken?: string;
}