var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require('angular2/core');
var PagedList_1 = require('../common/PagedList');
var PostListComponent = (function () {
    function PostListComponent(postService, mRouter, mRouteParams) {
        this.postService = postService;
        this.mRouter = mRouter;
        this.mRouteParams = mRouteParams;
        this.DataLoaded = new core_1.EventEmitter();
        this.Data = new PagedList_1.PagedList();
        this.MaxSize = 5;
        this.CurrentPage = 1;
        this.ShowBoundaryLinks = true;
        this.PageSize = 10;
        console.log("constructor of posts paged list");
    }
    PostListComponent.prototype.ngOnInit = function () {
        var page = this.mRouteParams.get('page');
        if (page)
            this.CurrentPage = page;
        console.log("OnInit load page " + page);
        this.LoadPosts();
    };
    PostListComponent.prototype.LoadPosts = function () {
        var _this = this;
        console.log("Load posts in post list component: page " + this.CurrentPage);
        this.postService.GetPosts(this.CurrentPage, this.PageSize, function (response) {
            _this.Data = response;
            console.log(_this.Data);
            _this.DataLoaded.emit(_this.Data);
        });
    };
    __decorate([
        core_1.Output()
    ], PostListComponent.prototype, "DataLoaded", void 0);
    PostListComponent = __decorate([
        core_1.Component({
            selector: 'post-list',
            templateUrl: '/blog/view/postlist'
        })
    ], PostListComponent);
    return PostListComponent;
})();
exports.PostListComponent = PostListComponent;
