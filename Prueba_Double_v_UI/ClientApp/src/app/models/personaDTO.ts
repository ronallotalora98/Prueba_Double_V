export interface PersonaDTO {
  id?: number;
  nombres: string;
  apellidos: string;
  numeroIdentificacion: string;
  email: string;
  tipoIdentificacion: string;
  fechaCreacion?: Date;
  numeroIdentificacionConcatenado?: string;
  nombresApellidosConcatenado?: string;
}
