import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from './company';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiurl ="https://localhost:7029/api/CompanyController1";
  constructor(private http: HttpClient) { }

  get():Observable<any>{
    return this.http.get(this.apiurl)
  }
  getbyid(id:number):Observable<any>{
    return this.http.get(`${this.apiurl}/${id}`)
  }
  post(company:Company):Observable<any>{
    return this.http.post<any>(`${this.apiurl}`,company)
  }
  delete(id:number):Observable<any>{
    return this.http.delete(`${this.apiurl}/${id}`)
  }
  update(id:number,company:Company):Observable<Company>{
    return this.http.put<Company>(`${this.apiurl}/${id}`,company);
  }
}
