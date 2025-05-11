export interface Verify2FARequest {
  email: string;
  code: string;
}

export interface Verify2FAResponse {
  token: string;
  refreshToken: string;
}
