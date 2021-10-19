import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from '../module/category';
import { Note } from '../note/note';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-edit-note',
  templateUrl: './edit-note.component.html',
  styleUrls: ['./edit-note.component.scss']
})
export class EditNoteComponent implements OnInit {

  title: string;
  description: string;
  idCategoryNote: string;
  
  note: Note[];
  categories: Category[];
  id: string;
  sub: any;

  constructor(private noteService: NoteService, private route: ActivatedRoute, private router:Router) { }
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  

  updateNote(note: Note) {
    
        this.noteService.getNotes();
      
      this.router.navigateByUrl("");
  }
    

}
