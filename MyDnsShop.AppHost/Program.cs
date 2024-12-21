var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres").WithPgWeb().WithPgAdmin();
var postgresDb = postgres.AddDatabase("myDnsDb");

builder.AddProject<Projects.MyDnsShop_Api>("mydnsshop").WithReference(postgresDb);


builder.Build().Run();
