import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewDegreeComponent } from './new-degree.component';

describe('NewDegreeComponent', () => {
  let component: NewDegreeComponent;
  let fixture: ComponentFixture<NewDegreeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewDegreeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewDegreeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
