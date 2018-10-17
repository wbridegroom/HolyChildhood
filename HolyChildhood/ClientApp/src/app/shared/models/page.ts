export interface Page {
    id: number;
    title: string;
    children: Array<Page>;
    parent: Page;
    pageContents: PageContent[];
}

export interface PageContent {
    id: number;
    content: string;
    contentType: string;
    editing: boolean;
    x: number;
    y: number;
    height: number;
    width: number;
    page: Page;
}
