import {Injectable, Component, OnInit} from 'angular2/core';
import {Router, RouteParams, RouteConfig, RouterOutlet} from 'angular2/router';
import {PAGINATION_DIRECTIVES} from 'ng2-bootstrap/ng2-bootstrap';

import {DataService} from '../services/DataService';
import {PostService} from '../services/PostService';
import {PagedList} from '../common/PagedList';
import {Post} from '../models/post';
import {PostListComponent} from './PostListComponent';
import {PaginationDataContext} from '../common/PaginationDataContext';

@Component({
    selector: 'paged-posts',
    templateUrl: "/blog/view/postpagedlist/",
    directives: [PAGINATION_DIRECTIVES, RouterOutlet],
    providers: [PostService, DataService, PaginationDataContext]
})
@RouteConfig([
        { path: '/', name: 'HomePostsPage', component: PostListComponent, useAsDefault: true },
        { path: '/page/:page', name: 'PagedPosts', component: PostListComponent }
])
@Injectable()
export class PostsPagedListComponent implements OnInit {  

    constructor(
        private DataContext:PaginationDataContext,
        private postService: PostService,
        private mRouter: Router) {

    }

    ngOnInit() {        
        this.LoadPosts();
    }

    LoadPosts(): void {
        this.postService.GetPosts(this.DataContext.CurrentPage, this.DataContext.PageSize, response=> {
            this.DataContext.Data = response;
        });
    }
    
    private onPageChanged(event: any): void {
        if (this.DataContext.CurrentPage != event.page) {
            this.DataContext.CurrentPage = event.page;
            //this.LoadPosts();
            this.mRouter.navigate(['PagedPosts', { page: event.page }]);
            //console.log(this.DataContext);
            
        }
    }
}
