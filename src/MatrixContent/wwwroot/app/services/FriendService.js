define(["require", "exports", '../models/Person.ts'], function (require, exports, Person_ts_1) {
    var FriendService = (function () {
        function FriendService() {
            this.Persons = [
                new Person_ts_1.Person("Arav"),
                new Person_ts_1.Person("Martin"),
                new Person_ts_1.Person("Kai"),
                new Person_ts_1.Person("Andrew")
            ];
        }
        return FriendService;
    })();
    exports.FriendService = FriendService;
});
