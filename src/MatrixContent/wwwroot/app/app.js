var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") return Reflect.decorate(decorators, target, key, desc);
    switch (arguments.length) {
        case 2: return decorators.reduceRight(function(o, d) { return (d && d(o)) || o; }, target);
        case 3: return decorators.reduceRight(function(o, d) { return (d && d(target, key)), void 0; }, void 0);
        case 4: return decorators.reduceRight(function(o, d) { return (d && d(target, key, o)) || o; }, desc);
    }
};
define(["require", "exports", 'angular2/platform/browser', 'angular2/core', 'angular2/http', './models/Person.ts', './services/FriendService.ts'], function (require, exports, browser_1, core_1, http_1, Person_ts_1, FriendService_ts_1) {
    var AppComponent = (function () {
        function AppComponent(friendService, http) {
            console.log("Start app component.");
            this.title = "My first Angular 2 App";
            //var friendService = new FriendService();
            this.Persons = friendService.Persons;
        }
        AppComponent.prototype.addFriend = function (newFriend) {
            if (newFriend.value) {
                var friend = new Person_ts_1.Person(newFriend.value);
                this.Persons.push(friend);
                newFriend.value = null;
            }
        };
        AppComponent.prototype.removeFriend = function (friend) {
            if (friend) {
                var index = this.Persons.indexOf(friend);
                if (index != undefined) {
                    this.Persons.splice(index, 1);
                }
            }
        };
        AppComponent = __decorate([
            core_1.Component({
                selector: 'my-app'
            }),
            core_1.View({
                templateUrl: "/view/friendeditor/",
            })
        ], AppComponent);
        return AppComponent;
    })();
    browser_1.bootstrap(AppComponent, [
        FriendService_ts_1.FriendService,
        http_1.HTTP_PROVIDERS
    ]).then(function (success) { return console.log('App Bootstrapped!'); }, function (error) { return console.log(error); });
});
