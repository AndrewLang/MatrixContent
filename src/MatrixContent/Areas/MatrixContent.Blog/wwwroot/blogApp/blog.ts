
/*
 * Angular 2 decorators and services
 */
import {bootstrap}       from 'angular2/platform/browser'
import {FORM_PROVIDERS, ELEMENT_PROBE_PROVIDERS, Directive, Attribute, Component, View, ElementRef, EventEmitter} from 'angular2/core';
import {NgForm, NgIf}    from 'angular2/common';
import {Http, Response, Headers,HTTP_PROVIDERS, BaseRequestOptions} from 'angular2/http';
import 'rxjs/Rx';
/*
 * Angular Directives
 */
import {CORE_DIRECTIVES, FORM_DIRECTIVES} from 'angular2/core';

import {Post} from './models/Post.ts';
import {PostService} from './services/PostService.ts';
import {ErrorHandlingService} from './services/ErrorHandlingService.ts';
import {DataService} from './services/DataService.ts';

@Component({
    selector: 'posts'
})
@View({
    templateUrl: "/blog/view/postlist/",      // Call ASP MVC to retrieve the partial view
    //directives: [CORE_DIRECTIVES]           // Call Core directives and custom directives
})
class AppComponent {
    title: string;
    Posts: Array<Post>;
    newName: string;

    constructor(postService: PostService) {
        this.title = "Blog app ";
        this.Posts = [];
        postService.GetPosts(1, 20, response=> {
            this.Posts = response.Items;
            console.log(response);
        });
    }
}


bootstrap(AppComponent, [
    HTTP_PROVIDERS,
    PostService,
    ErrorHandlingService,
    DataService,
    // These are dependencies of our App

    //FORM_PROVIDERS,
    //ROUTER_PROVIDERS,
    //ELEMENT_PROBE_PROVIDERS
]).then(
    success => console.log('Blog App Bootstrapped!'),
    error => console.log(error));