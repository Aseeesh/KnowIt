
import { Action, createReducer, on } from '@ngrx/store';
import { createEntityAdapter, EntityAdapter, EntityState } from '@ngrx/entity';
import * as _Actions from '../actions/event.actions';
import { EventModel as _model } from '../../model/event';

export const ENTITY_FEATURE_KEY  = 'event';
 
export interface State extends EntityState<_model> {
  loaded: boolean;
  loading: boolean;
  selectedId: string | null;
  error?: Error | any;
}

export const adapter: EntityAdapter<_model> = createEntityAdapter<_model>({
  selectId: (item: _model) => item.id,
  sortComparer: false,
});

export interface EntityPartialState {
  readonly [ENTITY_FEATURE_KEY ]: State;
}

export const initialState: State = adapter.getInitialState({
  loaded: false,
  selectedId:null,
   entities:null,
  loading: false,
  ids: [], 
  error: null
});



 const _reducer = createReducer(  initialState,
  
  on(_Actions.loadSingleSuccess, (state, { model }) => adapter.addOne(model, state)),

  on( _Actions.loadMultipleSuccess,  (state, { models }) => adapter.addMany(models, state)  ),
  
  on(_Actions._createSuccess, (state, action) => {    return adapter.addOne(action._model, state);  }),

  on(_Actions._deleteSuccess, (state, action) => {    return adapter.removeOne(action.Id, state);  }),
 
  on(_Actions._updateSuccess, (state, action) => {    return adapter.upsertOne(action._model, state);  }),  
  // on(_Actions.clearUsers, state => {    return adapter.removeAll({ ...state, selectedUserId: null });  })
);


export function reducer(state: State | undefined, action: Action ) {
  return _reducer(state, action);
}


export const getLoaded = (state: State) => state.loaded;

export const getLoading = (state: State) => state.loading;

export const getIds = (state: State) => state.ids;
export const getAll = (state: State) => state.entities;

export const selectId = (state: State) => state.selectedId; 
