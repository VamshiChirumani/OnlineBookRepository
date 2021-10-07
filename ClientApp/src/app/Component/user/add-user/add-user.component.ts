import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import {MatSnackBar} from '@angular/material/snack-bar';

import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  constructor(public dialogBox:MatDialogRef<AddUserComponent>,
    public service:UserService,
    private snackBar:MatSnackBar) { }

  ngOnInit() {
    this.resetForm();
  }
resetForm(form?:NgForm){
  if(form!=null)
  form.resetForm();

  this.service.formData={
    UserId: 0 ,
    Name:"",
    Email:"",
    Address:""
  }
}
onClose(){
  this.dialogBox.close();
  this.service.filter('Register click');
  }

  onSubmit(form:NgForm){
  
    this.service.Adduser(form.value).subscribe(res=>
      {
        this.resetForm(form);
        this.snackBar.open("User registered successfully", '', {
          duration:5000,
          verticalPosition:'top'
        });
      }
      )
  }

}
