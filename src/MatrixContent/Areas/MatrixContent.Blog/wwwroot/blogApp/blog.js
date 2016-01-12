var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
/*
 * Angular 2 decorators and services
 */
var browser_1 = require('angular2/platform/browser');
var core_1 = require('angular2/core');
var http_1 = require('angular2/http');
require('rxjs/Rx');
var PostService_ts_1 = require('./services/PostService.ts');
var ErrorHandlingService_ts_1 = require('./services/ErrorHandlingService.ts');
var DataService_ts_1 = require('./services/DataService.ts');
var AppComponent = (function () {
    function AppComponent(postService) {
        var _this = this;
        this.title = "Blog app ";
        this.Posts = [];
        postService.GetPosts(1, 20, function (response) {
            _this.Posts = response.Items;
            console.log(response);
        });
    }
    AppComponent = __decorate([
        core_1.Component({
            selector: 'posts'
        }),
        core_1.View({
            templateUrl: "/blog/view/postlist/",
        })
    ], AppComponent);
    return AppComponent;
})();
browser_1.bootstrap(AppComponent, [
    http_1.HTTP_PROVIDERS,
    PostService_ts_1.PostService,
    ErrorHandlingService_ts_1.ErrorHandlingService,
    DataService_ts_1.DataService,
]).then(function (success) { return console.log('Blog App Bootstrapped!'); }, function (error) { return console.log(error); });
