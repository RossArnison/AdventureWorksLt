import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProductsComponent } from './components/products/products.component';
import { AdminComponent } from "./components/admin/admin.component";

const routes: Routes = [
  { path: '',  component: ProductsComponent },
  { path: 'admin',  component: AdminComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
