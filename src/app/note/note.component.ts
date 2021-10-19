import { Component, OnInit } from '@angular/core';
import { NoteService as NoteService } from '../services/note.service';
import { Note } from './note';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {

  notes: Note[] = [];
  searchedNote: Note[];

  constructor ( private noteService: NoteService ) { }

  ngOnInit(): void {
    this.noteService.serviceCall();
    this.notes = this.noteService.getNotes();
  }

  showNote(){
    
  }
  getNotes(){
    return this.notes;
  }

  deleteNote(id: string) {
    
    this.noteService.deleteNote(id);
  }

  getNoteById() {
    
    let id: string = "";
    this.noteService.getNoteByID(id)
  }

  getNoteByTitle() {
   
    let title: string = "";
    this.noteService.getNoteByTitle();
    
  }


  
}