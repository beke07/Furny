export default class AddressDto {
  constructor(data) {
    if (data) {
      this.id = data.id;
      this.zipCode = data.zipCode;
      this.city = data.city;
      this.country = data.country;
    }
  }
}
