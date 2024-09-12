import { Component } from '@angular/core';
import { Company } from '../company';
import { ApiService } from '../api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-update-company',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './update-company.component.html',
  styleUrl: './update-company.component.css'
})
export class UpdateCompanyComponent {


  constructor(
    private apiser: ApiService,
    private route: ActivatedRoute,
    private router: Router
  ) { }
  company: Company = { companyId: 0, companyName: '' };

  ngOnInit():void{
    const id= +this.route.snapshot.params['id'];
    this.apiser.getbyid(id).subscribe(
      (response) => {
        this.company=response
      }
    )
  }
  onSubmit():void{
    this.apiser.update(this.company.companyId,this.company).subscribe(
      (response) =>{
        console.log('updated added successfully',response);
        this.router.navigate(['/']);
      }
    )
   };
  
}
