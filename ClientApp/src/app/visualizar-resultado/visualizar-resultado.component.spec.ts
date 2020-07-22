import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarResultadoComponent } from './visualizar-resultado.component';

describe('VisualizarResultadoComponent', () => {
  let component: VisualizarResultadoComponent;
  let fixture: ComponentFixture<VisualizarResultadoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VisualizarResultadoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarResultadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
