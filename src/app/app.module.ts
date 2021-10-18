import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NoteComponent } from './note/note.component';
import { ToolsComponent } from './tools/tools.component';
import {MatInputModule} from '@angular/material/input';
import { MatFormFieldModule} from '@angular/material/form-field';
import {MatButtonModule } from '@angular/material/button';
import { MatIconModule} from '@angular/material/icon';
import { FormsModule } from '@angular/forms';
import { AddPipePipe } from './add-pipe.pipe';
import { FilterComponent } from './filter/filter.component';
import { MatCardModule } from "@angular/material/card";
import { AddNoteComponent } from './add-note/add-note.component';
import { HomeComponent } from './home/home.component';
import { AppHighlightDirective } from './app-highlight.directive';
import { NotedetailsComponent } from './notedetails/notedetails.component';



@NgModule({
  declarations: [
    AppComponent,
    NoteComponent,
    ToolsComponent,
    AddPipePipe,
    FilterComponent,
    AddNoteComponent,
    HomeComponent,
    AppHighlightDirective,
    NotedetailsComponent,
    
   
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatIconModule,
    FormsModule,
    MatCardModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
