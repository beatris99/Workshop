import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { NoteService as NoteService } from '../services/note.service';
import { Note } from './note';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit, OnChanges {

  notes: Note[] = [];
  searchedNote: Note[];
  @Input() selectedCategoryId: string;

  constructor(private noteService: NoteService, private router: Router) { }
  
  ngOnInit(): void {
    this.noteService.serviceCall();
    this.notes = this.noteService.getNotes();
  }
  
  ngOnChanges(): void {
    if (this.selectedCategoryId) {
      this.notes = this.noteService.getFiltredNotes(this.selectedCategoryId);
    }

  }

  getNotes(){
    return this.notes;
  }

  deleteNote(id: string) {
    console.log(id);
    let indexToBeRemoved = -1;
    this.notes.forEach((note, index) => {
      if (note.id === id) {
        indexToBeRemoved = index;
      }
    })
    if (indexToBeRemoved != -1) {
      this.notes.splice(indexToBeRemoved, 1);
    }
    this.notes.splice(1);
  }

  getNoteByDescription() {
    
    const inputElement = <HTMLInputElement>document.getElementById("searchInput");
    let description: string = "";
    description = inputElement.value;
    if (description !== "")
      {
        this.noteService.getNoteByDescription(description);
        this.getNotes();
      }
    else
      this.ngOnInit();
  }

  getNoteByTitle() {
    const inputElement = <HTMLInputElement>document.getElementById("searchInputTitle");
    let title: string = "";
    title = inputElement.value;
    console.log(title);
    if (title !== "")
      this.noteService.getNoteByTitle(title);
    else
      this.ngOnInit();
  }

  redirectToEdit(id: string) {
    this.router.navigate(['edit-note', id]);
  }

  
}