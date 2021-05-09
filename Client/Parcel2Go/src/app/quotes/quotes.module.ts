import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuoteCardComponent } from './quote-card/quote-card.component';
import { QuotesComponent } from './quotes.component';
import { QuoteServiceCardComponent } from './quote-service-card/quote-service-card.component';



@NgModule({
  declarations: [
    QuoteCardComponent,
    QuotesComponent,
    QuoteServiceCardComponent

  ],
  imports: [
    CommonModule
  ]
})
export class QuotesModule { }
