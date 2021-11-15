  import { Component, OnInit } from '@angular/core';
  import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import * as moment from 'moment';
  import { ToastrModule, ToastrService } from 'ngx-toastr';
  import { AfiliadoService } from '../../services/afiliado.service';

  @Component({
    selector: 'app-crud',
    templateUrl: './crud.component.html',
    styleUrls: ['./crud.component.css']
  })
  export class CrudComponent implements OnInit {
    listAfiliados:  any[] = [];
    accion = 'Agregar';
    id: number | undefined;
    form: FormGroup;
    constructor(private fb: FormBuilder, private toastr: ToastrService, private _afiliadoservice: AfiliadoService ) {
      this.form = this.fb.group({
        nombre: ['', [Validators.required, Validators.minLength(3) ]],
        apellido: ['', [Validators.required, Validators.minLength(3) ]],
        sexo: ['',[Validators.required, Validators.minLength(1), Validators.maxLength(1)]],
        fechaNacimiento: ['',[Validators.required, Validators.maxLength(12), Validators.minLength(2)]],
        recaudo: ['', [Validators.required, Validators.minLength(3)]]
      })
    }
  guardarAfiliado() {
    const afiliado: any = 
    {
      nombre: this.form.get('nombre')?.value,
      apellido: this.form.get('apellido')?.value,
      sexo: this.form.get('sexo')?.value,
      fechaNacimiento: this.form.get('fechaNacimiento')?.value,
      recaudo: parseInt(this.form.get('recaudo')?.value)
    }
    if (this.id == undefined){
      this._afiliadoservice.saveafiliado(afiliado).subscribe(data => {
        const nombres= this.form.get('nombre')?.value +' '+ this.form.get('apellido')?.value
        this.toastr.success('Afiliado '+ nombres + ' creado!', '¡Exito!' );
        this.obtenerafiliados();
        this.form.reset();
      },error => {
        this.toastr.error(error, 'Error' );
      } );
    }else{
      afiliado.id=this.id;
      this._afiliadoservice.updateafiliado(this.id, afiliado).subscribe(data => {
        this.toastr.info('Afiliado con el ID: '+ this.id +' ha sido actualizado!', '¡Exito!' );
        this.accion='Agregar';
        this.obtenerafiliados();
        this.form.reset();
        this.id = undefined;
      },error => {
        this.toastr.error(error, 'Error' );
      });
    }
 
  
  }
    eliminarAfiliado(id: number)
      {
      this._afiliadoservice.deleteafiliado(id).subscribe(data => {
        this.toastr.info('Afiliado con el ID: '+ id +' ha sido eliminado!', '¡Exito!' );
        this.accion='Agregar';
        this.obtenerafiliados();
      },error => {
        this.toastr.error(error, 'Error' );
      }
      );
      }
      
      editarAfiliado(afiliado:any){
        this.id=afiliado.id;
        this.accion='Actualizar';
        let fecha = moment(afiliado.fechaNacimiento).format('YYYY-MM-DD');
        this.form.patchValue({
        nombre: afiliado.nombre,
        apellido: afiliado.apellido,
        sexo: afiliado.sexo,
        fechaNacimiento: fecha,
        recaudo: afiliado.recaudo
        }
        );
      }
    ngOnInit(): void {
  this.obtenerafiliados();
    }
    obtenerafiliados(){
      this._afiliadoservice.getlistafiliados().subscribe(data => {
        this.listAfiliados=data.responseParams;
      }, error => {
        console.log(error);
      }
        );
    }
  }
