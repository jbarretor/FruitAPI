# FruitAPI

This is a rest API developed in Net Core which contains all the operations of a CRUD, it manages a database in memory to persist the information that has been saved

## Operations

### POST
This method receives all the data of the new fruit that you want to save, to execute it you only have to enter the following URL:

```http
  POST /Fruits
```

In the body sent a JSON taking into account that the `Description` field must contain a minimum of 25 characters

```json
{
    "Name":"Orange",
    "Description":"From California, United States",
    "Type":{
        "Id":"1",
        "Name":"Citric",
        "Description":"Like oranges"
    }
}
```


### GET

This method returns all the fruits that have been saved during the execution of the project, to execute it you only have to enter the following URL:

```http
  GET /Fruits
```

### GET by Id

This method returns a specific fruit, to execute it you just have to enter the following URL replacing `ID` with the Id of the fruit you are looking for:

```http
  GET /Fruits/ID
```


### PUT

This method receives all the data of the fruit that you want to update, to execute it you only have to enter the following URL replacing `ID` with the Id of the fruit you want to update:

```http
  PUT /Fruits/ID
```

In the body sent a JSON taking into account that the `Description` field must contain a minimum of 25 characters

```json
{
    "Id":"1",
    "Name":"Orange",
    "Description":"From California, United States",
    "Type":{
        "Id":"1",
        "Name":"Citric",
        "Description":"Like oranges"
    }
}
```

### DELETE

This method receives the fruit ID of the fruit you want to remove, to execute it you just have to enter the following URL replacing `ID` with the Id of the fruit you want to remove:

```http
  DELETE /Fruits/ID
```
