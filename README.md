# IdealFinancialAPI
This is a .net core (2.2) app. There is a seed that includes a user, user's account, user creditline. It could be found in the models folder.
This app uses mysql database.
Needs to be build first, add initial migration and update database from the package manager console. (Tools->NuGet package manager)
A credit line can be created for the same account to keep a history  through postman values will change acordingly.
Initially credit line amount and available funds will have the same amount.

The ends points are the follow:

Get
http://localhost:49911/api/users/1
Response:
{
    "id": 1,
    "name": "Maria",
    "userName": "maria12345",
    "password": "12345mo",
    "accounts": []
}

Get
http://localhost:49911/api/accounts/1

Response:
{
    "id": 1,
    "balance": 141425.0,
    "availableFunds": 8575.0,
    "creditLine": 150000.0
}

Post
http://localhost:49911/api/transactions

body:
{
    "AccountId": 1,
    "Amount": "600",
    "TypeTxn": "Withdraw"
}

Post
http://localhost:49911/api/CreditLines

body:
{
    "AccountId": 1,
    "Amount": "150000"
}
