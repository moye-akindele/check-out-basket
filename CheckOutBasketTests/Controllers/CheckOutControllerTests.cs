using CheckOutBasket.Controllers;
using CheckOutBasket.ServiceInterfaces;
using CheckOutBasketData.Models;
using CheckOutBasketTests.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CheckOutBasketTests.Controllers
{
    public class CheckOutControllerTests
    {
        CheckOutController _controller;
        ICheckOutService _service;

        public CheckOutControllerTests()
        {
            _service = new CheckOutServiceFake();
            _controller = new CheckOutController(_service);
        }

        [Fact]
        public void Post_ExistingProductAndVoucherIdsPassed_ReturnsOkResult()
        {
            // Arrange
            CheckOutRequest request = new CheckOutRequest()
            {
                ProductIds = new int[] { 1, 2, 3 },
                VoucherIds = new int[] { 1, 2 }
            };
            // Act
            var okResult = _controller.Post(request);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Post_NoVoucherIdsPassed_ReturnsOkResult()
        {
            // Arrange
            CheckOutRequest request = new CheckOutRequest()
            {
                ProductIds = new int[] { 1, 2, 3 },
                VoucherIds = new int[] {}
            };
            // Act
            var okResult = _controller.Post(request);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Post_ExistingProductIdsPassed_ReturnsRightItem()
        {
            // Arrange
            CheckOutRequest request = new CheckOutRequest()
            {
                ProductIds = new int[] { 1, 2, 3 },
                VoucherIds = new int[] { }
            };
            // Act
            var okResult = _controller.Post(request).Result as OkObjectResult;
            // Assert
            Assert.IsType<CheckOutResponse>(okResult.Value);
            Assert.Equal(request.ProductIds.Length, (okResult.Value as CheckOutResponse).RetrievedProducts.Count());
        }
    }
}
