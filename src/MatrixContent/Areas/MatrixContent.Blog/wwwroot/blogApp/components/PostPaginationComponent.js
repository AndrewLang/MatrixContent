var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require('angular2/core');
var ng2_bootstrap_1 = require('ng2-bootstrap/ng2-bootstrap');
var DataService_1 = require('../services/DataService');
var PostService_1 = require('../services/PostService');
var PostPaginationComponent = (function () {
    function PostPaginationComponent(DataContext, mRouter, mRouteParams) {
        this.DataContext = DataContext;
        this.mRouter = mRouter;
        this.mRouteParams = mRouteParams;
    }
    PostPaginationComponent.prototype.onPageChanged = function (event) {
        console.log("Enter page changed " + event.page);
        if (this.DataContext.CurrentPage != event.page) {
            console.log('Changing current Page ' + this.DataContext.CurrentPage + ' to: ' + event.page);
            this.DataContext.CurrentPage = event.page;
            //this.LoadPosts();
            this.mRouter.navigate(['PagedPosts', { page: event.page }]);
        }
    };
    PostPaginationComponent = __decorate([
        core_1.Component({
            selector: 'posts-pagination',
            templateUrl: '/blog/view/postpagination/',
            directives: [ng2_bootstrap_1.PAGINATION_DIRECTIVES],
            providers: [PostService_1.PostService, DataService_1.DataService]
        }),
        core_1.Injectable()
    ], PostPaginationComponent);
    return PostPaginationComponent;
})();
exports.PostPaginationComponent = PostPaginationComponent;
