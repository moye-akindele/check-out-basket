using CheckOutBasket.Controllers;
using CheckOutBasket.ServiceInterfaces;
using CheckOutBasketData;
using CheckOutBasketTests.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CheckOutBasketTests.Controllers
{
    public class VoucherControllerTest
    {
        VouchersController _controller;
        IVoucherService _service;

        public VoucherControllerTest()
        {
            _service = new VoucherServiceFake();
            _controller = new VouchersController(_service);
        }

        // Tests for Get() ---------------------------------------
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;
            // Assert
            var selectedProducts = Assert.IsType<List<Voucher>>(okResult.Value);
            Assert.Equal(3, selectedProducts.Count);
        }

        // Tests for Get(int voucherId) ------------------------------------
        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(111);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var testId = 1;
            // Act
            var okResult = _controller.Get(testId);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdsPassed_ReturnsRightItem()
        {
            // Arrange
            var testId = 1;
            // Act
            var okResult = _controller.Get(testId).Result as OkObjectResult;
            // Assert
            Assert.IsType<Voucher>(okResult.Value);
            Assert.Equal(testId, (okResult.Value as Voucher).Id);
        }

        // Tests for GetMultiple(int[] productIds) ------------------------------------
        [Fact]
        public void GetMultiple_ExistingIdsPassed_ReturnsOkResult()
        {
            // Arrange
            var testIds = new int[] { 1, 2 };
            // Act
            var okResult = _controller.GetMultiple(testIds);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetMultiple_ExistingIdsPassed_ReturnsRightItems()
        {
            // Arrange
            var testIds = new int[] { 1, 2 };
            // Act
            var okResult = _controller.GetMultiple(testIds).Result as OkObjectResult;
            // Assert
            var selectedProducts = Assert.IsType<List<Voucher>>(okResult.Value);
            Assert.Equal(2, selectedProducts.Count);
        }
    }
}
