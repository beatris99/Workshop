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
    return this.getNotes();
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
    this.noteService.getNotes().subscribe((result) =>{
      this.notes  = result;
      });
   
  }

  deleteNote(id: string) {
    console.log(id);
    
    this.noteService.deleteNote(id).subscribe(() =>this.getNotes());
    
   // this.ngOnInit();
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
    const inputElement = <HTMLInputElement>document.getElementById("searchInputDescription");
    let description: string = " ";
    description = inputElement.value;
    console.log(description);
    if (description !== "")
      this.noteService.getNoteByDescription(description).subscribe((result) => this.notes = result);
    else
      this.ngOnInit();
  }

  getNoteByTitle() {
    const inputElement = <HTMLInputElement>document.getElementById("searchInputTitle");
    let title: any = "";
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