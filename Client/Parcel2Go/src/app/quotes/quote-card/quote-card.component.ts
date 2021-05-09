import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Quote } from '../models/quote';

@Component({
  selector: 'app-quote-card',
  templateUrl: './quote-card.component.html',
  styleUrls: ['./quote-card.component.css']
})
export class QuoteCardComponent implements OnInit {

  @Input() public quotes: Quote[];
  @Input() public weight: number;
  @Output() public asc = new EventEmitter<any>();
  @Output() public desc = new EventEmitter<any>();

  constructor() { }

  ngOnInit(): void {
  }

  sortAsc(){

    this.asc.emit();
  }

  sortDesc(){

    this.desc.emit();

  }

}
