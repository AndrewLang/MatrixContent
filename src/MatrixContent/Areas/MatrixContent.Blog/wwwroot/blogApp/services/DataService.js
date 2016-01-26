var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require('angular2/core');
var http_1 = require('angular2/http');
require('rxjs/Rx');
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
        core_1.Injectable()
    ], DataService);
    return DataService;
})();
exports.DataService = DataService;
