import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginRequest } from 'src/app/models/loginRequest';
import { PersonaDTO } from 'src/app/models/personaDTO';
import { PersonaService } from 'src/app/services/persona.service';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  // @ts-ignore
  registerForm: FormGroup;

  constructor(private fb: FormBuilder,
    private personaService: PersonaService,
    private usuarioPersona: UsuarioService,
    private router: Router
  ) { }

  ngOnInit() {
    this.validationsForms();
  }

  validationsForms() {
    this.registerForm = this.fb.group({
      nombres: ['', Validators.required],
      apellidos: ['', Validators.required],
      numeroIdentificacion: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      tipoIdentificacion: ['', Validators.required],
      usuario: ['', Validators.required],
      pass: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  onSubmit(): void {
    this.personaService.getPersonas().subscribe(res => {

    });
    if (this.registerForm.valid) {

      // let persona: PersonaDTO = this.registerForm.value
      this.personaService.addPersona(this.mapPersonsaDto()).subscribe(res => {
        if (res) {
          this.usuarioPersona.addUsuario(this.mapLoginRequest()).subscribe(registe => {
            if (registe) {
              this.router.navigate(['/login']);
            }
          });
        }
      });
      // console.log('Form Submitted!', persona);
      // Aquí puedes añadir la lógica para enviar los datos al servidor
    } else {
      console.log('Form not valid');
      this.registerForm.markAllAsTouched();
    }
  }

  mapPersonsaDto() {
    let persona: PersonaDTO = {
      nombres: this.registerForm.value.nombres,
      apellidos: this.registerForm.value.apellidos,
      numeroIdentificacion: this.registerForm.value.numeroIdentificacion,
      email: this.registerForm.value.email,
      tipoIdentificacion: this.registerForm.value.tipoIdentificacion
    }
    return persona;
  }

  mapLoginRequest() {
    const loginRequest:LoginRequest = {
      usuario: this.registerForm.value.usuario,
      pass: this.registerForm.value.pass
    }
    return loginRequest;
  }

}
