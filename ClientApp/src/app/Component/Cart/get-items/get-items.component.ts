import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import {MatDialog} from '@angular/material/dialog';
import { MatDialogConfig } from '@angular/material/dialog';

import { Cart } from 'src/app/Models/Cart';
import { CartService } from 'src/app/services/cart.service';
import { UserService } from 'src/app/services/user.service';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-get-items',
  templateUrl: './get-items.component.html',
  styleUrls: ['./get-items.component.css']
})
export class GetItemsComponent implements OnInit {

  constructor(private service:CartService,
    private userService:UserService,
    private orderService:OrderService) { }

    list: MatTableDataSource<any>;
    Dcolumns:string[]=["ItemId","bookId"];
    items:Cart[];
    userId=this.userService.UserID;
    userAvailable=false;
    userUnavailable=true;
    GetItems(){
      if(this.userId>0){
        this.userAvailable=true;
        this.userUnavailable=false;
      }
      else{
        this.userAvailable=false;
        this.userUnavailable=true;
      }
    }

  ngOnInit(): void {
    this.GetAllItems();
  }
  GetAllItems():void{
    this.service.getCartItems().subscribe(data=>{
      this.list=new MatTableDataSource(data);
    });
  }
  AdditemsToOrder(){
    this.orderService.postOrder().subscribe();
  }

}
