import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtistFeatureComponent } from './artist-feature.component';

describe('ArtistFeatureComponent', () => {
  let component: ArtistFeatureComponent;
  let fixture: ComponentFixture<ArtistFeatureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ArtistFeatureComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ArtistFeatureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
