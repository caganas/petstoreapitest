using Newtonsoft.Json;
using NUnit.Framework;
using petstoreapitestapi;

namespace petstoreapitest
{
    public class Tests
    {
        private PetStoreAPI _petStoreApi;
        [SetUp]
        public void Setup()
        {
            _petStoreApi = new PetStoreAPI();
        }

        [Test]
        [TestCase("available")]
        [TestCase("")]
        [TestCase("pending")]
        [TestCase("sold")]
        [TestCase("fake")]
        public void Test1(string status)
        {
            var result = _petStoreApi.petFindByStatusIsEmpty(status);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("available", "fish")]
        [TestCase("pending", "cat")]
        [TestCase("sold", "doggie")]
        [TestCase("fake", "human")]
        public void Test2(string status, string name)
        {
            var result = _petStoreApi.petFindByStatusHasName(status, name);
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("available", "fish")]
        [TestCase("noname", null)]
        [TestCase("pending", "dog")]
        [TestCase(null, "nostatus")]
        public void Test3(dynamic status, dynamic name)
        {
            var result = _petStoreApi.postPetSucceed(status, name);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("available", "fish")]
        [TestCase("noname", null)]
        [TestCase(null, null)]
        [TestCase("pending", "dog")]
        [TestCase(null, "nostatus")]
        public void Test4(dynamic status, dynamic name)
        {
            var result = _petStoreApi.putPetSucceed(status, name);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("9223372036854774963")]
        [TestCase("9223372036854774937c")]
        [TestCase("")]
        [TestCase("sold")]
        [TestCase("9223372036854775574")]
        [TestCase("92233720 36854775574")]
        public void Test5(string id)
        {
            var result = _petStoreApi.petById(id);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("9223372036854774963", "placed", false)]
        [TestCase("9223372036854774963", null, true)]
        [TestCase("9223372036854772222", "placed", true)]
        [TestCase("aaa", "placed", false)]
        public void Test6(dynamic petId, dynamic status, dynamic complete)
        {
            var result = _petStoreApi.postStoreOrder(petId, status, complete);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(1)]
        [TestCase(" ")]
        [TestCase("good")]
        [TestCase(null)]
        [TestCase(0)]
        public void Test7(dynamic userStatus)
        {
            var result = _petStoreApi.postUserCreatWithArray(userStatus);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(0)]
        [TestCase(" ")]
        [TestCase("hello")]
        [TestCase(null)]
        [TestCase(1)]
        public void Test8(dynamic userStatus)
        {
            var result = _petStoreApi.postUserCreatWithList(userStatus);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(1, "tom", "jack", "jane", "tomjane@gmail.com", "pwd123", "111-111-111", 1)]
        [TestCase(2, "tom1", "jack", "jane", "tomjane@gmail.com", "pwd123", "111-111-111", 1)]
        [TestCase(3, "tom2", "jack", "jane", "tomjane@gmail.com", "pwd123", "111-111-111", 1)]
        [TestCase("123", "tom3", "jack", "jane", "tomjane@gmail.com", "pwd123", "", 1)]
        [TestCase(666, "tom4", "jack", "jane", "tomjan", "pwd123", "111-111-111", 1)]
        [TestCase("fakeid", null, "jack", "jane", "tomjane@gmail.com", "pwd123", "111-111-111", 1)]
        public void Test9(dynamic id, dynamic username, dynamic firstname, dynamic lastname, dynamic email, dynamic password, dynamic phone, dynamic userStatus)
        {
            var result = _petStoreApi.putUser(id, username, firstname, lastname, email, password, phone, userStatus);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("tom123")]
        [TestCase(" ")]
        [TestCase("hello")]
        [TestCase(null)]
        [TestCase(1)]
        public void Test10(string username)
        {
            var result = _petStoreApi.getUserByUsername(username);
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("tom1", "pwd123")]
        [TestCase("", "")]
        [TestCase(555, null)]
        [TestCase("hello", null)]
        [TestCase(null, null)]
        [TestCase(null, 999)]
        [TestCase(1, 1)]
        public void Test11(string username, string password)
        {
            var result = _petStoreApi.userLogin(username, password);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(1, "tom", "jack", "jane", "tomjane@gmail.com", "pwd123", "111-111-111", 1)]
        [TestCase(2, "tom1", "jack", "jane", "tomjane@gmail.com", "pwd123", "111-111-111", 1)]
        [TestCase(3, "tom2", "jack", "jane", "tomjane@gmail.com", "pwd123", "111-111-111", 1)]
        [TestCase("123", "tom3", "jack", "jane", "tomjane@gmail.com", "pwd123", "", 1)]
        [TestCase(666, "tom4", "jack", "jane", "tomjan", "pwd123", "111-111-111", 1)]
        [TestCase("fakeid", null, "jack", "jane", "tomjane@gmail.com", "pwd123", "111-111-111", 1)]
        public void Test12(dynamic id, dynamic username, dynamic firstname, dynamic lastname, dynamic email, dynamic password, dynamic phone, dynamic userStatus)
        {
            var result = _petStoreApi.postUser(id, username, firstname, lastname, email, password, phone, userStatus);
            Assert.IsTrue(result);
        }
    }
}