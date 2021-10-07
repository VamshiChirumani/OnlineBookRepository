import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import {MatTabsModule} from '@angular/material/tabs';
import {MatMenuModule} from '@angular/material/menu';
import {MatTableModule} from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { HttpClientModule } from '@angular/common/http';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GetOrdersComponent } from './Component/Orders/get-orders/get-orders.component';
import { PostOrdersComponent } from './Component/Orders/post-orders/post-orders.component';
import { PostItemComponent } from './Component/Cart/post-item/post-item.component';
import { GetItemsComponent } from './Component/Cart/get-items/get-items.component';
import { PostBookComponent } from './Component/Book/post-book/post-book.component';
import { GetBookComponent } from './Component/Book/get-book/get-book.component';
import { GetUserComponent } from './Component/user/get-user/get-user.component';
import { AddUserComponent } from './Component/user/add-user/add-user.component';

import { BookService } from './services/book.service';
import { UserService } from './services/user.service';
import { CartService } from './services/cart.service';
import { OrderService } from './services/order.service';
import { EditBookComponent } from './component/book/edit-book/edit-book.component';

@NgModule({
  declarations: [
    AppComponent,
    GetOrdersComponent,
    PostOrdersComponent,
    PostItemComponent,
    GetItemsComponent,
    PostBookComponent,
    GetBookComponent,
    GetUserComponent,
    AddUserComponent,
    EditBookComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    MatTabsModule,
    MatMenuModule,
    MatTableModule,
    HttpClientModule,
    MatDialogModule,
    MatSnackBarModule,
    MatFormFieldModule,
    MatInputModule
  ],
  providers: [BookService,UserService,CartService,OrderService],
  bootstrap: [AppComponent]
})
export class AppModule { }
