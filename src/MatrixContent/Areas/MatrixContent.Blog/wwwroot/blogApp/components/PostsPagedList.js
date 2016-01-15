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
var Pagination_ts_1 = require('../common/Pagination.ts');
var PostService_ts_1 = require('../services/PostService.ts');
var PagedList_ts_1 = require('../common/PagedList.ts');
var PostsPagedList = (function () {
    function PostsPagedList(postService) {
        var _this = this;
        this.Data = new PagedList_ts_1.PagedList();
        postService.GetPosts(1, 20, function (response) {
            _this.Data = response;
        });
    }
    PostsPagedList = __decorate([
        core_1.Component({
            selector: 'posts',
            templateUrl: "/blog/view/postlist/",
            directives: [Pagination_ts_1.Pagination]
        }),
        __param(0, core_1.Inject(PostService_ts_1.PostService))
    ], PostsPagedList);
    return PostsPagedList;
})();
exports.PostsPagedList = PostsPagedList;
