export default class ClosingsDto {
  constructor(data) {
    if (data) {
      this.left = data.left;
      this.right = data.right;
      this.top = data.top;
      this.bottom = data.bottom;
    }
  }
}
