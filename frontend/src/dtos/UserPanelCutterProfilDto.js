import UserDesignerProfilDto from "./UserDesignerProfilDto";

export default class UserPanelCutterProfilDto extends UserDesignerProfilDto {
  constructor(data) {
    super(data);
    if (data) {
      this.opened = data.opened;
      this.facebook = data.facebook;
      this.extras = data.extras;
    }
  }
}
