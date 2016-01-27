import {PagedList}                      from './PagedList';
import {Post}                           from '../models/post';

export class PaginationDataContext {
    Data: PagedList<Post> = new PagedList<Post>();
    MaxSize: number = 5;
    CurrentPage: number = 1;
    ShowBoundaryLinks: boolean = true;
    PageSize: number = 10;
}