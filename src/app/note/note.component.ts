import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Note } from './note';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {

  notes: Note[] = [
    {
      id: "Id1",
      title: "First note",
      description: "This is the description for the first note"
    },
    {
      id: "Id2",
      title: "Second note",
      description: "This is the description for the second note"
    }
  ];

  constructor( private router: Router) { }

  ngOnInit(): void {
  }

  showNote(){
   // this.router.navigateByURL()
  }

}
