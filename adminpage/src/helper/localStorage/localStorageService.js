const localStorageService = {
  setUserData(tokenObj) {
    localStorage.setItem("acToken", tokenObj.acToken);
    localStorage.setItem("fullName", tokenObj.fullName);
    localStorage.setItem("role", tokenObj.role);
    localStorage.setItem("userId", tokenObj.userId);
  },

  getUserData() {
    return {
      acToken: this.getAccessToken(),
      fullName: this.getFullName(),
      role: this.getRole(),
      userId: this.getUserId(),
    };
  },

  getAccessToken() {
    return localStorage.getItem("acToken");
  },

  setAccessToken(acToken) {
    return localStorage.setItem("acToken", acToken);
  },

  getFullName() {
    return localStorage.getItem("fullName");
  },

  getRole() {
    return JSON.parse(localStorage.getItem("role"));
  },

  getUserId() {
    return localStorage.getItem("userId");
  },

  clearAll() {
    return localStorage.clear();
  },
};

export default localStorageService;
