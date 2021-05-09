import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { QuotesComponent } from './quotes.component';
import { QuotesService } from './quotes.service';

const routes: Routes = [
  {path: '', component: QuotesComponent},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  providers: [QuotesService],
  exports: [RouterModule]
})
export class QuotesRoutingModule { }
