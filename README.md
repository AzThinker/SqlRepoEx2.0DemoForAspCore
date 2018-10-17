# 2.2.0 版本更新 2018.10.17

### 1、修正MySql 增加语句有自增自段时，返回语句时的错误；

### 2、  IInsertStatement<TEntity>和IUpdateStatement<TEntity>接口增加两个方法

```
	string ParamSql();

        (string paramsql, TEntity entity) ParamSqlWithEntity();
```
返回形如下列SQL语句：
```
var repository = MsSqlRepoFactory.Create<ToDo>();
var results = repository.Query().Where(c => c.Id == 6).Go().FirstOrDefault();
Console.WriteLine(resultinsert.ParamSql());

1、	INSERT  ToDo ( CreatedDate , IsCompleted , Task )
		VALUES(@CreatedDate,@IsCompleted,@Task);


var resultinsert = repository.Update().For(results);
 Console.WriteLine(resultinsert.ParamSql());
2、	UPDATE   ToDo 
	SET CreatedDate  = @CreatedDate, IsCompleted  = @IsCompleted, Task  = @Task
	WHERE Id  = @Id;
```

 以解决储如Dapper等ORM工具需要参数类型字符串需求</br>

  SqlRepoEx中是可以与 Dapper 同时并存，意味着初始化SqlRepoEx后，</br>
  1、可以直接从 SqlRepoEx 中操作返回结果；</br>
  2、可以通过 SqlRepoEx 来生成SQL语句，另外Dapper 主要是基于SqlMapper  ，SqlMapper中定义了基于 IDbConnection 接口的操作，你可以通过SqlRepoEx 的  IConnectionProvider 接口来获取一个 DbConnection</br>
   有两种方法</br>
```   
     （1）、 var connectionProvider = new AppConfigFirstConnectionProvider();
     IDbConnection dbConnection = connectionProvider.GetDbConnection;

     （2）、 var repository = MsSqlRepoFactory.Create<ToDo>();
            IDbConnection dbConnection = repository.GetConnectionProvider.GetDbConnection;
     
```

# 2.1.0  版本更新 2018.10.16

## 增加事务支持


### 1、起用事务支持的语句执行器

```
 MsSqlRepoFactory.UseStatementTransactionExecutor();
```

### 2、代码中使用使用方法 repository.GetConnectionProvider.BeginTransaction() 获取事务控制
```
public void DoTransactionIt()
        {
            var repository = MsSqlRepoFactory.Create<ToDo>();
            var results = repository.Query().Where(c => c.Id < 6);
           foreach (var item in results.Go())
            {
                Console.WriteLine($"{item.Id}\t {item.Task} ");
            }
            using (var tranc = repository.GetConnectionProvider.BeginTransaction())
            {
                repository.Update().Set(c => c.Task, "A01").Where(c => c.Id == 1).Go();// A1
                repository.Update().Set(c => c.Task, "B01").Where(c => c.Id == 2).Go();// B2
                tranc.Rollback();
            }
           foreach (var item in results.Go())
            {
                Console.WriteLine($"{item.Id}\t {item.Task} ");
            }
            Console.WriteLine(results.Sql());

        }


```



# 2.0.8版本更新 2018.10.15

## 1、修正部分错误
## 2、优化代码
## 3、增加代码注释

# 注意：本次修改有两处重要变化,主要是拼写错误，现修正

### 1、IdentityFiledAttribute，改为IdentityFildAttribute
### 2、KeyFiledAttribute 改为 KeyFieldAttribute

更改保留了原有特性，但不会长期支持并存，请使用新的特定标识

</br>
</br>

# SqlRepoEx2.0DemoForAspCore

# 本例演示 SqlRepoEx2.0 在 AspCore 中的应用。


# 2.0.7 版本更新 2018.10.14
## 1、修正部分错误
## 2、优化代码
## 3、增加代码注释


# 2.0.4版本更新 2018.10.9
 ## 1、修正分页错误
 ## 2、SqlRepoEx.MsSql.ServiceCollection;与SqlRepoEx.MySql.ServiceCollection 命名空间错误修正
 
# 2.0.3版本更新 2018.10.7
## 1、增加分页辅助功能

查询语句增加PageGo()
var results = repository.Query().Select(e => e.Id, e => e.Task, e => e.CreatedDate).Page(5,1).PageGo();
返回是一个(IEnumerable<TEntity> QueryResult, int PageCount) 的Tupe值
用于分页控件使用。

## 2、增加ServiceCollection一些功能方法

## 3、修正部分bug


 
 # 2.0.2版本更新
 ### 2018.10.5
## 1、增加数据特性 
SqlRepoDbFieldAttribute<br/>
标识是否为数据字段，主要是因为<br/>
### （1）、部分类型拥有复杂属性；<br/>
### （2）、有些属性不是来源于数据库；<br/>
### （3）、用户在原来的代码中使用 SqlRepoEx ，减少字段与数据库字段之间的冲突；<br/>
## 2、增加属性判断器
 增加 SimpleWritablePropertyMatcher 属性判断器，<br/>
  1、增加SqlRepoDbFieldAttribute特性后，如果用户程序仍然为POJO类型，不必标识SqlRepoDbFieldAttribute时，用SimpleWritablePropertyMatcher<br/>
  2、如果明确要区分，就用WritablePropertyMatcher ；<br/>
 ~~~
  string ConnectionString = "Data Source=(Local);Initial Catalog=Northwind;User ID=test;Password=test";

            var connectionProvider = new ConnectionStringConnectionProvider(ConnectionString);

            MsSqlRepoFactory.UseConnectionProvider(connectionProvider);
            MsSqlRepoFactory.UseWritablePropertyMatcher(new SimpleWritablePropertyMatcher());

            var repository = MsSqlRepoFactory.Create<Customers>();
~~~
### 3、二进制数据支持
  增加对 byte[]类型的支持，但应注意，其 byte[]格式成 Convert.ToBase64String() 后，SQL字串的总体长度不能超过8000字符。<br/>

# SqlRepoEx2.0示例


![image](https://raw.githubusercontent.com/AzThinker/SqlRepoEx2.0Demo/master/Demos/GettingStartedStatic/SqlRepoEx1.1与2.0功能对比.png)
