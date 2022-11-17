import {Component, OnInit, ViewChild} from '@angular/core';
import { MatTableDataSource } from "@angular/material/table";
import IProductTableDto from "../../../interfaces/IProductTableDto";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { ProductService } from "../../../services/ProductService";
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { EditDialogComponent } from "./edit-dialog/edit-dialog.component";
import {IProductDto} from "../../../interfaces/IProductDto";

@Component({
  selector: 'admin-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class AdminProductsComponent implements OnInit {
  tableData: MatTableDataSource<IProductTableDto> = new MatTableDataSource();
  columns = [
    'image',
    'name',
    'model',
    'category',
    'listPrice',
    'delete'
  ];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private productService: ProductService, private dialog: MatDialog)
  { }

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

  editProduct(productId: number) {
    this.dialog
      .open(EditDialogComponent, { data: productId })
      .afterClosed()
      .subscribe((result?:IProductDto) => {
        if (result)
          this.onProductEdited(result);
      })
  }

  deleteProduct(product: IProductTableDto) {
    if (product.id && confirm(`Are you sure you want to delete ${product.name}`))
      this.productService
        .deleteProduct(product.id)
        .subscribe(successful => {
          if (successful)
            this.tableData.data = this.tableData.data.filter(p => p.id != product.id)
          else
            alert('deletion unsuccessful!');
        });
  }

  onProductEdited(result: IProductDto) {
    this.productService
      .updateProduct(result)
      .subscribe(successful => {
        if (successful){
          const product = this.tableData.data.filter(p => p.id == result.id)[0];
          product.name = result.name;
          product.listPrice = result.listPrice;
        }
      });
  }
}
