var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require('angular2/core');
var ng2_bootstrap_1 = require('ng2-bootstrap/ng2-bootstrap');
var DataService_1 = require('../services/DataService');
var PostService_ts_1 = require('../services/PostService.ts');
var PagedList_ts_1 = require('../common/PagedList.ts');
var PostsPagedList = (function () {
    function PostsPagedList(postService, mRouter) {
        this.mRouter = mRouter;
        this.Data = new PagedList_ts_1.PagedList();
        this.MaxSize = 5;
        this.CurrentPage = 1;
        this.ShowBoundaryLinks = true;
        this.PageSize = 10;
        console.log("constructor of posts paged list");
        this.postService = postService;
        this.LoadPosts();
    }
    PostsPagedList.prototype.LoadPosts = function () {
        var _this = this;
        console.log("Load posts: page " + this.CurrentPage);
        this.postService.GetPosts(this.CurrentPage, this.PageSize, function (response) {
            _this.Data = response;
            console.log(_this.Data);
        });
    };
    PostsPagedList.prototype.pageChanged = function (event) {
        if (this.CurrentPage != event.page) {
            console.log('Page changed to: ' + event.page);
            //    this.CurrentPage = event.page;
            //    this.LoadPosts();
            this.mRouter.navigate(['PagedPosts', { page: event.page }]);
        }
    };
    PostsPagedList = __decorate([
        core_1.Component({
            selector: 'posts',
            templateUrl: "/blog/view/postlist/",
            directives: [ng2_bootstrap_1.PAGINATION_DIRECTIVES],
            providers: [PostService_ts_1.PostService, DataService_1.DataService]
        }),
        core_1.Injectable()
    ], PostsPagedList);
    return PostsPagedList;
})();
exports.PostsPagedList = PostsPagedList;
