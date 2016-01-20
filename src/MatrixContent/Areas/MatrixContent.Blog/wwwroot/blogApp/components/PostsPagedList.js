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
define(["require", "exports", 'angular2/core', 'ng2-bootstrap/ng2-bootstrap', '../services/PostService.ts', '../common/PagedList.ts'], function (require, exports, core_1, ng2_bootstrap_1, PostService_ts_1, PagedList_ts_1) {
    var PostsPagedList = (function () {
        function PostsPagedList(postService) {
            var _this = this;
            this.Data = new PagedList_ts_1.PagedList();
            this.MaxSize = 5;
            this.ShowBoundaryLinks = true;
            this.postService = postService;
            postService.GetPosts(1, 10, function (response) {
                _this.Data = response;
                console.log(_this.Data);
            });
        }
        PostsPagedList.prototype.OnPageChanged = function (event) {
            console.log('Page changed to: ' + event.page);
            console.log('Number items per page: ' + event.itemsPerPage);
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
});
