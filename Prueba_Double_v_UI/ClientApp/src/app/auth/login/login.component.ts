import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginRequest } from 'src/app/models/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginRequest: LoginRequest = {
    usuario: '',
    pass: ''
  };

  constructor(private usuarioService: UsuarioService,
    private router: Router
  ) {}


  ngOnInit(){

  }

  onSubmit(): void {
    if (this.loginRequest.usuario == '' || this.loginRequest.pass == '') {
      return;
    }
    this.usuarioService.login(this.loginRequest).subscribe(response => {
      if (response  && response.isOk) {
        this.router.navigate(['/home']);
      } else {
        alert('Credenciales incorrectas')
        console.log('Credenciales incorrectas');
      }
    });
  }

  goToRegisterForm() {
    this.router.navigate(['/Register']);
  }

}
