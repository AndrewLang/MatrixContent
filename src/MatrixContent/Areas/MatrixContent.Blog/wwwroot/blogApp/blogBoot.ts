import {bootstrap}          from 'angular2/platform/browser';
import {provide}            from 'angular2/core';
import {ROUTER_PROVIDERS, LocationStrategy, HashLocationStrategy} from 'angular2/router';
import {HTTP_PROVIDERS}     from 'angular2/http';

import {BlogComponent}      from './components/BlogComponent';

bootstrap(BlogComponent, [ROUTER_PROVIDERS, HTTP_PROVIDERS])
    .then(
        success => console.log('Blog App Bootstrapped!'),
        error => console.log(error)
);