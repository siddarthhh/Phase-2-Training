import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { response } from 'express';
import { CommonModule } from '@angular/common';
import { Company } from '../company';
import { Router } from '@angular/router';


@Component({
  selector: 'app-company',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './company.component.html',
  styleUrl: './company.component.css'
})
export class CompanyComponent {
  // data :any;
     companies: Company[] = [];

     constructor(private apiser:ApiService,private router:Router)
     {

     }

   /*ngOnInit():void{
        this.apiser.get().subscribe(
          (response) => {
            this.data=response;
            console.log()
          }
        );
     }*/
        ngOnInit(): void {
          this.loadCompanies();
        }
      
        loadCompanies(): void {
          this.apiser.get().subscribe(
            (data) => this.companies = data,
            (error) => console.error('Error loading companies', error)
          );
        }
      
          viewDetails(id: number): void {
          this.router.navigate(['/company', id]);
        }
      
        updateCompany(id: number): void {
          this.router.navigate(['/companyup', id]);
        }
        addCompany(): void {
          this.router.navigate(['/companyAdd']);
        }
        deleteCompany(id: number): void {
          if (confirm('Are you sure you want to delete this company?')) {
            this.apiser.delete(id).subscribe(
              () => {
                console.log('Company deleted successfully');
                this.loadCompanies(); 
              },
              (error) => console.error('Error deleting company', error)
            );
          }
        }
}

