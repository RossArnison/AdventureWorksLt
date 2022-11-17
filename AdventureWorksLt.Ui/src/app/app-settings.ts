const appSettingsJson = require('../assets/appsettings.json');

export default class appSettings {
  private static _apiUri?: string;

  public static get apiUri() {
    return this._apiUri ??= this.getApiUri()
  }

  private static getApiUri() {
    let apiUri = appSettingsJson.apiUrl;

    if (!this.uriHasSlashSuffix(apiUri))
      apiUri += "/";

    return apiUri;
  }

  private static uriHasSlashSuffix(uri?: string) {
    return uri
      && uri.length > 0
      && uri.slice(uri.length - 1) == "/"
  }
}
