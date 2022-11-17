import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
  currentTable = tableEnum.products;
  tableEnum = tableEnum;

  ngOnInit(): void {
  }

}

enum tableEnum {
  products,
  descriptions,
  categories
}
