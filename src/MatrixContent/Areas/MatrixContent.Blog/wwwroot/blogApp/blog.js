var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") return Reflect.decorate(decorators, target, key, desc);
    switch (arguments.length) {
        case 2: return decorators.reduceRight(function(o, d) { return (d && d(o)) || o; }, target);
        case 3: return decorators.reduceRight(function(o, d) { return (d && d(target, key)), void 0; }, void 0);
        case 4: return decorators.reduceRight(function(o, d) { return (d && d(target, key, o)) || o; }, desc);
    }
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
var PostsPagedList_ts_1 = require('./components/PostsPagedList.ts');
var BlogComponent = (function () {
    function BlogComponent() {
    }
    BlogComponent = __decorate([
        core_1.Component({
            selector: 'blog',
            templateUrl: "/blog/view/bloghome/",
            directives: [PostsPagedList_ts_1.PostsPagedList]
        })
    ], BlogComponent);
    return BlogComponent;
})();
exports.BlogComponent = BlogComponent;
browser_1.bootstrap(BlogComponent, [
    http_1.HTTP_PROVIDERS,
    ErrorHandlingService_ts_1.ErrorHandlingService,
    DataService_ts_1.DataService,
    PostService_ts_1.PostService
]).then(function (success) { return console.log('Blog App Bootstrapped!'); }, function (error) { return console.log(error); });
