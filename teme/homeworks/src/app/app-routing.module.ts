import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddNoteComponent } from './add-note/add-note.component';
import { ToolsComponent } from './tools/tools.component';

const routes: Routes = [
 
  {path: "addNote", component: AddNoteComponent},
  {path: '**', component: ToolsComponent},
  { path: '**', redirectTo: ''}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
