import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { ProgramComponent } from './program/program.component';
import { TodayInCinemaComponent } from './today-in-cinema/today-in-cinema.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'program', component: ProgramComponent },
  { path: 'today-in-cinema', component: TodayInCinemaComponent },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
