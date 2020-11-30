export default class AdDto {
  constructor(data) {
    if (data) {
      this.id = data.id;
      this.title = data.title;
      this.text = data.text;
      this.imageId = data.imageId;
    }
  }
}
