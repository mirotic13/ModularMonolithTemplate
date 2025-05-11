export interface LoginRequest {
  email: string;
  password: string;
}

export interface LoginResponse {
  token: string;
  twoFactorEnabled: boolean;
  userName: string;
  roles: string[];
  refreshToken?: string;
}
