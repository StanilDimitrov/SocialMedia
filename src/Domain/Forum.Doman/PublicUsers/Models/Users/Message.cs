﻿using Forum.Domain.Common.Models;
using Forum.Doman.PublicUsers.Exceptions;
using System;
using static Forum.Domain.PublicUsers.Models.ModelConstants.Message;

namespace Forum.Doman.PublicUsers.Models.Users
{
    public class Message : Entity<int>
    {
        internal Message(string text, PublicUser receiver)
        {
            this.ValidateText(text);

            this.Text = text;
            this.PublicUser = receiver;
            this.CreatedOn = DateTime.Now;
        }

        private Message(string text)
        {
            this.ValidateText(text);

            this.Text = text;
            this.PublicUser = default!;
            this.CreatedOn = DateTime.Now;
        }

        public PublicUser PublicUser { get; private set; }

        public string Text { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public Message UpdateText(string description)
        {
            this.ValidateText(description);
            this.Text = description;

            return this;
        }

        public void ValidateText(string text)
         => Guard.ForStringLength<InvalidPublicUserException>(
             text,
             MinTextLenght,
             MaxTextLength,
             nameof(this.Text));
    }
}
