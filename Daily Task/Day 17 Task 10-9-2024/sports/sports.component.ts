import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-sports',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './sports.component.html',
  styleUrl: './sports.component.css'
})
export class SportsComponent {
  lstcar:Car[]=[
    {carid:1,carname:"AUDI A8",carbrand:"Audi",carstock:2,carprice:7500000,rating:5,carimg:"./../../../public/assets/audi.jfif"},
    {carid:2,carname:"G-Wagon",carbrand:"Benz",carstock:2,carprice:9700000,rating:4,carimg:"./../../../public/assets/benz.jfif"},
    {carid:3,carname:"M8 Competition",carbrand:"BMW",carstock:5,carprice:8500000,rating:3,carimg:"./../../../public/assets/bmw.jfif"},
    {carid:4,carname:"CountryMan",carbrand:"Mini Cooper",carstock:2,carprice:4500000,rating:2,carimg:"./../../../public/assets/minicooper.jfif"},
    {carid:5,carname:"Phantom",carbrand:"Rolls Royce",carstock:5,carprice:9500000,rating:5,carimg:"./../../../public/assets/bmw.jfif"},

  ]

  cart: any[] = [];

  addToCart(car: any) {
      const cartItem = this.cart.find(item => item.carid === car.carid);
      if (cartItem) {
          cartItem.quantity++;
      } else {
          this.cart.push({ ...car, quantity: 1 });
      }
      car.carstock--;
  }
  buyNow(car: any) {
    car.carstock--;
    alert(`Buying ${car.carname} for Rs: ${car.carprice}`);
}
  getTotal() {
      return this.cart.reduce((total, item) => total + (item.carprice * item.quantity), 0);
  }
  buyAll() {
    if (this.cart.length > 0) {
        const total = this.getTotal();
        alert(`Buying all items in the cart for Rs: ${total}`);
        this.cart = []; // Clear the cart after purchase
    }
}
    
}
class Car{
  carid?:number
  carname?:string
  carbrand?:string
  carstock:number=0
  rating:number=0
  carprice?:number
  carimg?:string
  }
  
