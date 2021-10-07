import { Component, OnInit } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import {MatDialog} from '@angular/material/dialog';
import { MatDialogConfig } from '@angular/material/dialog';

import { Book } from 'src/app/Models/Book';
import { BookService } from 'src/app/services/book.service';
import { PostBookComponent } from '../post-book/post-book.component';
import { EditBookComponent } from '../edit-book/edit-book.component';
import { CartService } from 'src/app/services/cart.service';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-get-book',
  templateUrl: './get-book.component.html',
  styleUrls: ['./get-book.component.css']
})
export class GetBookComponent implements OnInit {

  constructor( private bookservice:BookService,
    private dialog:MatDialog,
    private cartService:CartService,
    private orderService:OrderService ) {}

  list: MatTableDataSource<any>;
  Dcolumns:string[]=["Options","bookName","author","rating","cost"];
  // books:Book[];


selectedBook:Book;
  ngOnInit(): void {
    this.GetAllBooks();
  }

  GetAllBooks():void{
    this.bookservice.getBooks().subscribe(data=>{
      this.list=new MatTableDataSource(data);
    });
  }
  onEdit(book:Book){
    this.bookservice.formData=book;
    const dialogConfig=new MatDialogConfig();
    dialogConfig.disableClose=true;
    dialogConfig.autoFocus=true;
    dialogConfig.width="70%";
    this.dialog.open(EditBookComponent,dialogConfig);
  }
  AddBookToCart(book:Book){
    this.orderService.postOrderFromSell(book).subscribe();
    this.cartService.postCartItem(book.bookId).subscribe();
  }

  Buy(book:Book){
    this.orderService.postOrderFromBookList(book).subscribe();
  }

  onAdd(){
    const dialogConfig=new MatDialogConfig();
    dialogConfig.disableClose=true;
    dialogConfig.autoFocus=true;
    dialogConfig.width="70%";
    this.dialog.open(PostBookComponent,dialogConfig);
  }


}
