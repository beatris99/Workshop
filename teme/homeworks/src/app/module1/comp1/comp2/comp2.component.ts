import { Component, Input, OnInit } from '@angular/core';
import { Comp1Component } from '../comp1.component';

@Component({
  selector: 'app-comp2',
  templateUrl: './comp2.component.html',
  styleUrls: ['./comp2.component.scss']
})
export class Comp2Component implements OnInit {

  
  constructor() { }

  ngOnInit(): void {
  }

}
