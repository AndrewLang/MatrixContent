var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") return Reflect.decorate(decorators, target, key, desc);
    switch (arguments.length) {
        case 2: return decorators.reduceRight(function(o, d) { return (d && d(o)) || o; }, target);
        case 3: return decorators.reduceRight(function(o, d) { return (d && d(target, key)), void 0; }, void 0);
        case 4: return decorators.reduceRight(function(o, d) { return (d && d(target, key, o)) || o; }, desc);
    }
};
define(["require", "exports", 'angular2/core'], function (require, exports, core_1) {
    var TabHeading = (function () {
        function TabHeading(templateRef, tab) {
            this.templateRef = templateRef;
            tab.headingRef = templateRef;
        }
        TabHeading = __decorate([
            core_1.Directive({ selector: '[tab-heading]' })
        ], TabHeading);
        return TabHeading;
    })();
    exports.TabHeading = TabHeading;
});