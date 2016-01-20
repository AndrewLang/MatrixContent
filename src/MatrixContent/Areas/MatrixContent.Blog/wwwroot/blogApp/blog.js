var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") return Reflect.decorate(decorators, target, key, desc);
    switch (arguments.length) {
        case 2: return decorators.reduceRight(function(o, d) { return (d && d(o)) || o; }, target);
        case 3: return decorators.reduceRight(function(o, d) { return (d && d(target, key)), void 0; }, void 0);
        case 4: return decorators.reduceRight(function(o, d) { return (d && d(target, key, o)) || o; }, desc);
    }
};
define(["require", "exports", 'angular2/platform/browser', 'angular2/core', 'angular2/http', './services/PostService.ts', './services/ErrorHandlingService.ts', './services/DataService.ts', './components/PostsPagedList.ts', 'rxjs/Rx'], function (require, exports, browser_1, core_1, http_1, PostService_ts_1, ErrorHandlingService_ts_1, DataService_ts_1, PostsPagedList_ts_1) {
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
});
