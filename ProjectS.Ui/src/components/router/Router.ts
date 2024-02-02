import { Component } from "solid-js";

export default class Router {
    path: string
    component: Component

    constructor(path: string, component: Component) {
        this.path = path;
        this.component = component;
    }
}