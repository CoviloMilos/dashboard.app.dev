import { Customer } from './../_models/customer';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Server } from '../_models/server';
import { Order } from '../shared/order';


@Injectable({
  providedIn: 'root'
})
export class AdvantageService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCustomers() {
    return this.http.get<Customer[]>(this.baseUrl + "customer");
  }

  getCustomer(id): Observable<Customer> {
    return this.http.get<Customer>(this.baseUrl+ "customer/" + id);
  }

  getServers() {
    return this.http.get<Server[]>(this.baseUrl + 'servers');
  }

  changeServerStatus(id) {
    return this.http.get<any>(this.baseUrl + 'servers/changeStatus/' + id);
  }

  getOrders(pageIndex: number, pageSize: number) {
    return this.http.get<Order[]>(this.baseUrl + "orders/" + pageIndex + "/" + pageSize);
  }

}
