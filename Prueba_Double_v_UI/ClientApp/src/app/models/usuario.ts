export interface Usuario {
  id?: number;
  usuario: string;
  pass: string;
  fechaCreacion?: Date;
}

export interface LoginRequest {
  usuario: string;
  pass: string;
}
