import { ORDERS_DATA_MOCK } from './../../shared/orders.mock';
import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/shared/Order';

const ORDERS_DATA: Order[] = ORDERS_DATA_MOCK;

@Component({
  selector: 'app-section-orders',
  templateUrl: './section-orders.component.html',
  styleUrls: ['./section-orders.component.css']
})
export class SectionOrdersComponent implements OnInit {

  public orders: Order[] = ORDERS_DATA;
  
  constructor() { }

  ngOnInit() {
    console.log(ORDERS_DATA);
  }

}
