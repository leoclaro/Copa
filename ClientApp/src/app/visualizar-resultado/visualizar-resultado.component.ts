import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { EquipeService } from './../services/equipe.service';

@Component({
  selector: 'app-visualizar-resultado',
  templateUrl: './visualizar-resultado.component.html'
})
export class VisualizarResultadoComponent  {

  equipeService: EquipeService
  public resultado: any;  

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, equipeService: EquipeService) {

    this.equipeService = equipeService;

    this.http.post(this.baseUrl + 'equipe/resultado', this.equipeService.checkedEquipes).subscribe(result => {
      this.resultado = result; 
    }, error => console.error(error));
  }
}
