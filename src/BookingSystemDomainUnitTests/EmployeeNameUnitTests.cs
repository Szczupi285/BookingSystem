using BookingSystem.Domain.Exceptions.Employee.EmployeeName;
using BookingSystem.Domain.ValueObjects.Employee;

namespace BookingSystemDomainUnitTests
{
    public class EmployeeNameUnitTests
    {
        [Fact]
        public void ValidName_ShouldCreateInstance()
        {
            var employeeName = new EmployeeName("John");
            Assert.Equal("John", employeeName.Value);
        }

        [Fact]
        public void NullName_ShouldThrowEmployeeNameCannotBeNullException()
        {
            Assert.Throws<EmployeeNameCannotBeNullException>(() => new EmployeeName(null));
        }

        [Theory]
        [InlineData("Jo")]
        [InlineData("ThisStringHaveMoreThanThirtyFiveChar")]
        public void InvalidLength_ShouldThrowInvalidEmployeeNameLengthException(string name)
        {
            Assert.Throws<InvalidEmployeeNameLengthException>(() => new EmployeeName(name));
        }

        [Theory]
        [InlineData("John123")]
        [InlineData("John!")]
        [InlineData("  John  ")]
        public void NonLetterCharacters_ShouldThrowInvalidEmployeeNameException(string name)
        {
            Assert.Throws<InvalidEmployeeNameException>(() => new EmployeeName(name));
        }

        [Fact]
        public void ImplicitConversion_FromString_ShouldConvertToEmployeeName()
        {
            EmployeeName employeeName = "John";
            Assert.Equal("John", employeeName.Value);
        }
        [Fact]
        public void ImplicitConversion_FromEmployeeName_ShouldConvertToString()
        {
            EmployeeName employeeName = "John";
            string name = employeeName;
            Assert.Equal("John", name);
        }

        [Fact]
        public void Normalize_LowercaseName_ShouldEqual()
        {
            var employeeName = new EmployeeName("john");
            Assert.Equal("John", employeeName.Value);
        }

        [Fact]
        public void Normalize_UppercaseName_ShouldEqual()
        {
            var employeeName = new EmployeeName("JOHN");
            Assert.Equal("John", employeeName.Value);
        }

        [Fact]
        public void Normalize_MixedCaseName_ShouldEqual()
        {
            var employeeName = new EmployeeName("jOhN");
            Assert.Equal("John", employeeName.Value);
        }

    
    }
}