import { Component, OnInit } from '@angular/core';
import { Order } from '../models/order';
import { OrderFilter } from '../models/order-filter';
import { OrderService } from '../services/order.service';
import { MatDialog } from '@angular/material';
import { OrderModalComponent } from './order-modal/order-modal.component';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  orders: Order[];
  filter: OrderFilter = new OrderFilter();
  constructor(private orderService: OrderService, 
    public dialog: MatDialog) { }

  ngOnInit() {
    this.loadOrders();
    this.orderService.onChange
      .subscribe(_ => this.loadOrders());
  }
  
  loadOrders() {
    this.orderService.getOrdersByFilter(this.filter)
      .subscribe((data: Order[]) => this.orders = data);    
  }

  onDeleteOrder(id: number) {
    this.orderService.deleteOrder(id)
      .subscribe(_ => this.loadOrders());
  }

  onApplyFilter(filter: OrderFilter) {
    this.filter = filter;
    this.loadOrders();
  }

  openDialog(orderId?: number) {
    this.dialog.open(OrderModalComponent, {
      data: orderId ? this.orders.find(o => o.id === orderId) : new Order()
    });
  }
}
