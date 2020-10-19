import { NumberSymbol } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EMPTY, Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Endereco } from './address.model';
import { Cep } from './cep.model';
import { Client } from './client.model';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  baseCepUrl = 'http://localhost:5000/api/cep';

  resultado: Cep;
  endereco: Endereco;
  
  //baseUrl = 'http://localhost:3001/clientes'
  baseUrl = 'http://localhost:5000/api/cliente';

  constructor(
    private snackBar: MatSnackBar, 
    private http: HttpClient
  ) { }

  showMessage(msg: string, isError: boolean = false): void {
    this.snackBar.open(msg, 'X', {  
      duration: 3000,
      horizontalPosition: "center",
      verticalPosition: "top",
      panelClass: isError ? ['msg-error'] : ['msg-success']
    });
  }

  create(client: Client): Observable<Client> {
    return this.http.post<Client>(this.baseUrl, client).pipe(
      map(obj => obj)
    );
  }

  read(): Observable<Client[]> {
    return this.http.get<Client[]>(this.baseUrl).pipe(
      map(obj => obj)
    );
  }

  readById(id: any): Observable<Client> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.get<Client>(url).pipe(
      map(obj => obj)
    );
  }

  update(client: Client): Observable<Client> {
    return this.http.put<Client>(this.baseUrl, client).pipe(
      map(obj => obj)
    );
  }

  delete(id: any): Observable<Client> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.delete<Client>(url).pipe(
       map(obj => obj)
    );
  }

  errorHandler(e: any): Observable<any> {
    console.log(e);
    this.showMessage('Ocorreu um erro!', true);
    return EMPTY;
  }

  buscarCep(cep: string) {
    const url = `${this.baseCepUrl}/${cep}`;
    return this.http.get<Endereco>(url).pipe(
      map(data => this.resultado = this.converterRespostaParaEndereco(data))
    );
  }

  private converterRespostaParaEndereco(cepNaResposta: Cep): Endereco{
    this.endereco.cep = cepNaResposta.cep;
    this.endereco.logradouro = cepNaResposta.logradouro;
    this.endereco.numero = cepNaResposta.numero;
    this.endereco.complemento = cepNaResposta.complemento;
    this.endereco.bairro = cepNaResposta.bairro;
    this.endereco.cidade = cepNaResposta.cidade;
    this.endereco.estado = cepNaResposta.estado;

    return this.endereco;
  }  

  createAdrressBasedOnCep(endereco: Endereco): Observable<Endereco> {
    return this.http.post<Endereco>(this.baseUrl, endereco).pipe(
      map(obj => obj)
    );
  }  

}
