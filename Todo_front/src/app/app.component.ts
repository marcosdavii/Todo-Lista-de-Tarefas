import { RouterModule, Router } from '@angular/router';
import { auth } from 'firebase';
import { AngularFireAuth } from '@angular/fire/auth';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  template: '<router-outlet></router-outlet>'
  
})
export class AppComponent implements OnInit {

  constructor(
    private afAuth: AngularFireAuth,
    private router: Router
  ) {}

  ngOnInit() {
    this.afAuth.onAuthStateChanged(data => {
      if(data) {
        this.router.navigateByUrl('/');
      } else {
        this.router.navigateByUrl('/login');
      }
    });

    this.afAuth.idToken.subscribe(token => sessionStorage.setItem('token', token));
  }
  
}
