import { Routes } from '@angular/router';

import { SongListComponent } from './Components/song-list/song-list.component';
import { SongComponent } from './Components/song/song.component';
import { AddSongComponent } from './Components/add-song/add-song.component';

export const routes: Routes = [
    {
        path:'song',
        component: SongListComponent
    },
    {
        path:'song/:id',
        component: SongComponent
    },
    {
        path:'addsong',
        component: AddSongComponent
    }
];
