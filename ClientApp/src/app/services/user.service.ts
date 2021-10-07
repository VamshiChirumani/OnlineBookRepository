import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Subject} from 'rxjs';
import { User } from '../Models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }

  formData:User;
  readonly ApiUrl="https://localhost:44345/api";
  UserID:number=0;
  UserName:string="";
  getUserId(UName:string){
    this.UserName=UName;
    return this.http.get(this.ApiUrl+"/User?userName="+UName).subscribe(id=>{
      this.UserID=Number(id);
    }
  )
  }
  Adduser(user:User){
    return this.http.post(this.ApiUrl+"/User",user);
  }

  private _listners = new Subject<any>();
listen(): Observable<any>{
  return this._listners.asObservable();
}
filter(filterBy: string){
  this._listners.next(filterBy);
}

}
