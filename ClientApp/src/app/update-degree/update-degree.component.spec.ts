import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateDegreeComponent } from './update-degree.component';

describe('UpdateDegreeComponent', () => {
  let component: UpdateDegreeComponent;
  let fixture: ComponentFixture<UpdateDegreeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateDegreeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateDegreeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
