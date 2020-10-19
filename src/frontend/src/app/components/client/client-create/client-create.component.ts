import { ClientService } from './../client.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Client } from '../client.model';
import { Endereco } from '../address.model';
import { Sexo } from '../sexo.model';

@Component({
  selector: 'app-client-create',
  templateUrl: './client-create.component.html',
  styleUrls: ['./client-create.component.css']
})
export class ClientCreateComponent implements OnInit {

  endereco: Endereco = { 
    cep: '',
    logradouro: '',
    numero: '',
    complemento: '',
    bairro: '',
    estado: '',
    cidade: '',
  }

  client: Client = {
    nome: '',
    dataNascimento: null,
    sexo: null,
    endereco: this.endereco
  }

  constructor(
    private clientService: ClientService,
    private router: Router
  ) { }

  ngOnInit(): void {
    
  }

  createClient(): void {

    if (!this.client.nome){
      this.clientService.showMessage('Nome é obrigatório!');   
      return;
    }
    else if (!this.client.dataNascimento){
      this.clientService.showMessage('Data de nascimento é obrigatório!');   
      return;      
    }    
    else if (!this.client.sexo){
      this.clientService.showMessage('Sexo é obrigatório!');   
      return;      
    }

    this.clientService.create(this.client).subscribe(() => {
      this.clientService.showMessage('Cliente cadastrado com sucesso!');
      this.router.navigate(['/clients']);
    });

  }

  cancel(): void {
    this.router.navigate(['/clients']);
  }

  somenteNumeros(e: any) {
    let charCode = e.charCode ? e.charCode : e.keyCode;
    // charCode 8 = backspace   
    // charCode 9 = tab
  
    if (charCode != 8 && charCode != 9) {
      // charCode 48 equivale a 0   
      // charCode 57 equivale a 9
      let max = 3;    
  
      if ((charCode < 48 || charCode > 57)||(e.target.value.length >= max)) return false;
    }
  }

  chamarServicoCepPreenchendoCamposEndereco(cep: any) {
    if (this.somenteNumeros(cep)){
      this.clientService.buscarCep(cep).subscribe(dadosCep => {
        this.endereco.cep = dadosCep.cep;
        this.endereco.logradouro = dadosCep.logradouro;
        this.endereco.numero = dadosCep.numero;
        this.endereco.complemento = dadosCep.complemento;
        this.endereco.bairro = dadosCep.bairro;
        this.endereco.estado = dadosCep.estado;
        this.endereco.cidade = dadosCep.cidade;
      });
    }
  }
}
