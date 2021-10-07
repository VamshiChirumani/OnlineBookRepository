import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Order } from 'src/app/Models/Order';

import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-get-orders',
  templateUrl: './get-orders.component.html',
  styleUrls: ['./get-orders.component.css']
})
export class GetOrdersComponent implements OnInit {

  constructor(private orderService:OrderService) { }

  list: MatTableDataSource<any>;
  list1:Order[];
  Dcolumns:string[]=["OrderId","Category","Amount"];

  ngOnInit(): void {
    this.GetOrders();
  }
  GetOrders():void{
    this.orderService.getOrders().subscribe(data=>{
      this.list=new MatTableDataSource(data);
      this.list1=data;
    })
  }

}
