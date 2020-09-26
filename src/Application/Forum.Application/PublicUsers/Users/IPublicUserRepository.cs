﻿using CarRentalSystem.Application.Dealerships.Dealers.Queries.Details;
using Forum.Application.Common.Contracts;
using Forum.Application.PublicUsers.Users.Queries.Common;
using Forum.Doman.PublicUsers.Models.Users;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.PublicUsers.Users
{
    public interface IPublicUserRepository : IRepository<PublicUser>
    {
        Task<PublicUser> FindByCurrentUser(string userId, CancellationToken cancellationToken = default);

        Task<int> GetPublicUserId(string userId, CancellationToken cancellationToken = default);

        Task<bool> HasPost(int publicUserId, int postId, CancellationToken cancellationToken = default);

        Task<bool> HasComment(int publicUserId, int commentId, CancellationToken cancellationToken = default);

        Task<PublicUserDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<UserOutputModel> GetDetailsByPostId(int postId, CancellationToken cancellationToken = default);
    }
}