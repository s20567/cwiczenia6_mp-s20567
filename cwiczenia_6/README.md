### Used EF commands
```sh
dotnet ef migrations add <message>
dotnet ef database update # update origin database
dotnet ef migrations script # generate sql script
```

### Database Inheritance Strategies
TPH - Table per hierarchy
TPT - Table per type

```json
{
  "firstName": "Joe",
  "lastName": "Doe",
  "email": "joedoe@gmail.com"
}
```

```json
{
  "firstName": "Adam",
  "lastName": "Nowak",
  "email": null
}
```