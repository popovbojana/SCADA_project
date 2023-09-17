import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TrendingComponent } from './components/trending/trending.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { TagsComponent } from './components/tags/tags.component';
import { AlarmsComponent } from './components/alarms/alarms.component';
import { ReportsComponent } from './components/reports/reports.component';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [
  {path: "", component: TrendingComponent},
  {path: "login", component: LoginComponent},
  {path: "trending", component: TrendingComponent},
  {path: "registration", component: RegistrationComponent},
  {path: "tags", component: TagsComponent},
  {path: "alarms", component: AlarmsComponent},
  {path: "reports", component: ReportsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
