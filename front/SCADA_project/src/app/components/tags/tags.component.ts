import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { AnalogInput, AnalogOutput, DigitalInput, DigitalOutput, Tag, TagService } from 'src/app/services/tag/tag.service';


@Component({
  selector: 'app-tags',
  templateUrl: './tags.component.html',
  styleUrls: ['./tags.component.css']
})
export class TagsComponent implements OnInit {
  filteredTags: Tag[] = [];
  allTags: Tag[] = [];
  inputs: Tag[] = [];
  outputs: Tag[] = [];
  analogInputs: AnalogInput[] = [];
  analogOutputs: AnalogOutput[] = [];
  digitalInputs: DigitalInput[] = [];
  digitalOutputs: DigitalOutput[] = [];
  pageTitle: string = 'All Tags';
  filter: string = 'all';

  showAddAnalogInputForm: boolean = false;
  showAddAnalogOutputForm: boolean = false;
  showAddDigitalInputForm: boolean = false;
  showAddDigitalOutputForm: boolean = false;

  constructor(private tagService: TagService, private router: Router) { }

  ngOnInit(): void {
    this.tagService.getAllTags().subscribe((response) => {
      this.allTags = response;
      console.log(response);
    });

    this.filterTags('all');
  }

  filterTags(filterType: string): void {
    if (filterType === 'all') {
      this.filteredTags = this.allTags;
      this.pageTitle = `All Tags`;
      this.filter = 'all';
    } else if(filterType === 'input') {
      this.tagService.getAllInputs().subscribe((response) => {
        this.filteredTags = response;
        console.log(response);
      });
      this.pageTitle = `All Input Tags`;
      this.filter = `${filterType}`;
    } else if(filterType === 'output'){
      this.tagService.getAllOutputs().subscribe((response) => {
        this.filteredTags = response;
        console.log(response);
      });
      this.pageTitle = `All Output Tags`;
      this.filter = `${filterType}`;
    } else if(filterType === 'analog-input'){
      this.tagService.getAllAnalogInputs().subscribe((response) => {
        this.analogInputs = response;
        console.log(response);
      });
      this.pageTitle = `All Analog Inputs`;
      this.filter = `${filterType}`;
    } else if(filterType === 'analog-output'){
      this.tagService.getAllAnalogOutputs().subscribe((response) => {
        this.analogOutputs = response;
        console.log(response);
      });
      this.pageTitle = `All Analog Outputs`;
      this.filter = `${filterType}`;
    } else if(filterType === 'digital-input'){
      this.tagService.getAllDigitalInputs().subscribe((response) => {
        this.digitalInputs = response;
        console.log(response);
      });
      this.pageTitle = `All Digital Inputs`;
      this.filter = `${filterType}`;
    } else {
      this.tagService.getAllDigitalOutputs().subscribe((response) => {
        this.digitalOutputs = response;
        console.log(response);
      });
      this.pageTitle = `All Digital Outputs`;
      this.filter = `${filterType}`;
    }
  }

  newAInputName: string = '';
  newAInputDescription: string = '';
  newAInputIOAddress: string = '';
  newAInputValue: number = 0;
  newAInputScanTime: number = 0;
  // newAInputIsScanOn: boolean = true;
  newAInputLowLimit: number = 0;
  newAInputHighLimit: number = 0;
  newAInputUnit: string = '';

  addAnalogInput() {
    const newAnalogInput: AnalogInput = {
      name: this.newAInputName,
      description: this.newAInputDescription,
      ioAddress: this.newAInputIOAddress,
      value: this.newAInputValue,
      scanTime: this.newAInputScanTime,
      isScanOn: true,
      lowLimit: this.newAInputLowLimit,
      highLimit: this.newAInputHighLimit,
      unit: this.newAInputUnit
    }

    this.tagService.addAnalogInput(newAnalogInput).subscribe((response) => {
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

  newAOutputName: string = '';
  newAOutputDescription: string = '';
  newAOutputIOAddress: string = '';
  newAOutputValue: number = 0;
  newAOutputLowLimit: number = 0;
  newAOutputHighLimit: number = 0;
  newAOutputUnit: string = '';

  addAnalogOutput() {
    const newAnalogOutput: AnalogOutput = {
      name: this.newAOutputName,
      description: this.newAOutputDescription,
      ioAddress: this.newAOutputIOAddress,
      value: this.newAOutputValue,
      lowLimit: this.newAOutputLowLimit,
      highLimit: this.newAOutputHighLimit,
      unit: this.newAOutputUnit
    }

    this.tagService.addAnalogOutput(newAnalogOutput).subscribe((response) => {
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

  newDInputName: string = '';
  newDInputDescription: string = '';
  newDInputIOAddress: string = '';
  newDInputValue: number = 0;
  newDInputScanTime: number = 0;

  addDigitalInput() {
    const newDigitalInput: DigitalInput = {
      name: this.newDInputName,
      description: this.newDInputDescription,
      ioAddress: this.newDInputIOAddress,
      value: this.newDInputValue,
      scanTime: this.newDInputScanTime,
      isScanOn: true
    }

    this.tagService.addDigitalInput(newDigitalInput).subscribe((response) => {
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

  newDOutputName: string = '';
  newDOutputDescription: string = '';
  newDOutputIOAddress: string = '';
  newDOutputValue: number = 0;

  addDigitalOutput() {
    const newDigitalOutput: DigitalOutput = {
      name: this.newDOutputName,
      description: this.newDOutputDescription,
      ioAddress: this.newDOutputIOAddress,
      value: this.newDOutputValue
    }

    this.tagService.addDigitalOutput(newDigitalOutput).subscribe((response) => {
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


  deleteTag(tagId: number): void {
    this.tagService.removeTag(tagId).subscribe((response) => {
      alert(response.message);
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        window.location.reload();
      });
    },
    (error) => {
      alert(error.error.message);
    });
  }

  turnOnScan(tagId: number){
    this.tagService.turnOnScan(tagId).subscribe((response) => {
      alert(response.message);
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        window.location.reload();
      });
    },
    (error) => {
      alert(error.error.message);
    });
  }

  turnOffScan(tagId: number){
    this.tagService.turnOffScan(tagId).subscribe((response) => {
      alert(response.message);
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        window.location.reload();
      });
    },
    (error) => {
      alert(error.error.message);
    });
  }
}
