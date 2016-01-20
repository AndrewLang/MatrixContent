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
    ShowBoundaryLinks: boolean=true;

    constructor( @Inject(PostService) postService: PostService) {
        this.postService = postService;

        postService.GetPosts(1, 10, response=> {
            this.Data = response;
            console.log(this.Data);
        });
    }

    OnPageChanged(event: any): void {
        console.log('Page changed to: ' + event.page);
        console.log('Number items per page: ' + event.itemsPerPage);
    }
}