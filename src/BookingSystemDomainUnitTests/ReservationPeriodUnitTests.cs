using BookingSystem.Domain.DateTimeProvider;
using BookingSystem.Domain.Exceptions.Reservation;
using BookingSystem.Domain.ValueObjects.Reservation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemDomainUnitTests
{
    public class ReservationPeriodUnitTests
    {
        private readonly Mock<IDateTimeProvider> _dateTimeProviderMock;
        public ReservationPeriodUnitTests()
        {
            _dateTimeProviderMock = new Mock<IDateTimeProvider>();
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        public void ValidReservationPeriod_ShouldCreateInstance(int endDay)
        {
            var date = new DateTime(2024, 1, 1);
            _dateTimeProviderMock.Setup(p => p.UtcNow()).Returns(date);
            var reservationPeriod = new ReservationPeriod(new DateOnly(2024, 2, 1), new DateOnly(2024, 2, endDay), _dateTimeProviderMock.Object);
        }
        [Fact]
        public void InvalidReservationPeriod_ShouldThrowReservationCannotEndBeforeItStartsException()
        {
            var date = new DateTime(2024, 1, 1);
            _dateTimeProviderMock.Setup(p => p.UtcNow()).Returns(date);
            Assert.Throws<ReservationCannotEndBeforeItStartsException>(() => new ReservationPeriod(new DateOnly(2024, 2, 2), new DateOnly(2024, 2, 1), _dateTimeProviderMock.Object));
        }
        [Fact]
        public void InvalidReservationPeriod_ShouldThrowExceededMaximumReservationPeriodException()
        {
            var date = new DateTime(2024, 1, 1);
            _dateTimeProviderMock.Setup(p => p.UtcNow()).Returns(date);
            Assert.Throws<ExceededMaximumReservationPeriodException>(() => new ReservationPeriod(new DateOnly(2024, 2, 1), new DateOnly(2024, 2, 8), _dateTimeProviderMock.Object));
        }
        [Fact]
        public void InvalidReservationPeriod_ShouldThrowReservationDateCannotBeInThePastException()
        {
            var date = new DateTime(2024, 1, 1);
            _dateTimeProviderMock.Setup(p => p.UtcNow()).Returns(date);
            Assert.Throws<ReservationDateCannotBeInThePastException>(() => new ReservationPeriod(new DateOnly(2023, 12, 31), new DateOnly(2024, 1, 1), _dateTimeProviderMock.Object));
        }
    }
}
