﻿namespace Forum.Domain.PublicUsers.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 20;
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int MaxUrlLength = 2048;
            public const int Zero = 0;
        }

        public class Category
        {
            public const int MinDescriptionLength = 20;
            public const int MaxDescriptionLength = 1000;
        }


        public class Post
        {
            public const int MinDescriptionLength = 2;
            public const int MaxDescriptionLength = 1000;
        }

        public class Comment
        {
            public const int MinDescriptionLength = 2;
            public const int MaxDescriptionLength = 1000;
        }

        public class Message
        {
            public const int MinTextLenght = 2;
            public const int MaxTextLength = 1000;
        }
    }
}
