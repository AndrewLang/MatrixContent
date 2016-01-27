import {Injectable, Component, OnInit, Input} from 'angular2/core';
import {Router, RouteParams} from 'angular2/router';
import {PAGINATION_DIRECTIVES} from 'ng2-bootstrap/ng2-bootstrap';

import {DataService} from '../services/DataService';
import {PostService} from '../services/PostService';
import {PagedList} from '../common/PagedList';
import {Post} from '../models/post';
import {PaginationDataContext}          from '../common/PaginationDataContext'

@Component({
    selector: 'posts-pagination',
    templateUrl: '/blog/view/postpagination/',
    directives: [PAGINATION_DIRECTIVES],
    providers: [PostService, DataService]
})
@Injectable()
export class PostPaginationComponent {
       

    constructor(private DataContext: PaginationDataContext,
        private mRouter: Router,
        private mRouteParams: RouteParams)
    {
        console.log("constructor of post pagination component");
    }

    private onPageChanged(event: any): void {
        console.log("Enter page changed " + event.page);
        if (this.DataContext.CurrentPage != event.page) {
            console.log('Changing current Page ' + this.DataContext.CurrentPage + ' to: ' + event.page);
            this.DataContext.CurrentPage = event.page;
            //this.LoadPosts();
            this.mRouter.navigate(['PagedPosts', { page: event.page }]);
        }
    }
}