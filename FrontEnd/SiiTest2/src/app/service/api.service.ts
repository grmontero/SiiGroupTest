import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private urlApi = 'https://localhost:7234/api/Employees/getEmployees';
  
  
  constructor(private http: HttpClient) {}

  public getData(): Observable<any>{
    return this.http.get<any>(this.urlApi);
  }
  public getDataById(id:string): Observable<any>{
    return this.http.get<any>(this.urlApi + "/" + id);
  }
}