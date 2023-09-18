import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Alarm, AlarmService } from 'src/app/services/alarm/alarm.service';

@Component({
  selector: 'app-alarms',
  templateUrl: './alarms.component.html',
  styleUrls: ['./alarms.component.css']
})
export class AlarmsComponent implements OnInit {
  allAlarms: Alarm[] = [];
  showAddAlarmForm: boolean = false;

  constructor(private alarmService: AlarmService, private router: Router) { }

  ngOnInit(): void {
    this.alarmService.getAllAlarms().subscribe((response) => {
      for (let element of response){
        const alarm: Alarm = {
          id: element.id,
          value: element.value,
          tagId: element.tagId,
          type: element.type,
          priority: element.priority
        }
        this.allAlarms.push(alarm);
      }
      console.log(response);
    });
  }

  value: number = 0;
  tagId: number = 0;
  type: string = '';
  priority: string = '';

  addAlarm() {
    const newAlarm: Alarm = {
      value: this.value,
      tagId: this.tagId,
      type: this.type,
      priority: this.priority
    }

    this.alarmService.addAlarm(newAlarm).subscribe((response) => {
      alert(response.message);
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        window.location.reload();
      });
    },
    (error) => {
      alert(error.error.message);
    }
    );

  }

  deleteAlarm(alarmId: number){
    this.alarmService.removeAlarm(alarmId).subscribe((response) => {
      alert(response.message);
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        window.location.reload();
      });
    },
    (error) => {
      alert(error.error.message);
    }
    );
  }

}
