import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IOrder } from '../shared/models/order';
import { OrdersService } from './orders.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {

 orders:IOrder[];

  constructor(private orderService:OrdersService) { }

  ngOnInit(): void {
this.getOrders();
  }
getOrders(){
  this.orderService.getOrders().subscribe((orders:IOrder[])=>{
    this.orders=orders
  },error=>{
    console.log(error);
  });
}

}
