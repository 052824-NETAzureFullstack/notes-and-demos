import { AsyncPipe, CommonModule } from '@angular/common';
import { NgIf } from '@angular/common';
import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Observable } from 'rxjs';
import { SongService } from './../../Services/song-service.service';
import { Song } from './../../Models/song';


@Component({
  selector: 'app-song',
  standalone: true,
  imports: [ CommonModule, NgIf, AsyncPipe ],
  templateUrl: './song.component.html',
  styleUrl: './song.component.css'
})

export class SongComponent {
  currentSong$!:  Observable<Song>;
  songId!: number;
  
  constructor(private songService: SongService, private route: ActivatedRoute) {
    this.songId = parseInt(this.route.snapshot.params['id'], 10);
    console.log(this.songId);

    this.currentSong$ = this.songService.GetSongById(this.songId);
  }

  ngOnInit(): void {
  }
}