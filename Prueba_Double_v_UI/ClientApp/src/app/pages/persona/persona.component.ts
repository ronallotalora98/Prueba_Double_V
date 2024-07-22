import { Component, OnInit } from '@angular/core';
import { PersonaDTO } from 'src/app/models/personaDTO';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-persona',
  templateUrl: './persona.component.html',
  styleUrls: ['./persona.component.css']
})
export class PersonaComponent implements OnInit {

  persona: PersonaDTO = {
    nombres: '',
    apellidos: '',
    numeroIdentificacion: '',
    email: '',
    tipoIdentificacion: ''
  };

  constructor(private personaService: PersonaService) {}

  ngOnInit(): void {}

  onSubmit(): void {
    this.personaService.addPersona(this.persona).subscribe(response => {
      console.log('Persona creada:', response);
    });
  }

}
