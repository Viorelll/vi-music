export class Song {
  url: string;
  name: string;
  artist: string;
  coverImageUrl: string;
  genre: string;

  constructor(url: string, name: string, artist: string, coverImageUrl: string, genre: string) {
    this.url = url;
    this.name = name;
    this.artist = artist;
    this.coverImageUrl = coverImageUrl;
    this.genre = genre;
  }
}
