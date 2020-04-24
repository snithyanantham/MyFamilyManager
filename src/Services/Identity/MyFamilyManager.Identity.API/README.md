# MyFamilyManager Identity Provider

### DB Migration

```
dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb
dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb
```

### From Visual Studio PMC (Package Manager Console)

```
Add-Migration InitialApplicationDbContext -Context ApplictionDbContext
Add-Migration InitialConfigurationDbContext -Context ConfigurationDbContext
Add-Migration InitialPersistedGrantDbContext -Context PersistedGrantDbContext
```
