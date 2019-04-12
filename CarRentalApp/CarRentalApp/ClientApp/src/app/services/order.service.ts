import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { OrderFilter } from '../models/order-filter';
import { Order } from '../models/order';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  readonly url = 'https://localhost:44352/orders';
  private messageSource = new Subject();
  onChange = this.messageSource.asObservable();
  constructor(private http: HttpClient){ }

  getOrders() {
    return this.http.get(this.url);
  }

  deleteOrder(id: number) {
    return this.http.delete(this.url + `/${id}`);
  }

  addOrder(order: Order) {
    return this.http.post(this.url, order)
      .subscribe(_ => this.messageSource.next());
  }

  editOrder(order: Order) {
    return this.http.put(this.url + `/${order.id}`, order)
      .subscribe(_ => this.messageSource.next());
  }

  getOrdersByFilter(filter: OrderFilter) {
    let params = this.getParamsByFilter(filter);
    return this.http.get(this.url, {params});
  }

  private getParamsByFilter(filter: OrderFilter) {
    let params = new HttpParams();
    for (const key in filter) {
      if (filter.hasOwnProperty(key) && filter[key]) {
        params = params.set(key, filter[key]);   
      }
    }

    return params;
  }
}
