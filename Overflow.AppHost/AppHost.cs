#pragma warning disable ASPIRECERTIFICATES001
var builder = DistributedApplication.CreateBuilder(args);

var keycloak = builder.AddKeycloak("keycloak", 6001)
    .WithoutHttpsCertificate()
    .WithDataVolume("keycloak-data");

var postgres = builder.AddPostgres("postgress", port: 5432)
    .WithDataVolume("postgress-data")
    .WithPgAdmin();

var questionDb = postgres.AddDatabase("questionDb");

var questionSevice = builder.AddProject<Projects.QuestionService>("question-svc")
    .WithReference(keycloak)
    .WithReference(questionDb)
    .WaitFor(keycloak)
    .WaitFor(questionDb);

builder.Build().Run();