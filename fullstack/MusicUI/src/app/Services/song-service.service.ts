import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Song } from './../Models/song';
import { NewSong } from './../Models/new-song'

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

  AddNewSong(newSong: NewSong){
    return this.http.post<any>(this.URL, newSong);
  }

  Delete(deleteSong: number){
    return this.http.delete<any>(this.URL + '/' + deleteSong);
  }
}