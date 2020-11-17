export default class UserAddressDto {
  constructor(data) {
    if (data) {
      this.address = data.address;
      this.streetAndHouse = data.streetAndHouse;
    }
  }
}
