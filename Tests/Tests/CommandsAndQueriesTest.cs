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
using Moq;
using MediatR;
using PhoneBook.CommandsAndQueries.Commands;
using System.Threading;
using PhoneBook.CommandsAndQueries.Queries;

namespace Tests
{
    [TestClass]
    public class CommandsAndQueriesTest
    {
        private IRepository<PhoneRecord> _repository;
        private PhoneRecordsController _controller;
        private IMappedRepository<PhoneRecordViewModel, PhoneRecord> _mappedRepository;
        

        [TestInitialize]
        public void Setup()
        {            
            var config=new MapperConfiguration(cfg=>cfg.CreateMap<PhoneRecordViewModel, PhoneRecord>().ReverseMap());
            var mapper=config.CreateMapper();            
            _repository = ContextHelper.Repository;            
            _mappedRepository = new MappedRepository<PhoneRecordViewModel, PhoneRecord>(_repository,mapper);            
        }
                
              
        [TestMethod]
        public void GetRecordByIdTest()
        {
            var query = new GetPhoneRecordByIdQuery { Id = 1 };
            var handler=new GetPhoneRecordByIdQueryHandler(_mappedRepository);
            var result=handler.Handle(query,new CancellationToken());            
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetPageTest()
        {
            GetPageQuery query = new GetPageQuery() { PageIndex = 0, PageSize = 2 };
            GetPageQueryHandler handler=new GetPageQueryHandler(_mappedRepository);
            var result=handler.Handle(query,new CancellationToken()).Result;
            Assert.IsTrue(result is IPage<PhoneRecordViewModel>);
        }
        

        [TestMethod]
        public void CreateRecordCommandTest()
        {
            CreateRecordCommand command=new CreateRecordCommand
            {
                PhoneRecord=new PhoneRecordViewModel
                {
                    FirstName="Test",
                    LastName="Test Last",
                }
            };

            CrateRecordCommandHandler handler = new CrateRecordCommandHandler(_mappedRepository);
            var result=handler.Handle(command,new CancellationToken()).Result;
            Assert.AreNotEqual(0, result.Id);
        }
    

        [TestMethod]
        [DataRow(1)]
        public void DeleteByIdCommandTest(int id)
        {            
            DeleteByIdRecordCommand command=new DeleteByIdRecordCommand { Id=id};
            DeleteByIdCommandHandler handler = new DeleteByIdCommandHandler(_mappedRepository);
            var result=handler.Handle(command,new CancellationToken()).Result;
            Assert.IsNotNull(result);
        }
    }
}
