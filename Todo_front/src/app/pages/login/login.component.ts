import { Component, OnInit } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/auth';
import { auth } from 'firebase';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(
    private afAuth:AngularFireAuth
  ) { }

  ngOnInit(): void {
    this.afAuth.onAuthStateChanged(data => {
      console.log(data)
    })
  }


  login() {
    this.afAuth.signInWithPopup(new auth.GoogleAuthProvider()).then(data =>{
      console.log(data)
    }
      );  
  }
}
