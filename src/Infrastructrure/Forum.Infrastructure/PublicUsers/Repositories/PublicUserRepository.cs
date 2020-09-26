﻿using AutoMapper;
using CarRentalSystem.Application.Dealerships.Dealers.Queries.Details;
using Forum.Application.PublicUsers.Users;
using Forum.Application.PublicUsers.Users.Queries.Common;
using Forum.Doman.PublicUsers.Exceptions;
using Forum.Doman.PublicUsers.Models.Users;
using Forum.Infrastructure.Common.Persistence;
using Forum.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Infrastructure.PublicUsers.Repositories
{
    internal class PublicUserRepository : DataRepository<IPublicUsersDbContext, PublicUser>, IPublicUserRepository
    {
        private readonly IMapper mapper;

        public PublicUserRepository(IPublicUsersDbContext dbContext, IMapper mapper)
        : base(dbContext)
        => this.mapper = mapper;

        public async Task<PublicUser> FindByCurrentUser(string userId, CancellationToken cancellationToken = default)
        => await this.FindByUser(userId, user => user.PublicUser!, cancellationToken);

        public async Task<PublicUserDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
          => await this.mapper
                .ProjectTo<PublicUserDetailsOutputModel>(this
                    .All()
                    .Where(pu => pu.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<UserOutputModel> GetDetailsByPostId(int postId, CancellationToken cancellationToken = default)
         => await this.mapper
                .ProjectTo<PublicUserDetailsOutputModel>(this
                    .All()
                    .Where(pu => pu.Posts.Any(c => c.Id == postId)))
                .SingleOrDefaultAsync(cancellationToken);

        public Task<int> GetPublicUserId(string userId, CancellationToken cancellationToken = default)
         => this.FindByUser(userId, user => user.PublicUser!.Id, cancellationToken);

        public Task<bool> HasComment(int publicUserId, int commentId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> HasPost(int publicUserId, int postId, CancellationToken cancellationToken = default)
           => await this
                .All()
                .Where(pu => pu.Id == publicUserId)
                .AnyAsync(pu => pu.Posts
                    .Any(pu => pu.Id == postId), cancellationToken);


        private async Task<T> FindByUser<T>(
           string userId,
           Expression<Func<User, T>> selector,
           CancellationToken cancellationToken = default)
        {
            var publicUser = await this
                .Data
                .Users
                .Where(u => u.Id == userId)
                .Select(selector)
                .FirstOrDefaultAsync(cancellationToken);

            if (publicUser == null)
            {
                throw new InvalidPublicUserException("This user is not a public user.");
            }

            return publicUser;
        }
    }
}