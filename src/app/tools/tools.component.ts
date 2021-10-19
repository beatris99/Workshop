import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-tools',
  templateUrl: './tools.component.html',
  styleUrls: ['./tools.component.scss']
})
export class ToolsComponent implements OnInit {

  title: string = 'Add note';
  titleColor: string = 'red';
  noteContent: string = '';
  testValue: boolean = true;

  array = ['first', 'second'];
  constructor(private router: Router) { }

  ngOnInit(): void {}
  
  addNote(): void{
    this.router.navigateByUrl('/addnote');
    }
  
  setTitle() {
      this.title = 'test event binding';
    }
  
  setValue(): boolean {
      return true;
    }
 }
