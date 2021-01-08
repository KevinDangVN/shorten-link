import roles from "../helper/config/Roles";

const MENU = [
  {
    key: "dashboard",
    title: "Dashboard",
    link: "/dashboard",
    icon: "dashboard",
    role: [roles.ADMIN],
  },
  {
    key: "facility",
    title: "Quản lý chung",
    icon: "dashboard",
    role: [roles.EMPLOYEE, roles.ADMIN],
    sub: [
      {
        key: "manageRequest",
        title: "Quản lý link",
        link: "/facility/manage",
        role: [roles.EMPLOYEE, roles.ADMIN],
      },
      {
        key: "viewRequest",
        title: "Quản lý nhân viên",
        link: "/facility/status",
        role: [roles.EMPLOYEE, roles.ADMIN],
      },
    ],
  },
];

export default MENU;
