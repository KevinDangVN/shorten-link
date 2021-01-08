import { BrowserRouter, Redirect, Route, Switch } from "react-router-dom";
import Slug from "./Slug";

const App = () => {
  const routes = (
    <Switch>
      <Route path="/:slug" component={Slug} />

      <Redirect to="/" />
    </Switch>
  );

  return (
    <>
      abc
      <BrowserRouter>{routes}</BrowserRouter>
    </>
  );
};

export default App;
