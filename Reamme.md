# 人生管理プロジェクト

## アーキテクチャー

DDD 採用

## ER 図

```mermaid
erDiagram
  users ||--o{ user_histories : "ユーザーの経歴を保持"
  users ||--o{ family_member : "所属家族を表現"
  families ||--o{ family_member: "所属家族を表現"
  families ||--o{ fixed_cost: "家族の固定費を表現"
  families ||--o{ schedules: "家族のスケジュールを表現"
  schedules ||--o{ schedule_photos: "スケジュールの思い出写真などを表現"
  family_member ||--o{ banks: "家族の貯金金額を表現"
  banks ||--o{ bank_histories: "貯金金額の履歴を表現"
  family_member ||--o{ tasks: "家族メンバーのタスクを表現"

  users {
    bigint id PK
  }

  user_histories{
    bigint id PK
    references user_id FK
  }

  families {
    bigint id PK
  }

  family_member {
    bigint id PK
    references user_id FK
    references family_id FK
  }


  fixed_cost {
    bigint id PK
    references family_id FK
  }

  schedules{
    bigint id PK
    references family_id FK
  }

  schedule_photos{
    bigint id PK
    references schedule_id FK
    string path "s3のパスを記載"
  }

  banks{
    bigint id PK
    references family_member_id FK
  }

  bank_histories{
    bigint id PK
    references bank_id FK
  }

  tasks{
    bigint id PK
    references family_member_id FK
  }

```
