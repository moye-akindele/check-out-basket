using CheckOutBasket.Controllers;
using CheckOutBasket.ServiceInterfaces;
using CheckOutBasketData.Models;
using CheckOutBasketTests.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace CheckOutBasketTests
{
    public class ProductControllerTest
    {
        ProductsController _controller;
        IProductService _service;

        public ProductControllerTest()
        {
            _service = new ProductServiceFake();
            _controller = new ProductsController(_service);
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
            var selectedProducts = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Equal(6, selectedProducts.Count);
        }

        // Tests for Get(int id) ------------------------------------
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
            Assert.IsType<Product>(okResult.Value);
            Assert.Equal(testId, (okResult.Value as Product).Id);
        }

        // Tests for GetMultiple(int[] productIds) ------------------------------------
        [Fact]
        public void GetMultiple_ExistingIdsPassed_ReturnsOkResult()
        {
            // Arrange
            var testIds = new int[] { 1, 2, 3 };
            // Act
            var okResult = _controller.GetMultiple(testIds);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetMultiple_ExistingIdsPassed_ReturnsRightItems()
        {
            // Arrange
            var testIds = new int[] { 1, 2, 3 };
            // Act
            var okResult = _controller.GetMultiple(testIds).Result as OkObjectResult;
            // Assert
            var selectedProducts = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Equal(3, selectedProducts.Count);
        }
    }
}
