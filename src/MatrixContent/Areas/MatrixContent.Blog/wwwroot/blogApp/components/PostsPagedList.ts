import {Inject, Component, View} from 'angular2/core';
import {Pagination} from '../common/Pagination.ts';
import {PostService} from '../services/PostService.ts';
import {PagedList} from '../common/PagedList.ts';

@Component({
    selector: 'posts',
    templateUrl: "/blog/view/postlist/",
    directives: [Pagination]
})
export class PostsPagedList {

    Data: PagedList<Post> = new PagedList<Post>();

    constructor( @Inject(PostService) postService: PostService) {
        postService.GetPosts(1, 20, response=> {
            this.Data = response;
        });
    }
}