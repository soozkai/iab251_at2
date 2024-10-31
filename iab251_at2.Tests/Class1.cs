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
                QuotationNumber
