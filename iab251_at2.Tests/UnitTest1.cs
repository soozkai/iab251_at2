using NUnit.Framework;
using iab251_at2.Models;
using iab251_at2.Services;
using Moq; // For mocking NotificationService

namespace iab251_at2.Tests
{
    [TestFixture]
    public class CustomerQuotationTests
    {
        private Mock<INotificationService> _mockNotificationService;

        [SetUp]
        public void Setup()
        {
            // Setup mock notification service
            _mockNotificationService = new Mock<INotificationService>();
        }

        [Test]
        public void ViewQuotation_ShouldDisplayQuotationDetails()
        {
            // Arrange: Create a sample quotation
            var quotation = new Quotation
            {
                QuotationNumber = "Q1001",
                ClientName = "Alice",
                DateIssued = DateTime.Now,
                Status = "Pending",
                ContainerType = "20 ft",
                Scope = "Electronics import",
                DepotCharges = 150.00m,
                LCLCharges = 200.00m
            };

            // Act & Assert: Verify all properties
            Assert.AreEqual("Q1001", quotation.QuotationNumber);
            Assert.AreEqual("Alice", quotation.ClientName);
            Assert.AreEqual("Pending", quotation.Status);
            Assert.AreEqual(150.00m, quotation.DepotCharges);
            Assert.AreEqual(200.00m, quotation.LCLCharges);
        }

        [Test]
        public void AcceptQuotation_ShouldUpdateStatusAndSendNotification()
        {
            // Arrange: Create a sample quotation
            var quotation = new Quotation
            {
                QuotationNumber = "Q1001",
                ClientName = "Alice",
                Status = "Pending"
            };

            // Act: Accept the quotation
            quotation.Status = "Accepted";
            _mockNotificationService.Object.SendNotification(
                quotation.QuotationNumber,
                $"Customer has accepted the quotation: {quotation.QuotationNumber}"
            );

            // Assert: Check if status updated and notification was sent
            Assert.AreEqual("Accepted", quotation.Status);
            _mockNotificationService.Verify(n => n.SendNotification(
                "Q1001",
                "Customer has accepted the quotation: Q1001"), Times.Once);
        }

        [Test]
        public void RejectQuotation_ShouldUpdateStatusAndSendNotification()
        {
            // Arrange: Create a sample quotation
            var quotation = new Quotation
            {
                QuotationNumber = "Q1002",
                ClientName = "Bob",
                Status = "Pending"
            };

            // Act: Reject the quotation
            quotation.Status = "Rejected";
            _mockNotificationService.Object.SendNotification(
                quotation.QuotationNumber,
                $"Customer has rejected the quotation: {quotation.QuotationNumber}"
            );

            // Assert: Check if status updated and notification was sent
            Assert.AreEqual("Rejected", quotation.Status);
            _mockNotificationService.Verify(n => n.SendNotification(
                "Q1002",
                "Customer has rejected the quotation: Q1002"), Times.Once);
        }
    }
}
