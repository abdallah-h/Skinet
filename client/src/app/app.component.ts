import { IPagination } from './shared/models/pagination';
import { IProduct } from './shared/models/product';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'SkiNet';

  constructor() {}

  ngOnInit(): void {}
}
