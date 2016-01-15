
export interface IPagedList {
    HasNextPage: boolean;
    HasPreviousPage: boolean;
    IsFirstPage: boolean;
    IsLastPage: boolean;
    PageCount: number;
    PageIndex: number;
    PageNumber: number;
    PageSize: number;
    TotalItemCount: number;
}