import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from '../module/category';
import { Note } from '../note/note';
import { FilterService } from '../services/filter.service';
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

  constructor(private noteService: NoteService, private route: ActivatedRoute, private filterService:FilterService, private router:Router) { }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.id = params['id'];
      console.log(this.id);
      this.noteService.getNoteById(this.id);
    });
    this.categories=this.filterService.getFilters();
  }


  updateNote(note: Note)  {
    this.noteService.updateNote(note).subscribe(
      (result: Note) => {
        this.noteService.getNotes();
      });
      this.router.navigateByUrl("");
  }

}