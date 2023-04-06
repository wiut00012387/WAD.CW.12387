import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClubComponent } from './pages/club/club.component';
import { ClubsComponent } from './pages/clubs/clubs.component';
import { CreateClubComponent } from './pages/create-club/create-club.component';
import { CreatePlayerComponent } from './pages/create-player/create-player.component';
import { EditClubComponent } from './pages/edit-club/edit-club.component';
import { EditPlayerComponent } from './pages/edit-player/edit-player.component';
import { HomeComponent } from './pages/home/home.component';
import { LeagueComponent } from './pages/league/league.component';
import { LeaguesComponent } from './pages/leagues/leagues.component';
import { PlayerComponent } from './pages/player/player.component';
import { PlayersComponent } from './pages/players/players.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'players',
    component: PlayersComponent,
  },
  {
    path: 'players/:id',
    component: PlayerComponent,
  },
  {
    path: 'create-player',
    component: CreatePlayerComponent,
  },
  {
    path: 'edit-player/:id',
    component: EditPlayerComponent,
  },
  {
    path: 'leagues',
    component: LeaguesComponent,
  },
  {
    path: 'leagues/:id',
    component: LeagueComponent,
  },
  {
    path: 'clubs',
    component: ClubsComponent,
  },
  {
    path: 'clubs/:id',
    component: ClubComponent,
  },
  {
    path: 'create-club',
    component: CreateClubComponent,
  },
  {
    path: 'edit-club/:id',
    component: EditClubComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
