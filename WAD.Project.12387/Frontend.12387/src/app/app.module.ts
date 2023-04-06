import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { HomeComponent } from './pages/home/home.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { PlayersComponent } from './pages/players/players.component';
import { PlayersCardComponent } from './pages/players/components/players-card/players-card.component';
import { LeaguesComponent } from './pages/leagues/leagues.component';
import { LeaguesCardComponent } from './pages/leagues/components/leagues-card/leagues-card.component';
import { ClubsComponent } from './pages/clubs/clubs.component';
import { ClubsCardComponent } from './pages/clubs/components/clubs-card/clubs-card.component';
import { ClubComponent } from './pages/club/club.component';
import { LeagueComponent } from './pages/league/league.component';
import { PlayerComponent } from './pages/player/player.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CreatePlayerComponent } from './pages/create-player/create-player.component';
import { EditPlayerComponent } from './pages/edit-player/edit-player.component';
import { EditClubComponent } from './pages/edit-club/edit-club.component';
import { CreateClubComponent } from './pages/create-club/create-club.component';
import { SortPipe } from './sort.pipe';
import { MatTableModule } from '@angular/material/table';
import { MatNativeDateModule } from '@angular/material/core';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSortModule } from '@angular/material/sort';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FooterComponent,
    HeaderComponent,
    PlayersComponent,
    PlayersCardComponent,
    LeaguesComponent,
    LeaguesCardComponent,
    ClubsComponent,
    ClubsCardComponent,
    ClubComponent,
    LeagueComponent,
    PlayerComponent,
    CreatePlayerComponent,
    EditPlayerComponent,
    EditClubComponent,
    CreateClubComponent,
    SortPipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatNativeDateModule,
    MatTableModule,
    MatPaginatorModule,
    MatSlideToggleModule,
    MatSortModule,
    MatProgressSpinnerModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
