import { Component, OnInit } from '@angular/core';
import { Category } from '../module/category';


@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {

  categories: Category[] = [
    {name:'To Do', id:'1'},
    {name:'Done', id:'2'},
    {name:'Doing', id:'3'}
    ];
    

  
  constructor() { }

  ngOnInit(): void {
  }

}
