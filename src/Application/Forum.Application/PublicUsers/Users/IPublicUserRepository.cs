﻿using Forum.Application.Common.Contracts;
using Forum.Application.PublicUsers.Users.Queries.Common;
using Forum.Application.PublicUsers.Users.Queries.Details;
using Forum.Doman.PublicUsers.Models.Users;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.PublicUsers.Users
{
    public interface IPublicUserRepository : IRepository<PublicUser>
    {
        Task<PublicUser> Find(
            int id, 
            CancellationToken cancellationToken = default);

        Task<PublicUser> FindByCurrentUser(
            string userId,
            CancellationToken cancellationToken = default);

        Task<int> GetPublicUserId(
            string userId,
            CancellationToken cancellationToken = default);

        Task<bool> HasPost(
            int publicUserId,
            int postId,
            CancellationToken cancellationToken = default);

        Task<bool> HasMessage(
            int publicUserId,
            int messageId,
            CancellationToken cancellationToken = default);

        Task<PublicUserDetailsOutputModel> GetDetails(
            int id,
            CancellationToken cancellationToken = default);

        Task<Message> GetMessage(
            int messageId,
            CancellationToken cancellationToken = default);

        Task<PublicUserOutputModel> GetDetailsByPostId(
            int postId,
            CancellationToken cancellationToken = default);
    }
}
