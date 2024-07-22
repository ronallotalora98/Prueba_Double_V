import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PersonaDTO } from '../models/personaDTO';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  private apiUrl = environment.urlApi + 'api/Persona';

  constructor(private http: HttpClient) {}

  getPersonas(): Observable<PersonaDTO[]> {
    return this.http.get<PersonaDTO[]>(this.apiUrl);
  }

  addPersona(persona: PersonaDTO): Observable<PersonaDTO> {
    return this.http.post<PersonaDTO>(this.apiUrl, persona);
  }

}
