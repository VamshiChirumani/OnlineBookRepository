import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from '../Models/Book';
import { Order } from '../Models/Order';
import {Subject} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http:HttpClient) { }

  readonly ApiUrl="https://localhost:44345/api";

  getOrders():Observable<Order[]>{
    return this.http.get<Order[]>(this.ApiUrl+"/Orders");
  }

  postOrder(){
    return this.http.post(this.ApiUrl+"/Orders",null);
  }

  postOrderFromBookList(book:Book){
    return this.http.post(this.ApiUrl+"/PostBookOrderFromBookList?BookId="+book.bookId.toString(),null)
  }

  postOrderFromSell(book:Book){
    return this.http.post(this.ApiUrl+"/PostBookOrderFromSell?bookId="+book.bookId.toString(),null)
  }

  private _listners = new Subject<any>();
  listen(): Observable<any>{
    return this._listners.asObservable();
  }
  filter(filterBy: string){
    this._listners.next(filterBy);
  }

}
