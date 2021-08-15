import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './auth/state/services'; 
import { NotFoundPageComponent } from './core/containers/not-found-page.component/not-found-page.component';

export const routes: Routes = [
  { path: '', redirectTo: '/events', pathMatch: 'full' },
  {
    path: 'events',
    loadChildren: () =>
      import('./event-details/event-details.module').then((m) => m.EventDetailsModule),
    canActivate: [AuthGuard]    ,
    data: { title: 'Event collection' }
  },
  {
    path: '**',
    component: NotFoundPageComponent,
    data: { title: 'Not found' },
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      useHash: true,
      relativeLinkResolution: 'legacy',
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
