import { Pipe, PipeTransform } from '@angular/core';
import { Club } from './services/club.service';

@Pipe({
  name: 'sort',
})
export class SortPipe implements PipeTransform {
  transform(clubs: Club[] | null, leagueName: string): Club[] {
    if (!clubs) {
      return [];
    }

    if (!leagueName) {
      return clubs;
    }

    const filteredClubs = clubs.filter((club) => {
      return club.league.name === leagueName;
    });

    return filteredClubs.sort((a, b) => a.name.localeCompare(b.name));
  }
}
