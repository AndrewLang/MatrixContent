var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require('angular2/core');
var PostService = (function () {
    function PostService(dataService) {
        this.dataService = dataService;
    }
    PostService.prototype.GetPosts = function (page, pageSize, callback) {
        try {
            var command = { Name: "Blog.GetPosts", Parameters: { Page: page, PageSize: 10 } };
            this.dataService.Post("/api/commands", command, function (response) {
                callback(response.Data);
            });
        }
        catch (ex) {
            console.log(ex);
        }
    };
    PostService = __decorate([
        core_1.Injectable()
    ], PostService);
    return PostService;
})();
exports.PostService = PostService;
