import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Tag, TagService } from 'src/app/services/tag/tag.service';

@Component({
  selector: 'app-trending',
  templateUrl: './trending.component.html',
  styleUrls: ['./trending.component.css']
})
export class TrendingComponent implements OnInit {
  tags: Tag[] = [];

  constructor( private tagService: TagService){
    this.connectHub();
  }

  ngOnInit(){

    
  }

  ngOnDestroy(){
    this.tagService.stopConnection();
  }

  connectHub(){
    this.tagService.startConnection()
      .then(() => {
        console.log('SignalR Simulation connection established');
      })
      .catch((error) => {
        console.error('SignalR Simulation connection error:', error);
      });

      this.tagService.getHubConnection().on('SendTagValue', (tagValue) => {
        console.log('Tag value:', tagValue);
      });
      

  }

}
