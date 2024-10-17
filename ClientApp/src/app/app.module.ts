import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CandidatesComponent } from './candidates/candidates.component';
import { NewCandidateComponent } from './new-candidate/new-candidate.component';
import { NewDegreeComponent } from './new-degree/new-degree.component';
import { DeleteDegreeComponent } from './delete-degree/delete-degree.component';
import { DegreesComponent } from './degrees/degrees.component';
import { UpdateDegreeComponent } from './update-degree/update-degree.component';

@NgModule({
  declarations: [
    AppComponent,
    CandidatesComponent,
    NewCandidateComponent,
    NavMenuComponent,
    NewDegreeComponent,
    DeleteDegreeComponent,
    DegreesComponent,
    UpdateDegreeComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: "", component: CandidatesComponent },
      { path: "candidates", component: CandidatesComponent },
      { path: "new-candidate", component: NewCandidateComponent },
      { path: "degrees", component: DegreesComponent },
      { path: "new-degree", component: NewDegreeComponent },
      { path: "update-degree/:id", component: UpdateDegreeComponent },
      { path: "delete-degree/:id", component: DeleteDegreeComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
