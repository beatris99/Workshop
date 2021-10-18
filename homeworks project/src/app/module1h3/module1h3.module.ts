import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Component1Component } from './component1/component1.component';
import { Component2Component } from './component1/component2/component2.component';
import { Component3Component } from './component1/component2/component3/component3.component';



@NgModule({
  declarations: [
    Component1Component,
    Component2Component,
    Component3Component
  ],
  imports: [
    CommonModule
  ],
  exports: [
    Component1Component,
    Component2Component,
  
  ]
})
export class Module1h3Module { }
