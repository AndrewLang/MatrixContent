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
var http_1 = require('angular2/http');
require('rxjs/Rx');
var ErrorHandlingService_ts_1 = require('./ErrorHandlingService.ts');
var DataService = (function () {
    function DataService(http, errorHandlingService) {
        this.http = http;
        this.errorHandlingService = errorHandlingService;
        this.headers = new http_1.Headers();
        this.headers.append('Content-Type', 'application/json');
    }
    // Post
    DataService.prototype.Post = function (url, data, callback) {
        var _this = this;
        var body = JSON.stringify(data);
        this.http.post(url, body, { headers: this.headers })
            .map(function (response) {
            callback(response.json());
        })
            .subscribe(function (response) { }, function (error) { _this.errorHandlingService.HandleError(error); });
    };
    DataService = __decorate([
        __param(0, core_1.Inject(http_1.Http)),
        __param(1, core_1.Inject(ErrorHandlingService_ts_1.ErrorHandlingService))
    ], DataService);
    return DataService;
})();
exports.DataService = DataService;
