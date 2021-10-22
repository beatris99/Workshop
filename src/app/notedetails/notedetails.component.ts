import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Note } from '../note/note';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-notedetails',
  templateUrl: './notedetails.component.html',
  styleUrls: ['./notedetails.component.scss']
})
export class NotedetailsComponent implements OnInit {

  notes: Note[];
  id: string;
  sub: any;
  previous: number;
  next: number;
  constructor(private noteService: NoteService, private route: ActivatedRoute, private router: Router) {

  }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.id = params['id'];

      this.noteService.getNoteById(this.id).subscribe((result) => this.notes = result);

      this.previous = + this.id.replace('id', '');
      this.next = + this.id.replace('id', '');

      this.checkNan();
    });
   
  }

  toPrevious(): void {

    this.previous = this.previous - 1;
    this.router.navigateByUrl('/app-notedetails/id${this.previous}')
  }

  toNext(): void {
    this.next = this.next + 1;
    this.router.navigateByUrl('/app-notedetails/id${this.next}')
  }

  checkNan(){
    if(this.notes.length===0)
      this.router.navigateByUrl('/app-notedetails');
    
  }
}
