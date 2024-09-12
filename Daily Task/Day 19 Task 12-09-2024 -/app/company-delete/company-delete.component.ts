import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-company-delete',
  standalone: true,
  imports: [],
  templateUrl: './company-delete.component.html',
  styleUrl: './company-delete.component.css'
})
export class CompanyDeleteComponent {
  constructor(private apiser:ApiService,private route : ActivatedRoute){
    
  }
  ngOnInit () : void {
    const id = +this.route.snapshot.params['id'];
    this.apiser.delete(id).subscribe(
    )
  }

}
