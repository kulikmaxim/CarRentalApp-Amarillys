import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OrderService } from './services/order.service';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule }   from '@angular/common/http';
import { OrdersComponent } from './orders/orders.component';
import { OrderListComponent } from './orders/order-list/order-list.component';
import { MatTableModule, MatButtonModule, MatDatepickerModule, MatFormFieldModule, MatNativeDateModule, MatInputModule, MatDialogModule, MatSelectModule } from '@angular/material';
import { OrderFilterComponent } from './orders/order-filter/order-filter.component';  
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OrderFormComponent } from './orders/order-form/order-form.component';
import { OrderModalComponent } from './orders/order-modal/order-modal.component';
import { UserService } from './services/user.service';
import { CarService } from './services/car.service';

@NgModule({
  declarations: [
    AppComponent,
    OrdersComponent,
    OrderListComponent,
    OrderFilterComponent,
    OrderFormComponent,
    OrderModalComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    MatTableModule,
    MatButtonModule,
    MatInputModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatFormFieldModule,
    MatDialogModule,
    MatSelectModule
  ],
  entryComponents: [OrderModalComponent],
  providers: [OrderService, UserService, CarService, HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
