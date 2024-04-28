/* @refresh reload */
import { render } from "solid-js/web";
import { Route, Router } from "@solidjs/router";
import { lazy } from "solid-js";

const root = document.getElementById("root");

const login = {
  path: "/",
  component: lazy(() => import("./routes/login/index")),
};

const home = {
  path: "/home",
  component: lazy(() => import("./routes/login/index")),
};

render(
  () => (
    <Router>
      {" "}
      <Route path={login.path} component={login.component} />
      <Route path={home.path} component={home.component} />
    </Router>
  ),
  root!
);
