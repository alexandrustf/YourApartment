using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moq;
using YourApartment.Domain;

namespace YourApartment.Tests.Common.Factories
{
    public static class MockWriteRepositoryFactory<T>
        where T : Entity
    {
        public static Mock<IWriteRepository<T>> Create(MockRepository repository)
        {
            var writeRepositoryMock = repository.Create<IWriteRepository<T>>();
            writeRepositoryMock.Setup(r => r.Create(It.IsAny<T>()))
                .Returns(Task.CompletedTask);
            writeRepositoryMock.Setup(r => r.Commit())
                .Returns(Task.CompletedTask);
            return writeRepositoryMock;
        }
    }
}
