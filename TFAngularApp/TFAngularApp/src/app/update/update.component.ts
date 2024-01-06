import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  name: string;
  age: number;
  constructor(private router: ActivatedRoute, private route: Router) { }

  ngOnInit(): void {
    this.name = this.router.snapshot.params['name'];
    this.age = this.router.snapshot.params['age'];
  }
  updateProduct(form: NgForm) {
    alert("age is updated");
    this.route.navigate(['/home']);

  }
  searchProduct(item: string) {
    //alert("item recieved in search box");
  }
}
