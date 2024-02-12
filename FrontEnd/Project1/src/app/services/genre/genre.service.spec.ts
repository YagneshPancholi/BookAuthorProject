import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { GenreService } from './genre.service';

describe('GenreService', () => {
  let service: GenreService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
    });
    service = TestBed.inject(GenreService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should have deleteGenre method', () => {
    const service: GenreService = TestBed.get(GenreService);
    expect(service.deleteGenre).toBeTruthy();
  });
});
