import { BrowserRouter, Redirect, Route, Switch } from "react-router-dom";
import Home from "./Home";
import Slug from "./Slug";

const App = () => {
  const routes = (
    <Switch>
      <Route path="/" component={Home} exact />
      <Route path="/:slug" component={Slug} />
      <Redirect to="/" component={Home} />
    </Switch>
  );

  return (
    <>
      <BrowserRouter>{routes}</BrowserRouter>
    </>
  );
};

export default App;
