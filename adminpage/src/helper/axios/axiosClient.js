import axios from "axios";
import localStorageService from "../localStorage/localStorageService";

const axiosClient = axios.create({
  baseURL: process.env.REACT_APP_API_URL,
});

const refreshAccessToken = async (userData) => {
  return false;
};

axiosClient.interceptors.request.use(
  async (config) => {
    const acToken = localStorageService.getAccessToken();
    if (acToken) {
      config.headers["Authorization"] = `Bearer ${acToken}`;
    }
    return config;
  },
  (err) => {
    Promise.reject(err);
  }
);

axiosClient.interceptors.response.use(
  (response) => {
    if (response && response.data) {
      return response.data;
    }
    return response;
  },
  async (err) => {
    const originalRequest = err.config;
    if (err.response) {
      if (err.response.status === 403 && !originalRequest._retry) {
        originalRequest._retry = true;
        const userData = localStorageService.getUserData();
        const accessToken = await refreshAccessToken(userData);
        if (accessToken) {
          axios.defaults.headers.common["Authorization"] =
            "Bearer" + accessToken;
          localStorageService.setAccessToken(accessToken);
          return axiosClient(originalRequest);
        }
      }
    }
    return Promise.reject(err);
  }
);

export default axiosClient;
