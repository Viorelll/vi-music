import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MainAlbumComponent } from './main-album.component';

describe('MainAlbumComponent', () => {
  let component: MainAlbumComponent;
  let fixture: ComponentFixture<MainAlbumComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MainAlbumComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MainAlbumComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
