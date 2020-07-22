import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { VisualizarResultadoComponent } from './visualizar-resultado/visualizar-resultado.component';
import { FaseSelecaoComponent } from './fase-selecao/fase-selecao.component';
import { EquipeService } from './services/equipe.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    VisualizarResultadoComponent,
    FaseSelecaoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'fase-selecao', component: FaseSelecaoComponent },
      { path: 'visualizar-resultado', component: VisualizarResultadoComponent },
    ])
  ],
  providers: [EquipeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
