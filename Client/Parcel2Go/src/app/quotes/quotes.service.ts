import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Quote } from './models/quote';


@Injectable({
  providedIn: 'root'
})
export class QuotesService {

  private apiUrl: string = 'https://localhost:5001/api/quotes/'

  constructor(private http: HttpClient) { }

  getQuote(weight: number){
    return this.http.get<Quote[]>(this.apiUrl + weight);
  }

  getServices(){
    return this.http.get(this.apiUrl + 'services');
  }
}
