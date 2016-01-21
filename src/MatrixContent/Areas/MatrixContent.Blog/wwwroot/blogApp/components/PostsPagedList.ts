import {Inject, Component, View} from 'angular2/core';
import {PAGINATION_DIRECTIVES} from 'ng2-bootstrap/ng2-bootstrap';

import {PostService} from '../services/PostService.ts';
import {PagedList} from '../common/PagedList.ts';

@Component({
    selector: 'posts',
    templateUrl: "/blog/view/postlist/",
    directives: [PAGINATION_DIRECTIVES]
})
export class PostsPagedList {

    Data: PagedList<Post> = new PagedList<Post>();
    postService: PostService;
    MaxSize: number = 5;
    CurrentPage: number = 1;
    ShowBoundaryLinks: boolean = true;
    PageSize: number = 10;

    constructor( @Inject(PostService) postService: PostService) {
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
        console.log('Page changed to: ' + event.page);
        if (this.CurrentPage != event.page) {
            this.CurrentPage = event.page;
            this.LoadPosts();
        }
    }
}