export default class ComponentDto {
  constructor(data) {
    if (data) {
      this.name = data.name;
      this.width = data.width;
      this.height = data.height;
      this.closings = data.closings;
    }
  }
}
