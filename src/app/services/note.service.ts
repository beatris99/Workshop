import { Injectable } from '@angular/core';
import { Note } from '../note/note';

@Injectable()
export class NoteService {


  notes: Note[] = [
    {
    id: "Id1",
    title: "First note",
    description: "This is the description for the first note",
    categoryId: "1"
  },
    {
    id: "Id2",
    title: "Second note",
    description: "This is the description for the second note",
    categoryId: "2"
    }
    ];
  constructor() { }

  serviceCall() {
    console.log("Note service was called");
  }
  
  getNotes() {
    return this.notes;
  }
  getFiltredNotes(categoryId: string){
    return this.notes.filter(note => note.categoryId === categoryId);
  }
  getNoteById(id: string)
  {
    console.log(id);
    return this.notes.filter(note => note.categoryId === id);
  }
  getNoteByDescription(description: string) {
    console.log(description);
    return this.notes.filter(
      note =>  note.description == description);
  
  }

  getNoteByTitle(title: string) {
    console.log(this.getNoteByTitle);
    return this.notes.filter(note => note.title === title);
    
  }
  addNote(noteTitle: string, noteDescription: string, noteCategoryId: string) {
    let note: Note = {
      id: "10",
      description: noteDescription,
      title: noteTitle,
      categoryId: noteCategoryId
    }
    return this.notes.push(note) ;
  }
  updateNote(note: Note) {
    return this.notes;
  }

  deleteNote(id: number)
  {
    return this.notes.splice(id, 1);
  }
}
