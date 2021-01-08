import axiosClient from "../axiosClient";

import localStorageService from "../../localStorage/localStorageService";

const manageRequest = {
  getAllLink: () => {
    const employeeId = localStorageService.getUserId();
    const url = `/api/linkdata/link/emp/${employeeId}`;
    return axiosClient.get(url);
  },
  createLink: (form) => {
    const employeeId = localStorageService.getUserId();
    const url = `api/linkdata/link/emp/${employeeId}`;
    return axiosClient.post(url, form);
  },
  deleteLink: (linkId) => {
    const employeeId = localStorageService.getUserId();
    const url = `api/linkdata/link/emp/${employeeId}/${linkId}`;
    return axiosClient.delete(url);
  },
  putEditRequest: (requestId, facilityRequest) => {
    const url = `/oisp/fm/manage/fmManage/${requestId}`;
    return axiosClient.put(url, facilityRequest);
  },
};

export default manageRequest;
