import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Category } from '../module/category';
import { FilterService } from '../services/filter.service';


@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {

  categories: Category[];
  @Output() emitSelectedFilter = new EventEmitter<string>();
    
  constructor(private filterService: FilterService) {}

  ngOnInit() {
    this.categories = this.filterService.categories;
  }

  selectFilter(categoryId: string) {
    this.emitSelectedFilter.emit(categoryId);
  }

}
