＃Lifequest とは？

## Web アプリ概要

家族の管理を行うことができる。

### できること

1. 家族のお金管理
2. 家族の目標管理
3. 家族の予定管理
4. 家族の経歴管理

## コーディングルール

1. 基本的に DDD をベースにコーディングをします。
2. Entity → DB のマップは mapper を使用 OK。
3. Entity → ViewModel は mapper を使用 OK。
4. DB → Entity、ViewModel → Entity は mapper ではなく、コンストラクタを使用すること。

# マイグレーション

# session 管理方法

```c#
    await HttpContext.Session.LoadAsync();
    var storeValue = HttpContext.Session.GetString("test1");
    Console.WriteLine(storeValue);
    if (storeValue == null)
    {
      Console.WriteLine("保存しにいってるよ");
      HttpContext.Session.SetString("test2", "テスト2");

      // Redisにデータを保存する
      await HttpContext.Session.CommitAsync();
    }
```

# JWT から uid を取得する方法　

```c#
var uid = User.Claims.Where(_ => _.Type == "user_id").First().Value;
```

※ user データを取得する場合は、authUserContext を使用すること

---
title: Order example
---
``` mermaid
erDiagram
    CUSTOMER ||--o{ ORDER : places
    ORDER ||--|{ LINE-ITEM : contains
    CUSTOMER }|..|{ DELIVERY-ADDRESS : uses
```

```mermaid
gantt
  title PHPのライフサイクル

  section PHP 7.2
    アクティブサポート      : done, 2017-11-30, 2019-11-30
    セキュリティサポート     : crit, 2020-11-30

  section PHP7.3
    アクティブサポート      : 2018-12-06, 2020-12-06
    セキュリティサポート     : crit, 2021-12-06

  section PHP7.4
    アクティブサポート      : 2019-11-28, 2021-11-28
    セキュリティサポート     : crit, 2022-11-28
```

```mermaid
graph TD;
    A-->B;
```
