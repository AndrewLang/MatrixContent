var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require('angular2/core');
var router_1 = require('angular2/router');
var ng2_bootstrap_1 = require('ng2-bootstrap/ng2-bootstrap');
var DataService_1 = require('../services/DataService');
var PostService_1 = require('../services/PostService');
var PostListComponent_1 = require('./PostListComponent');
var PaginationDataContext_1 = require('../common/PaginationDataContext');
var PostsPagedListComponent = (function () {
    function PostsPagedListComponent(DataContext, postService, mRouter) {
        this.DataContext = DataContext;
        this.postService = postService;
        this.mRouter = mRouter;
    }
    PostsPagedListComponent.prototype.ngOnInit = function () {
        this.LoadPosts();
    };
    PostsPagedListComponent.prototype.LoadPosts = function () {
        var _this = this;
        this.postService.GetPosts(this.DataContext.CurrentPage, this.DataContext.PageSize, function (response) {
            _this.DataContext.Data = response;
        });
    };
    PostsPagedListComponent.prototype.onPageChanged = function (event) {
        if (this.DataContext.CurrentPage != event.page) {
            this.DataContext.CurrentPage = event.page;
            //this.LoadPosts();
            this.mRouter.navigate(['PagedPosts', { page: event.page }]);
        }
    };
    PostsPagedListComponent = __decorate([
        core_1.Component({
            selector: 'paged-posts',
            templateUrl: "/blog/view/postpagedlist/",
            directives: [ng2_bootstrap_1.PAGINATION_DIRECTIVES, router_1.RouterOutlet],
            providers: [PostService_1.PostService, DataService_1.DataService, PaginationDataContext_1.PaginationDataContext]
        }),
        router_1.RouteConfig([
            { path: '/', name: 'HomePostsPage', component: PostListComponent_1.PostListComponent, useAsDefault: true },
            { path: '/page/:page', name: 'PagedPosts', component: PostListComponent_1.PostListComponent }
        ]),
        core_1.Injectable()
    ], PostsPagedListComponent);
    return PostsPagedListComponent;
})();
exports.PostsPagedListComponent = PostsPagedListComponent;
