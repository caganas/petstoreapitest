using log4net;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using petstoreapitestapi;
using System.Reflection.Metadata;

namespace petstoreapitest
{
    public class Tests
    {
        static ILog log = log4net.LogManager.GetLogger(typeof(Tests));

        private PetStoreAPI _petStoreApi;
        [SetUp]
        public void Setup()
        {
            _petStoreApi = new PetStoreAPI();
        }

        [Test]
        [TestCase("available")]
        [TestCase("pending")]
        [TestCase("sold")]
        public void Test1(string status)
        {
            log.Info("(GET) pet/findByStatus positive test case will run");
            var result = _petStoreApi.petFindByStatusIsEmpty(status);
            Assert.IsTrue(result);
            log.Info("Test1 Passed.");
        }

        [Test]
        [TestCase("fake")]
        public void Test1_1(string status)
        {
            log.Info("(GET) pet/findByStatus negative test case will run");
            var result = _petStoreApi.petFindByStatusIsEmpty(status);
            Assert.False(result);
            log.Info("Test1_1 Passed.");

        }

        [Test]
        [TestCase("available", "fish")]
        
        public void Test1_2(string status, string name)
        {
            log.Info("(GET) pet/findByStatus negative test case will run");
            var result = _petStoreApi.petFindByStatusHasName(status, name);
            Assert.True(result);
            log.Info("Test1_2 Passed.");
        }

        [Test]
        [TestCase("pending", "cat")]
        [TestCase("fake", "human")]
        public void Test1_3(string status, string name)
        {
            log.Info("(GET) pet/findByStatus negative test case will run");
            var result = _petStoreApi.petFindByStatusHasName(status, name);
            Assert.False(result);
            log.Info("Test1_3 Passed.");
        }



        [Test]
        [TestCase("available", "fish")]
        [TestCase("pending", "dog")]
        public void Test2(dynamic status, dynamic name)
        {
            log.Info("(GET) /pet positive test case will run");
            var result = _petStoreApi.postPetSucceed(status, name);
            Assert.IsTrue(result);
            log.Info("Test2 Passed.");
        }

        [Test]
        [TestCase("noname", null)]
        [TestCase(null, "nostatus")]
        public void Test2_1(dynamic status, dynamic name)
        {
            log.Info("(GET) /pet negative test case will run");
            var result = _petStoreApi.postPetSucceed(status, name);
            Assert.IsFalse(result);
            log.Info("Test2_1 Passed.");
        }



        [Test]
        [TestCase("available", "fish")]
        [TestCase("pending", "dog")]
        public void Test3(dynamic status, dynamic name)
        {
            log.Info("(PUT) /pet positive test case will run");
            var result = _petStoreApi.putPetSucceed(status, name);
            Assert.IsTrue(result);
            log.Info("Test3 Passed.");
        }

        [Test]
        [TestCase("9223372036854646501")]
        public void Test5(string id)
        {
            log.Info("(GET) /pet/{id} positive test case will run");
            var result = _petStoreApi.petById(id);
            Assert.IsTrue(result);
            log.Info("Test5 Passed.");
        }

        [Test]
        [TestCase("9223372036854774963", "placed", false)]
        [TestCase("9223372036854774963", null, true)]
        [TestCase("9223372036854772222", "placed", true)]
        public void Test6(dynamic petId, dynamic status, dynamic complete)
        {
            log.Info("(Post) /store/order positive test case will run");
            var result = _petStoreApi.postStoreOrder(petId, status, complete);
            Assert.IsTrue(result);
            log.Info("Test6 Passed.");

        }


        [Test]
        [TestCase("aaa", "placed", false)]
        public void Test6_1(dynamic petId, dynamic status, dynamic complete)
        {
            log.Info("(Post) /store/order negative test case will run");
            var result = _petStoreApi.postStoreOrder(petId, status, complete);
            Assert.False(result);
            log.Info("Test6_1 Passed.");
        }

        [Test]
        [TestCase(1)]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase(0)]
        public void Test7(dynamic userStatus)
        {
            log.Info("(Post) user/createWithArray positive test case will run");
            var result = _petStoreApi.postUserCreatWithArray(userStatus);
            Assert.IsTrue(result);
            log.Info("Test7 Passed.");

        }

        [Test]
        [TestCase(0)]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase(1)]
        public void Test8(dynamic userStatus)
        {
            log.Info("(Post) user/createWithList positive test case will run");
            var result = _petStoreApi.postUserCreatWithList(userStatus);
            Assert.IsTrue(result);
            log.Info("Test8 Passed.");
        }

        [Test]
        [TestCase(1, "tom", "jack", "jane", "tomjane@gmail.com", "pwd123", "111-111-111", 1)]
        [TestCase(2, "tom1", "jack", "jane", "tomjane@gmail.com", "pwd123", "111-111-111", 1)]
        [TestCase(3, "tom2", "jack", "jane", "tomjane@gmail.com", "pwd123", "111-111-111", 1)]
        [TestCase("123", "tom3", "jack", "jane", "tomjane@gmail.com", "pwd123", "", 1)]
        [TestCase(666, "tom4", "jack", "jane", "tomjan", "pwd123", "111-111-111", 1)]
        public void Test9(dynamic id, dynamic username, dynamic firstname, dynamic lastname, dynamic email, dynamic password, dynamic phone, dynamic userStatus)
        {
            log.Info("(Put) /user/{username} positive test case will run");
            var result = _petStoreApi.putUser(id, username, firstname, lastname, email, password, phone, userStatus);
            Assert.IsTrue(result);
            log.Info("Test9 Passed.");
        }


        [Test]
        [TestCase("tom1", "pwd123")]
        [TestCase("", "")]
        public void Test10(string username, string password)
        {
            log.Info("(Get) user/login positive test case will run");
            var result = _petStoreApi.userLogin(username, password);
            Assert.IsTrue(result);
            log.Info("Test10 Passed.");
        }


        [Test]
        [TestCase(1, "tom", "jack", "jane", "tomjane@gmail.com", "pwd123", "111-111-111", 1)]
        [TestCase(2, "tom1", "jack", "jane", "tomjane@gmail.com", "pwd123", "111-111-111", 1)]
        [TestCase(3, "tom2", "jack", "jane", "tomjane@gmail.com", "pwd123", "111-111-111", 1)]
        [TestCase("123", "tom3", "jack", "jane", "tomjane@gmail.com", "pwd123", "", 1)]
        [TestCase(666, "tom4", "jack", "jane", "tomjan", "pwd123", "111-111-111", 1)]
        public void Test11(dynamic id, dynamic username, dynamic firstname, dynamic lastname, dynamic email, dynamic password, dynamic phone, dynamic userStatus)
        {
            log.Info("(Post) /user positive test case will run");
            var result = _petStoreApi.postUser(id, username, firstname, lastname, email, password, phone, userStatus);
            Assert.IsTrue(result);
            log.Info("Test11 Passed.");
        }

        [TestCase("fakeid", null, "jack", "jane", "tomjane@gmail.com", "pwd123", "111-111-111", 1)]
        public void Test11_1(dynamic id, dynamic username, dynamic firstname, dynamic lastname, dynamic email, dynamic password, dynamic phone, dynamic userStatus)
        {
            log.Info("(Post) /user negative test case will run");
            var result = _petStoreApi.postUser(id, username, firstname, lastname, email, password, phone, userStatus);
            Assert.IsFalse(result);
            log.Info("Test11_1 Passed.");
        }

    }
}