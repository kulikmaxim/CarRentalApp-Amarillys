import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { CarService } from 'src/app/services/car.service';
import { UserService } from 'src/app/services/user.service';
import { Car } from 'src/app/models/car';
import { User } from 'src/app/models/user';
import { Order } from 'src/app/models/order';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-order-form',
  templateUrl: './order-form.component.html',
  styleUrls: ['./order-form.component.css']
})
export class OrderFormComponent implements OnInit {
  orderForm: FormGroup;
  cars: Car[];
  users: User[];
  @Input() order: Order;
  @Output() onSubmitOrder = new EventEmitter<void>();
  constructor(private carService: CarService, 
    private userService: UserService,
    private orderService: OrderService) { }

  ngOnInit() {
    this.orderForm = new FormGroup({
      comment: new FormControl(this.order.comment),
      beginDate: new FormControl(this.order.rentalBeginDate),
      endDate: new FormControl(this.order.rentalEndDate),
      carId: new FormControl(this.order.carId),
      userId: new FormControl(this.order.userId),
    });
    this.carService.getCars()
      .subscribe((data: Car[]) => this.cars = data);
    this.userService.getUsers()
      .subscribe((data: User[]) => this.users = data);
  }

  onSubmit(formData) {
    let order: Order = {
      id: this.order.id,
      rentalBeginDate: formData.beginDate,
      rentalEndDate: formData.endDate,
      comment: formData.comment,
      carId: formData.carId,
      userId: formData.userId,
      car: null,
      user: null
    };

    this.order.id 
      ? this.orderService.editOrder(order)
      : this.orderService.addOrder(order);
    this.onSubmitOrder.emit();
  }
}
