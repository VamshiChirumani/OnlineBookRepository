import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { AddUserComponent } from '../add-user/add-user.component';


import { MatDialogConfig } from '@angular/material/dialog';
import {MatDialog} from '@angular/material/dialog';

@Component({
  selector: 'app-get-user',
  templateUrl: './get-user.component.html',
  styleUrls: ['./get-user.component.css']
})
export class GetUserComponent implements OnInit {

  constructor(private service:UserService,
    private dialog:MatDialog) { }

  ngOnInit(): void {
  }
  UserName:string="";
  UserAvailable:boolean=true;
  

  getUser(){
    this.service.getUserId(this.UserName); 
    this.UserAvailable=false;
  }
  onAdd(){
    const dialogConfig=new MatDialogConfig();
    dialogConfig.disableClose=true;
    dialogConfig.autoFocus=true;
    dialogConfig.width="70%";
    this.dialog.open(AddUserComponent,dialogConfig);
  }


}
