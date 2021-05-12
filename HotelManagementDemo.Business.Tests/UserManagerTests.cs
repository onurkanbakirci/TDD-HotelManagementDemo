using AutoFixture;
using HotelManagementDemo.Business.Abstract;
using HotelManagementDemo.Business.Concrete;
using HotelManagementDemo.Core.Utilities.Results;
using HotelManagementDemo.DataAccess.Abstract;
using HotelManagementDemo.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDemo.Business.Tests
{
    [TestClass]
    public class UserManagerTests
    {
        Fixture _fixture;
        Mock<IUserDal> _mockUserDal;
        List<User> _dbUsers;


        [TestInitialize]
        public void Setup()
        {

            //setup autofixure in order to generate fake model data
            _fixture = new Fixture();

            //setup pre-populated hotel datas
            _dbUsers = _fixture.CreateMany<User>(417).ToList();
            _dbUsers.AddRange(_fixture.Build<User>().With(x => x.FirstName, "Onurkan").CreateMany(1));

            //setup hotelDal methods
            _mockUserDal = new Mock<IUserDal>();
            _mockUserDal.Setup(m => m.GetList(null)).Returns(_dbUsers);
            _mockUserDal.Setup(m => m.Get(x => x.Id == 10)).Returns(_dbUsers.Where(x => x.Id == 10).SingleOrDefault());
            _mockUserDal.Setup(m => m.Update(_dbUsers.Where(x => x.Id == 10).SingleOrDefault()));
            _mockUserDal.Setup(m => m.Delete(_dbUsers.Where(x => x.Id == 10).SingleOrDefault()));

        }


        /// <summary>
        /// All users should be able to be listed
        /// </summary>
        [TestMethod]
        public void Get_All_Users_ReturnsListOfUser()
        {
            IUserService userService = new UserManager(_mockUserDal.Object);

            IDataResult<List<User>> users = userService.GetList();

            Assert.IsTrue(users.Success);
            Assert.AreEqual(418, users.Data.Count);
        }


        /// <summary>
        /// Get user by user id
        /// </summary>
        [TestMethod]
        public void Get_User_By_Id_ReturnsUser()
        {
            IUserService userService = new UserManager(_mockUserDal.Object);

            IDataResult<User> user = userService.GetById(10);

            Assert.IsTrue(user.Success);
        }


        /// <summary>
        /// Get user by user username
        /// </summary>
        [TestMethod]
        public void Get_User_By_UserName_ReturnsUser()
        {
            IUserService userService = new UserManager(_mockUserDal.Object);

            IDataResult<User> user = userService.GetByUserName("yellowpeacock139");

            Assert.IsTrue(user.Success);
        }


        /// <summary>
        /// Add new user to database
        /// </summary>
        [TestMethod]
        public void Add_User_ReturnsResultEntity()
        {
            IUserService userService = new UserManager(_mockUserDal.Object);

            var user = new User()
            {
                FirstName = "Onurkan",
                LastName = "Bakırcı",
                Email = "onurkanbkrc@gmail.com",
                Password = "abcded",
            };

            IResult addOperation = userService.Add(user);

            Assert.IsTrue(addOperation.Success);
        }


        /// <summary>
        /// Update user in database
        /// </summary>
        [TestMethod]
        public void Update_User_ReturnsResultEntity()
        {
            IUserService userService = new UserManager(_mockUserDal.Object);
            var user = userService.GetById(10);
            user.Data.FirstName = "Onurkan";
            user.Data.LastName = "Bakırcı";
            var result = userService.Update(user.Data);
            Assert.IsTrue(result.Success);
        }


        /// <summary>
        /// Delete user from database
        /// </summary>
        [TestMethod]
        public void Delete_User_ReturnsResultEntity()
        {
            IUserService userService = new UserManager(_mockUserDal.Object);
            var user = userService.GetById(10);
            var result = userService.Delete(user.Data);
            Assert.IsTrue(result.Success);
        }
    }
}
