export default class MaterialDto {
  constructor(data) {
    if (data) {
      this.name = data.name;
      this.price = data.price;
      this.type = data.type;
    }
  }
}
