export default class UserDesignerProfilDto {
  constructor(data) {
    if (data) {
      this.name = data.name;
      this.phone = data.phone;
      this.streetAndHouse = data.streetAndHouse;
      this.imageId = data.imageId;
      this.addressId = data.addressId;
    }
  }
}
