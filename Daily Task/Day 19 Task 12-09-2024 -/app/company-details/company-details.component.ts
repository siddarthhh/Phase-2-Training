import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { ActivatedRoute } from '@angular/router';
import { Company } from '../company';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-company-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './company-details.component.html',
  styleUrl: './company-details.component.css'
})
export class CompanyDetailsComponent {
  constructor(private apiser:ApiService,private route: ActivatedRoute){
  }
  company : Company | undefined;

  ngOnInit () : void {
    const id = +this.route.snapshot.params['id'];
    this.apiser.getbyid(id).subscribe(
      (response)=>{
        this.company=response;
      }
    )
  }
}
