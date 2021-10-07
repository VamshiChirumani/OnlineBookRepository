import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import {MatSnackBar} from '@angular/material/snack-bar';

import { BookService } from 'src/app/services/book.service';



@Component({
  selector: 'app-post-book',
  templateUrl: './post-book.component.html',
  styleUrls: ['./post-book.component.css']
})
export class PostBookComponent implements OnInit {

  constructor(public dialogBox:MatDialogRef<PostBookComponent>,
    public service:BookService,
    private snackBar:MatSnackBar) { }

    ngOnInit() {
      this.resetForm();
    }
  resetForm(form?:NgForm){
    if(form!=null)
    form.resetForm();
  
    this.service.formData={
      bookId:0,
      bookName:"",
      author:"",
      cost:0,
      rating:0
    }
  }
  onClose(){
    this.dialogBox.close();
    this.service.filter('Register click');
    }
  
    onSubmit(form:NgForm){
    
      this.service.postBook(form.value).subscribe(res=>
        {
          this.resetForm(form);
          this.snackBar.open("Book added successfully", '', {
            duration:5000,
            verticalPosition:'top'
          });
        }
        )
    }

}
