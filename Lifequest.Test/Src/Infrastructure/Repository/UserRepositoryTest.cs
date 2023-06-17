// using NUnit.Framework;
// using Lifequest.Src.Infrastructure.Repository;
// using System.Collections.Generic;

// namespace Lifequest.Test.Src.Infrastructure.Repository;

// [TestFixture]
// public class UserRepositoryTest
// {
//   private UserRepository _userRepository;
  
//   [SetUp]
//   public void SetUp()
//   {
//      _userRepository = new UserRepository();
//   }

//   // テスト実施
//   [TestCaseSource(nameof(Test1Cases))]
//   public void Test1Test(string name, int id,string expected, string testName)
//   {
//     var result = _userRepository.Test(name, id);
//     Assert.AreEqual(result, expected, testName);
//   }


//   // テストケース生成
//   static IEnumerable<TestCaseData> Test1Cases()
//   {    
//       yield return new TestCaseData("test1", 1, "test1だよ", "test1の場合、");
//       yield return new TestCaseData("test2", 2, "test2だよ", "test2の場合");
//       yield return new TestCaseData("wwww", 100, "や", "それ以外");
//   }

// }