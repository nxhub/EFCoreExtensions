## 概述
封装了 EF Core 数据库迁移方法。

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
