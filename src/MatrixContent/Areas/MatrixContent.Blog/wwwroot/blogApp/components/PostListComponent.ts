import {Injectable, Component, OnInit, Output, EventEmitter} from 'angular2/core';
import {Router, RouteParams} from 'angular2/router';
import {PAGINATION_DIRECTIVES} from 'ng2-bootstrap/ng2-bootstrap';

import {DataService} from '../services/DataService';
import {PostService} from '../services/PostService';
import {PagedList} from '../common/PagedList';
import {Post} from '../models/post';
import {PaginationDataContext} from '../common/PaginationDataContext';

@Component({
    selector: 'post-list',
    templateUrl: '/blog/view/postlist'
})
export class PostListComponent implements OnInit {

    constructor(
        private DataContext: PaginationDataContext,
        private postService: PostService,
        private mRouteParams: RouteParams) {

    }

    ngOnInit() {
        let page = this.mRouteParams.get('page');
        if (page) {
            this.DataContext.CurrentPage = page;
            this.LoadPosts();
        } 
    }

    LoadPosts(): void {
        this.postService.GetPosts(this.DataContext.CurrentPage, this.DataContext.PageSize, response=> {
            this.DataContext.Data = response;
        });
    }
}