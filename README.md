# Item Marketplace Test Task

REST API to query marketplace auctions

## Tech Stack

.NET 6, EF Core 7, ASP.NET Core Web API, MS SQL Server


## API Reference

#### Get auctions by filter

```http
  GET /auctions
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `PageNumber` | `int` | Result list page number |
| `Limit` | `int` | Size of page in result |
| `Status` | `int` | Auction status (0 - None, 1 - Canceled, 2 - Finished, 3 - Active) |
| `Seller` | `string` | Filter for Seller in Auctions (exact match) |
| `Name` | `string` | Filter for Item Name in Auctions (case insensitive, any position) |
| `SortKey` | `string` | Name of the sorting field. Default field - CreatedAt. |
| `SortOrder` | `string` | Sorting order (asc, desc). Default order - ascending. |

#### Get auction by id

```http
  GET /auctions/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of auction to fetch |



## Features

- Pagination with page limit
- Optional filtering (by status, by seller, by name), filtering by name is case insensitive, any position
- Sorting (by key: CreatedDt, Price, by order: asc, desc)
- Optimization for searching by name
- API versioning
- Logging to console

