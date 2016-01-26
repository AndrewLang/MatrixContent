var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require('angular2/core');
var common_1 = require('angular2/common');
var Pagination = (function () {
    function Pagination() {
        this.MaxSize = 5; //Max page item to display
        this.ShowDirectionLinks = true;
        this.ShowBoundaryLinks = true;
        this.AutoHide = false;
        this.Rotate = true;
        this.PreviousText = "Previous";
        this.NextText = "Next";
        this.FirstText = "First";
        this.LastText = "Last";
        this.Pages = [];
    }
    Pagination.prototype.ngOnChanges = function () {
        console.log("on changes");
        console.log(this.Source);
    };
    Pagination.prototype.ngAfterContentInit = function () {
        console.log("After conent init ");
        console.log(this.Source);
    };
    Pagination.prototype.ngAfterContentChecked = function () {
        if (this.Source != null && this.Source.PageCount > 0 && this.Pages.length == 0) {
            console.log("After conent checked ");
            console.log(this.Source);
            this.Pages = this.BuildPages();
            console.log(this.Pages);
        }
    };
    /*
    * build page items
    */
    Pagination.prototype.BuildPages = function () {
        var items = [];
        var source = this.Source;
        var startIndex = 1;
        if (source.IsFirstPage)
            startIndex = 1;
        if (source.IsLastPage)
            startIndex = source.PageCount - this.MaxSize;
        if (startIndex < 1)
            startIndex = 1;
        while (startIndex <= this.MaxSize) {
            items.push({ Label: startIndex, Value: startIndex });
            startIndex++;
        }
        return items;
    };
    __decorate([
        core_1.Input()
    ], Pagination.prototype, "Source", void 0);
    __decorate([
        core_1.Input()
    ], Pagination.prototype, "MaxSize", void 0);
    __decorate([
        //Max page item to display
        core_1.Input()
    ], Pagination.prototype, "ShowDirectionLinks", void 0);
    __decorate([
        core_1.Input()
    ], Pagination.prototype, "ShowBoundaryLinks", void 0);
    __decorate([
        core_1.Input()
    ], Pagination.prototype, "AutoHide", void 0);
    __decorate([
        core_1.Input()
    ], Pagination.prototype, "Rotate", void 0);
    __decorate([
        core_1.Input()
    ], Pagination.prototype, "PreviousText", void 0);
    __decorate([
        core_1.Input()
    ], Pagination.prototype, "NextText", void 0);
    __decorate([
        core_1.Input()
    ], Pagination.prototype, "FirstText", void 0);
    __decorate([
        core_1.Input()
    ], Pagination.prototype, "LastText", void 0);
    Pagination = __decorate([
        core_1.Component({
            selector: 'pagination',
            template: "\n    <nav>\n      <ul class=\"pagination\">\n        <li class=\"page-item\">\n          <a class=\"page-link\" href=\"#\" aria-label=\"Previous\">\n            <span >{{FirstText}}</span>\n          </a>\n        </li>\n        <li class=\"page-item\">\n          <a class=\"page-link\" href=\"#\" aria-label=\"Previous\">\n            <span >{{PreviousText}}</span>\n          </a>\n        </li>\n        <li class=\"page-item\" *ngFor=\"#page of Pages\"><a class=\"page-link\" href=\"#\">{{page.Label}}</a></li>\n\n        <li class=\"page-item\">\n          <a class=\"page-link\" href=\"#\" aria-label=\"Next\">\n            <span >{{NextText}}</span>\n          </a>\n        </li>\n        <li class=\"page-item\">\n          <a class=\"page-link\" href=\"#\" aria-label=\"Next\">\n            <span >{{LastText}}</span>\n          </a>\n        </li>\n      </ul>\n    </nav>\n    ",
            directives: [common_1.CORE_DIRECTIVES]
        })
    ], Pagination);
    return Pagination;
})();
exports.Pagination = Pagination;
