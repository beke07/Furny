export default class UserPanelCutterRegistrationDto {
  constructor(data) {
    if (data) {
      this.name = data.name;
      this.email = data.email;
      this.password = data.password;
      this.passwordAgain = data.passwordAgain;
      this.phone = data.phone;
      this.opened = data.opened;
      this.facebook = data.facebook;
      this.extras = data.extras;
      this.userAddress = data.userAddress;
    }
  }
}
