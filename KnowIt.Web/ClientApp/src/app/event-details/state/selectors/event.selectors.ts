import { createFeatureSelector, createSelector } from "@ngrx/store";
import { selectCurrentRoute } from "src/app/reducers";
import { RouterStateUrl } from "src/app/reducers/router/router.serializer";

import { State, adapter, ENTITY_FEATURE_KEY } from "../reducers/event.reducers";

// Lookup the 'Entity' feature state managed by NgRx
const getEntityState = createFeatureSelector<State>(ENTITY_FEATURE_KEY);
// get the selectors
const { selectIds, selectAll, selectTotal,selectEntities } = adapter.getSelectors();

// select the array of Entity ids
export const selectEntityIds = createSelector(  getEntityState,  selectIds);

// select the array of Entitys
export const selectAllEntities = createSelector(  getEntityState,  selectAll);


export const areAllCompanyLoaded = createSelector(  getEntityState,  state => state.loaded);

// select the total Entity count
export const selectEntityCount = createSelector(  getEntityState,  selectTotal);

// select entity loaded flag
export const selectEntityLoaded = createSelector(  getEntityState,  state => state.loaded);

export const getEntities = createSelector(getEntityState, selectEntities);
// select entity error
export const selectError = createSelector(
  getEntityState,
  state => state.error
);
export const getProductById = createSelector(
    getEntities,
    selectCurrentRoute,
    (products, route: RouterStateUrl) => {
      return products ? products[route?.params?.id] : null;
    }
  );
  export const getById = createSelector(
    getEntityState,
    (state: State) => { 
        state.selectedId}
)

  export const getSingle = createSelector( 
    getEntityState,
    getById,
    state => state.entities[state.selectedId]
  )


