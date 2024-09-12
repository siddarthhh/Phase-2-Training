import { Routes } from '@angular/router';
import { CompanyComponent } from './company/company.component';
import { CompanyDetailsComponent } from './company-details/company-details.component';
import { CompanyAddComponent } from './company-add/company-add.component';
import { CompanyDeleteComponent } from './company-delete/company-delete.component';
import { UpdateCompanyComponent } from './update-company/update-company.component';

export const routes: Routes = [
    {path:'',component:CompanyComponent},
    {path:'company/:id',component:CompanyDetailsComponent},
    {path:'companydel/:id',component:CompanyDeleteComponent},
    {path:'companyup/:id',component:UpdateCompanyComponent},

    {path:'companyAdd',component:CompanyAddComponent}


];
