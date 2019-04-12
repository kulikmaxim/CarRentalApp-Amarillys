import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Order } from 'src/app/models/order';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  @Input() orders: Order[];
  @Output() onDelete = new EventEmitter<number>();
  @Output() onEdit = new EventEmitter<number>();
  displayedColumns: string[] = 
    ['id', 'userName', 'car', 'rentalBeginDate', 'rentalEndDate', 'comment', 'edit', 'delete'];

  
  constructor() { }

  ngOnInit() {
  }

  deleteOrder(id : number) {
    this.onDelete.emit(id);
  }

  editOrder(id : number) {
    this.onEdit.emit(id);
  }
}
