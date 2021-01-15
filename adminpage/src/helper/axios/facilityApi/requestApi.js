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
  postEmployee: (formData) => {
    const url = "/api/employee";
    return axiosClient.post(url, formData);
  },
  getRoleNameById: (id) => {
    const url = `/api/employee/getrolename/${id}`;
    return axiosClient.get(url);
  },
  deleteEmp: (empId) => {
    const url = `/api/employee/${empId}`;
    return axiosClient.delete(url);
  },
  editEmp: (empId, formData) => {
    const url = `/api/employee/${empId}`;
    return axiosClient.patch(url, formData);
  },
  getRoleId: () => {
    const url = "/api/employee/getrole";
    return axiosClient.get(url);
  },
};

export default requestApi;
