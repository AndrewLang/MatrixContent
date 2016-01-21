var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") return Reflect.decorate(decorators, target, key, desc);
    switch (arguments.length) {
        case 2: return decorators.reduceRight(function(o, d) { return (d && d(o)) || o; }, target);
        case 3: return decorators.reduceRight(function(o, d) { return (d && d(target, key)), void 0; }, void 0);
        case 4: return decorators.reduceRight(function(o, d) { return (d && d(target, key, o)) || o; }, desc);
    }
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
var core_1 = require('angular2/core');
var ng2_bootstrap_1 = require('ng2-bootstrap/ng2-bootstrap');
var PostService_ts_1 = require('../services/PostService.ts');
var PagedList_ts_1 = require('../common/PagedList.ts');
var PostsPagedList = (function () {
    function PostsPagedList(postService) {
        this.Data = new PagedList_ts_1.PagedList();
        this.MaxSize = 5;
        this.CurrentPage = 1;
        this.ShowBoundaryLinks = true;
        this.PageSize = 10;
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
        console.log('Page changed to: ' + event.page);
        if (this.CurrentPage != event.page) {
            this.CurrentPage = event.page;
            this.LoadPosts();
        }
    };
    PostsPagedList = __decorate([
        core_1.Component({
            selector: 'posts',
            templateUrl: "/blog/view/postlist/",
            directives: [ng2_bootstrap_1.PAGINATION_DIRECTIVES]
        }),
        __param(0, core_1.Inject(PostService_ts_1.PostService))
    ], PostsPagedList);
    return PostsPagedList;
})();
exports.PostsPagedList = PostsPagedList;
