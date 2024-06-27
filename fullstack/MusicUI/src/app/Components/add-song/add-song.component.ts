import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NewSong } from '../../Models/new-song';
import { NewArtist }  from '../../Models/new-artist';
import { NewGenre } from '../../Models/new-genre';
import { SongService } from '../../Services/song-service.service';

@Component({
  selector: 'app-add-song',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-song.component.html',
  styleUrl: './add-song.component.css'
})

export class AddSongComponent {
  song: NewSong = {
    title : '',
    url : '',
    artists : [{ name: '' }],
    ratingCount : 0,
    totalRating : 0,
    averageRating : 0,
    genre : {
      name: ''
    },
    tempo : 0
  }

  constructor(private songService: SongService) {}

  addSong() {
    console.log(this.song);
    this.songService.AddNewSong(this.song).subscribe( result => {
      console.log(result)
    });
  }

}