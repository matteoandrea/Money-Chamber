
import { lazy } from "solid-js";
import Home from "../../Pages/Home";
import Login from "../../Pages/Login";
import Router from "./Router";
import NotFound from "../../Pages/NotFound";

export default class Routing {
    static home: Router = new Router("/", Home);
    static login: Router = new Router("/login", Login);
    static notFound: Router = new Router("*", NotFound);

    static routes = [
        {
            path: this.home.path,
            component: this.home.component,
        },
        {
            path: this.login.path,
            component: this.login.component,
        },
        {
            path: this.notFound.path,
            component: this.notFound.component,
        },
    ];
}