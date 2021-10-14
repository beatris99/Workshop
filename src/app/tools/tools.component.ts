import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tools',
  templateUrl: './tools.component.html',
  styleUrls: ['./tools.component.scss']
})
export class ToolsComponent implements OnInit {

  title: string = "Something";
  textColor: string = "";
  noteContent: string= "";
  constructor() { }

  ngOnInit(): void {
    this.title = "something else";
  }
  
  buttonClick(): void{
    
    this.textColor = this.noteContent;
    this.noteContent= " ";
  }

}
