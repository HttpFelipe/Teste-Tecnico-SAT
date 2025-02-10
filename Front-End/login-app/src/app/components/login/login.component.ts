import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { LoginService } from '../../services/login/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule]
})
export class LoginComponent {
  loginForm: FormGroup;
  mensagemErro: string | null = null;
  mensagemSucesso: string | null = null;

  constructor(private fb: FormBuilder, private loginService: LoginService) {
    this.loginForm = this.fb.group({
      usuario: ['', [Validators.required]],
      senha: ['', [Validators.required, Validators.minLength(6)]],
    });
  }
  onBlur(field: string) {
    this.loginForm.get(field)!.markAsTouched();
  }
  onSubmit() {
    if (this.loginForm.valid) {


      const dadosCadastro = {
        login: this.loginForm.get('usuario')!.value,
        senha: this.loginForm.get('senha')!.value
      };

      this.loginService.loginUsuario(dadosCadastro).subscribe({
        next: (response) => {
          this.mensagemErro = null;
          this.mensagemSucesso = 'Acesso Permitido!';
        },
        error: (err) => {
          if (err.status === 400 && err.error?.message) {
            this.mensagemErro = err.error.message;
          } else {
            this.mensagemErro = 'Usuário ou Senha incorretos';
          }
          this.mensagemSucesso = null;
        }
      });

      
    }
  }
}