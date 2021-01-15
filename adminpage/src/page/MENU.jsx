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
    title: "Management",
    icon: "dashboard",
    role: [roles.EMPLOYEE, roles.ADMIN],
    sub: [
      {
        key: "manageRequest",
        title: "Slug",
        link: "/facility/slug",
        role: [roles.EMPLOYEE, roles.ADMIN],
      },
      {
        key: "viewRequest",
        title: "Employee",
        link: "/facility/employee",
        role: [roles.ADMIN],
      },
    ],
  },
];

export default MENU;
