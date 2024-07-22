export interface LoginRequest {
  usuario: string;
  pass: string;
}

export interface LoginResponse {

  id: number;
  userName: string;
  isOk: boolean;
  token: string;
  timeToExpire: number;
}
