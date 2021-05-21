import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IOrder } from 'src/app/shared/models/order';
import { environment } from 'src/environments/environment';
import { BreadcrumbService } from 'xng-breadcrumb';
import { OrdersService } from '../orders.service';

@Component({
  selector: 'app-order-detailed',
  templateUrl: './order-detailed.component.html',
  styleUrls: ['./order-detailed.component.scss']
})
export class OrderDetailedComponent implements OnInit {
order:IOrder;
  constructor(private orderService:OrdersService,private route:ActivatedRoute,private breadCrumbService:BreadcrumbService) {
    this.breadCrumbService.set('@OrderDetailed','');
   }

  ngOnInit(): void {
    this.orderService.getOrderDetailed(+this.route.snapshot.paramMap.get('id')).subscribe((order:IOrder)=>{
      this.order=order;
      this.breadCrumbService.set('@OrderDetailed',`Order# ${order.id} - ${order.status}`);
    },error=>{
      console.log(error);
    });
  }

}
