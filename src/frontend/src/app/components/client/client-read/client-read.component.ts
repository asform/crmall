import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Client } from '../client.model';
import { ClientService } from '../client.service';

@Component({
  selector: 'app-client-read',
  templateUrl: './client-read.component.html',
  styleUrls: ['./client-read.component.css']
})
export class ClientReadComponent implements OnInit {

  clients: Client[];
  displayedColumns = ['id','nome','dataNascimento','sexo','cep','logradouro','numero',
    'complemento','bairro','estado','cidade','action'];
    // displayedColumns = ['id','nome','dataNascimento','sexo','action'];
  constructor(
    private clientService: ClientService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.clientService.read().subscribe(clients => {
      this.clients = clients;
      console.log(clients);
    });
  }

  deleteClient(id: any): void {
    const confirmExclusion = confirm('Deseja mesmo excluir o cliente?');
    if (confirmExclusion) {
      this.clientService.delete(id).subscribe(() => {
        this.clientService.showMessage('Cliente excluído com sucesso!');
        this.router.navigate(['/clients']);
      });
    }
  }

}
