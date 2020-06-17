## 概述
封装了 EF Core 数据库迁移方法，用于在程序启动时迁移数据库。

## 安装
```xml
<PackageReference Include="NXHub.EntityFrameworkCore.Migrater" Version="0.0.1" />
```

## 使用
```cs
public void Configure(
    IApplicationBuilder app,
    IWebHostEnvironment env,
    IHostApplicationLifetime host)
{
    // ...
    
    host.TryMigrateDb<TestDataContext>(app);
}
```
