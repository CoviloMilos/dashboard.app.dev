import { AdvantageService } from './../../_services/advantage.service';
import { Server } from './../../shared/server';
import { Component, OnInit } from '@angular/core';

const SAMPLE_SERVERS = [
  {id: 1, name: 'dev-web', isOnline: true},
  {id: 1, name: 'dev-mail', isOnline: false},
  {id: 1, name: 'prod-web', isOnline: true},
  {id: 1, name: 'prod-mail', isOnline: true},
];

@Component({
  selector: 'app-section-health',
  templateUrl: './section-health.component.html',
  styleUrls: ['./section-health.component.css']
})
export class SectionHealthComponent implements OnInit {

  servers: Server[];

  constructor(private service: AdvantageService) { }

  ngOnInit() {
    this.loadServers();
  }

  loadServers() {
    this.service.getServers()
      .subscribe(
        (res: Server[]) => {
          this.servers = res
      }, error => {
        console.log(error);
      });
  }

}
