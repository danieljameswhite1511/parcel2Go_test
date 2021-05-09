import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { QuotesService } from './quotes/quotes.service';
import { HomeComponent } from './home/home.component';
import { MenuModule } from './menu/menu.module';
import { ReactiveFormsModule } from '@angular/forms';
import { QuotesModule } from './quotes/quotes.module';
import { NgxSpinnerModule } from 'ngx-spinner';
import { LoadingInterceptor } from './shared/interceptors/loading.interceptor';
import { BusyService } from './shared/services/busy.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MenuModule,
    QuotesModule,
    ReactiveFormsModule,
    NgxSpinnerModule

  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  exports: [MenuModule, ReactiveFormsModule, QuotesModule],
  providers: [QuotesService, BusyService, {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true}],
  bootstrap: [AppComponent],


})
export class AppModule { }
