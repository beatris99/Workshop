import { Component, OnInit } from '@angular/core';
import { Items } from '../module/items';

@Component({
  selector: 'app-tools',
  templateUrl: './tools.component.html',
  styleUrls: ['./tools.component.scss']
})
export class ToolsComponent implements OnInit {

  title: string = "something";
  textColor: string = "";
  noteContent: string= "";
  noteContentBground: string= "";
  sizeTitle: string="px";
  size: string="";
  bColor: string="";
  color=' ';
  
  items: Items[] = [
    {name:'banana', id:'1'},
    {name:'milk', id:'2'},
    {name:'eggs', id:'3'}
    ];

  currentDate= [
    "2019-06-17 09:21:20+05:30",
    "2019-06-18 09:21:20+05:30",
    "2019-06-19 09:21:20+05:30",
    "2019-06-20 09:21:20+05:30"
    ];

  constructor() { }


  ngOnInit(): void {
    this.title = "something else";
  }
  
  buttonClick(): void{
    
    this.textColor = this.noteContent;
    this.noteContent= " ";
    
    
  }
  setTheme(): void{
    this.bColor = this.noteContentBground;
    this.noteContentBground="";
  }

  setSize(): void{
    this.sizeTitle = this.size;
    this.sizeTitle = "";
  }
 

  
}
