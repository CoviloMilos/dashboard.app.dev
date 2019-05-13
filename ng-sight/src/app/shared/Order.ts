export interface Order {
    id: number;
    name: string;
    total: number;
    placed: Date;
    completed: Date;
    status: 'Status';
}