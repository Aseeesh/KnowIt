import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Actions, ofType, createEffect } from '@ngrx/effects';
import { Observable, of, throwError } from 'rxjs';
import { catchError, concatMap, exhaustMap, filter, map, mergeMap, switchMap, tap, withLatestFrom } from 'rxjs/operators';
import * as _Actions from '../actions/event.actions';
import { EventModel as _model } from '../../model/event';
import { EventService as _Services }  from '../../event.service';   
import { Action, Store } from '@ngrx/store';
import { RouterNavigatedAction, ROUTER_NAVIGATION } from '@ngrx/router-store';
import { Update } from '@ngrx/entity';
 
@Injectable()
export class EventEffects {
  
  constructor(
    private store: Store, 
    private _actions$: Actions,
    private _service$: _Services,
    private router: Router,
    private dialog: MatDialog
  ) {}
 
loadMultiple$: Observable<Action> = createEffect(() => {
    return this._actions$.pipe(
        ofType(_Actions.loadMultiple),
     // withLatestFrom(this._store.pipe(select(Reducers.get_models))),
      mergeMap(() => this._service$._getMultiples()),
      map(_response =>{ 
            console.log("_data effects: Get _data")  
            console.log(_response)
          if(_response !=null){ 
              return    _Actions.loadMultipleSuccess({models:_response})   
                }
                else{
                    return   _Actions.loadMultiplefailure({error:""});
                }
      } ),
      catchError(this.handleError)
  )
});
 
loadSingle$: Observable<Action> = createEffect(() => {
    return this._actions$.pipe(
        ofType(_Actions.loadSingle), 
      mergeMap((action) => this._service$._getById(action.Id)),
      map(_response =>{ 
          if(_response !=null){ 
              return    _Actions.loadSingleSuccess({model:_response})   
                }
                else{
                    return   _Actions.loadSinglefailure({error:""});
                }
      } ),
      catchError(this.handleError)
  )
});
add$ = createEffect(() =>
this._actions$.pipe(
  ofType(_Actions._create),
  switchMap(action => {
    return this._service$._addService(action._model).pipe(
      map(product => {
          if(action._model!=null){ 
        const value: _model = product
        return _Actions._createSuccess({ _model: value });
          }
           
      })
    );
  })
)
);
  update$ = createEffect(() =>
    this._actions$.pipe(
      ofType(_Actions._update),
      switchMap(action => {
        return this._service$._updateService(action._model).pipe(
          map(product => {
              if(action._model!=null){ 
            
                const updatedValue: Update<_model> = {
                    id: action._model.id,
                    changes: {
                      ...product
                    }
                  };
                  return _Actions._updateSuccess({ _model: action._model });
              }
          })
        );
      })
    )
  );
  delete$ = createEffect(() => {
    return this._actions$.pipe(
      ofType(_Actions._delete),
      switchMap(action => {
        console.log(action)
        return this._service$._deleteService(action?.Id).pipe(
          catchError(err => {
            console.log('catch error', err)
            return of(err?.message)
          }),
          map(data => {
            return _Actions._deleteSuccess({ Id: action.Id });
          })
        );
      })
    );
  });
private handleError(error: any) {
  console.error(error);
  return throwError(error)
}
 
}
