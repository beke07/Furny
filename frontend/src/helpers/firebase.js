import * as firebase from "firebase/app";
import "firebase/auth";
import { firebaseConfig } from "./firebase-config";
import axios from "axios";

firebase.initializeApp(firebaseConfig);

export default {
  auth: firebase.auth(),
  login() {
    const provider = new firebase.auth.GoogleAuthProvider();
    firebase
      .auth()
      .signInWithPopup(provider)
      .then((result) => {
        return result.user.getIdToken();
      })
      .then((idToken) => {
        document.cookie = `token=${idToken}`;
        axios.get("https://localhost:44348/api/auth/user-sync");
      })
      .catch((error) => {
        console.log(error);
      });
  },
  logout() {
    firebase
      .auth()
      .signOut()
      .then(function() {
        document.cookie = "token= ; expires = Thu, 01 Jan 1970 00:00:00 GMT";
      })
      .catch(function(error) {
        console.log(error);
      });
  },
};
