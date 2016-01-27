import {Inject, Injectable, Component} from 'angular2/core';
import {Router, RouteParams} from 'angular2/router';
import {PAGINATION_DIRECTIVES} from 'ng2-bootstrap/ng2-bootstrap';

import {DataService} from '../services/DataService';
import {PostService} from '../services/PostService';
import {PagedList} from '../common/PagedList';
import{ Post} from '../models/post';

@Component({
    //selector: 'posts',
    templateUrl: "/blog/view/postlist/",
    directives: [PAGINATION_DIRECTIVES],
    providers: [PostService, DataService]
})
@Injectable()
export class PostsPagedListComponent {

    Data: PagedList<Post> = new PagedList<Post>();
    postService: PostService;
    MaxSize: number = 5;
    CurrentPage: number = 1;
    ShowBoundaryLinks: boolean = true;
    PageSize: number = 10;

    constructor(postService: PostService, private mRouter: Router) {
        console.log("constructor of posts paged list");
        this.postService = postService;

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
            console.log('Page changed to: ' + event.page);
            //    this.CurrentPage = event.page;
            //    this.LoadPosts();
            this.mRouter.navigate(['PagedPosts', { page: event.page }]);
        }
    }
}