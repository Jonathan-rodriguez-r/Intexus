import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrModule, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-crud',
  templateUrl: './crud.component.html',
  styleUrls: ['./crud.component.css']
})
export class CrudComponent implements OnInit {
  listEmpleados:  any[] = [
    {nombre: 'Jonathan', apellido: 'Rodriguez', edad: 32, cedula: 1015123456, ciudad: 'Bogotá'},
    {nombre: 'Efrain', apellido: 'Diaz', edad: 31, cedula: 1014456789, ciudad: 'Fresno'}
  ];

  form: FormGroup;
  constructor(private fb: FormBuilder, private toastr: ToastrService ) {
    this.form = this.fb.group({
      nombre: ['', [Validators.required, Validators.minLength(3) ]],
      apellido: ['', [Validators.required, Validators.minLength(3) ]],
      edad: ['',[Validators.required, Validators.max(120), Validators.min(1)]],
      cedula: ['',[Validators.required, Validators.maxLength(12), Validators.minLength(6)]],
      ciudad: ['', [Validators.required, Validators.maxLength(3)]]
    })
  }
agregarEmpleado() {
console.log(this.form);
  const empleado: any = 
  {
    nombre: this.form.get('nombre')?.value,
    apellido: this.form.get('apellido')?.value,
    edad: this.form.get('edad')?.value,
    cedula: this.form.get('cedula')?.value,
    ciudad: this.form.get('ciudad')?.value
  }
  
  this.listEmpleados.push(empleado);
  const nombres= this.form.get('nombre')?.value +' '+ this.form.get('apellido')?.value
  this.toastr.success('Empleado '+ nombres + ' creado!', '¡Exito!' );
  this.form.reset();
}
  eliminarEmpleado(index: number)
    {
    console.log(index);
    this.listEmpleados.splice(index, 1);
    this.toastr.error('Empleado eliminado!', '¡Exito!' );

    }
  ngOnInit(): void {

  }
  
}
