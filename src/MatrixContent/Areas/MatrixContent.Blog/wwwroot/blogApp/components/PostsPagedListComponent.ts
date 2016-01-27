import {Injectable, Component, OnInit} from 'angular2/core';
import {Router, RouteParams, RouteConfig, RouterOutlet} from 'angular2/router';
import {PAGINATION_DIRECTIVES} from 'ng2-bootstrap/ng2-bootstrap';

import {DataService} from '../services/DataService';
import {PostService} from '../services/PostService';
import {PagedList} from '../common/PagedList';
import {Post} from '../models/post';
import {PostListComponent} from './PostListComponent';

@Component({
    selector: 'paged-posts',
    templateUrl: "/blog/view/postpagedlist/",
    directives: [PAGINATION_DIRECTIVES, RouterOutlet],
    providers: [PostService, DataService]
})
@RouteConfig([
        { path: '/', name: 'HomePostsPage', component: PostListComponent, useAsDefault: true },
        { path: '/page/:page', name: 'PagedPosts', component: PostListComponent }
])
@Injectable()
export class PostsPagedListComponent implements OnInit {
    Data: PagedList<Post> = new PagedList<Post>();
    MaxSize: number = 5;
    CurrentPage: number = 1;
    ShowBoundaryLinks: boolean = true;
    PageSize: number = 10;

    constructor(private postService: PostService,
        private mRouter: Router,
        private mRouteParams: RouteParams) {

        console.log("constructor of posts paged list");
    }

    ngOnInit() {
        let page = this.mRouteParams.get('page');
        if (page)
            this.CurrentPage = page;
        console.log("OnInit load page " + page);
        this.LoadPosts();
    }

    LoadPosts(): void {
        console.log("Load posts: page " + this.CurrentPage);
        this.postService.GetPosts(this.CurrentPage, this.PageSize, response=> {
            this.Data = response;
            console.log(this.Data);
        });
    }
    private dataLoaded(event: any): void {
        console.log("data loaded");
    }
    private onPageChanged(event: any): void {
        console.log("Enter page changed " + event.page);
        if (this.CurrentPage != event.page) {
            console.log('Current Page ' + this.CurrentPage + ' changed to: ' + event.page);
            this.CurrentPage = event.page;
            //this.LoadPosts();
            this.mRouter.navigate(['PagedPosts', { page: event.page }]);
        }
    }
}
