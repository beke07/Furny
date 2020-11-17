export default class UserLoginDto {
  constructor(data) {
    if (data) {
      this.username = data.username;
      this.password = data.password;
    }
  }
}
