import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ProductService } from "../../../../services/ProductService";
import {IProductDto} from "../../../../interfaces/IProductDto";

@Component({
  selector: 'app-edit-dialog',
  templateUrl: './edit-dialog.component.html',
  styleUrls: ['./edit-dialog.component.scss']
})
export class EditDialogComponent implements OnInit {
  product!: IProductDto;

  constructor(private productsService: ProductService,
              @Inject(MAT_DIALOG_DATA) private productId: number) {

  }

  ngOnInit(): void {
    this.productsService
      .getProduct(this.productId)
      .subscribe(p => this.product = p);
  }

  public get name() { return this.product.name }
  public set name(name: string) { this.product.name = name }

  public get listPrice() { return this.product.listPrice }
  public set listPrice(price: number) { this.product.listPrice = price }
}
