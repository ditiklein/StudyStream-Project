import { Routes } from '@angular/router';
import { LoginComponent } from '../component/login/login.component';
import { ShowUsersComponent } from '../component/login/show-users/show-users.component';

export const routes: Routes = [
    { path: '', component: LoginComponent },
    { path: '/Users', component:  ShowUsersComponent},


];
