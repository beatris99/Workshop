import { Injectable } from '@angular/core';
import { Note } from '../note/note';

@Injectable()
export class NoteService {


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
  constructor() { }

  serviceCall() {
    console.log("Note service was called");
  }
  
  getNotes() {
    return this.notes;
  }
  getNoteByID(id:any) {
    console.log(id);
    
  }

  getNoteByTitle() {
    console.log(this.getNoteByTitle);
    
  }
  addNote(noteTitle: string, noteDescription: string, noteCategoryId: string) {
    let note = {
      description: noteDescription,
      title: noteTitle,
      categoryId: noteCategoryId
    }
    return this.addNote;
  }
  updateNote(note: Note) {
    return this.notes;
  }

  deleteNote(id:string)
  {
    return this.deleteNote;
  }
}
