import {Component, View, Input, Output} from 'angular2/core';
import {CORE_DIRECTIVES} from 'angular2/common'
import {PagedList} from './PagedList.ts'


export interface IPageItem {
    Label: string;
    Value: any;
}

@Component({
    selector: 'pagination',
    template: `
    <nav>
      <ul class="pagination">
        <li class="page-item">
          <a class="page-link" href="#" aria-label="Previous">
            <span >{{FirstText}}</span>
          </a>
        </li>
        <li class="page-item">
          <a class="page-link" href="#" aria-label="Previous">
            <span >{{PreviousText}}</span>
          </a>
        </li>
        <li class="page-item" *ngFor="#page of Pages"><a class="page-link" href="#">{{page.Label}}</a></li>

        <li class="page-item">
          <a class="page-link" href="#" aria-label="Next">
            <span >{{NextText}}</span>
          </a>
        </li>
        <li class="page-item">
          <a class="page-link" href="#" aria-label="Next">
            <span >{{LastText}}</span>
          </a>
        </li>
      </ul>
    </nav>
    `,
    directives: [CORE_DIRECTIVES]
})
export class Pagination {

    @Input() Source: PagedList;
    @Input() MaxSize: number = 5;                   //Max page item to display
    @Input() ShowDirectionLinks: boolean = true;
    @Input() ShowBoundaryLinks: boolean = true;
    @Input() AutoHide: boolean = false;
    @Input() Rotate: boolean = true;
    @Input() PreviousText: string = "Previous";
    @Input() NextText: string = "Next";
    @Input() FirstText: string = "First";
    @Input() LastText: string = "Last";
    

    Pages: IPageItem[] = [];

    constructor() {

    }

    ngOnChanges() {
        console.log("on changes");
        console.log(this.Source);
    }

    ngAfterContentInit() {
        console.log("After conent init ");
        console.log(this.Source);
    }
    
    ngAfterContentChecked() {
        if (this.Source != null && this.Source.PageCount > 0 && this.Pages.length == 0) {
            console.log("After conent checked ");
            console.log(this.Source);

            this.Pages = this.BuildPages();

            console.log(this.Pages);
        }
    }
    /*
    * build page items
    */
    BuildPages(): IPageItem[] {
        let items = [];
        let source = this.Source;
        let startIndex = 1;

        if (source.IsFirstPage)
            startIndex = 1;

        if (source.IsLastPage)
            startIndex = source.PageCount - this.MaxSize;

        if (startIndex < 1)
            startIndex = 1;

        while (startIndex <= this.MaxSize) {
            items.push({ Label: startIndex, Value: startIndex });
            startIndex++;
        }


        return items;
    }
}