import { Component, Input, OnInit } from '@angular/core';
import { Service } from '../models/service';

@Component({
  selector: 'app-quote-service-card',
  templateUrl: './quote-service-card.component.html',
  styleUrls: ['./quote-service-card.component.css']
})
export class QuoteServiceCardComponent implements OnInit {

  @Input() public services: Service[];

  constructor() { }

  ngOnInit(): void {
  }

}
