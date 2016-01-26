var browser_1 = require('angular2/platform/browser');
var router_1 = require('angular2/router');
var http_1 = require('angular2/http');
var BlogComponent_1 = require('./components/BlogComponent');
browser_1.bootstrap(BlogComponent_1.BlogComponent, [router_1.ROUTER_PROVIDERS, http_1.HTTP_PROVIDERS])
    .then(function (success) { return console.log('Blog App Bootstrapped!'); }, function (error) { return console.log(error); });
