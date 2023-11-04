namespace Lifequest.Src.Domain.Models.Users;

public class User
{
  public uint Id {get; private set;}
  public string Uid {get; private set;}
  public string Email {get; private set;}
  public string Name {get; private set;}
  public DateTime Birthday {get; private set;}
  public byte Age {get; private set;}
  public bool Gender {get; private set;}
  public DateTime DeletedAt {get; private set;}
  public DateTime CreatedAt {get; private set;}
  public DateTime UpdatedAt {get; private set;}

  /// <summary>
  /// 初回作成コンストラクタ
  /// </summary>
  /// <param name="uid"></param>
  /// <param name="email"></param>
  /// <param name="name"></param>
  /// <param name="birthday"></param>
  /// <param name="age"></param>
  /// <param name="gender"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentException"></exception>
  public static User Create(string uid, string email, string name, DateTime birthday, byte age, bool gender)
  {
    if(string.IsNullOrEmpty(uid))
    {
      throw new ArgumentException(nameof(uid));
    }
    if(string.IsNullOrEmpty(email))
    {
      throw new ArgumentException(nameof(email));
    }
    if(string.IsNullOrEmpty(name))
    {
      throw new ArgumentException(nameof(name));
    }
    if(birthday == null)
    {
      throw new ArgumentException(nameof(birthday));
    }
    return new User
    {
      Uid = uid,
      Email = email,
      Name = name,
      Birthday = birthday,
      Age = age,
      Gender = gender
    };
  }

  /// <summary>
  /// 再構成コンストラクタ
  /// </summary>
  /// <param name="id"></param>
  /// <param name="uid"></param>
  /// <param name="email"></param>
  /// <param name="name"></param>
  /// <param name="birthday"></param>
  /// <param name="age"></param>
  /// <param name="gender"></param>
  /// <param name="deletedAt"></param>
  /// <param name="createdAt"></param>
  /// <param name="updatedAt"></param>
  /// <returns></returns>
  public static User fromRepository(uint id, string uid, string email, string name, DateTime birthday, byte age, bool gender, DateTime deletedAt, DateTime createdAt, DateTime updatedAt)
  {
    return new User
    {
      Id = id,
      Uid = uid,
      Email = email,
      Name = name,
      Birthday = birthday,
      Age = age,
      Gender = gender,
      DeletedAt = deletedAt,
      CreatedAt = createdAt,
      UpdatedAt = updatedAt
    };
  }

  /// <summary>
  /// 内部使用にとどめる
  /// </summary>
  private User()
  {
  }
}