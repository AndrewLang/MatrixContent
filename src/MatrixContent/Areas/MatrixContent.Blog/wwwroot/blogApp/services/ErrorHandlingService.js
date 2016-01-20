define(["require", "exports"], function (require, exports) {
    // Error handling service
    var ErrorHandlingService = (function () {
        function ErrorHandlingService() {
        }
        ErrorHandlingService.prototype.HandleError = function (error) {
            console.log(error);
        };
        return ErrorHandlingService;
    })();
    exports.ErrorHandlingService = ErrorHandlingService;
});
