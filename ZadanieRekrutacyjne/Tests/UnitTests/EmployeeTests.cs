using ZadanieRekrutacyjne.Models;

namespace ZadanieRekrutacyjne.Tests.UnitTests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void employee_can_request_vacation()
        {
            // Arrange

            Employee3 employee = new(1, "Jan Kowalski", 1, 1);
            Vacation vacation = new(1, new DateTime(2025, 1, 1), new DateTime(2025, 1, 15), null, false, 1);
            VacationPackage vacationPackage = new(1, "Standard", 26, 2025);

            // Act

            bool canRequest = Employee3.IfEmployeeCanRequestVacation(employee, [vacation], vacationPackage);

            // Assert

            Assert.IsTrue(canRequest);
        }

        [TestMethod]
        public void employee_cant_request_vacation()
        {
            // Arrange

            Employee3 employee = new(1, "Jan Kowalski", 1, 1);
            Vacation vacation = new(1, new DateTime(2025, 1, 1), new DateTime(2025, 1, 31), null, false, 1);
            VacationPackage vacationPackage = new(1, "Standard", 26, 2025);

            // Act

            bool canRequest = Employee3.IfEmployeeCanRequestVacation(employee, [vacation], vacationPackage);

            // Assert

            Assert.IsFalse(canRequest);
        }
    }
}
