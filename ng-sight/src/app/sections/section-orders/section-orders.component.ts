import { AdvantageService } from './../../_services/advantage.service';
import { ORDERS_DATA_MOCK } from './../../shared/orders.mock';
import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/shared/order';


const ORDERS_DATA: Order[] = ORDERS_DATA_MOCK;

@Component({
  selector: 'app-section-orders',
  templateUrl: './section-orders.component.html',
  styleUrls: ['./section-orders.component.css']
})
export class SectionOrdersComponent implements OnInit {

  public orders: Order[];
  total = 0;
  page = 1;
  limit = 10;
  loading = false;

  constructor(private advantageService: AdvantageService) { }

  ngOnInit() {
    this.loadOrders();
  }

  loadOrders() {
   this.advantageService.getOrders(this.page, this.limit)
    .subscribe(
      (res: Order[]) => {
        console.log('Result from getOrders: ', res);
        this.orders = res['page']['data'];
        this.total = res['page'].total;
        this.loading = false;
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  goToPrevious(): void {
    this.page--;
    this.loadOrders();
  }

  goToNext(): void {
    this.page++;
    this.loadOrders();
  }

  goToPage(n: number): void {
    this.page = n;
    this.loadOrders();
  }
}
