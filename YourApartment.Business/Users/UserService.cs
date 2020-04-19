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
        private readonly IReadRepository<Apartment> readApartmentRepository;
        private readonly IWriteRepository<Apartment> writeApartmentRepository;

        private readonly ITokenProvider tokenProvider;

        public UserService(IMapper mapper, IReadRepository<User> readRepository, IWriteRepository<User> writeRepository, IReadRepository<Apartment> readApartmentRepository, IWriteRepository<Apartment> writeApartmentRepository, ITokenProvider tokenProvider)
        {
            _mapper = mapper;
            this.readRepository = readRepository;
            this.writeRepository = writeRepository;
            this.readApartmentRepository = readApartmentRepository;
            this.writeApartmentRepository = writeApartmentRepository;
            this.tokenProvider = tokenProvider; 
        }

        public async Task<Result<AuthenticationToken>> Authenticate(AuthenticateUserCommand command)
        {
            var email = command.Email;
            var password = command.Password;

            EnsureArg.IsNotNullOrEmpty(email);
            EnsureArg.IsNotNullOrEmpty(password);

            var userOrNull = (await readRepository.FindOne(x => x.Email.ToLower() == email.ToLower()))
                .ToResult("User does not exist!");
            
            return Result.FirstFailureOrSuccess(userOrNull)
                .Map(() => userOrNull.Value)
                .Ensure(u => PasswordHasher.VerifyPasswordHash(password, u.PasswordHash, u.PasswordSalt), "Incorrect email or password!")
                .Map(u => tokenProvider.CreateTokenForUser(u));
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

        public async Task<Result> AddFavoriteApartment(AddToFavoriteCommand command)
        {
            EnsureArg.IsNotNull(command);

            var userOrNull = (await readRepository.FindOne(u => u.Email == command.Email))
                .ToResult("User does not exist!");

            var apartmentOrNull = await readApartmentRepository.GetById(command.ApartmentId)
                .ToResult("Apartment does not exist!");

            return await Result.FirstFailureOrSuccess(apartmentOrNull, userOrNull)
                .Map(() => userOrNull.Value)
                .Ensure(u => u.FavoriteApartments.FirstOrDefault(p => p.Apartment == apartmentOrNull.Value
                                            && p.User == u) == null, "Apartment already in favorite list of this user!")
                .Map(u => u.AddToFavorite(apartmentOrNull.Value))
                .Tap(u => writeApartmentRepository.Commit());
        }
    }
}
