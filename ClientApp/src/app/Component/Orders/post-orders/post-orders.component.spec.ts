import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostOrdersComponent } from './post-orders.component';

describe('PostOrdersComponent', () => {
  let component: PostOrdersComponent;
  let fixture: ComponentFixture<PostOrdersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostOrdersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PostOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
