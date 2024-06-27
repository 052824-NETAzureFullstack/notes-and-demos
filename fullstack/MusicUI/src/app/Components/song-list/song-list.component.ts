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
  public songList: Song[] = [];

  constructor(private songService: SongService) {}

  ngOnInit(): void {
    this.songService.GetSongs().subscribe( data => {
      this.songList = data;
    });
  }

  deleteSong(song: Song ) {
    let result = this.songService.Delete(song.id).subscribe( result => {
        console.log(result);
    });

    if (result) {
      this.songList.splice(this.songList.indexOf(song),1);
    }
  }
}

