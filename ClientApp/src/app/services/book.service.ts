import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Subject} from 'rxjs';
import { Book } from '../Models/Book';
import { OrderService } from './order.service';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http:HttpClient) { }

  formData:Book;
  readonly ApiUrl="https://localhost:44345/api";
getBooks():Observable<Book[]>{
  return this.http.get<Book[]>(this.ApiUrl+ "/Books");
}

postBook(book:Book){
  return this.http.post(this.ApiUrl+"/Books",book);
}
putBook(book:Book){
  return this.http.put(this.ApiUrl+"/Books",book);
}

private _listners = new Subject<any>();
listen(): Observable<any>{
  return this._listners.asObservable();
}
filter(filterBy: string){
  this._listners.next(filterBy);
}


}
