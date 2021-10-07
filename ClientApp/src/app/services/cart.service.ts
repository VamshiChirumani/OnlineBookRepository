import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cart } from '../Models/Cart';
import {Subject} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private http:HttpClient) { }

  readonly ApiUrl="https://localhost:44345/api";

  getCartItems():Observable<Cart[]>{
    return this.http.get<Cart[]>(this.ApiUrl+"/GetCartItems");
  }
  
  postCartItem(id:number){
    return this.http.post(this.ApiUrl+"/PostCartItems",id);
  }

  private _listners = new Subject<any>();
listen(): Observable<any>{
  return this._listners.asObservable();
}
filter(filterBy: string){
  this._listners.next(filterBy);
}
  
}


