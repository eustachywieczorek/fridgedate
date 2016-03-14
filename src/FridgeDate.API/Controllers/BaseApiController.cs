using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using FridgeDate.Data.Interfaces;

namespace FridgeDate.API.Controllers
{
    public class BaseApiController : ApiController
    {
        protected IMapper Mapper;
        protected IUnitOfWork UnitOfWork;
        public BaseApiController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

    }
}
