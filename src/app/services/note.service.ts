import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Note } from '../note/note';
import { map } from "rxjs/operators";

@Injectable()
export class NoteService {


  readonly  baseUrl= "https://localhost:5001";
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
  getFiltredNotes(categoryId: string): Observable<Note[]>{
    return this.HttpClient.get<Note[]>(this.baseUrl + '/notes', this.httpOptions).pipe(map((notes) => notes.filter((note) => note.categoryId === categoryId)));
  }
  getNoteById(id: string): Observable<Note[]>{
    
    return this.HttpClient.get<Note[]>(this.baseUrl + '/notes', this.httpOptions).pipe(map((notes) => notes.filter(note => note.id == id)));
  }
  getNoteByDescription(description: string): Observable<Note[]> {
    return this.HttpClient.get<Note[]>(this.baseUrl + '/notes', this.httpOptions).pipe(map((notes) => notes.filter(note => note.description.toLowerCase() == description)));
  }

  getNoteByTitle(title: any): Observable<Note[]> {
    //console.log(this.getNoteByTitle);
    return this.HttpClient.get<Note[]>(this.baseUrl + '/notes', this.httpOptions).pipe(map((notes) => notes.filter(note => note.title.toLowerCase() == title)));
  }

  addNote(noteTitle: string, noteDescription: string, noteCategoryId: string): Observable<Note> {
    const note: Note = {
      
      description: noteDescription,
      title: noteTitle,
      categoryId: noteCategoryId
    }
    return this.HttpClient.post<Note>(this.baseUrl + '/notes', note);
  }

  updateNote(note: Note): Observable<Note>  {
    return this.HttpClient.put<Note>(this.baseUrl + '/notes/' + note.id, note);
  }

  deleteNote(id: string)
  {
    return this.HttpClient.delete(this.baseUrl + '/notes/' + id);
  }
}
