import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../../services/vehicle.service';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
makes: any[];
models: any[];
features: any[];
vehicle: any = {};

    constructor(private vehicleService: VehicleService) {
    }
    ngOnInit(): void {
        this.vehicleService.getMakes()
        .subscribe((makes: any) => {
            this.makes = makes;
           // console.log(JSON.stringify(makes, null, 4));
        });
        this.vehicleService.getFeatures()
        .subscribe((features: any[] )=>
            this.features = features);
    }

    onMakeChange(){
        let selectedMake = this.makes.find(m => m.id == this.vehicle.make);
        this.models = selectedMake ? selectedMake.models : [];
    }

    submit(){
        this.vehicleService.createVehicle(this.vehicle).subscribe(x => console.log(JSON.stringify(x, null, 4)));
    }
}
