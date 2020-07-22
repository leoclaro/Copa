import { Component, Inject, ViewChild, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

import { EquipeService } from './../services/equipe.service';

@Component({
  selector: 'app-fase-selecao',
  templateUrl: './fase-selecao.component.html'
})
export class FaseSelecaoComponent {

  public equipes: Equipe[];  
  showGerarCopaModalBox: boolean = false;

  equipeService: EquipeService;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, equipeService: EquipeService, private router: Router) {
    http.get<Equipe[]>(baseUrl + 'equipe').subscribe(result => {
      this.equipes = result;
    }, error => console.error(error));
    this.equipeService = equipeService;
    this.equipeService.checkedEquipes = [];
  }

  private updateCheckedEquipes(id: string, name: string, checked: boolean) {    
    let index = this.equipeService.checkedEquipes.findIndex(i => i.id === id);
    if ( index != -1 && !checked ) {     
      this.equipeService.checkedEquipes.splice(index, 1);      
    }
    else if(checked) {      
      this.equipeService.checkedEquipes.push({ "id": id, "nome": name });      
    }   
  }

  public getCountCheckedEquipes() {
    return this.equipeService.checkedEquipes.length;
  }
  
  public onChange(event: any) {     
    this.updateCheckedEquipes(event.currentTarget.id, event.currentTarget.name, event.currentTarget.checked);    
  } 

  public gerarCopa() {
    if (this.getCountCheckedEquipes() != 8) {      
      this.showGerarCopaModalBox = true;      
    } else {
      this.showGerarCopaModalBox = false;     
      this.router.navigate(['/visualizar-resultado']);
    }
  }
}

interface Equipe {
  id: string;
  nome: string;
  sigla: string;
  gols: number;
  selecionado: boolean;
}

