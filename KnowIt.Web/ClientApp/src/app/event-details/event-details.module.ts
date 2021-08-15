import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EventDetailsRoutingModule } from './event-details-routing.module';
import { EventListComponent } from './event-list/event-list.component';
import { EventEditorComponent } from './event-editor/event-editor.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; 

import { NgSelectModule } from '@ng-select/ng-select';

import { EventEffects  as _effects} from './state/effects/event.effects';
import * as fromState from './state/reducers/event.reducers';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { NgxDatatableModule } from "@swimlane/ngx-datatable";

@NgModule({
  declarations: [EventListComponent, EventEditorComponent],
  imports: [
    CommonModule,NgxDatatableModule,
    FormsModule, NgSelectModule,
    ReactiveFormsModule,
    EventDetailsRoutingModule,
    StoreModule.forFeature({
      name: fromState.ENTITY_FEATURE_KEY,
      reducer: fromState.reducer,
    }),
    EffectsModule.forFeature([_effects]),
  ]
})
export class EventDetailsModule { }
