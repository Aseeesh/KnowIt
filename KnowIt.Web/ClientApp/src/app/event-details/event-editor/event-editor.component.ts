import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import {NgbDateStruct, NgbCalendar} from '@ng-bootstrap/ng-bootstrap';
import * as moment  from 'moment';
 
import { EventModel as _model} from '../model/event';
 
import { Store, select } from '@ngrx/store'; 
import * as _Actions from '../state/actions/event.actions';
import * as fromState from '../state/reducers/event.reducers';
import * as fromSelectors from '../state/selectors/event.selectors'; 
@Component({
  selector: 'app-event-editor',
  templateUrl: './event-editor.component.html',
  styleUrls: ['./event-editor.component.css']
})
export class EventEditorComponent implements OnInit { 
  public eventForm: FormGroup = null;
  public _Event: _model= null;
  selectedCategory:number; 
  loading = false;
  currentUser=null;
  submitted = false;
  returnUrl: string;
  model: NgbDateStruct;
  date: {year: number, month: number};
  categoryData$: any;
 
   data$:_model;// Observable<_model>= this.store.select(  fromSelectors.getSingle  );//this.store.pipe(select(fromSelectors.getProductById));
  isNew: boolean=true;
  title: string="Add Event";
  constructor(  
    private router: Router,
    private store: Store<fromState.State>,  
      private formBuilder: FormBuilder,
      private route: ActivatedRoute
  ) {
      // redirect to home if already logged in
      // if (this.eventService.currentUserValue) {
      //     this.router.navigate(['/']);
      // }
   
  }
  
  ngOnInit() { 
      
    this.route.params.subscribe(params => {
      this.eventForm = this.formBuilder.group({
        id:[0],
        name: ['', Validators.required],
          description: ['', Validators.required],
          title: ['', Validators.required], 
          // eventDate:[this.calendar.getToday()]
      });
       
      let id = +params['id'];
      if (id != null && id>0) {
        
      this.store.dispatch( _Actions.loadSingle({Id:params.id}))  
      this.store.select(fromSelectors.getProductById  ).subscribe((item)=>{
        if(item!=null){
          this.isNew= false;
          this.title="Add Event";
          this.data$=item;
          this.eventForm.patchValue({
            id: item.id,
            name: item.name,
            title: item.title,
            description: item.description
          })
        }
      },
      err => {
        console.log(err);
      },)

       
      }
    }, error => {
      console.log(JSON.stringify(error));
    });

   
      // get return url from route parameters or default to '/'
     // this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  // convenience getter for easy access to form fields
  get f() { return this.eventForm.controls; }

  onSubmit() { 
      this.submitted = true; 
  if (this.eventForm.invalid) { 
          return;
      }
      const _Event: _model = this.eventForm.value; 
      this.loading = true;  
         if(_Event.id>0){
           
          this.store.dispatch(_Actions._update({ _model:_Event}));
         }else{
           
          this.store.dispatch(_Actions._create({ _model:_Event}));
         }
     
         this.router.navigate(['/events']);
    
  }

}
