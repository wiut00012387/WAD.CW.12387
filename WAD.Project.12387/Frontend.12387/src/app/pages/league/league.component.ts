import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
  League,
  LeagueService,
  LeagueTable,
} from 'src/app/services/league.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { Sort } from '@angular/material/sort';
import { LiveAnnouncer } from '@angular/cdk/a11y';

@Component({
  selector: 'app-league',
  templateUrl: './league.component.html',
  styleUrls: ['./league.component.css'],
})
export class LeagueComponent implements OnInit, AfterViewInit {
  table: LeagueTable[] = [];
  league$!: Observable<League>;

  displayedColumns: string[] = [
    'position',
    'club',
    'playedGames',
    'won',
    'draw',
    'lost',
    'goalsFor',
    'goalsAgainst',
    'points',
  ];
  dataSource = new MatTableDataSource<LeagueTable>(this.table);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private leagueService: LeagueService,
    private router: ActivatedRoute,
    private _liveAnnouncer: LiveAnnouncer
  ) {}

  ngOnInit(): void {
    this.router.params.subscribe((params) => {
      this.leagueService.getLeagueTable(params['id']).subscribe((data) => {
        this.table = data.sort((a, b) => a.position - b.position);
        this.dataSource.data = this.table;
        this.dataSource.paginator = this.paginator;
      });

      this.league$ = this.leagueService.getLeague(params['id']);
    });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  announceSortChange(sortState: any) {
    // This example uses English messages. If your application supports
    // multiple language, you would internationalize these strings.
    // Furthermore, you can customize the message to add additional
    // details about the values being sorted.
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }
}
