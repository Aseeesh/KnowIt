import { Update } from '@ngrx/entity';
import { props, createAction } from '@ngrx/store';
import { EventModel as _model } from '../../model/event'; 
const ModuleName="Event";

export const loadSingleSuccess = createAction(  '[ Single'+ModuleName+' Operation Success]',props<{ model: _model }>());
export const loadSinglefailure = createAction(  '['+ModuleName+' Operations Failed]',props<{ error: any }>());
export const loadSingle = createAction('['+ModuleName+'Operations Initiated ] Load Single',props<{ Id: string }>());

export const loadMultipleSuccess = createAction(  '[ Multiple '+ModuleName+' Operation Success]',props<{ models: _model[] }>());
export const loadMultiplefailure = createAction(  '['+ModuleName+' Operations Failed] ',props<{ error: any }>());
export const loadMultiple = createAction('['+ModuleName+'Operations Initiated] Load Multiple');


export const _create= createAction('['+ModuleName+' Operations Create Initiated]', props<{_model: _model}>());
export const _createSuccess= createAction('['+ModuleName+' Operations Create Success]',props<{_model: _model}>());
                              
export const _delete = createAction('['+ModuleName+' Operations Delete Initiated]',  props<{Id: string}>());
 export const _deleteSuccess = createAction('['+ModuleName+' Operations Delete Success]',props<{ Id: string }>());  

 export const _update= createAction('['+ModuleName+' Operations Update Initiated]',props<{_model: _model}>());
export const _updateSuccess = createAction( '['+ModuleName+' Operation Update Success] ',props<{ _model: _model }>());   