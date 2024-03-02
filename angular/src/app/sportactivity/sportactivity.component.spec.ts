import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SportActivityComponent } from './sportactivity.component';

describe('SportActivityComponent', () => {
  let component: SportActivityComponent;
  let fixture: ComponentFixture<SportActivityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SportActivityComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SportActivityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
