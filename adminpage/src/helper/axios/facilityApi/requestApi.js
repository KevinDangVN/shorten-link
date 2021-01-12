import axiosClient from "../axiosClient";

const requestApi = {
  getAllEmployee: () => {
    const url = `/api/employee/viewall`;
    return axiosClient.get(url);
  },
  getAllRequestEmpId: () => {
    const url = `/api/linkdata/alllinks`;
    return axiosClient.get(url);
  },
  postRequest: (formData) => {
    const url = "/oisp/fm/request/add";
    return axiosClient.post(url, formData);
  },
  deleteRequest: (requestId) => {
    const url = `/oisp/fm/request/${requestId}`;
    return axiosClient.delete(url);
  },
  editRequest: (requestId, formData) => {
    const url = `/oisp/fm/request/${requestId}`;
    return axiosClient.put(url, formData);
  },
  getRoleId: () => {
    const url = "/api/employee/getrole";
    return axiosClient.get(url);
  },
};

export default requestApi;
