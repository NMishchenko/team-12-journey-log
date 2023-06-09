﻿using FluentValidation;
using JourneyLog.BLL.Models.Auth;

namespace JourneyLog.BLL.Validators.Auth;

public class SignupModelValidator : AbstractValidator<SignupModel>
{
    public SignupModelValidator()
    {
        RuleFor(info => info.FirstName)
            .NotEmpty().WithMessage("First name cannot be empty, null or whitespace")
            .MaximumLength(50).WithMessage("Last name must be at most 50 characters long");
        
        RuleFor(info => info.LastName)
            .NotEmpty().WithMessage("First name cannot be empty, null or whitespace")
            .MaximumLength(50).WithMessage("Last name must be at most 50 characters long");
    }
}