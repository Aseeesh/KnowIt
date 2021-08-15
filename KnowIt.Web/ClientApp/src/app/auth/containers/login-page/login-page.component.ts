import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Credentials } from '../../models';
import * as fromAuth from '../../state/reducers';
import { LoginPageActions } from '../../state/actions';

@Component({
  selector: 'login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']  
})
export class LoginPageComponent {
  pending$ = this.store.select(fromAuth.selectLoginPagePending);
  error$ = this.store.select(fromAuth.selectLoginPageError);

  constructor(private store: Store) {}

  onSubmit(credentials: Credentials) {
    this.store.dispatch(LoginPageActions.login({ credentials }));
  }
}

