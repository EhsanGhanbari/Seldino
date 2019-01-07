using Seldino.Application.Query.MembershipService;
using Seldino.CrossCutting.Enums;
using System;
using System.Collections.Generic;

namespace Seldino.Application.Query.BannerService
{
    public class BannerDto
    {
        public Guid BannerId { get; set; }

        public bool IsActive { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public BannerPictureDto Picture { get; set; }

        public BannerType BannerType { get; set; }

        public decimal Fee { get; set; }

        public string Url { get; set; }

        public string Caption { get; set; }

        public bool IsConfirmed { get; set; }

        public ICollection<UserDto> Users { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }

    public class BannerPictureDto
    {
        public Guid PictureId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string FullPath => Address + Name;
    }
}
