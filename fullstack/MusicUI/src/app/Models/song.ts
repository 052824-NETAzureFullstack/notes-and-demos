import { Artist } from "./artist";
import { Genre } from "./genre";

export interface Song {
    id: number;
    title: string;
    url: string;
    artists: Artist;
    ratingCount: number;
    totalRating: number;
    averageRating: number;
    genre: Genre;
    tempo: number
}

/*
{
    "id": 0,
    "title": "string",
    "url": "string",
    "artists": [
      {
        "id": 0,
        "name": "string",
        "songs": [
          "string"
        ]
      }
    ],
    "ratingCount": 0,
    "totalRating": 0,
    "averageRating": 0,
    "genre": {
      "id": 0,
      "name": "string",
      "song": [
        "string"
      ]
    },
    "tempo": 0
  }
*/