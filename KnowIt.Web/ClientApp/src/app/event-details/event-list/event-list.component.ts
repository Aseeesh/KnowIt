import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { first } from 'rxjs/operators';
import { EventModel as _model} from "../model/event";  
import { User } from 'src/app/models';
import { EventService } from '../event.service';
import { Observable } from 'rxjs';
import { Store, select } from '@ngrx/store';
import * as _Actions from '../state/actions/event.actions';
import * as fromState from '../state/reducers/event.reducers'; 
import * as fromSelectors from '../state/selectors/event.selectors';
import { MatDialog } from '@angular/material/dialog';
import { ColumnMode } from '@swimlane/ngx-datatable';
@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {
  summaryForGender(cells: any) {
    throw new Error('Method not implemented.');
  }

  public  _EventList = this.store.pipe(select(fromSelectors.selectAllEntities));
  
  isLoaded$: Observable<boolean>;
  loading: false;
  currentUser: User=null;
  constructor(
    private store: Store<fromState.State>,  
    private router: Router, ) { 
      this._EventList = this.store.pipe(select(fromSelectors.selectAllEntities));
    }
    entries: number = 10;
    selected: any[] = [];
    temp = [];
    activeRow: any; 
     rows = [];
    loadingIndicator = true;
    reorderable = true;
  
    columns = [
      { prop: 'id', summaryFunc: () => null },
      { prop: 'title', summaryFunc: () => null },
      { prop: 'eventDate', summaryFunc: () => null },
     // { name: 'description', summaryFunc: cells => this.summaryForGender(cells) },
      { name: 'description', summaryFunc: () => null }
    ];
  
    ColumnMode = ColumnMode;
  ngOnInit() {
    
    this.store.dispatch(_Actions.loadMultiple()); 
    //  if (!this.authenticationService.currentUserValue) {
    //       this.router.navigate(['/']);
    //   }
  //this.currentUser = this.authenticationService.currentUserValue.user; 

  
     
  }
  entriesChange($event) {
    this.entries = $event.target.value;
  }
  filterTable($event) {
    // let val = $event.target.value;
    // this.dataa = this.rows.filter(function(d) {
    //   for (var key in d) {
    //     if (d[key].toLowerCase().indexOf(val) !== -1) {
    //       return true;
    //     }
    //   }
    //   return false;
    // });
  }
  onActivate(event) {
    this.activeRow = event.row;
  }
  onSelect({ selected }) {
    this.selected.splice(0, this.selected.length);
    this.selected.push(...selected);
  }
  editData(item: _model){    
   this.router.navigate(['events/edit', item.id])
 }
 
 delete(id: string) {
  if (confirm('Are you sure do you want to delete this Game?')) {
    //this.store.dispatch(_Actions._delete({Id:id}));
  }
}
}
