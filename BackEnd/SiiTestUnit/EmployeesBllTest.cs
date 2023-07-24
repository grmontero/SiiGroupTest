using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiiTestBackEndDotNetCore.Controllers;
using SiiTestBLL;
using SiiTestBLL.Interfaces;
using SiiTestDAL;
using SiiTestDAL.Interfaces;
using SiiTestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiiTestUnit
{
   

    public class EmployeesBllTest 
    {
        private readonly EmployeesController _controller;


        private readonly IEmployeesBll _service;


        public EmployeesBllTest()
        {
            EmployeesDAL dal = new EmployeesDAL();
            _service = new EmployeesBll(dal);
            _controller = new EmployeesController(_service);

        }
        [Fact]
        public void Test1()
        {

        }


        [Fact]
        private void GetEmployeesAsync_WhenCalled_ReturnsOkResult()
        {
            // Act
            var respuesta = _controller.getEmployeesById("1").Result as OkObjectResult;
            // Arrange
            var item = Assert.IsType<ServiceResponse<List<Employees>>>(respuesta.Value);
            // Assert
            Assert.NotNull(item);
            Assert.Equal("success", item.status);
            Assert.NotNull(item.message);
        }
    }
}