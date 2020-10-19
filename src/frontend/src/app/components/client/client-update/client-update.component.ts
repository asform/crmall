import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Client } from '../client.model';
import { ClientService } from '../client.service';

@Component({
  selector: 'app-client-update',
  templateUrl: './client-update.component.html',
  styleUrls: ['./client-update.component.css']
})
export class ClientUpdateComponent implements OnInit {

  client: Client

  constructor(
    private clientService: ClientService, 
    private router: Router, 
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.clientService.readById(id).subscribe(client => {
      this.client = client;
    });
  }

  updateClient(): void {
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

    this.clientService.update(this.client).subscribe(() => {
      this.clientService.showMessage('Cliente atualizado com sucesso!');
      this.router.navigate(['/clients']); 
    });
  }

  cancel(): void {
    this.router.navigate(['/clients']);
  }
}
