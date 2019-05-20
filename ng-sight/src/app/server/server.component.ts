import { AdvantageService } from './../_services/advantage.service';
import { Component, OnInit, Input } from '@angular/core';
import { Server } from '../shared/server';

@Component({
  selector: 'app-server',
  templateUrl: './server.component.html',
  styleUrls: ['./server.component.css']
})
export class ServerComponent implements OnInit {
  @Input() serverInput: Server;
  color: string;
  buttonText: string;

  constructor(private advantageService: AdvantageService) { }

  ngOnInit() {
    this.setServerStatus(this.serverInput.isOnline);
  }

  setServerStatus(isOnline: boolean) {
    if (isOnline) {
      this.serverInput.isOnline = true;
      this.color = '#66BB6A';
      this.buttonText = 'Shut Down';
    } else {
      this.serverInput.isOnline = false;
      this.color = '#FF6B6B';
      this.buttonText = 'Start';
    }
  }

  toggleStatus(onlineStatus: boolean, id: number) {
    console.log(this.serverInput.name, ': ', onlineStatus);
    this.advantageService.changeServerStatus(id)
      .subscribe((res: any) => {
        this.setServerStatus(!onlineStatus);
      }, error => {
        console.log(error);
      });
  }
}
