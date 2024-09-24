using AspireTest.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer(ServicesName.SqlName).AddDatabase("");
var redis = builder.AddRedis(ServicesName.CacheName);

builder.AddProject<Projects.PetClinicWebMonolith>("petclinicwebmonolith")
    .WithReference(sql)
    .WithReference(redis);

var app = builder.Build();
app.Run();