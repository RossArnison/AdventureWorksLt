import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module';

import { MatTableModule } from "@angular/material/table";
import { MatSortModule } from "@angular/material/sort";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatTooltipModule } from "@angular/material/tooltip";
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';

import { ProductService } from "./services/ProductService";

import { AppComponent } from './app.component';
import { AdminComponent } from './components/admin/admin.component';
import { ToolbarComponent } from './components/shared/toolbar/toolbar.component';
import { ProductsComponent } from './components/products/products.component';
import { ProductTableComponent } from './components/products/product-table/product-table.component';
import { LoadingSpinnerComponent } from './components/shared/loading-spinner/loading-spinner.component';
import { AdminProductsComponent } from './components/admin/products/products.component';
import { AdminProductCategoriesComponent } from './components/admin/product-categories/product-categories.component';
import { AdminProductDescriptionsComponent } from './components/admin/product-descriptions/product-descriptions.component';
import { EditDialogComponent } from './components/admin/products/edit-dialog/edit-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    ToolbarComponent,
    ProductsComponent,
    ProductTableComponent,
    LoadingSpinnerComponent,
    AdminProductsComponent,
    AdminProductCategoriesComponent,
    AdminProductDescriptionsComponent,
    EditDialogComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatTooltipModule,
    MatIconModule,
    MatDialogModule
  ],
  providers: [
    ProductService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
