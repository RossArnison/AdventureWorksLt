import { Component, ViewChild, OnInit } from '@angular/core';
import { MatTableDataSource } from "@angular/material/table";
import { MatSort } from "@angular/material/sort";

import { ProductService } from 'src/app/services/ProductService';
import IProductTableDto from "src/app/interfaces/IProductTableDto";
import {MatPaginator, MatPaginatorModule} from "@angular/material/paginator";

@Component({
  selector: 'product-table',
  templateUrl: './product-table.component.html',
  styleUrls: ['./product-table.component.scss']
})
export class ProductTableComponent implements OnInit {
  tableData: MatTableDataSource<IProductTableDto> = new MatTableDataSource();
  columns = [
    'image',
    'name',
    'model',
    'category',
    'listPrice',
  ];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.productService
      .getProducts()
      .subscribe(products => this.setProducts(products));
  }

  ngAfterViewInit() {
    this.tableData.paginator = this.paginator;
    this.tableData.sort = this.sort;
  }

  setProducts(products: IProductTableDto[]) {
    this.tableData.data = products;
  }

  applyFilter(event: Event) {
    const input = event.target as HTMLInputElement
    const filter = input.value.trim().toUpperCase();
    this.tableData.filter = filter;
  }
}
