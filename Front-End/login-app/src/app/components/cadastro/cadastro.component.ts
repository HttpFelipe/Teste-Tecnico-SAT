import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { CadastroService } from '../../services/cadastro/cadastro.service';

@Component({
  selector: 'app-cadastro',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent {
  cadastroForm: FormGroup;
  senhaDiferente: boolean = false;
  mensagemErro: string | null = null;

  constructor(private fb: FormBuilder, private router: Router, private cadastroService: CadastroService) {
    this.cadastroForm = this.fb.group({
      usuario: ['', [Validators.required]],
      senha: ['', [Validators.required, Validators.minLength(6)]],
      confirmSenha: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  onBlur(field: string) {
    this.cadastroForm.get(field)!.markAsTouched();
  }

  onSubmit() {
    const senha = this.cadastroForm.get('senha')!.value;
    const confirmSenha = this.cadastroForm.get('confirmSenha')!.value;

    if (senha !== confirmSenha) {
      this.senhaDiferente = true;
    } else {
      this.senhaDiferente = false;

      const dadosCadastro = {
        login: this.cadastroForm.get('usuario')!.value,
        senha: this.cadastroForm.get('senha')!.value
      };

      this.cadastroService.cadastrarUsuario(dadosCadastro).subscribe({
        next: (response) => {
          this.mensagemErro = null;
          this.router.navigate(['/login']);
        },
        error: (err) => {
          if (err.status === 400 && err.error?.message) {
            this.mensagemErro = err.error.message;
          } else {
            this.mensagemErro = 'Erro inesperado ao cadastrar usuário.';
          }
        }
      });
    }
  }
}