import { NewComponent } from './pages/new/new.component';
import { AllComponent } from './pages/all/all.component';
import { TomorrowComponent } from './pages/tomorrow/tomorrow.component';
import { TodayComponent } from './pages/today/today.component';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: "login", component: LoginComponent },
  {
    path: '', component: HomeComponent, children: [
      { path: '', component: TodayComponent },
      { path: 'tomorrow', component: TomorrowComponent },
      { path: 'all', component: AllComponent },
      { path: 'new', component: NewComponent },

    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
