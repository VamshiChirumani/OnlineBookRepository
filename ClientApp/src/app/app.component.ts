import { Component , OnInit} from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(){}

  title = 'Online Book Store';
  id=0;
  username : string;
  Books = false;  
Cart = false;  
Order=false;

active = 0
  onSelect(active=1){
    if(active == 1){
      this.Books = true; // Books screen visible
      this.Cart = false;
      this.Order=false;
    }else if(active == 2){
      this.Books = false; 
      this.Cart = true;  // Cart screen visible
      this.Order=false;
    }else if(active==3){
      this.Books = false; 
      this.Cart = false; 
      this.Order=true;//Orders screen visible
    }
    else{
      this.Books = false; 
      this.Cart = false; 
      this.Order=false;
    }
   }
   
  
}

