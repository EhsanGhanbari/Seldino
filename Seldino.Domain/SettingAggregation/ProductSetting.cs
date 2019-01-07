using System;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.SettingAggregation
{
    public class ProductSetting : EntityBase
    {
        #region Product

        public bool IsAutoPublished { get; set; }

        #endregion

        #region Image
        public string ImagePrefixAddress { get; set; }

        #endregion

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
