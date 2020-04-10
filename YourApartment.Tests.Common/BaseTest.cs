using Moq;

namespace YourApartment.Tests.Common
{
    public abstract class BaseTest<T>
        where T : class
    {
        protected BaseTest()
        {
            SetupMocks(new MockRepository(MockBehavior.Strict));
            SystemUnderTest = CreateSystemUnderTest();
        }

        public T SystemUnderTest { get; set; }

        protected abstract void SetupMocks(MockRepository mockRepository);

        protected abstract T CreateSystemUnderTest();
    }
}