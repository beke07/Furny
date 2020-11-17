export default class UserDesignerRegistrationDto {
  constructor(data) {
    if (data) {
      this.name = data.name;
      this.email = data.email;
      this.password = data.password;
      this.passwordAgain = data.passwordAgain;
      this.phone = data.phone;
      this.userAddress = data.userAddress;
    }
  }
}
