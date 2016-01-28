var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require('angular2/core');
var PostListComponent = (function () {
    function PostListComponent(DataContext, postService, mRouteParams) {
        this.DataContext = DataContext;
        this.postService = postService;
        this.mRouteParams = mRouteParams;
    }
    PostListComponent.prototype.ngOnInit = function () {
        var page = this.mRouteParams.get('page');
        if (page) {
            this.DataContext.CurrentPage = page;
            this.LoadPosts();
        }
    };
    PostListComponent.prototype.LoadPosts = function () {
        var _this = this;
        this.postService.GetPosts(this.DataContext.CurrentPage, this.DataContext.PageSize, function (response) {
            _this.DataContext.Data = response;
        });
    };
    PostListComponent = __decorate([
        core_1.Component({
            selector: 'post-list',
            templateUrl: '/blog/view/postlist'
        })
    ], PostListComponent);
    return PostListComponent;
})();
exports.PostListComponent = PostListComponent;
