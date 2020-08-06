import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TodayInCinemaComponent } from './today-in-cinema.component';

describe('TodayInCinemaComponent', () => {
  let component: TodayInCinemaComponent;
  let fixture: ComponentFixture<TodayInCinemaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [TodayInCinemaComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TodayInCinemaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
