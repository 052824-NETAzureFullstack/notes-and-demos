import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Song } from './../Models/song';

@Injectable({
  providedIn: 'root'
})
export class SongService {
  URL: string = 'http://localhost:5295/api/Song';
  http = inject(HttpClient);
  constructor() { }

  GetSongById(songId: number): Observable<Song> {
    return this.http.get<Song>(`${this.URL}/${songId}`);
  }

  GetSongs(): Observable<Song[]> {
    return this.http.get<Song[]>(this.URL);
  }
}