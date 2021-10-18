import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.scss']
})
export class AddNoteComponent implements OnInit {

  title: string;
  description: string;
 
  idCategoryNote: string;
  
  constructor( private router: Router) { }

  ngOnInit() {
    
  }

  add() {
    
    this.router.navigateByUrl('');
  }

}
