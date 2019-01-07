using System;
using FluentValidation.Attributes;
using Seldino.Application.Command.CommandHandler;
using Seldino.CrossCutting.Enums;

namespace Seldino.Application.Command.DiscountHandler
{
    public interface IDiscountCommand : ICommand
    {
        string Name { get; set; }

        decimal Percentage { get; set; }

        decimal Amount { get; set; }

        DiscountLimitation DiscountLimitation { get; set; }

        DateTime? StartDate { get; set; }

        DateTime? EndDate { get; set; }

        bool Stopped { get; set; }
    }

    [Validator(typeof(DiscountCommandValidation))]
    public class DiscountCommand : IDiscountCommand
    {
        public string Name { get; set; }

        public decimal Percentage { get; set; }

        public DiscountLimitation DiscountLimitation { get; set; }

        public decimal Amount { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool Stopped { get; set; }

    }

    public class CreateDiscountCommand : DiscountCommand
    {
    }

    public class EditDiscountCommand : DiscountCommand
    {
        public Guid DiscountId { get; set; }

        public DateTime CreationDate { get; set; }
    }

    public class StartDiscountCommand : ICommand
    {
        public Guid[] DiscountIds { get; set; }
    }

    public class StopDiscountCommand : ICommand
    {
        public Guid[] DiscountIds { get; set; }
    }

    public class DeleteDiscountCommand : ICommand
    {
        public Guid[] DiscountIds { get; set; }
    }
}
