namespace UnitTesting
{
        [TestFixture]
        public class EmployeeTests
        {
            [Test]
            public void Employee_NameProperty_ShouldReturnCorrectName()
            {
                // Arrange
                string expectedName = "Siddarth";
                int age = 30;
                Employee emp = new Employee(expectedName, age);

                // Act
                string actualName = emp.name;

                // Assert
                Assert.AreEqual(expectedName, actualName);
            }

            [Test]
            public void Employee_AgeProperty_ShouldReturnCorrectAge()
            {
                // Arrange
                string name = "Prathik";
                int expectedAge = 28;
                Employee emp = new Employee(name, expectedAge);

                // Act
                int actualAge = emp.age;

                // Assert
                Assert.AreEqual(expectedAge, actualAge);
            }

            [Test]
            public void Employee_SetName_ShouldUpdateName()
            {
                // Arrange
                string initialName = "Sanjit";
                string updatedName = "Nivetha";
                int age = 26;
                Employee emp = new Employee(initialName, age);

                // Act
                emp.name = updatedName;
                string actualName = emp.name;

                // Assert
                Assert.AreEqual(updatedName, actualName);
            }

            [Test]
            public void Employee_SetAge_ShouldUpdateAge()
            {
                // Arrange
                string name = "Siddarth";
                int initialAge = 30;
                int updatedAge = 35;
                Employee emp = new Employee(name, initialAge);

                // Act
                emp.age = updatedAge;
                int actualAge = emp.age;

                // Assert
                Assert.AreEqual(updatedAge, actualAge);
            }
        }

        [TestFixture]
        public class MathOpeTests
        {
            private MathOpe _mathOpe;

            [SetUp]
            public void Setup()
            {
                _mathOpe = new MathOpe();
            }

            [Test]
            public void Add_WhenCalled_ShouldReturnSumOfTwoNumbers()
            {
                // Arrange
                int a = 5;
                int b = 3;
                int expectedResult = 8;

                // Act
                int result = _mathOpe.add(a, b);

                // Assert
                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void Sub_WhenCalled_ShouldReturnDifferenceOfTwoNumbers()
            {
                // Arrange
                int x = 10;
                int y = 4;
                int expectedResult = 6;

                // Act
                int result = _mathOpe.Sub(x, y);

                // Assert
                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void Pro_WhenCalled_ShouldReturnProductOfTwoNumbers()
            {
                // Arrange
                int x = 7;
                int y = 3;
                int expectedResult = 21;

                // Act
                int result = _mathOpe.Pro(x, y);

                // Assert
                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void Div_WhenCalled_ShouldReturnQuotientOfTwoNumbers()
            {
                // Arrange
                int x = 20;
                int y = 4;
                int expectedResult = 5;

                // Act
                int result = _mathOpe.Div(x, y);

                // Assert
                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void Div_WhenDividingByZero_ShouldThrowDivideByZeroException()
            {
                // Arrange
                int x = 20;
                int y = 0;

                // Act & Assert
                Assert.Throws<DivideByZeroException>(() => _mathOpe.Div(x, y));
            }

            [Test]
            public void CheckValues_WhenCalled_ShouldReturnFalse()
            {
                // Arrange
                var mathOpe = new MathOpe();

                // Act
                var result = mathOpe.CheckValues();

                // Assert
                Assert.IsFalse(result);
            }
        }

}