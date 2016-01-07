import {Inject} from 'angular2/core';


import {Post} from '../models/Post.ts';
import {DataService} from './DataService.ts'

export class PostService {

    dataService: DataService;

    constructor( @Inject(DataService) dataService: DataService) {       
        this.dataService = dataService;
    }

    GetPosts(page: number, pageSize: number, callback: (response: any) => {}): void {
        console.log("Get posts: Page " + page + " PageSize" + pageSize);
        try {
            var command = { Name: "Blog.GetPosts", Parameters: { Page: 1, PageSize: 10 } };

            this.dataService.Post("/api/commands", command, response=> {
                callback(response.Data);
            });
        }
        catch (ex)
        {
            console.log(ex);
        }
    }

}
