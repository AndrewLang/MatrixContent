define(["require", "exports"], function (require, exports) {
    var Person = (function () {
        function Person(name) {
            this.Name = name;
        }
        return Person;
    })();
    exports.Person = Person;
});
