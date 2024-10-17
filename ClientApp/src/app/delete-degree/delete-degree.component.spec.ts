import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteDegreeComponent } from './delete-degree.component';

describe('DeleteDegreeComponent', () => {
  let component: DeleteDegreeComponent;
  let fixture: ComponentFixture<DeleteDegreeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteDegreeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteDegreeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
