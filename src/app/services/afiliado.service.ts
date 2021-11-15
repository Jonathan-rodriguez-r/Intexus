import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AfiliadoService {
private appurl = 'https://localhost:44383';
private apiurl = '/api/crud';
private deleteurl = '/EliminarAfiliado';
private saveurl='/InsertarAfiliado';
private updateurl='/ActualizarAfiliado';
  constructor(private http : HttpClient ) { }
  getlistafiliados (): Observable <any>{
    return this.http.get(this.appurl+this.apiurl);
  };
  deleteafiliado (id : number): Observable <any> {
    return this.http.post(this.appurl+this.apiurl+this.deleteurl, id);
  }
  saveafiliado(afiliado: any): Observable<any> {
    return this.http.post(this.appurl+this.apiurl+this.saveurl, afiliado);
  }
  updateafiliado (id: number, afiliado: any): Observable <any> {
    return this.http.post(this.appurl+this.apiurl+this.updateurl, afiliado);

  }
}
