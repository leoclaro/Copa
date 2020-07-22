import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FaseSelecaoComponent } from './fase-selecao.component';

describe('FaseSelecaoComponent', () => {
  let component: FaseSelecaoComponent;
  let fixture: ComponentFixture<FaseSelecaoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FaseSelecaoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FaseSelecaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
