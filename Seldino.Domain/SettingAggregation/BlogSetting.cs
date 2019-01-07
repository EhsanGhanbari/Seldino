using System;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.SettingAggregation
{
    public class BlogSetting : EntityBase
    {

        #region Comment

        public bool IsCommentAutoPublished { get; set; }

        public int CommentLength { get; set; }

        public int CommentIntervalTime { get; set; }

        #endregion


        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
