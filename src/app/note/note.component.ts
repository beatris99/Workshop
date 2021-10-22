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
    this.noteService.getNotes().subscribe((result) =>{
    this.notes  = result;
    });
   // this.notes = this.noteService.getNotes();
  }
  
  ngOnChanges(): void {
    if (this.selectedCategoryId) {
      this.noteService.getFiltredNotes(this.selectedCategoryId).subscribe((result) =>{
        this.notes  = result;
        });
     // this.notes = this.noteService.getFiltredNotes(this.selectedCategoryId);
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

    this.noteService.deleteNote(id).subscribe(data => { console.log(data); });
  }

  getNoteById() {
    const inputElement = <HTMLInputElement>document.getElementById("searchInput");
    let id: string = " ";
    id = inputElement.value;
    if (id !== " ")
      this.noteService.getNoteById(id).subscribe((result) => this.notes = result);
    else
      this.ngOnInit();
  }
  
  getNoteByDescription() {
    const inputElement = <HTMLInputElement>document.getElementById("searchInputTitle");
    let description: string = " ";
    description = inputElement.value;
    console.log(description);
    if (description !== " ")
      this.noteService.getNoteByDescription(description).subscribe((result) => this.notes = result);
    else
      this.ngOnInit();
  }

  getNoteByTitle() {
    const inputElement = <HTMLInputElement>document.getElementById("searchInputTitle");
    let title: string = "";
    title = inputElement.value;
    console.log(title);
    if (title !== "")
      this.noteService.getNoteByTitle(title).subscribe((result) => this.notes = result);
    else
      this.ngOnInit();
  }

  redirectToEdit(id: string) {
    this.router.navigateByUrl('/app-edit-note/' + id);
  }

  
}