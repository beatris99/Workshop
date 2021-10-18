import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-tools',
  templateUrl: './tools.component.html',
  styleUrls: ['./tools.component.scss']
})
export class ToolsComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {}
  
  addNote(): void{
    this.router.navigateByUrl('/addnote');
    }
 }
