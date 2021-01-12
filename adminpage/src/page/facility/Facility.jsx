import React from "react";
import { Redirect, Switch, useRouteMatch } from "react-router-dom";

import PrivateRoute from "../../compoment/privateRoute/PrivateRoute";
import Roles from "../../helper/config/Roles";
import ManageSlug from "./ManageSlug/ManageSlug";
import ManageEmp from "./ManageEmp/ManageEmp";

const Facility = (props) => {
  let routes;
  const match = useRouteMatch();

  routes = (
    <Switch>
      <PrivateRoute
        path={`${match.path}/employee`}
        roles={[Roles.ADMIN]}
        component={ManageEmp}
      />

      <PrivateRoute
        path={`${match.path}/slug`}
        roles={[Roles.ADMIN, Roles.EMPLOYEE]}
        component={ManageSlug}
      />

      <Redirect to={`${match.path}/manage`} />
    </Switch>
  );

  return <div>{routes}</div>;
};

export default Facility;
