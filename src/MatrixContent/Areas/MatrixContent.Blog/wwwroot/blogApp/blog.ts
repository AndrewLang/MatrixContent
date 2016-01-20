
/*
 * Angular 2 decorators and services
 */
import {bootstrap}       from 'angular2/platform/browser'
import {FORM_PROVIDERS, ELEMENT_PROBE_PROVIDERS, Directive, Attribute, Component, View, ElementRef, EventEmitter, Input, Output} from 'angular2/core';
import {NgForm, NgIf}    from 'angular2/common';
import {Http, Response, Headers, HTTP_PROVIDERS, BaseRequestOptions} from 'angular2/http';
import 'rxjs/Rx';

/*
 * Angular Directives
 */
import {CORE_DIRECTIVES, FORM_DIRECTIVES} from 'angular2/core';

import {PostService} from './services/PostService.ts';
import {ErrorHandlingService} from './services/ErrorHandlingService.ts';
import {DataService} from './services/DataService.ts';
import {PostsPagedList} from './components/PostsPagedList.ts';

@Component({
    selector: 'blog', 
    templateUrl: "/blog/view/bloghome/",       
    directives: [PostsPagedList]
})
export class BlogComponent {
    
    constructor() {
        
    }
}


bootstrap(BlogComponent, [
    HTTP_PROVIDERS,
    ErrorHandlingService,
    DataService,
    PostService    
]).then(
    success => console.log('Blog App Bootstrapped!'),
    error => console.log(error));