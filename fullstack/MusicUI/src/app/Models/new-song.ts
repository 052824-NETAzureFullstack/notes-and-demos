import { NewArtist } from './new-artist';
import { NewGenre } from './new-genre';

export interface NewSong {
    title: string;
    url: string;
    artists: NewArtist[];
    ratingCount: number;
    totalRating: number;
    averageRating: number;
    genre: NewGenre;
    tempo: number;
}
