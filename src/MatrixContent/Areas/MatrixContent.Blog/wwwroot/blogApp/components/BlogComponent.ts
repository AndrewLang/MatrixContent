
/*
 * Angular 2 decorators and services
 */
import {Component} from 'angular2/core';
import {RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS} from 'angular2/router';

import {ErrorHandlingService} from '../services/ErrorHandlingService';
import {DataService} from '../services/DataService';
import {PostService} from '../services/PostService';
import {PostsPagedList} from '../components/PostsPagedList';
import {PagedPostComponent} from '../components/PagedPostComponent';

@Component({
    selector: 'blog',
    templateUrl: "/blog/view/bloghome/",
    directives: [PostsPagedList, ROUTER_DIRECTIVES],
    providers: [DataService, PostService, ErrorHandlingService]
})
@RouteConfig([
    { path: '/', name: 'DefaultPagedPosts', useAsDefault: true, component: PostsPagedList },
    { path: '/page/:page', name: 'PagedPosts', component: PostsPagedList }
])
export class BlogComponent { }

