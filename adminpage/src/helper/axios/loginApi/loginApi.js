import axiosClient from "../axiosClient";

const loginApi = {
  postLogin: (form) => {
    const url = "api/employee/auth";
    return axiosClient.post(url, form);
  },
};

export default loginApi;
