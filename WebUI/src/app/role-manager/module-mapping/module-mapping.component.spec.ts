import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModuleMappingComponent } from './module-mapping.component';

describe('ModuleMappingComponent', () => {
  let component: ModuleMappingComponent;
  let fixture: ComponentFixture<ModuleMappingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModuleMappingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModuleMappingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
