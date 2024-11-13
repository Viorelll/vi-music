import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PlaylistsClient } from 'src/app/web-api-client';

@Component({
  selector: 'app-add-playlist',
  templateUrl: './add-playlist.component.html',
  styleUrls: ['./add-playlist.component.scss'],
})
export class AddPlaylistComponent {
  palyListForm =  this.formBuilder.group({
    name: ['', Validators.required],
    coverImageUrl: ['', Validators.required],
  });

  constructor(private formBuilder: FormBuilder, private router: Router, private client: PlaylistsClient) {}

  onSubmit(playlistCommand: any) {

    this.client.create(playlistCommand).subscribe(result => {
      this.router.navigate(['/playlists']);
    }, error => console.error(error));
  }
}
