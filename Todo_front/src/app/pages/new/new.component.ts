import { AngularFireAuth } from '@angular/fire/auth';
import { Router } from '@angular/router';
import { DataService } from './../../data.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css']
})
export class NewComponent implements OnInit {
  public form: FormGroup;

  constructor( private fb: FormBuilder,
    private service: DataService,
    private router: Router,
    private afAuth: AngularFireAuth,
  ) {
    this.form = this.fb.group({
      title: ['', Validators.compose([
        Validators.minLength(3),
        Validators.maxLength(60),
        Validators.required,
      ])],
      date: [new Date().toJSON().substring(0, 10), Validators.required]
    });
  }

  ngOnInit(): void {
  }

  submit() {
    this.afAuth.idToken.subscribe(token => {
      this.service.postTodo(this.form.value, token)
        .subscribe(res => {
          this.router.navigateByUrl("/");
        });
    });
  }

}
