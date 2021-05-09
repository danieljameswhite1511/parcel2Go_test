import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Quote } from './models/quote';
import { Service } from './models/service';
import { QuotesService } from './quotes.service';

@Component({
  selector: 'app-quotes',
  templateUrl: './quotes.component.html',
  styleUrls: ['./quotes.component.css']
})
export class QuotesComponent implements OnInit {

  public quotes: Quote[];
  public form: FormGroup = new FormGroup({});
  public weights:any[] = [1,2,3,4,5,10,20,50,100];
  public weight: number;
  public services: Service[];

  constructor(private quoteService: QuotesService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.quoteService.getServices().subscribe((services: Service[])=>{

      this.services=services;
      console.log(this.services);

    });
    this.createForm();
  }

  createForm(){
    this.form = this.formBuilder.group({
      search: new FormControl('')
    });
  }

  getQuotes(weight: number){
    this.quoteService.getQuote(weight).subscribe((quotes: Quote[])=>{
      this.weight=weight;
      this.quotes=quotes;
    });
  }

  sortAsc(){

    this.quotes.sort((a, b) => {
      if (b.totalPrice < a.totalPrice) return -1
      return b.totalPrice > a.totalPrice ? 1 : 0
    });

  }

  sortDesc(){

    this.quotes.sort((a, b) => {
      if (a.totalPrice < b.totalPrice) return -1
      return a.totalPrice > b.totalPrice ? 1 : 0
    });
  }
}
