import * as firebase from "firebase/app";
import "firebase/auth";
import { firebaseConfig } from "./firebase-config";

firebase.initializeApp(firebaseConfig);

export default {
  auth: firebase.auth(),
  login() {
    const provider = new firebase.auth.GoogleAuthProvider();
    return firebase
      .auth()
      .signInWithPopup(provider)
      .then((result) => {
        return result.user.getIdToken();
      })
      .catch((error) => {
        throw new Error(error);
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
        throw new Error(error);
      });
  },
};
