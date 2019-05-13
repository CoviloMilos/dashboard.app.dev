import { Order } from './order';

const date = new Date();

export const ORDERS_DATA_MOCK: Order[] = [
    {
        id:1,
        customer: {id: 1, name: 'Main St Bakery', email:'example@email.com',state: 'CD'},
        total: 230,
        placed: date,
        fulfilled: date,
        status: 'Status'
    },
    {
        id:2,
        customer: {id: 1, name: 'Main St Bakery', email:'example@email.com',state: 'CD'},
        total: 230,
        placed: date,
        fulfilled: date,
        status: 'Status'
    },
    {
        id:3,
        customer: {id: 1, name: 'Main St Bakery', email:'example@email.com',state: 'CD'},
        total: 230,
        placed: date,
        fulfilled: date,
        status: 'Status'
    },
    {
        id:4,
        customer: {id: 1, name: 'Main St Bakery', email:'example@email.com',state: 'CD'},
        total: 230,
        placed: date,
        fulfilled: date,
        status: 'Status'
    },
    {
        id:5,
        customer: {id: 1, name: 'Main St Bakery', email:'example@email.com',state: 'CD'},
        total: 230,
        placed: date,
        fulfilled: date,
        status: 'Status'
    },   
];