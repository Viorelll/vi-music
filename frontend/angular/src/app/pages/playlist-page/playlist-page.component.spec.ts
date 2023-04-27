import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlaylistPageComponent } from './playlist-page.component';

describe('PlaylistComponent', () => {
  let component: PlaylistPageComponent;
  let fixture: ComponentFixture<PlaylistPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlaylistPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlaylistPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
