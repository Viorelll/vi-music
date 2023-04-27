export class Song {
  imageUrl: string;
  artistName: string;
  title: string;
  duration: string;

  constructor(imageUrl: string, artistName: string, title: string, duration: string) {
    this.imageUrl = imageUrl;
    this.artistName = artistName;
    this.title = title;
    this.duration = duration;
  }
}
