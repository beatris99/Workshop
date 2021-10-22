import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Note } from '../note/note';
import { map } from "rxjs/operators";

@Injectable()
export class NoteService {


  readonly  baseUrl= "https://localhost:4200";
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
  };

  inputSearch: string;
  constructor(private HttpClient: HttpClient) { }

  serviceCall() {
    console.log("Note service was called");
  }
  
  getNotes(): Observable<Note[]> {
    return this.HttpClient.get<Note[]>(this.baseUrl + '/notes', this.httpOptions);
  }
  getFiltredNotes(categoryId: string){
    return this.HttpClient.get<Note[]>(this.baseUrl + '/notes', this.httpOptions).pipe(map((notes) => notes.filter((note) => note.categoryId === categoryId)));
  }
  getNoteById(id: string): Observable<Note[]>{
    
    return this.HttpClient.get<Note[]>(this.baseUrl + '/notes', this.httpOptions).pipe(map((notes) => notes.filter(note => note.id == id)));
  }
  getNoteByDescription(description: string) {
    return this.HttpClient.get<Note[]>(this.baseUrl + '/note', this.httpOptions).pipe(map((notes) => notes.filter(note => note.description == description)));
  }

  getNoteByTitle(title: string) {
    console.log(this.getNoteByTitle);
    return this.HttpClient.get<Note[]>(this.baseUrl + '/notes', this.httpOptions).pipe(map((notes) => notes.filter(el => el.title == title)));
  }
  addNote(noteTitle: string, noteDescription: string, noteCategoryId: string) {
    const note: Note = {
      
      description: noteDescription,
      title: noteTitle,
      categoryId: noteCategoryId
    }
    return this.HttpClient.post(this.baseUrl + '/notes', note, this.httpOptions).subscribe();
  }
  updateNote(note: Note) {
    return this.HttpClient.put<Note>(this.baseUrl + 'app-edit-note' + note.id, note, this.httpOptions);
  }

  deleteNote(id: string)
  {
    return this.HttpClient.delete(this.baseUrl + '/note/' + id, this.httpOptions);
  }
}
