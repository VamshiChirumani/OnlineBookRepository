import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { BookService } from 'src/app/services/book.service';

import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-edit-book',
  templateUrl: './edit-book.component.html',
  styleUrls: ['./edit-book.component.css']
})
export class EditBookComponent implements OnInit {

  constructor(public dialogBox:MatDialogRef<EditBookComponent>,
    public bookService:BookService,
    private snackBar:MatSnackBar) { }

  ngOnInit(): void {
  }

  onClose(){
    this.dialogBox.close();
    this.bookService.filter('Register click');
      }

  onSubmit(form:NgForm){
    this.bookService.putBook(form.value).subscribe(res=>{
      this.snackBar.open(res.toString(),'',{
        duration:5000,
        verticalPosition:'top'

      })
    })
  }

}
