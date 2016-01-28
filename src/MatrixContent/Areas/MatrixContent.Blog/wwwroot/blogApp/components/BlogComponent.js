var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
/*
 * Angular 2 decorators and services
 */
var core_1 = require('angular2/core');
var router_1 = require('angular2/router');
var ErrorHandlingService_1 = require('../services/ErrorHandlingService');
var DataService_1 = require('../services/DataService');
var PostService_1 = require('../services/PostService');
var PostsPagedListComponent_1 = require('../components/PostsPagedListComponent');
var BlogComponent = (function () {
    function BlogComponent() {
    }
    BlogComponent = __decorate([
        core_1.Component({
            selector: 'blog',
            templateUrl: "/blog/view/bloghome/",
            directives: [PostsPagedListComponent_1.PostsPagedListComponent, router_1.ROUTER_DIRECTIVES],
            providers: [DataService_1.DataService, PostService_1.PostService, ErrorHandlingService_1.ErrorHandlingService]
        }),
        router_1.RouteConfig([
            { path: '/list/...', name: 'DefaultPagedPosts', useAsDefault: true, component: PostsPagedListComponent_1.PostsPagedListComponent },
        ])
    ], BlogComponent);
    return BlogComponent;
})();
exports.BlogComponent = BlogComponent;
