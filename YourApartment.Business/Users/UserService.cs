using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using EnsureThat;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using YourApartment.Common;
using YourApartment.Domain;

namespace YourApartment.Business.Users
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IReadRepository<User> readRepository; 
        private readonly IWriteRepository<User> writeRepository;
        private readonly ITokenProvider tokenProvider;

        public UserService(IMapper mapper, IReadRepository<User> readRepository, IWriteRepository<User> writeRepository, ITokenProvider tokenProvider)
        {
            _mapper = mapper;
            this.readRepository = readRepository;
            this.writeRepository = writeRepository;
            this.tokenProvider = tokenProvider;
        }

        public async Task<AuthenticationToken> Authenticate(string email, string password)
        {
            EnsureArg.IsNotNullOrEmpty(email);
            EnsureArg.IsNotNullOrEmpty(password);

            var userOrNull = (await readRepository.FindOne(x => x.Email.ToLower() == email.ToLower()));
            if (userOrNull.HasNoValue)
                return null;

            var user = userOrNull.Value;

            if (!PasswordHasher.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return tokenProvider.CreateTokenForUser(user.Id, user.Email, user.Name);
        }

        public async Task<Result> Create(CreateUserCommand command)
        {
            EnsureArg.IsNotNull(command);
            var userDuplicated = (await readRepository.FindOne(x => x.Email.ToLower() == command.Email.ToLower()))
                .ToInverseResult("User Already Exists");

            return await Result.FirstFailureOrSuccess(userDuplicated)
                .Map(() => PasswordHasher.CreatePasswordHash(command.Password))
                .Map(t => User.Create(command.Name, command.Email, command.PhoneNumber, t.Item1, t.Item2))
                .Tap(u => writeRepository.Create(u.Value))
                .Tap(_ => writeRepository.Commit());
        }
    }
}
