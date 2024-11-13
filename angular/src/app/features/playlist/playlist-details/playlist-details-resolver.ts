import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, ResolveFn, Router } from '@angular/router';
import { EMPTY, of } from 'rxjs';
import { mergeMap } from 'rxjs/operators';

import { PlaylistsClient, PlaylistSongsBriefDto } from 'src/app/web-api-client';

export const playlistDetailResolver: ResolveFn<PlaylistSongsBriefDto> = (
  route: ActivatedRouteSnapshot
) => {
  const router = inject(Router);
  const client = inject(PlaylistsClient);
  const id = route.paramMap.get('id')!;

  return client.getPlaylistSongsWithPagination(+id).pipe(
    mergeMap((playlistSongsBriefDto) => {
      if (playlistSongsBriefDto) {
        return of(playlistSongsBriefDto);
      } else {
        // id not found
        router.navigate(['/playlists']);
        return EMPTY;
      }
    })
  );
};

/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/
