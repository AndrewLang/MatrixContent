var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") return Reflect.decorate(decorators, target, key, desc);
    switch (arguments.length) {
        case 2: return decorators.reduceRight(function(o, d) { return (d && d(o)) || o; }, target);
        case 3: return decorators.reduceRight(function(o, d) { return (d && d(target, key)), void 0; }, void 0);
        case 4: return decorators.reduceRight(function(o, d) { return (d && d(target, key, o)) || o; }, desc);
    }
};
define(["require", "exports", 'angular2/core', 'angular2/common', "./pagination-service"], function (require, exports, core_1, common_1, pagination_service_1) {
    var DEFAULT_TEMPLATE = "\n    <ul class=\"pagination\" role=\"navigation\" aria-label=\"Pagination\" *ngIf=\"displayDefaultTemplate()\">\n\n        <li class=\"pagination-previous\" [class.disabled]=\"isFirstPage()\" *ngIf=\"directionLinks\">\n            <a *ngIf=\"1 < getCurrent()\" (click)=\"setCurrent(getCurrent() - 1)\" aria-label=\"Next page\">\n                Previous <span class=\"show-for-sr\">page</span>\n            </a>\n            <span *ngIf=\"isFirstPage()\">Previous <span class=\"show-for-sr\">page</span></span>\n        </li>\n\n        <li [class.current]=\"getCurrent() === page.value\" *ngFor=\"#page of pages\">\n            <a (click)=\"setCurrent(page.value)\" *ngIf=\"getCurrent() !== page.value\">\n                <span class=\"show-for-sr\">Page</span>\n                <span>{{ page.label }}</span>\n            </a>\n            <div *ngIf=\"getCurrent() === page.value\">\n                <span class=\"show-for-sr\">You're on page</span>\n                <span>{{ page.label }}</span>\n            </div>\n        </li>\n\n        <li class=\"pagination-next\" [class.disabled]=\"isLastPage()\" *ngIf=\"directionLinks\">\n            <a *ngIf=\"!isLastPage()\" (click)=\"setCurrent(getCurrent() + 1)\" aria-label=\"Next page\">\n                Next <span class=\"show-for-sr\">page</span>\n            </a>\n            <span *ngIf=\"isLastPage()\">Next <span class=\"show-for-sr\">page</span></span>\n        </li>\n\n    </ul>\n    ";
    function getTemplate() {
        return pagination_service_1.PaginationService.template || DEFAULT_TEMPLATE;
    }
    var PaginationControlsCmp = (function () {
        function PaginationControlsCmp(service, viewContainer) {
            var _this = this;
            this.service = service;
            this.viewContainer = viewContainer;
            this.maxSize = 7;
            this.directionLinks = true;
            this.autoHide = false;
            this.pageChange = new core_1.EventEmitter();
            this.pages = [];
            this.changeSub = this.service.change
                .subscribe(function (id) {
                if (_this.id === id) {
                    _this.updatePages();
                }
            });
        }
        PaginationControlsCmp.prototype.updatePages = function () {
            var inst = this.service.getInstance(this.id);
            this.pages = this.createPageArray(inst.currentPage, inst.itemsPerPage, inst.totalItems, this.maxSize);
        };
        PaginationControlsCmp.prototype.displayDefaultTemplate = function () {
            if (this.customTemplate !== null) {
                return false;
            }
            return !this.autoHide || 1 < this.pages.length;
        };
        /**
         * Set up the subscription to the PaginationService.change observable.
         */
        PaginationControlsCmp.prototype.ngOnInit = function () {
            if (this.id === undefined) {
                this.id = this.service.defaultId;
            }
        };
        PaginationControlsCmp.prototype.ngAfterContentInit = function () {
            if (this.customTemplate !== null) {
                this.viewContainer.createEmbeddedView(this.customTemplate);
            }
        };
        PaginationControlsCmp.prototype.ngOnChanges = function () {
            this.updatePages();
        };
        PaginationControlsCmp.prototype.ngOnDestroy = function () {
            // TODO: do i need to manually clean these up??? What's the difference between unsubscribe() and remove()
            this.changeSub.unsubscribe();
        };
        /**
         * Set the current page number.
         */
        PaginationControlsCmp.prototype.setCurrent = function (page) {
            this.service.setCurrentPage(this.id, page);
            this.pageChange.emit(this.service.getCurrentPage(this.id));
        };
        /**
         * Get the current page number.
         */
        PaginationControlsCmp.prototype.getCurrent = function () {
            return this.service.getCurrentPage(this.id);
        };
        PaginationControlsCmp.prototype.isFirstPage = function () {
            return this.getCurrent() === 1;
        };
        PaginationControlsCmp.prototype.isLastPage = function () {
            var inst = this.service.getInstance(this.id);
            return Math.ceil(inst.totalItems / inst.itemsPerPage) === inst.currentPage;
        };
        /**
         * Returns an array of IPage objects to use in the pagination controls.
         */
        PaginationControlsCmp.prototype.createPageArray = function (currentPage, itemsPerPage, totalItems, paginationRange) {
            // paginationRange could be a string if passed from attribute, so cast to number.
            paginationRange = +paginationRange;
            var pages = [];
            var totalPages = Math.ceil(totalItems / itemsPerPage);
            var halfWay = Math.ceil(paginationRange / 2);
            var isStart = currentPage <= halfWay;
            var isEnd = totalPages - halfWay < currentPage;
            var isMiddle = !isStart && !isEnd;
            var ellipsesNeeded = paginationRange < totalPages;
            var i = 1;
            while (i <= totalPages && i <= paginationRange) {
                var label = void 0;
                var pageNumber = this.calculatePageNumber(i, currentPage, paginationRange, totalPages);
                var openingEllipsesNeeded = (i === 2 && (isMiddle || isEnd));
                var closingEllipsesNeeded = (i === paginationRange - 1 && (isMiddle || isStart));
                if (ellipsesNeeded && (openingEllipsesNeeded || closingEllipsesNeeded)) {
                    label = '...';
                }
                else {
                    label = pageNumber;
                }
                pages.push({
                    label: label,
                    value: pageNumber
                });
                i++;
            }
            return pages;
        };
        /**
         * Given the position in the sequence of pagination links [i],
         * figure out what page number corresponds to that position.
         */
        PaginationControlsCmp.prototype.calculatePageNumber = function (i, currentPage, paginationRange, totalPages) {
            var halfWay = Math.ceil(paginationRange / 2);
            if (i === paginationRange) {
                return totalPages;
            }
            else if (i === 1) {
                return i;
            }
            else if (paginationRange < totalPages) {
                if (totalPages - halfWay < currentPage) {
                    return totalPages - paginationRange + i;
                }
                else if (halfWay < currentPage) {
                    return currentPage - halfWay + i;
                }
                else {
                    return i;
                }
            }
            else {
                return i;
            }
        };
        __decorate([
            core_1.Input()
        ], PaginationControlsCmp.prototype, "id");
        __decorate([
            core_1.Input()
        ], PaginationControlsCmp.prototype, "maxSize");
        __decorate([
            core_1.Input()
        ], PaginationControlsCmp.prototype, "directionLinks");
        __decorate([
            core_1.Input()
        ], PaginationControlsCmp.prototype, "autoHide");
        __decorate([
            core_1.Output()
        ], PaginationControlsCmp.prototype, "pageChange");
        __decorate([
            core_1.ContentChild(core_1.TemplateRef)
        ], PaginationControlsCmp.prototype, "customTemplate");
        PaginationControlsCmp = __decorate([
            core_1.Component({
                selector: 'pagination-controls',
                template: getTemplate(),
                directives: [common_1.CORE_DIRECTIVES]
            })
        ], PaginationControlsCmp);
        return PaginationControlsCmp;
    })();
    exports.PaginationControlsCmp = PaginationControlsCmp;
});
