import { Component } from '@angular/core';
import { inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Observable } from 'rxjs';

import { SongService } from './../../Services/song-service.service';
import { Song } from '../../Models/song';
//import { NgFor } from '@angular/common';

@Component({
  selector: 'app-song-list',
  standalone: true,
  imports: [ RouterLink ],
  templateUrl: './song-list.component.html',
  styleUrl: './song-list.component.css'
})
export class SongListComponent {
  private songService = inject(SongService);
  public songs$ = this.songService.GetSongs();
  public songList: Song[] = [];

  ngOnInit(): void {
    this.songs$.subscribe( data => {this.songList = data;});
  }

  deleteSong(id: number ) {
    this.songService.Delete(id).subscribe( result => {
        console.log(result);
      });
  }
  ngOnChange() {
    this.songService.GetSongs().subscribe( data => {this.songList = data;});
  }
}
