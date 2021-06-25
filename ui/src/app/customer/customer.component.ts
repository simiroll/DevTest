import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CustomerTypeService } from '../services/customerType.service';
import { CustomerService } from '../services/customer.service';
import { CustomerModel } from '../models/customer.model';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  public cTypes: string[] = [];

  public customers: CustomerModel[] = [];

  public newCustomer: CustomerModel = {
    customerId: null,
    name: null,
    type: null
  };

  constructor(
    private customerService: CustomerService,
    private customerTypeService: CustomerTypeService) { }

  ngOnInit() {
    this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
    this.customerTypeService.GetCustomerTypes().subscribe(cTypes => this.cTypes = cTypes);
  }

  public createCustomer(form: NgForm): void {
    if (form.invalid) {
      alert('form is not valid');
    } else {
      this.customerService.CreateCustomer(this.newCustomer).then(() => {
        this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
      });
    }
  }

}
