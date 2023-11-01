using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using CarPolicy.Domain;
using CarPolicy.WebApi.Controllers;
using CarPolicy.Domain.Interfaces;
using AutoMapper;
using CarPolicy.WebApi.Models;
using CarPolicy.Domain.Entities;
using CarPolicy.Domain.Responses;

namespace CarPolicy.Test
{
    public class PolicyTest
    {
        [Fact]
        public async Task CreatePolicy_ValidInput_ReturnsOkResult()
        {
            // Arrange
            var mockPolicyServices = new Mock<IPolicyServices>();
            var mockMapper = new Mock<IMapper>();
            var controller = new PolicyController(mockPolicyServices.Object, mockMapper.Object);
            var policyModel = new PolicyModel(); // Define tu modelo de prueba

            // Configurar el servicio mock para que devuelva un resultado válido
            mockPolicyServices.Setup(s => s.CreatePolicy(It.IsAny<Policy>())).ReturnsAsync(new GeneralResponse { Success = true, Message = "Póliza creada" });

            // Act
            var result = await controller.CreatePolicy(policyModel);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task CreatePolicy_Invalido_BadRequest()
        {
            // Arrange
            var mockPolicyServices = new Mock<IPolicyServices>();
            var mockMapper = new Mock<IMapper>();
            var controller = new PolicyController(mockPolicyServices.Object, mockMapper.Object);
            var policyModel = new PolicyModel(); // Define tu modelo de prueba

            // Configurar el servicio mock para devolver un resultado inválido
            mockPolicyServices.Setup(s => s.CreatePolicy(It.IsAny<Policy>())).ReturnsAsync(new GeneralResponse { Success = false, Message = "Error al crear la póliza" });

            // Act
            var result = await controller.CreatePolicy(policyModel);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async Task GetPolicyByNumberOrPlate_HayDatos_Ok()
        {
            // Arrange
            var mockPolicyServices = new Mock<IPolicyServices>();
            var mockMapper = new Mock<IMapper>();
            var controller = new PolicyController(mockPolicyServices.Object, mockMapper.Object);

            // Configurar el servicio mock para devolver una póliza válida
            var existingData = "POL-12345"; // Define un valor válido
            mockPolicyServices.Setup(s => s.GetPolicyByNumberOrPlate(existingData)).ReturnsAsync(new Policy
                {
                    PolicyNumber = "POL-12345",
                    CustomerName = "Juan Pérez",
                    CustomerId = "ID-1234567890",
                    CustomerBirth = DateTime.Parse("1990-05-15T14:30:00Z"),
                    PolicyStartDate = DateTime.Parse("2023-10-01T09:00:00Z"),
                    PolicyEndDate = DateTime.Parse("2023-10-01T09:00:00Z"),
                    Coverages = new List<string> { "Coverage1", "Coverage2", "Coverage3" }.ToArray(),
                    MaxPolicyAmount = 50000,
                    PlanName = "Plan A",
                    CustomerCity = "Ciudad de Ejemplo",
                    CustomerAddress = "123 Calle Principal",
                    VehiclePlate = "ABC-123",
                    VehicleModel = "Modelo de Auto",
                    Inspection = true
                }
            );

            // Act
            var result = await controller.GetPolicyByNumberOrPlate(existingData);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetPolicyByNumberOrPlate_NoDatos_RetornaOk()
        {
            // Arrange
            var mockPolicyServices = new Mock<IPolicyServices>();
            var mockMapper = new Mock<IMapper>();
            var controller = new PolicyController(mockPolicyServices.Object, mockMapper.Object);

            // Configurar el servicio mock para no encontrar datos
            var nonExistingData = "NON-123"; // Define un valor no existente
            mockPolicyServices.Setup(s => s.GetPolicyByNumberOrPlate(nonExistingData)).ReturnsAsync((Policy)null);

            // Act
            var result = await controller.GetPolicyByNumberOrPlate(nonExistingData);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal("No se encontró la póliza consultada", okResult.Value);
        }

        [Fact]
        public async Task CreatePolicySimulation_BuenaEntrada_Ok()
        {
            // Arrange
            var mockPolicyServices = new Mock<IPolicyServices>();
            var mockMapper = new Mock<IMapper>();
            var controller = new PolicyController(mockPolicyServices.Object, mockMapper.Object);
            var policyModel = new PolicyModel(); // Define tu modelo de prueba

            // Configurar el servicio mock para devolver un resultado válido
            mockPolicyServices.Setup(s => s.CreatePolicySimulation(It.IsAny<Policy>())).ReturnsAsync(new GeneralResponse { Success = true, Message = "Póliza de simulación creada" });

            // Act
            var result = await controller.CreatePolicySim(policyModel);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task CreatePolicySimulation_Invalido_BadRequest()
        {
            // Arrange
            var mockPolicyServices = new Mock<IPolicyServices>();
            var mockMapper = new Mock<IMapper>();
            var controller = new PolicyController(mockPolicyServices.Object, mockMapper.Object);
            var policyModel = new PolicyModel(); // Define tu modelo de prueba

            // Configurar el servicio mock para devolver un resultado inválido
            mockPolicyServices.Setup(s => s.CreatePolicySimulation(It.IsAny<Policy>())).ReturnsAsync(new GeneralResponse { Success = false, Message = "Error al crear la póliza de simulación" });

            // Act
            var result = await controller.CreatePolicySim(policyModel);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async Task GetPolicyByNumberOrPlateSim_HayDatos_Ok()
        {
            // Arrange
            var mockPolicyServices = new Mock<IPolicyServices>();
            var mockMapper = new Mock<IMapper>();
            var controller = new PolicyController(mockPolicyServices.Object, mockMapper.Object);

            // Configurar el servicio mock para devolver una póliza válida
            var existingData = "POL-12345"; // Define un valor válido
            mockPolicyServices.Setup(s => s.GetPolicyByNumberOrPlateSimulation(existingData)).ReturnsAsync(new Policy
            {
                PolicyNumber = "POL-12345",
                CustomerName = "Juan Pérez",
                CustomerId = "ID-1234567890",
                CustomerBirth = DateTime.Parse("1990-05-15T14:30:00Z"),
                PolicyStartDate = DateTime.Parse("2023-10-01T09:00:00Z"),
                PolicyEndDate = DateTime.Parse("2023-10-01T09:00:00Z"),
                Coverages = new List<string> { "Coverage1", "Coverage2", "Coverage3" }.ToArray(),
                MaxPolicyAmount = 50000,
                PlanName = "Plan A",
                CustomerCity = "Ciudad de Ejemplo",
                CustomerAddress = "123 Calle Principal",
                VehiclePlate = "ABC-123",
                VehicleModel = "Modelo de Auto",
                Inspection = true
            });

            // Act
            var result = await controller.GetPolicyByNumberOrPlateSim(existingData);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetPolicyByNumberOrPlateSim_NoDatos_RetornaOk()
        {
            // Arrange
            var mockPolicyServices = new Mock<IPolicyServices>();
            var mockMapper = new Mock<IMapper>();
            var controller = new PolicyController(mockPolicyServices.Object, mockMapper.Object);

            // Configurar el servicio mock para no encontrar datos
            var nonExistingData = "NON-123"; // Define un valor no existente
            mockPolicyServices.Setup(s => s.GetPolicyByNumberOrPlateSimulation(nonExistingData)).ReturnsAsync((Policy)null);

            // Act
            var result = await controller.GetPolicyByNumberOrPlateSim(nonExistingData);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal("No se encontró la póliza consultada", okResult.Value);
        }

    }
}
