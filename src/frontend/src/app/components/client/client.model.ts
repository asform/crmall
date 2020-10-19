import { Endereco } from './address.model';

export interface Client {
    id?: string
    nome: string
    dataNascimento: Date
    sexo: string
    endereco: Endereco
}