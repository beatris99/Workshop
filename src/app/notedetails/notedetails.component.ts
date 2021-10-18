import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-notedetails',
  templateUrl: './notedetails.component.html',
  styleUrls: ['./notedetails.component.scss']
})
export class NotedetailsComponent implements OnInit {

  previous: number;
  next: number;
  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
  }
 
  toPrevious(): void {

    this.previous = this.previous - 1;
    this.router.navigateByUrl(`/app-notedetails/id${this.previous}`)
  }

  toNext(): void {
    this.next = this.next + 1;
    this.router.navigateByUrl(`/app-notedetails/id${this.next}`)
  }

}
