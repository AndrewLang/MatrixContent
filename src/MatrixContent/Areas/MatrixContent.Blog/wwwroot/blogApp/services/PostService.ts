import {Injectable} from 'angular2/core';

import {Post} from '../models/Post';
import {DataService} from './DataService'

@Injectable()
export class PostService {

    dataService: DataService;

    constructor( dataService: DataService) {
        this.dataService = dataService;
    }

    GetPosts(page: number, pageSize: number, callback: (response: any) => {}): void {
        try {
            var command = { Name: "Blog.GetPosts", Parameters: { Page: page, PageSize: 10 } };

            this.dataService.Post("/api/commands", command, response=> {
                callback(response.Data);
            });
        }
        catch (ex) {
            console.log(ex);
        }
    }

}
