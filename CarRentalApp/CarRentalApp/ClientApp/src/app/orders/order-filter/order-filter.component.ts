import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { OrderFilter } from 'src/app/models/order-filter';

@Component({
  selector: 'app-order-filter',
  templateUrl: './order-filter.component.html',
  styleUrls: ['./order-filter.component.css']
})
export class OrderFilterComponent implements OnInit {
  filterForm: FormGroup;
  @Input() filter: OrderFilter;
  @Output() filtered = new EventEmitter<OrderFilter>();
  constructor() { }

  ngOnInit() {
    this.filterForm = new FormGroup({
      userName: new FormControl(this.filter.userName),
      beginDate: new FormControl(this.filter.beginDate),
      endDate: new FormControl(this.filter.endDate),
      mark: new FormControl(this.filter.mark),
      model: new FormControl(this.filter.model)
    });
  }

  applyFilter(orderFormValue) {
    let filter: OrderFilter = {
      userName: orderFormValue.userName,
      beginDate: orderFormValue.beginDate,
      endDate: orderFormValue.endDate,
      mark: orderFormValue.mark,
      model: orderFormValue.model,
    }

    this.filtered.emit(filter);
  }
}
