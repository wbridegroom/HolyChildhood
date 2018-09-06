export interface Page {
    id: number;
    title: string;
    children: Array<Page>;
    parent: Page;
}
