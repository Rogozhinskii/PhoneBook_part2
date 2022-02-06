using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBook.Automapper;
using PhoneBook.Controllers;
using PhoneBook.DAL.Entities;
using Microsoft.Extensions.Logging;
using PhoneBook.Interfaces;
using PhoneBook.Models;
using System.Linq;
using Tests.Helpers;

namespace Tests
{
    [TestClass]
    public class PhoneRecordsControllerTest
    {
        private IRepository<PhoneRecord> _repository;
        private PhoneRecordsController _controller;
        private IMappedRepository<PhoneRecordViewModel, PhoneRecord> _mappedRepository;

        [TestInitialize]
        public void Setup()
        {
            var logger=LoggerFactory.Create(builder=>builder.AddDebug()).CreateLogger<PhoneRecordsController>();
            var config=new MapperConfiguration(cfg=>cfg.CreateMap<PhoneRecordViewModel, PhoneRecord>().ReverseMap());
            var mapper=config.CreateMapper();
            _repository = ContextHelper.Repository;
            _mappedRepository = new MappedRepository<PhoneRecordViewModel, PhoneRecord>(_repository,mapper);
            
        }
                

        [TestMethod]
        public void IndexViewResultNotNull()
        {            
            var result = _controller.Index(string.Empty,string.Empty, null, _repository.GetCountAsync().Result).Result as ViewResult;
            var model=result.Model as IPage<PhoneRecordViewModel>;
            Assert.IsNotNull(model);
            Assert.IsTrue(model.Items.Any());
        }

        [TestMethod]
        public void DetailsViewNotNull()
        {
            var result=_controller.Details(((_repository.GetAllAsync()).Result).FirstOrDefault().Id).Result as ViewResult;
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        [DataRow(1)]
        public void GetDeleteTest(int id)
        {
            var result = _controller.Delete(id).Result as ViewResult;
            var model = result.Model as PhoneRecordViewModel;
            Assert.IsNotNull(model);
        }

        [TestMethod]
        [DataRow(1)]
        public void DeleteConfirmedTest(int id)
        {
           
        }
    }
}
