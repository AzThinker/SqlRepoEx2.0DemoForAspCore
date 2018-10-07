# SqlRepoEx2.0DemoForAspCore

# 本例演示 SqlRepoEx2.0 在 AspCore 中的应用。

 
# 2.0.3版本更新 2018.10.7
## 1、增加数据特性

## 2、增加属性判断器

## 3、二进制数据支持


 
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
