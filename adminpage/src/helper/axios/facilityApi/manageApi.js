import axiosClient from "../axiosClient";

import localStorageService from "../../localStorage/localStorageService";

const manageRequest = {
  getAllLink: () => {
    const employeeId = localStorageService.getUserId();
    const url = `/api/linkdata/link/emp/${employeeId}`;
    return axiosClient.get(url);
  },
  seenRequest: (requestId) => {
    const url = `/oisp/fm/manage/view/${requestId}`;
    return axiosClient.put(url);
  },
  putFMTeamLeadEditRequest: (requestId, facilityRequest) => {
    const url = `/oisp/fm/manage/fmTeamLeadEdit/${requestId}`;
    return axiosClient.put(url, facilityRequest);
  },
  putEditRequest: (requestId, facilityRequest) => {
    const url = `/oisp/fm/manage/fmManage/${requestId}`;
    return axiosClient.put(url, facilityRequest);
  },
};

export default manageRequest;
