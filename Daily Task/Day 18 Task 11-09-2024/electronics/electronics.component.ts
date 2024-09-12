import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-electronics',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './electronics.component.html',
  styleUrls: ['./electronics.component.css']
})
export class ElectronicsComponent {
  elecList: electronics[] = [
    {EId: 1, Name: "iPhone 16 Pro Max", Price: 150000, Stock: 20, Category: "Mobile", Eimg: "./../../../public/assets/mobile.jfif"},
    {EId: 2, Name: "iPhone 16 Pro", Price: 100000, Stock: 20, Category: "Mobile", Eimg: "./../../../public/assets/mobile.jfif"},
    {EId: 3, Name: "iPhone 16", Price: 80000, Stock: 20, Category: "Mobile", Eimg: "./../../../public/assets/mobile.jfif"},
    {EId: 4, Name: "Sony QLED 8k 65 inch", Price: 240000, Stock: 20, Category: "TV", Eimg: "./../../../public/assets/tv.jfif"},
    {EId: 5, Name: "HP Omen i9 gaming laptop", Price: 160000, Stock: 20, Category: "Laptop", Eimg: "./../../../public/assets/laptop.jfif"},
    {EId: 6, Name: "Sony PS5", Price: 140000, Stock: 20, Category: "Game Console", Eimg: "./../../../public/assets/gameconsole.webp"},
    {EId: 7, Name: "Sony QLED 8k 55 inch", Price: 140000, Stock: 0, Category: "TV", Eimg: "./../../../public/assets/tv.jfif"},
  ];

  val: string = 'All';

  // Method to get unique categories
  getUniqueCategory(): string[] {
    return [...new Set(this.elecList.map(elec => elec.Category))];
  }

  // Method to filter the product list based on selected category
  filteredElecList() {
    return this.val === 'All' ? this.elecList : this.elecList.filter(elec => elec.Category === this.val);
  }

  // Method to handle form submission and add new product to the list
  onSubmit(form: any) {
    if (form.valid) {
      const newProduct: electronics = {
        EId: this.elecList.length + 1,
        Name: form.value.name,
        Price: form.value.price,
        Stock: form.value.stock,
        Category: form.value.category,
        Eimg: "./../../../public/assets/default.jfif"  // Placeholder image for new products
      };
      this.elecList.push(newProduct);
      form.reset();  // Reset form after submission
    }
  }
}

// Model class for electronics
class electronics {
  EId?: number;
  Name?: string;
  Price?: number;
  Stock: number = 0;
  Category: string = "";
  Eimg?: string;
}
