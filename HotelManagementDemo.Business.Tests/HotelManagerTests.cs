using AutoFixture;
using HotelManagementDemo.Business.Abstract;
using HotelManagementDemo.Business.Concrete;
using HotelManagementDemo.Core.Utilities.Results;
using HotelManagementDemo.DataAccess.Abstract;
using HotelManagementDemo.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagementDemo.Business.Tests
{
    [TestClass]
    public class HotelManagerTests
    {
        Fixture _fixture;
        Mock<IHotelDal> _mockHotelDal;
        List<Hotel> _dbHotels;
        

        [TestInitialize]
        public void Setup()
        {

            //setup autofixure in order to generate fake model data
            _fixture = new Fixture();

            //setup pre-populated hotel datas
            _dbHotels = _fixture.CreateMany<Hotel>(1700).ToList();
            _dbHotels.AddRange(_fixture.Build<Hotel>().With(x => x.City , "Mesa").CreateMany(4));
            _dbHotels.AddRange(_fixture.Build<Hotel>().With(x => x.State ,  "Arizona").CreateMany(23));

            //setup hotelDal methods
            _mockHotelDal = new Mock<IHotelDal>();
            _mockHotelDal.Setup(m => m.GetList(null)).Returns(_dbHotels);
            _mockHotelDal.Setup(m => m.Get(x=>x.Id == 10)).Returns(_dbHotels.Where(x=>x.Id == 10).SingleOrDefault());
            _mockHotelDal.Setup(m => m.Update(_dbHotels.Where(x=>x.Id == 10).SingleOrDefault()));
            _mockHotelDal.Setup(m => m.Delete(_dbHotels.Where(x => x.Id == 10).SingleOrDefault()));

        }


        /// <summary>
        /// All hotels should be able to be listed
        /// </summary>
        [TestMethod]
        public void Get_All_Hotels_ReturnsListOfHotel()
        {
            IHotelService hotelService = new HotelManager(_mockHotelDal.Object);

            IDataResult<List<Hotel>> hotels = hotelService.GetList();

            Assert.IsTrue(hotels.Success);
            Assert.AreEqual(1727, hotels.Data.Count);
        }


        /// <summary>
        /// Get all hotels by hotel city
        /// </summary>
        [TestMethod]
        public void Get_Hotels_By_City_ReturnsListOfHotel()
        {
            IHotelService hotelService = new HotelManager(_mockHotelDal.Object);

            IDataResult<List<Hotel>> hotels = hotelService.GetByCity("Mesa");

            Assert.IsTrue(hotels.Success);
            Assert.AreEqual(4, hotels.Data.Count);
        }


        /// <summary>
        /// Get all hotels by hotel state
        /// </summary>
        [TestMethod]
        public void Get_Hotels_By_State_ReturnsListOfHotel()
        {
            IHotelService hotelService = new HotelManager(_mockHotelDal.Object);

            IDataResult<List<Hotel>> hotels = hotelService.GetByState("Arizona");

            Assert.IsTrue(hotels.Success);
            Assert.AreEqual(23, hotels.Data.Count);
        }


        /// <summary>
        /// Add new hotel to database
        /// </summary>
        [TestMethod]
        public void Add_Hotel_ReturnsResultEntity()
        {
            IHotelService hotelService = new HotelManager(_mockHotelDal.Object);

            var hotel = new Hotel()
            {
                Name = "OnurkanOtel",
                City = "İstanbul",
                State = "Üsküdar",
                Address = "Üsküdar/Altunizade",
                Phone = "5387218258",
                Zip = "00000"
            };

            IResult addOperation = hotelService.Add(hotel);

            Assert.IsTrue(addOperation.Success);
        }


        /// <summary>
        /// Update hotel in database
        /// </summary>
        [TestMethod]
        public void Update_Hotel_ReturnsResultEntity()
        {
            IHotelService hotelService = new HotelManager(_mockHotelDal.Object);
            var hotel = hotelService.GetById(10);
            hotel.Data.Address = "Üsküdar/Altunizade";
            hotel.Data.Phone = "05387218258";
            var result = hotelService.Update(hotel.Data);
            Assert.IsTrue(result.Success);
        }


        /// <summary>
        /// Delete hotel from database
        /// </summary>
        [TestMethod]
        public void Delete_Hotel_ReturnsResultEntity()
        {
            IHotelService hotelService = new HotelManager(_mockHotelDal.Object);
            var hotel = hotelService.GetById(10);
            var result = hotelService.Delete(hotel.Data);
            Assert.IsTrue(result.Success);
        }
    }
}
