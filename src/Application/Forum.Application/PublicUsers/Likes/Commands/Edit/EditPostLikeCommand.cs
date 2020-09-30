﻿using Forum.Application.Common;
using Forum.Application.Common.Contracts;
using Forum.Application.PublicUsers.Likes.Commands.Common;
using Forum.Application.PublicUsers.Posts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.PublicUsers.Likes.Commands.Edit
{
    public class EditPostLikeCommand : PostLikeCommand<EditPostLikeCommand>, IRequest<Result>
    {
        public class EditPostLikeCommandHandler : IRequestHandler<EditPostLikeCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IPostRepository postRepository;

            public EditPostLikeCommandHandler(
                ICurrentUser currentUser,
                IPostRepository postRepository)
            {
                this.currentUser = currentUser;
                this.postRepository = postRepository;
            }

            public async Task<Result> Handle(
                EditPostLikeCommand request,
                CancellationToken cancellationToken)

            {
                
                var post = await this.postRepository
                    .Find(request.PostId, cancellationToken);

                var like = post.GetLike(currentUser.UserId);

                var userHasLike = this.currentUser.UserHasLike(like);

                if (!userHasLike)
                {
                    return userHasLike;
                }

                post.ChangeLike(like);

                await this.postRepository.Save(post, cancellationToken);
                return Result.Success;
            }
        }
    }
}
