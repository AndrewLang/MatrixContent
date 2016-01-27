import {Injectable, Component, OnInit} from 'angular2/core';
import {Router, RouteParams} from 'angular2/router';
import {PAGINATION_DIRECTIVES} from 'ng2-bootstrap/ng2-bootstrap';

import {DataService} from '../services/DataService';
import {PostService} from '../services/PostService.ts';
import {PagedList} from '../common/PagedList.ts';

@Component({
    selector: 'posts',
    templateUrl: "/blog/view/postlist/",
    directives: [PAGINATION_DIRECTIVES],
    providers: [PostService, DataService]
})
@Injectable()
export class PostsPagedList implements OnInit {
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

    private pageChanged(event: any): void {

        if (this.CurrentPage != event.page) {
            console.log('Current Page ' + this.CurrentPage + ' changed to: ' + event.page);
            //    this.CurrentPage = event.page;
            //    this.LoadPosts();
            this.mRouter.navigate(['PagedPosts', { page: event.page }]);
        }
    }
}