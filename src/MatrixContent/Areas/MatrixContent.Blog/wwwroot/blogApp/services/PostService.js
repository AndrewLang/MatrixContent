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
define(["require", "exports", 'angular2/core', './DataService.ts'], function (require, exports, core_1, DataService_ts_1) {
    var PostService = (function () {
        function PostService(dataService) {
            this.dataService = dataService;
        }
        PostService.prototype.GetPosts = function (page, pageSize, callback) {
            try {
                var command = { Name: "Blog.GetPosts", Parameters: { Page: 1, PageSize: 10 } };
                this.dataService.Post("/api/commands", command, function (response) {
                    callback(response.Data);
                });
            }
            catch (ex) {
                console.log(ex);
            }
        };
        PostService = __decorate([
            __param(0, core_1.Inject(DataService_ts_1.DataService))
        ], PostService);
        return PostService;
    })();
    exports.PostService = PostService;
});
