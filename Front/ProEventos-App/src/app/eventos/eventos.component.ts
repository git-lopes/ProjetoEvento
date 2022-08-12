import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any =[];
  larguraImagem: number = 150;
  margemImagem: number  = 2;
  exibirImagem: boolean = true;
  private _filtrolista: string = '';

  public get filtroLista() {
    return this._filtrolista;
  }

  public set filtroLista(value: string) {
    this._filtrolista=value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;

  }
  filtrarEventos(filtrarPor:String) : any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter (
     (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
     evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

constructor(private http:HttpClient) {

}

  alterarImagem() {
    this.exibirImagem = !this.exibirImagem
  }

  ngOnInit(): void {
    this.getEventos();
  }
  public getEventos():void {
    this.http.get('https://localhost:7203/api/eventos').subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      error => console.log(error)
    );
  }
}
