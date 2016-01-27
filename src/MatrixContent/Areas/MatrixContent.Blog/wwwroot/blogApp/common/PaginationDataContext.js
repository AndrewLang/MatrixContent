var PagedList_1 = require('./PagedList');
var PaginationDataContext = (function () {
    function PaginationDataContext() {
        this.Data = new PagedList_1.PagedList();
        this.MaxSize = 5;
        this.CurrentPage = 1;
        this.ShowBoundaryLinks = true;
        this.PageSize = 10;
    }
    return PaginationDataContext;
})();
exports.PaginationDataContext = PaginationDataContext;
