import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GetBookComponent } from './Component/Book/get-book/get-book.component';
import { GetItemsComponent } from './Component/Cart/get-items/get-items.component';
import { GetOrdersComponent } from './Component/Orders/get-orders/get-orders.component';
import { GetUserComponent } from './Component/user/get-user/get-user.component';
import { AddUserComponent } from './Component/user/add-user/add-user.component';

const routes: Routes = [
  { path: '', redirectTo: '/Books', pathMatch: 'full' },
  {path:'Books',component:GetBookComponent},
  {path:'Cart',component:GetItemsComponent},
  {path:'Orders',component:GetOrdersComponent},
  {path:'Login',component:GetUserComponent},
  {path:'UserRegistration',component:AddUserComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
