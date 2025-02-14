import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private apiUrl = 'http://localhost:5145/api/usuario/login';

  constructor(private http: HttpClient) {}

  loginUsuario(dados: any): Observable<any> {
    return this.http.post(this.apiUrl, dados);
  }
}
