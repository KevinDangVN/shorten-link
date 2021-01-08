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
    title: "Quản lý tài sản",
    icon: "dashboard",
    role: [roles.EMPLOYEE, roles.ADMIN],
    sub: [
      {
        key: "manageRequest",
        title: "Quản lý các đề xuất",
        link: "/facility/manage",
        role: [roles.EMPLOYEE, roles.ADMIN],
      },
      {
        key: "viewRequest",
        title: "Theo dõi đề xuất của bạn",
        link: "/facility/status",
        role: [roles.EMPLOYEE, roles.ADMIN],
      },
    ],
  },
];

export default MENU;
