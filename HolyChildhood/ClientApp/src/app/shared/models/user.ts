export interface Parishioner {
    id: number;
    title: string;
    firstName: string;
    middleInitial: string;
    lastName: string;
    groupMemberships: Member[];
    fullName: string;
}

export interface Group {
    id: number;
    name: string;
}

export interface Member {
    id: number;
    position: string;
    group: Group;
}
