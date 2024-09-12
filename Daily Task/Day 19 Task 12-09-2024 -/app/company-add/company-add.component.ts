import { Component } from '@angular/core';
import { Company } from '../company';
import { ApiService } from '../api.service';
import { Router, RouterLink } from '@angular/router';
import { response } from 'express';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-company-add',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './company-add.component.html',
  styleUrl: './company-add.component.css'
})
export class CompanyAddComponent {
  company :Company ={companyId:0,companyName:''};
  constructor (private apiser : ApiService,private router:Router){

  }

  onSubmit():void{
    this.apiser.post(this.company).subscribe(
      (response) => {
        console.log(response);
        this.router.navigate(['/']);
      }
    )
  }

}
