
/*
 * Angular 2 decorators and services
 */
import {Component} from 'angular2/core';
import {RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS} from 'angular2/router';

import {ErrorHandlingService} from '../services/ErrorHandlingService';
import {DataService} from '../services/DataService';
import {PostService} from '../services/PostService';
import {PostsPagedListComponent} from '../components/PostsPagedListComponent';
import {PostListComponent} from './PostListComponent';


@Component({
    selector: 'blog',
    templateUrl: "/blog/view/bloghome/",
    directives: [PostsPagedListComponent, ROUTER_DIRECTIVES],
    providers: [DataService, PostService, ErrorHandlingService]
})
@RouteConfig([
    { path: '/list/...', name: 'DefaultPagedPosts', useAsDefault: true, component: PostsPagedListComponent }
    
])
export class BlogComponent { }

