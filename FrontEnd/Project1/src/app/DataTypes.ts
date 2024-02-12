export const BaseURL = 'https://localhost:7034/api/';
export interface Book {
  bookName: string;
  price: number;
  authorNames: Array<string>;
  genreNames: Array<string>;
  publisherNames: Array<string>;
}
export interface Author {
  authorName: string;
  birthDate: string | null;
  email: string;
  education: string;
}

export interface Genre {
  genreName: string;
}
export interface Publisher {
  publisherName: string;
}
