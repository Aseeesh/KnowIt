import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router'; 
import { EventEditorComponent } from './event-editor/event-editor.component';
import { EventListComponent } from './event-list/event-list.component';


const routes: Routes = [
  {path:"", component: EventListComponent, data: { title: 'Event Overview' }},
  
  { path:  "edit/:id", component: EventEditorComponent, data: { title: 'Event details' } },
  { path:  "edit", component: EventEditorComponent , data: { title: 'Event details' }},
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EventDetailsRoutingModule { }
