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
var PagedList_1 = require('../common/PagedList');
var PostListComponent_1 = require('./PostListComponent');
var PostsPagedListComponent = (function () {
    function PostsPagedListComponent(postService, mRouter, mRouteParams) {
        this.postService = postService;
        this.mRouter = mRouter;
        this.mRouteParams = mRouteParams;
        this.Data = new PagedList_1.PagedList();
        this.MaxSize = 5;
        this.CurrentPage = 1;
        this.ShowBoundaryLinks = true;
        this.PageSize = 10;
        console.log("constructor of posts paged list");
    }
    PostsPagedListComponent.prototype.ngOnInit = function () {
        var page = this.mRouteParams.get('page');
        if (page)
            this.CurrentPage = page;
        console.log("OnInit load page " + page);
        this.LoadPosts();
    };
    PostsPagedListComponent.prototype.LoadPosts = function () {
        var _this = this;
        console.log("Load posts: page " + this.CurrentPage);
        this.postService.GetPosts(this.CurrentPage, this.PageSize, function (response) {
            _this.Data = response;
            console.log(_this.Data);
        });
    };
    PostsPagedListComponent.prototype.dataLoaded = function (event) {
        console.log("data loaded");
    };
    PostsPagedListComponent.prototype.onPageChanged = function (event) {
        console.log("Enter page changed " + event.page);
        if (this.CurrentPage != event.page) {
            console.log('Current Page ' + this.CurrentPage + ' changed to: ' + event.page);
            this.CurrentPage = event.page;
            //this.LoadPosts();
            this.mRouter.navigate(['PagedPosts', { page: event.page }]);
        }
    };
    PostsPagedListComponent = __decorate([
        core_1.Component({
            selector: 'paged-posts',
            templateUrl: "/blog/view/postpagedlist/",
            directives: [ng2_bootstrap_1.PAGINATION_DIRECTIVES, router_1.RouterOutlet],
            providers: [PostService_1.PostService, DataService_1.DataService]
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
